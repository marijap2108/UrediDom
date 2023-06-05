import { useCookies } from "react-cookie"
import "./Admin.scss"
import { FaCopy } from "react-icons/fa"

const Admin = () => {
  const [cookies] = useCookies(['token'])

  return <div className="admin">
    <h1>Dobrodošli na admin stranicu</h1>
    <h3>Admin token <FaCopy onClick={() => navigator.clipboard.writeText(cookies.token)} /> </h3>
    <p>Klikom na swagger otvaraju se funkcionalnosti admina:</p>
    <a href="https://localhost:7269/swagger/index.html">
      <img src="https://miro.medium.com/v2/resize:fit:600/1*u52zaS9KLPguwWz5ELxGcg.png" alt="swagger" />
    </a>
  </div>
}

export default Admin