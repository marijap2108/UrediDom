import { ChangeEvent, useCallback, useEffect, useMemo, useState } from "react"
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
  const [searchParams, setSearchParams] = useSearchParams()
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

  const handleSort = useCallback(({target: { id }}: ChangeEvent<HTMLInputElement>) => {
    const [newSort, newSortDirection] = id.split("_")
    const params = searchParams.toString() ? JSON.parse('{"' + decodeURI(searchParams.toString()).replace(/"/g, '\\"').replace(/&/g, '","').replace(/=/g,'":"') + '"}') : {}
    if (newSort === 'all') {
      delete params.sort
      delete params.sortDirection
    } else {
      params.sort = newSort
      params.sortDirection = newSortDirection
    }
    setSearchParams(params)
  }, [searchParams, setSearchParams])

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
            <input id="all" checked={!searchParams.get('sort') && !searchParams.get('sortDirection')} onChange={handleSort} type="radio" name="sort" />
            Prikaži sve
          </label>
        </li>
        <li>
          <label>
            <input id="price_asc" checked={searchParams.get('sort') + '_' + searchParams.get('sortDirection') === 'price_asc'} onChange={handleSort} type="radio" name="sort" />
            Po ceni rastuće
          </label>
        </li>
        <li>
          <label>
            <input id="price_desc" checked={searchParams.get('sort') + '_' + searchParams.get('sortDirection') === 'price_desc'} onChange={handleSort} type="radio" name="sort" />
            Po ceni opadajuće
          </label>
        </li>
        <li>
          <label>
            <input id="productName_asc" checked={searchParams.get('sort') + '_' + searchParams.get('sortDirection') === 'productName_asc'} onChange={handleSort} type="radio" name="sort" />
            Po proizvodima rastuće
          </label>
        </li>
        <li>
          <label>
            <input id="productName_desc" checked={searchParams.get('sort') + '_' + searchParams.get('sortDirection') === 'productName_desc'} onChange={handleSort} type="radio" name="sort" />
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