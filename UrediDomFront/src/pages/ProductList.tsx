import { useEffect, useState } from "react"
import ProductCard from "../components/ProductCard"

interface IProductCard {
  productID: number,
  productName: string,
  price: number,
  description: string
}

const ProductList = () => {
  const [products, setProducts] = useState<IProductCard[]>([])

  useEffect(() => {
    fetch('https://localhost:7269/product', {
      method: 'GET',
      mode: 'cors',
      headers: {
        "Content-Type": "application/json",
      }}).then(res => res.json().then(data => {
        setProducts(data)
      }))
  },[])

  return <div className="productList">
    {products.map((product) =>
      <ProductCard key={`product_${product.productID}`} {...product} />
    )}
  </div>
}

export default ProductList