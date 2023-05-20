import { useCallback, useState } from "react"
import { useCookies } from "react-cookie"
import { useNavigate } from "react-router-dom"
import "./SignUp.scss"
import Button from "../components/Button"

const SignUp = () => {
  const [form, setForm] = useState({name: '', surname: '', username: '', email: '', password: '', phone: '', birthday: '', role: ''})
  const [_cookies, setCookie] = useCookies(['token'])
  const navigate = useNavigate()

  const handleInput = useCallback(({target}: any) => {
    setForm(old => ({...old, [target.id]: target.value}))
  }, [])

  const handleSubmit = useCallback(() => {
    fetch('https://localhost:7269/register', {
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

  return <div className="signUp">
    <h2>Sign up</h2>
    <label>
      Name:
      <input type="text" name="name" value={form.name} id='name' onChange={handleInput} />
    </label>
    <label>
      Surname:
      <input type="text" name="surname" value={form.surname} id='surname' onChange={handleInput} />
    </label>
    <label>
      Username:
      <input type="text" name="username" value={form.username} id='username' onChange={handleInput} />
    </label>
    <label>
      Email:
      <input type="email" name="email" value={form.email} id='email' onChange={handleInput} />
    </label>
    <label>
      Password
      <input type="password" name="password" value={form.password} id='password' onChange={handleInput} />
    </label>
    <label>
      Phone:
      <input type="text" name="phone" value={form.phone} id='phone' onChange={handleInput} />
    </label>
    <label>
      Birthday:
      <input type="date" name="birthday" value={form.birthday} id='birthday' onChange={handleInput} />
    </label>
    <Button onClick={handleSubmit}>
      Submit
    </Button>
  </div>
}

export default SignUp