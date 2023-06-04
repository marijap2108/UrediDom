import { FaShoppingCart } from "react-icons/fa";
import { Link, useNavigate } from "react-router-dom";
import "./Navbar.scss"
import { useCookies } from "react-cookie";
import Button from "./Button";
import { useCallback } from "react";

const Navbar = () => {
  const [cookies, _setCookie, removeCookie] = useCookies(['token'])
  const navigate = useNavigate();

  const handleLogOut = useCallback(() => {
    removeCookie("token")
    navigate("/")
  }, [navigate, removeCookie])

  return <div className="navbar">
    <div className="navbar__left">
      <Link to="/home">
        <img src="/logo.png" alt="logo" width="80px" height="80px"/>
      </Link>
      <Link to="/home">
        Početna
      </Link>
      <Link to="/productList">
        Proizvodi
      </Link>
      <Link to="/aboutUs">
        O nama
      </Link>
    </div>
    <div className="navbar__right">
      <Link to="/order">
        <FaShoppingCart /> Korpa
      </Link>
      {cookies.token ?
      <>
        <Link to="/profile">
          Profil
        </Link>
        <Button onClick={handleLogOut}>
          Odjavi se
        </Button>
      </>
      :
      <>
        <Link to="/signIn">
          Prijavi se
        </Link>
        <Link to="/signUp">
          Kreiraj nalog
        </Link>
      </>
      }
    </div>
  </div>
}

export default Navbar