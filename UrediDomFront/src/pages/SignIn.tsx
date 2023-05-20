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
    <h2>Sign in</h2>
    <div className="signIn">
      <div className="signUp__left">
        <div className="signUp__left__text">
          <p>Thank you for visiting our web site!</p>
          <p>If you do not have an account and you want to have one, click on the SIGN UP bellow to create new account.</p>
        </div>
        <Link to="/signUp">
            Sign up
        </Link>
      </div>
      <div className="signIn__right">
        <label>
          Email:
          <input type="email" name="email" value={form.email} id='email' onChange={handleInput} />
        </label>
        <label>
          Password
          <input type="password" name="password" value={form.password} id='password' onChange={handleInput} />
        </label>
        <Button onClick={handleSubmit}>
          Submit
        </Button>
      </div>
    </div>
  </div>
}

export default SignIn