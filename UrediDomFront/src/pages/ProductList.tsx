import { useCallback, useEffect, useMemo, useState } from "react"
import ProductCard from "../components/ProductCard"
import "./ProductList.scss"
import { Link, useParams, useSearchParams } from "react-router-dom"
import { groupBy } from "../utils/Group"
import Button from "../components/Button"

interface IProductCard {
  productID: number,
  productName: string,
  price: number,
  description: string,
  imgSrc: string
}

interface IType {
  typeID: number,
  typeName: string
}

interface ICategory {
  categoryID: number,
  category: string,
  valueCat: string
}

const ProductList = () => {
  const [products, setProducts] = useState<IProductCard[]>([])
  const [types, setTypes] = useState<IType[]>([])
  const [categories, setCategories] = useState<ICategory[]>([])
  const { typeId } = useParams()
  const [searchParams] = useSearchParams()
  const [step, setStep] = useState(1)
  const [endOfList, setEndOfList] = useState(false)

  const categoriesGroup = useMemo(() => groupBy(categories, 'category'), [categories])

  useEffect(() => {
    fetch(`https://localhost:7269/product${typeId ? `s/${typeId}` : ''}?sortDirection=${searchParams.get('sortDirection') ?? 'asc'}&sort=${searchParams.get('sort') ?? 'productID'}`, {
      method: 'GET',
      mode: 'cors',
      headers: {
        "Content-Type": "application/json",
      }
    }).then(res => res.json().then(data => {
      setProducts(data)
    }))
    fetch('https://localhost:7269/typeOfProduct', {
      method: 'GET',
      mode: 'cors',
      headers: {
        "Content-Type": "application/json",
      }
    }).then(res => res.json().then(data => {
      setTypes(data)
    }))
    fetch('https://localhost:7269/productCategory', {
      method: 'GET',
      mode: 'cors',
      headers: {
        "Content-Type": "application/json",
      }
    }).then(res => res.json().then(data => {
      setCategories(data)
    }))
  }, [searchParams, typeId])

  const handleSort = useCallback((e: any) => {
    console.log(e)
  }, [])

  const loadMore = useCallback(() => {
    fetch(`https://localhost:7269/product${typeId ? `s/${typeId}` : ''}?sortDirection=${searchParams.get('sortDirection') ?? 'asc'}&sort=${searchParams.get('sort') ?? 'productID'}&step=${step * 9}`, {
      method: 'GET',
      mode: 'cors',
      headers: {
        "Content-Type": "application/json",
      }
    }).then(res => res.json().then(data => {
      if (data.length < 9) {
        setEndOfList(true)
      }
      setProducts(old => [...old, ...data])
    })).catch(() => setEndOfList(true))
    setStep(old => ++old)
  }, [searchParams, step, typeId])

  return <div className="productList">
    <div className="productList__left">
      <h2>Sortiranje</h2>
      <ul>
        <li>
          <label>
            <input id="all" onChange={handleSort} type="radio" name="sort" />
            Prikaži sve
          </label>
        </li>
        <li>
          <label>
            <input id="price_asc" onChange={handleSort} type="radio" name="sort" />
            Po ceni rastuće
          </label>
        </li>
        <li>
          <label>
            <input id="price_desc" onChange={handleSort} type="radio" name="sort" />
            Po ceni opadajuće
          </label>
        </li>
        <li>
          <label>
            <input id="name_asc" onChange={handleSort} type="radio" name="sort" />
            Po proizvodima rastuće
          </label>
        </li>
        <li>
          <label>
            <input id="name_desc" type="radio" name="sort" />
            Po proizvodima opadajuće
          </label>
        </li>
      </ul>
      {!typeId &&
        <>
          <h2>Tip proizvoda</h2>
          <ul>
            {types.map((type) =>
              <li key={`type_${type.typeName}`}>
                <Link to={`${type.typeID}`}>{type.typeName}</Link>
              </li>
            )}
          </ul>
        </>
      }
      {Object.keys(categoriesGroup).map((key) =>
        <section key={`category_${key}`}>
          <h2>{key}</h2>
          <ul>
            {categoriesGroup[key].map((category: ICategory) =>
              <li key={`category_${category.valueCat}`}>
                <label>
                  <input type="checkbox" />
                  {category.valueCat}</label>
              </li>
            )}
          </ul>
        </section>
      )}
    </div>
    <div className="productList__right">
      <h2>
        {types.find(type => type.typeID === ~~(typeId || 0))?.typeName}
      </h2>
      <div className="productList__right__list">
        {products.map((product) =>
          <ProductCard key={`product_${product.productID}`} {...product} />
        )}
      </div>
      {!endOfList && <Button onClick={loadMore}>Učitaj još</Button>}
    </div>
  </div>
}

export default ProductList