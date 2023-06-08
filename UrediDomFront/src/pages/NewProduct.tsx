import { useCallback, useState } from "react"
import Button from "../components/Button"
import { useNavigate } from "react-router-dom"
import "./NewProduct.scss"
import { useCookies } from "react-cookie"

const NewProduct = () => {
  const [form, setForm] = useState({ productName: '', price: '', description: '', quantity: '', typeID: '', groupID: '', imgSrc: ''})
  const navigate = useNavigate()
  const [cookies] = useCookies(['token'])

  const handleInput = useCallback(({ target }: any) => {
    setForm(old => ({ ...old, [target.id]: target.value }))
  }, [])

  const handleSubmit = useCallback((e: any) => {
    e.preventDefault()
    fetch('https://localhost:7269/product', {
      method: 'POST',
      mode: 'cors',
      headers: {
        "Content-Type": "application/json",
        'Authorization': `Bearer ${cookies.token}`
      },
      body: JSON.stringify(form)
    }).then(() =>
      navigate("/productList")
    )
  }, [cookies.token, form, navigate])

  return <div className="newProduct">
    <form onSubmit={handleSubmit} className="newProduct__bottom">
      <h2>Kreiraj novi proizvod</h2>
      <label>
        Ime proizvoda:
        <input type="text" name="productName" value={form.productName} id='productName' onChange={handleInput} required />
      </label>
      <label>
        Cena proizvoda:
        <input type="number" name="price" value={form.price} id='price' onChange={handleInput} required />
      </label>
      <label>
        Opis proizvoda:
        <input type="text" name="description" value={form.description} id='description' onChange={handleInput} required />
      </label>
      <label>
        Ukupno na stanju:
        <input type="number" name="quantity" value={form.quantity} id='quantity' onChange={handleInput} pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$" required />
      </label>
      <label>
        ID tipa proizvoda:
        <input type="number" name="typeID" value={form.typeID} id='typeID' onChange={handleInput} pattern="^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*_=+-]).{8,12}$" required />
      </label>
      <label>
        ID grupe proizvoda:
        <input type="number" name="groupID" value={form.groupID} id='groupID' onChange={handleInput} required />
      </label>
      <label>
        Link ka slici proizvoda:
        <input type="text" name="imgSrc" value={form.imgSrc} id='imgSrc' onChange={handleInput} required />
      </label>
      <Button>
        Potvrdi
      </Button>
    </form>
  </div>
}

export default NewProduct