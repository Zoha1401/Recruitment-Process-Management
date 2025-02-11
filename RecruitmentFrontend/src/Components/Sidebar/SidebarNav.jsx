import { Sidebar, Menu, MenuItem } from 'react-pro-sidebar';
import { Home } from '@mui/icons-material';
import MenuIcon from '@mui/icons-material/Menu';
import { useState } from 'react';
import "./SidebarNav.css"

const SidebarNav = () => {
  const [collapsed, setCollapsed] = useState(false);
  

  const handleToggleSidebar = () => {
    setCollapsed(!collapsed);
  }; 
  return (
  <Sidebar collapsed={collapsed} className='flex'>
    <MenuIcon onClick={handleToggleSidebar} className='flex'></MenuIcon>
    <Menu>
      <MenuItem icon={<Home />}>Home</MenuItem>
      {/* More menu items... */}
    </Menu>
    
  </Sidebar>
  )
}

export default SidebarNav