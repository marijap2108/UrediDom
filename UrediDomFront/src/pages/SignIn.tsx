import { useCallback, useState } from "react"
import { useCookies } from "react-cookie"
import { Link, useNavigate } from "react-router-dom"
import "./SignIn.scss"
import Button from "../components/Button"

const SignIn = () => {
  const [form, setForm] = useState({email: '', password: ''})
  const [_cookies, setCookie] = useCookies(['token'])
  const navigate = useNavigate()

  const handleInput = useCallback(({target}: any) => {
    setForm(old => ({...old, [target.id]: target.value}))
  }, [])

  const handleSubmit = useCallback(() => {
    fetch('https://localhost:7269/login', {
      method: 'POST',
      mode: 'cors',
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(form)
    }).then(res => res.json().then(data => {
      setCookie("token", data.token)
      navigate("/")
    }))
  }, [form, navigate, setCookie])

  return <div className="signInWrapper">
    <h2>Prijavi se</h2>
    <div className="signIn">
      <div className="signIn__left">
        <div className="signIn__left__text">
          <p>Hvala Vam što ste posetili našu veb stranicu!</p>
          <p>Ako nemate nalog i želite ga kreirati, kliknite na KREIRAJ NALOG ispod kako biste napravili novi nalog.</p>
        </div>
        <Link to="/signUp">
            KREIRAJ NALOG
        </Link>
      </div>
      <div className="signIn__right">
        <label>
          Email:
          <input type="email" name="email" value={form.email} id='email' onChange={handleInput} />
        </label>
        <label>
          Šifra:
          <input type="password" name="password" value={form.password} id='password' onChange={handleInput} />
        </label>
        <Button onClick={handleSubmit}>
          Prijavi se
        </Button>
      </div>
    </div>
  </div>
}

export default SignIn