import { useParams } from "react-router-dom"
import "./Product.scss"
import { MouseEvent, useCallback, useEffect, useState } from "react"
import Button from "../components/Button"
import { FaShoppingCart } from "react-icons/fa"
import { AddToCart } from "../utils/Cart"

const Product = () => {
  const { productID } = useParams()
  const [product, setProduct] = useState({productID: 0, productName: '', price: 0, description: '', quantity: 0, imgSrc: ''})

  const handleCart = useCallback((e: MouseEvent<HTMLElement>) => {
    AddToCart(product.productID, 1)
    e.stopPropagation()
  }, [product.productID])

  useEffect(() => {
    fetch(`https://localhost:7269/product/${productID}`, {
      method: 'GET',
      mode: 'cors',
      headers: {
        "Content-Type": "application/json",
      }}).then(res => res.json().then(data => {
        setProduct(data)
      }))
  },[])

  return <div className="product">
    <div className="product__left">
      <img src={product.imgSrc} />
    </div>
    <div className="product__right">
      <h2>{product.productName}</h2>
      <p>{product.description}</p>
      <p>{product.price}</p>
      <p>{product.quantity}</p>
      <Button onClick={handleCart}><FaShoppingCart /> Dodaj u korpu</Button>
    </div>
  </div>
}

export default Product