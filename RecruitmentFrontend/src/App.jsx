import {createBrowserRouter, RouterProvider} from 'react-router-dom'
import AuthProvider from './Context/AuthProvider'
import Register from './auth/Register'
import Login from './auth/Login'
import RecruiterDashboard from './Pages/Recruiter/RecruiterDashboard'
function App() {
 
  const router=createBrowserRouter([
    {
      path:'/',
      element:<Register/>
    },
    {
      path: '/login',
      element:<Login/>
    },
    {
      path:'/recruiterDashboard/:userId',
      element:<RecruiterDashboard/>
    }
  ])
  return (
    <AuthProvider><RouterProvider router={router}/></AuthProvider>
  )
}

export default App
