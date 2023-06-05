import { useEffect, useState } from "react"
import { Link, useSearchParams } from "react-router-dom"
import "./OrderComplete.scss"
import { ClearCart } from "../utils/Cart"
import Button from "../components/Button"
import { useCookies } from "react-cookie"

type Order = {
  orderID: number,
  dateOfOrder: string,
  amount: number,
  customerID: number,
  repairmanID: number,
  intent: string,
}

const OrderComplete = () => {
  const [searchParams] = useSearchParams()
  const [order, setOrder] = useState<Order>()
  const [cookies] = useCookies(['token'])

  useEffect(() => {
    fetch(`https://localhost:7269/order/intent/${searchParams.get('payment_intent')}`, {
      method: 'GET',
      mode: 'cors',
      headers: {
        "Content-Type": "application/json",
      }
    }).then(res => res.json().then(data => {
      setOrder(data)
    }))

    ClearCart()

  }, [searchParams])

  return <div className="orderComplete">
    <h1>Porudžbenica</h1>
    <h3>Vaša porudžbina sa ID-jem {order?.orderID} je uspešno plaćena</h3>
    <p>Plaćeno je: {order?.amount} rsd</p>
    <p>Datum porudžbine je: {(new Date(Date.parse(order?.dateOfOrder ?? ""))).toLocaleDateString("en-US")}</p>
    <img src="https://www.pngmart.com/files/16/Green-Check-Mark-PNG-File.png" alt="done" />
    <div>
      {cookies.token ? <Link to={`/reserve?order=${order?.orderID}`}><Button>Rezervacija majstora</Button></Link> : <Link to="/home"><Button>Nazad na početnu stranicu</Button></Link>}
    </div>
  </div>
}

export default OrderComplete