import { useCallback, useState } from "react"
import { useCookies } from "react-cookie"
import { useNavigate } from "react-router-dom"
import "./SignUp.scss"
import Button from "../components/Button"

const SignUp = () => {
  const [form, setForm] = useState({ name: '', surname: '', username: '', email: '', password: '', phone: '', birthday: '', role: '' })
  const [_cookies, setCookie] = useCookies(['token'])
  const navigate = useNavigate()

  const handleInput = useCallback(({ target }: any) => {
    setForm(old => ({ ...old, [target.id]: target.value }))
  }, [])

  const handleSubmit = useCallback((e: any) => {
    e.preventDefault()
    fetch('https://localhost:7269/register', {
      method: 'POST',
      mode: 'cors',
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(form)
    }).then(res => res.json().then(data => {
      setCookie("token", data.token)
      localStorage.setItem("role", data.role)
      navigate("/home")
    }))
  }, [form, navigate, setCookie])

  return <div className="wrapper">
    <img src="https://img.myloview.com/stickers/white-line-create-account-screen-icon-isolated-with-long-shadow-green-square-button-vector-700-240871722.jpg" alt="CREATE PROFILE" />
    <form onSubmit={handleSubmit} className="signUp">
      <h2>Kreiraj nalog</h2>
      <label>
        Ime:
        <input type="text" name="name" value={form.name} id='name' onChange={handleInput} required />
      </label>
      <label>
        Prezime:
        <input type="text" name="surname" value={form.surname} id='surname' onChange={handleInput} required />
      </label>
      <label>
        Korisničko ime:
        <input type="text" name="username" value={form.username} id='username' onChange={handleInput} required />
      </label>
      <label>
        Email:
        <input type="email" name="email" value={form.email} id='email' onChange={handleInput} pattern="[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$" required />
      </label>
      <label>
        Šifra:
        <input type="password" name="password" value={form.password} id='password' onChange={handleInput} pattern="^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*_=+-]).{8,12}$" required />
      </label>
      <label>
        Telefon:
        <input type="text" name="phone" value={form.phone} id='phone' onChange={handleInput} required />
      </label>
      <label>
        Datum rođenja:
        <input type="date" name="birthday" value={form.birthday} id='birthday' onChange={handleInput} required />
      </label>
      <Button>
        Potvrdi
      </Button>
    </form>
  </div>
}

export default SignUp