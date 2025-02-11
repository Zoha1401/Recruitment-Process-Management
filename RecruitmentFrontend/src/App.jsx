import {createBrowserRouter, RouterProvider} from 'react-router-dom'
import AuthProvider from './Context/AuthProvider'
import Register from './auth/Register'
import Login from './auth/Login'
import RecruiterDashboard from './Pages/Recruiter/RecruiterDashboard'
import CreateJob from './Pages/Recruiter/CreateJob'
import ViewCandidates from './Pages/Recruiter/ViewCandidates'
import AssignReviewer from './Pages/Recruiter/AssignReviewer'
import AssignInterviewer from './Pages/Recruiter/AssignInterviewer'
import AddCandidate from './Pages/Recruiter/AddCandidate'
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
    },
    {
      path:'/createJob/:userId',
      element:<CreateJob/>
    },
    {
      path:'/viewCandidates/:userId',
      element:<ViewCandidates/>
    },
    {
      path:'/assignReviewer/:jobId',
      element:<AssignReviewer/>
    },
    {
      path:'/assignInterviewer/:userId',
      element:<AssignInterviewer/>
    },
    {
      path:'/addCandidate/:userId',
      element:<AddCandidate/>
    }
  ])
  return (
    <AuthProvider><RouterProvider router={router}/></AuthProvider>
  )
}

export default App
