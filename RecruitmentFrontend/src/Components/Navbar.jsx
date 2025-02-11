
import { useAuth } from '../Context/AuthProvider'
import { useNavigate } from 'react-router-dom';


const Navbar = () => {

    const auth=useAuth();
    const navigate=useNavigate();
  const handleLogout = () => {
    auth.logout
    navigate('/login')
  }
  console.log("Current user", localStorage.getItem("currentUser"))
  return (
    <nav className="navbar navbar-expand-lg navbar-light bg-light">
    <div className="container-fluid">
      <button className="btn btn-danger btn-sm" onClick={handleLogout}>
        Logout
      </button>
    </div>
  </nav>
  )
}

export default Navbar