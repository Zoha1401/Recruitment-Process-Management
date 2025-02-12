
import { Button } from '@mui/material';
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
    <div className="container-fluid justify-content-end">
      <Button color='error' variant='contained' className="btn btn-danger btn-sm" onClick={handleLogout}>
        Logout
      </Button>
    </div>
  </nav>
  )
}

export default Navbar