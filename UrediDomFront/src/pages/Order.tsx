import { useCallback, useEffect, useState } from "react"
import Button from "../components/Button"
import ProductCard from "../components/ProductCard"
import "./Order.scss"
import { FaTrash } from "react-icons/fa"
import { RemoveFromCart } from "../utils/Cart"
import Payment from "../components/Payment"
import { loadStripe } from '@stripe/stripe-js';
import { Elements } from '@stripe/react-stripe-js';
import { useCookies } from "react-cookie"

const stripePromise = loadStripe('pk_test_51NEXvEERmXeMfmnki8TYpI6n9wGp1A6l8SHiBsUkhtDjias6nJYc3aCX0VeJFxdBQwKnl8TMjuTFlYfFA0lIzzXo00Ev3ldoid');

type Item = {
  [key: number]: number
}

type CartItem = {
  productID: number,
  productName: string,
  quantity: number,
  quantityLeft: number,
  price: number,
  description: string,
  imgSrc: string
}

const Order = () => {
  const [step, setStep] = useState(0)
  const [products, setProducts] = useState<CartItem[]>([])
  const [options, setOptions] = useState({ clientSecret: '' })
  const [cookies] = useCookies(['token'])

  const handleStep = useCallback(() => {
    if (step === 0) {
      fetch('https://localhost:7269/order', {
        method: 'POST',
        mode: 'cors',
        headers: {
          "Content-Type": "application/json",
          'Authorization': cookies.token ? `Bearer ${cookies.token}` : ''
        },
        body: JSON.stringify(products)
      }).then(res => res.json().then(data => {
        setOptions(data)
        setStep(old => ++old)
      }))
    }
  }, [cookies.token, products, step])

  const getProducts = useCallback(() => {
    setProducts([])
    const cart = localStorage.getItem("cart")
    if (cart) {
      const items: Item = JSON.parse(cart)
      Object.keys(items).map((productID: string) => {
        fetch(`https://localhost:7269/product/${productID}`, {
          method: 'GET',
          mode: 'cors',
          headers: {
            "Content-Type": "application/json",
          }
        }).then(res => res.json().then(data => {
          setProducts(old => [...old, { ...data, quantityLeft: data.quantity, quantity: items[~~productID] }])
        }))
      })
    }
  }, [])

  const handleCart = useCallback((id: number) => () => {
    RemoveFromCart(id, undefined)
    getProducts()
  }, [getProducts])

  useEffect(() => {
    getProducts()
  }, [getProducts])

  const renderSteps = useCallback(() => {
    switch (step) {
      case 0:
        return <>
          {products.map((product, i) =>
            <div key={`order_${i}`} className="cart__left__product">
              <ProductCard {...product} /> <FaTrash className="cart__left__product__trash" onClick={handleCart(product.productID)} />
            </div>
          )}
        </>
      case 1:
        return <Elements stripe={stripePromise} options={options}>
          <Payment />
        </Elements>
    }
  }, [handleCart, options, products, step])

  return <div className="cart">
    <div className="cart__left">
      {renderSteps()}
    </div>
    <div className="cart__right">
      <div>
        <h2>RECEIPT</h2>
        {products.map((product, i) =>
          <div key={`order_${i}`}>
            <span>{product.productName} </span>
            <span>{product.price} </span>
            <span>{product.quantity} </span>
            <span>{product.price * product.quantity}</span>
          </div>
        )}
        <div>
          <h3>TOTAL</h3>
          <div>
            {products.reduce((a, product) =>
              a + product.quantity * product.price, 0
            )}
          </div>
        </div>
      </div>
      <Button onClick={handleStep}>Pay</Button>
    </div>
  </div>
}

export default Order