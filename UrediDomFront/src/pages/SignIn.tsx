import { useCallback, useState } from "react"
import { useCookies } from "react-cookie"
import { useNavigate } from "react-router-dom"

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

  return <div className="signIn">
    <label>
      Email:
      <input type="email" name="email" value={form.email} id='email' onChange={handleInput} />
    </label>
    <label>
      Password
      <input type="password" name="password" value={form.password} id='password' onChange={handleInput} />
    </label>
    <button onClick={handleSubmit}>
      Submit
    </button>
  </div>
}

export default SignIn