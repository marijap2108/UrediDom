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
      <Link to="/">
        <img src="/logo.png" alt="logo" width="80px" height="80px"/>
      </Link>
      <Link to="/productList">
        Products
      </Link>
    </div>
    <div className="navbar__right">
      <Link to="/order">
        <FaShoppingCart /> Cart
      </Link>
      {cookies.token ?
      <>
        <Link to="/profile">
          Profile
        </Link>
        <Button onClick={handleLogOut}>
          Log out
        </Button>
      </>
      :
      <>
        <Link to="/signIn">
          Sign in
        </Link>
        <Link to="signUp">
          Sign up
        </Link>
      </>
      }
    </div>
  </div>
}

export default Navbar