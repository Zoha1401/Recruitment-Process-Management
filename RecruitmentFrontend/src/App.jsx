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
import ViewInterviews from './Pages/Recruiter/ViewInterviews'
import DefineInterviewRounds from './Pages/Recruiter/DefineInterviewRounds'
import InterviewerDashboard from './Pages/Interviewer/InterviewerDashboard'
import AddFeedback from './Pages/Interviewer/AddFeedback'
import ReviewerDashboard from './Pages/Reviewer/ReviewerDashboard'
import ReviewCandidate from './Pages/Reviewer/ReviewCandidate'
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
    },
    {
      path:'/viewInterviews',
      element:<ViewInterviews/>
    },
    {
      path:'/assignInterviewer/:interviewId',
      element:<AssignInterviewer/>
    },
    {
      path:'/defineInterviewRounds/:jobId',
      element:<DefineInterviewRounds/>

    },
    {
      path:'/interviewerDashboard',
      element:<InterviewerDashboard/>
    },
    {
      path:'/assignInterviewFeedback/:interviewId/:candidateId',
      element:<AddFeedback/>
    },
    {
      path:'/reviewerDashboard',
      element:<ReviewerDashboard/>
    },
    {
      path:'/reviewCandidate/:positionCandidateId',
      element:<ReviewCandidate/>
    }
  ])
  return (
    <AuthProvider><RouterProvider router={router}/></AuthProvider>
  )
}

export default App
