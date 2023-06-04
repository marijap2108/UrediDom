import { useCallback, useEffect, useState } from "react"
import "./Profile.scss"
import { useCookies } from "react-cookie"
import { FaCheck, FaEdit, FaTimes } from "react-icons/fa"
import Button from "../components/Button"

interface IUser {
  userId: number,
  name: string,
  surname: string,
  username: string,
  phone: string,
  birthday: string,
  email: string,
  password: string
}

const Profile = () => {
  const [user, setUser] = useState<IUser>()
  const [profile, setProfile] = useState<IUser>()
  const [editable, setEditable] = useState(false)
  const [cookies] = useCookies(['token'])

  const handleInput = useCallback(({target}: any) => {
    setProfile(old => old && ({...old, [target.id]: target.value}))
  }, [])

  const handleEditable = useCallback(() => {
    setEditable(old => !old)
    setProfile(user)
  }, [user])

  useEffect(() => {
    fetch('https://localhost:7269/user', {
      method: 'GET',
      mode: 'cors',
      headers: {
        "Content-Type": "application/json",
        'Authorization': `Bearer ${cookies.token}`
      }
    }).then(res => res.json().then(data => {
      setProfile(data)
      setUser(data)
    }))
  }, [cookies.token])

  const handleSave = useCallback(() => {
    fetch('https://localhost:7269/user', {
      method: 'PUT',
      mode: 'cors',
      headers: {
        "Content-Type": "application/json",
        'Authorization': `Bearer ${cookies.token}`
      },
      body: JSON.stringify(profile)
    }).then(res => res.json().then(data => {
      setUser(data)
      handleEditable()
    }))
  }, [cookies.token, handleEditable, profile])

  return <div className="profile">
    <div className="profile__left">
      <h2>Welcome to profile page</h2>
      <h3>This is page that shows information about your account.</h3>
      <h3>If you want to change any information on your profile, click on the pen icon next to Profile.</h3>
    </div>
    <div className="profile__right">
      <h3>Profile <FaEdit onClick={handleEditable} /></h3>
      <table>
        <tbody>
          <tr>
            <td><label htmlFor="name">NAME</label></td>
            <td><input id="name" value={profile?.name} disabled={!editable} onChange={handleInput} /></td>
          </tr>
          <tr>
            <td><label htmlFor="surname">SURNAME</label></td>
            <td><input id="surname" value={profile?.surname} disabled={!editable} onChange={handleInput} /></td>
          </tr>
          <tr>
            <td><label htmlFor="username">USERNAME</label></td>
            <td><input id="username" value={profile?.username} disabled={!editable} onChange={handleInput} /></td>
          </tr>
          <tr>
            <td><label htmlFor="phone">PHONE</label></td>
            <td><input id="phone" value={profile?.phone} disabled={!editable} onChange={handleInput} /></td>
          </tr>
          <tr>
            <td><label htmlFor="email">EMAIL</label></td>
            <td><input id="email" value={profile?.email} disabled={!editable} onChange={handleInput} /></td>
          </tr>
          <tr>
            <td><label htmlFor="password">PASSWORD</label></td>
            <td><input id="password" value={profile?.password} disabled={!editable} onChange={handleInput} /></td>
          </tr>
        </tbody>
      </table>
      {editable && <>
        <Button onClick={handleSave} >Save <FaCheck /></Button>
        <Button onClick={handleEditable}>Cancel <FaTimes /></Button>
      </>}
    </div>
  </div>
}

export default Profile