import { useCookies } from "react-cookie"
import "./Admin.scss"
import { FaCopy } from "react-icons/fa"
import { useCallback, useEffect, useState } from "react"
import Button from "../components/Button"

type Order = {
  orderID: number,
  dateOfOrder: string,
  amount: number,
  customerID: number
}

type Item = {
  productOrderID: number,
  productID: number, 
  orderID: number,
  quantity: number, 
  price: number
}

type User = {
  userID: number,
  name: string,
  surname: string,
  email: string,
  role: string
}

const Admin = () => {
  const [cookies] = useCookies(['token'])
  const [orders, setOrders] = useState<Order[]>([])
  const [items, setItems] = useState<Item[]>([])
  const [selectedOrder, setSelectedOrder] = useState<number>()
  const [users, setUsers] = useState<User[]>([])

  useEffect(() => {
    fetch('https://localhost:7269/order', {
      method: 'GET',
      mode: 'cors',
      headers: {
        "Content-Type": "application/json",
        'Authorization': `Bearer ${cookies.token}`
      }
    }).then(res => res.json().then(data => {
      setOrders(data)
    }))
  }, [cookies.token])

  useEffect(() => {
    if (!selectedOrder) return
    fetch(`https://localhost:7269/productOrder/${selectedOrder}`, {
      method: 'GET',
      mode: 'cors',
      headers: {
        "Content-Type": "application/json",
        'Authorization': `Bearer ${cookies.token}`
      }
    }).then(res => res.json().then(data => {
      setItems(data)
    }))
  },[cookies.token, selectedOrder])

  useEffect(() => {
    fetch('https://localhost:7269/users', {
      method: 'GET',
      mode: 'cors',
      headers: {
        "Content-Type": "application/json",
        'Authorization': `Bearer ${cookies.token}`
      }
    }).then(res => res.json().then(data => {
      setUsers(data)
    }))
  }, [cookies.token])

  const handleAdmin = useCallback((user: User) => () => {
    fetch(`https://localhost:7269/user`, {
      method: 'PUT',
      mode: 'cors',
      headers: {
        "Content-Type": "application/json",
        'Authorization': `Bearer ${cookies.token}`
      },
      body: JSON.stringify({ ...user, role: "Admin" })
    })
  },[cookies.token])

  return <div className="admin">
    <h1>Dobrodošli na admin stranicu</h1>
    <div className="orders">
    <h2>Porudžbine:</h2>
          <ul>
            {orders.map((order) =>
              <li key={`order_${order.orderID}`} className="li">
                <p>Id porudžbine - {order.orderID}, iznos - {order.amount} dinara, datum porudžbine - {(new Date(Date.parse(order?.dateOfOrder ?? ""))).toLocaleDateString("en-US")}, ID kupca - {order.customerID}</p>
                {selectedOrder === order.orderID ?
                <>
                  <h3>Stavke porudžbine</h3>
                  <ol>
                    {items.map((item) =>
                    <li key={`item_${item.productOrderID}`}>
                      Id proizvoda - {item.productID}, količina - {item.quantity}, cena po komadu - {item.price} dinara.
                    </li>
                    )}
                  </ol>
                </> 
                :
                <p><Button onClick={() => setSelectedOrder(order.orderID)}>Stavke porudzbine</Button></p>
                }
              </li>
            )}
          </ul>
    </div>
    <h2>Korisnici:</h2>
    <div className="users">
      <ul>
        {users.map((user) =>
        <li key={`user_${user.userID}`} className="li">
          <p>ID korisnika - {user.userID}, ime korisnika - {user.name} {user.surname}, email adresa - {user.email}, uloga korisnika - {user.role}</p>
          <p><Button onClick={handleAdmin(user)}>Postavite admina</Button></p>
        </li>
        )}
      </ul>
    </div>
    <h3>Admin token <FaCopy onClick={() => navigator.clipboard.writeText(cookies.token)} /> </h3>
    <p>Klikom na swagger otvaraju se funkcionalnosti admina:</p>
    <a href="https://localhost:7269/swagger/index.html">
      <img src="https://miro.medium.com/v2/resize:fit:600/1*u52zaS9KLPguwWz5ELxGcg.png" alt="swagger" />
    </a>
  </div>
}

export default Admin