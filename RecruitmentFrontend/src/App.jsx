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
import ViewApplicants from './Pages/Recruiter/ViewApplicants'
import ScheduleInterview from './Pages/Recruiter/ScheduleInterview'
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
      path:'/recruiterDashboard',
      element:<RecruiterDashboard/>
    },
    {
      path:'/createJob',
      element:<CreateJob/>
    },
    {
      path:'/viewCandidates',
      element:<ViewCandidates/>
    },
    {
      path:'/assignReviewer/:jobId',
      element:<AssignReviewer/>
    },
    {
      path:'/assignInterviewer',
      element:<AssignInterviewer/>
    },
    {
      path:'/addCandidate',
      element:<AddCandidate/>
    },
    {
      path:'/viewApplicants/:jobId',
      element:<ViewApplicants/>
    },
    {
      path:'/scheduleInterview/:applicantId',
      element:<ScheduleInterview/>
    }
  ])
  return (
    <AuthProvider><RouterProvider router={router}/></AuthProvider>
  )
}

export default App
