import { FaShoppingCart } from "react-icons/fa";
import { Link } from "react-router-dom";
import "./Navbar.scss"

const Navbar = () => {
  return <div className="navbar">
    <div className="navbar__left">
      <Link to="/">
        <img src="/logo.png" alt="logo" width="120px" height="120px"/>
      </Link>
      <Link to="/productList">
        Products
      </Link>
    </div>
    <div className="navbar__right">
      <Link to="/order">
        <FaShoppingCart /> Cart
      </Link>
      <Link to="/signIn">
        Sign in
      </Link>
      <Link to="signUp">
        Sign up
      </Link>
    </div>
  </div>
}

export default Navbar