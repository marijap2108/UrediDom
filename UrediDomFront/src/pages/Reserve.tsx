import { ChangeEvent, useCallback, useEffect, useState } from "react"
import "./Reserve.scss"
import Button from "../components/Button"
import { useCookies } from "react-cookie"
import { useNavigate } from "react-router-dom"

type Repairman = {
  repairmanID: number,
  sector: string
}

const Reserve = () => {
  const [form, setForm] = useState({ startDate: '', endDate: '' })
  const [reservation, setResevation] = useState()
  const [repairmans, setRepairmans] = useState<Repairman[]>()
  const [cookies] = useCookies(['token'])
  const [selected, setSelected] = useState('')
  const navigate = useNavigate()

  const handleInput = useCallback(({ target }: any) => {
    setForm(old => ({ ...old, [target.id]: target.value }))
  }, [])

  const handleChange = useCallback(({target: {value}}: ChangeEvent<HTMLSelectElement>) => {
    setSelected(value)
  },[])

  const handleReservation = useCallback((e: any) => {
    e.preventDefault()
    fetch('https://localhost:7269/reservation', {
      method: 'POST',
      mode: 'cors',
      headers: {
        "Content-Type": "application/json",
        'Authorization': `Bearer ${cookies.token}`
      },
      body: JSON.stringify({...form, repairmanID: selected})
    }).then(res => res.json().then(data => {
      setResevation(data)
      navigate("/reservationComplete")
    }))
  },[cookies.token, form, navigate, selected])

  useEffect(() => {
    fetch('https://localhost:7269/reapirman', {
      method: 'GET',
      mode: 'cors',
      headers: {
        "Content-Type": "application/json",
        'Authorization': `Bearer ${cookies.token}`
      }
    }).then(res => res.json().then((data: Repairman[]) => {
      setSelected(`${data[0].repairmanID}`)
      setRepairmans(data)
    }))
  },[cookies.token])

  return <div className="reserve">
    <h2>Rezervišite svog majstora</h2>
    <form onSubmit={handleReservation} className="reserve__top">
      <p>Kako bismo osigurali besprekorno iskustvo poboljšanja doma, nudimo vam praktičnu mogućnost da direktno rezervišete veštog majstora za popravku putem našeg sajta.</p>
      <label>
        Datum početka radova:
        <input required type="date" name="startDate" value={form.startDate} id='startDate' onChange={handleInput} />
      </label>
      <label>
        Datum završetka radova:
        <input required type="date" name="endDate" value={form.endDate} id='endDate' onChange={handleInput} />
      </label>
      <label>
        Odabir majstora: 
        <select onChange={handleChange} value={selected}>
          {repairmans?.map((repairman) =>
            <option value={repairman.repairmanID}>{repairman.repairmanID}. {repairman.sector}</option>
          )}
        </select>
      </label>
      <Button>Pošalji rezervaciju</Button>
    </form>
    <div className="reserve__bottom">
      <img src="https://thumbs.dreamstime.com/b/professional-repairman-uniform-holding-hammer-toolbox-different-icons-set-home-maintenance-repair-service-concept-full-204350121.jpg" alt="majstor" />
    </div>
  </div>
}

export default Reserve