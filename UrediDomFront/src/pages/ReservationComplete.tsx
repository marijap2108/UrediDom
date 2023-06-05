import { Link } from "react-router-dom"
import Button from "../components/Button"
import "./ReservationComplete.scss"

const ReservationComplete = () => {
  return <div className="reservationComplete">
    <h1>Rezervacija</h1>
    <h3>Vaša Rezervacija je uspešno kreirana</h3>
    <img src="https://www.pngmart.com/files/16/Green-Check-Mark-PNG-File.png" alt="done" />
    <div>
      <Link to="/home"><Button>Nazad na početnu stranicu</Button></Link>
    </div>
  </div>
}

export default ReservationComplete