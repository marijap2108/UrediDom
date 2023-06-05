import { Link } from 'react-router-dom'
import './Home.scss'
import Button from '../components/Button'

const Home = () => {
  return <div className="home">
    <div className='home__top'>
      <h1>Dobrodošli u našu online prodavnicu za uređenje doma!</h1>
      <p>Uz našu široku paletu proizvoda za uređenje doma, možete pretvoriti svoj prostor u mesto koje odiše stilom i udobnošću. Naša kolekcija nudi sve što vam je potrebno za stvaranje prostora koji odražava vašu ličnost i estetiku.</p>
      <p>Sve proizvode koje nudimo možete pogledati -{'>'} <Link to="/productList"><Button>PROIZVODI</Button></Link></p>
      <img src="https://jumanji.livspace-cdn.com/magazine/wp-content/uploads/sites/2/2022/01/27181703/Cover.jpg" alt="dekoracija" />
    </div>
    <div className='home__middle'>
      <h1>Kupujte uz besplatnu poštarinu</h1>
      <p>Prilikom svake kupovine, poštarina je u potpunosti besplatna.</p>
      <p>Uživajte u sigurnoj kupovini!</p>
      <img src='https://img.freepik.com/premium-vector/fast-delivery-truck-with-motion-lines-online-delivery-express-delivery-quick-move-fast-shipping-truck-apps-websites-cargo-van-moving-fast-chronometer-fast-distribution-service-24-7_435184-218.jpg?w=2000' alt='kupovina' />
    </div>
    <div className='home__bottom'>
      <h1>Rezervišite svog majstora za popravku</h1>
      <p>Kako bismo osigurali besprekorno iskustvo poboljšanja doma, nudimo vam praktičnu mogućnost da direktno rezervišete veštog majstora za popravku putem našeg sajta.</p>
      <p>Ukoliko ste odlučili da rezervišete svog majstora to je moguće ovde -{'>'} <Link to="/reserve"><Button>Rezervacija majstora</Button></Link></p>
      <img src="https://thumbs.dreamstime.com/b/professional-repairman-uniform-holding-hammer-toolbox-different-icons-set-home-maintenance-repair-service-concept-full-204350121.jpg" alt="majstor" />
    </div>
  </div>
}

export default Home