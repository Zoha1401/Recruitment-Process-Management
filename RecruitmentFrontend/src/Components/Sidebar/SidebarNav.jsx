import { Sidebar, Menu, MenuItem } from 'react-pro-sidebar';
import { Home } from '@mui/icons-material';
import MenuIcon from '@mui/icons-material/Menu';
import { useState } from 'react';
import "./SidebarNav.css"
import { Link } from 'react-router-dom';

const SidebarNav = () => {
  const [collapsed, setCollapsed] = useState(false);
  

 
  return (
  <Sidebar>
    <MenuIcon className=''></MenuIcon>
    <Menu className='flex-col flex mx-1 px-2 d-flex bg-green-100'>
      <MenuItem icon={<Home />} className='flex flex-col d-flex bg-green-200 rounded-sm shadow-sm'>Home</MenuItem>
      {/* More menu items... */}
    <Link to={`/createJob`} className='mt-2 flex flex-col d-flex bg-green-200 rounded-sm shadow-sm'><button>Create Job</button></Link>
    <Link to={`/viewCandidates`} className='mt-2 flex flex-col d-flex bg-green-200 rounded-sm shadow-sm'><button>View Candidates</button></Link>
    <Link to={`/viewInterviews`} className='mt-2 flex flex-col d-flex bg-green-200 rounded-sm shadow-sm'><button>View Interviews</button></Link>
   </Menu>
    
  </Sidebar>
  )
}

export default SidebarNav