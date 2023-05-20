import { useEffect, useState } from "react"
import Button from "../components/Button"
import ProductCard from "../components/ProductCard"
import "./Order.scss"

type Item = {
  [key: number]: number
}

type CartItem = {
  productID: number,
  productName: string,
  quantity: number,
  quantityOrdered: number,
  price: number,
  description: string
}

const Order = () => {
  const [products, setProducts] = useState<CartItem[]>([])

  useEffect (() => {
    const cart = localStorage.getItem("cart")
    if(cart) {
      const items: Item = JSON.parse(cart)
      Object.keys(items).map((productID: string) => {
        fetch(`https://localhost:7269/product/${productID}`, {
        method: 'GET',
        mode: 'cors',
        headers: {
          "Content-Type": "application/json",
        }}).then(res => res.json().then(data => {
          setProducts(old => [...old, {...data, quantityOrdered: items[~~productID]}])
        }))
        })
    }
  },[])

  return <div className="cart">
    <div className="cart__left">
      {products.map((product) => 
        <ProductCard {...product} />
      )}
    </div>
    <div className="cart__right">
      <div>
        <h2>RECEIPT</h2>
        {products.map((product) => 
          <div>
            <span>{product.productName} </span>
            <span>{product.price} </span>
            <span>{product.quantityOrdered} </span>
            <span>{product.price * product.quantityOrdered}</span>
          </div>
        )}
        <div>
          <h3>TOTAL</h3>
          <div>
            {products.reduce((a, product) => 
              a + product.quantityOrdered * product.price, 0
            )}
          </div>
        </div>
      </div>
      <Button>Pay</Button>
    </div>
  </div>
}

export default Order