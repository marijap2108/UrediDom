import { Link } from 'react-router-dom'
import './Home.scss'
import Button from '../components/Button'

const Home = () => {
  return <div className="home">
    <section>
      <h1>Dobrodošli u našu online prodavnicu za uređenje doma!</h1>
      <p>Uz našu široku paletu proizvoda za uređenje doma, možete pretvoriti svoj prostor u mesto koje odiše stilom i udobnošću. Naša kolekcija nudi sve što vam je potrebno za stvaranje prostora koji odražava vašu ličnost i estetiku.</p>
      <p>Sve proizvode koje nudimo možete pogledati -{'>'} <Link to="/productList"><Button>PROIZVODI</Button></Link></p>
    </section>
  </div>
}

export default Home