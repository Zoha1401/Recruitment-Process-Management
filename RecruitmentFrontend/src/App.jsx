/* eslint-disable react/prop-types */
import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import AuthProvider from './Context/AuthProvider';
import Register from './auth/Register';
import Login from './auth/Login';
import RecruiterDashboard from './Pages/Recruiter/RecruiterDashboard';
import CreateJob from './Pages/Recruiter/CreateJob';
import ViewCandidates from './Pages/Recruiter/ViewCandidates';
import AssignReviewer from './Pages/Recruiter/AssignReviewer';
import AssignInterviewer from './Pages/Recruiter/AssignInterviewer';
import AddCandidate from './Pages/Recruiter/AddCandidate';
import ViewApplicants from './Pages/Recruiter/ViewApplicants';
import ScheduleInterview from './Pages/Recruiter/ScheduleInterview';
import ViewInterviews from './Pages/Recruiter/ViewInterviews';
import DefineInterviewRounds from './Pages/Recruiter/DefineInterviewRounds';
import InterviewerDashboard from './Pages/Interviewer/InterviewerDashboard';
import AddFeedback from './Pages/Interviewer/AddFeedback';
import ReviewerDashboard from './Pages/Reviewer/ReviewerDashboard';
import ReviewCandidate from './Pages/Reviewer/ReviewCandidate';
import CandidateStatus from './Pages/Reviewer/CandidateStatus';
import ViewApplications from './Pages/Candidate/ViewApplications';
import CandidateDashboard from './Pages/Candidate/CandidateDashboard';
import UploadDocuments from './Pages/Candidate/UploadDocuments';
import UpdateJob from './Components/UpdateJob';
import { Navigate } from 'react-router-dom';
import ShortlistCandidate from './Pages/HR/ShortlistCandidate';


function App() {

const PrivateRoute = ({ allowedRoles, element }) => {
  const token = localStorage.getItem('token'); 
  
  if (!token) {
    return <Navigate to="/login" />; 
  }

  try {
    const parts = token.split('.');
    const decodedPayload = atob(parts[1]);
    
    const parsedPayload = JSON.parse(decodedPayload);
    console.log("response",parsedPayload)
    
    const { role } = parsedPayload; 

    
    if (allowedRoles && allowedRoles.includes(role)) {
      return <>{element}</>; 
    } else {
      return <Navigate to="/login" />; 
    }
  } catch (error) {
    console.error('Invalid token', error);
    return <Navigate to="/login" />; 
  }
};

  const router = createBrowserRouter([
    // Public Routes
    {
      path: '/',
      element: <Register />,
    },
    {
      path: '/login',
      element: <Login />,
    },

   
    {
      path: '/recruiterDashboard',
      element: <PrivateRoute element={<RecruiterDashboard />} allowedRoles={['Recruiter']} />,
    },
    {
      path: '/createJob',
      element: <PrivateRoute element={<CreateJob />} allowedRoles={['Recruiter']} />,
    },
    {
      path: '/viewCandidates',
      element: <PrivateRoute element={<ViewCandidates />} allowedRoles={['Recruiter']} />,
    },
    {
      path: '/assignReviewer/:jobId',
      element: <PrivateRoute element={<AssignReviewer />} allowedRoles={['Recruiter']} />,
    },
    {
      path: '/assignInterviewer',
      element: <PrivateRoute element={<AssignInterviewer />} allowedRoles={['Recruiter']} />,
    },
    {
      path: '/addCandidate',
      element: <PrivateRoute element={<AddCandidate />} allowedRoles={['Recruiter']} />,
    },
    {
      path: '/viewApplicants/:jobId',
      element: <PrivateRoute element={<ViewApplicants />} allowedRoles={['Recruiter']} />,
    },
    {
      path: '/scheduleInterview/:applicantId',
      element: <PrivateRoute element={<ScheduleInterview />} allowedRoles={['Recruiter']} />,
    },
    {
      path: '/viewInterviews',
      element: <PrivateRoute element={<ViewInterviews />} allowedRoles={['Recruiter']} />,
    },
    {
      path: '/assignInterviewer/:interviewId',
      element: <PrivateRoute element={<AssignInterviewer />} allowedRoles={['Recruiter']} />,
    },
    {
      path: '/defineInterviewRounds/:jobId',
      element: <PrivateRoute element={<DefineInterviewRounds />} allowedRoles={['Recruiter']} />,
    },

  
    {
      path: '/interviewerDashboard',
      element: <PrivateRoute element={<InterviewerDashboard />} allowedRoles={['Interviewer']} />,
    },
    {
      path: '/assignInterviewFeedback/:interviewId/:candidateId',
      element: <PrivateRoute element={<AddFeedback />} allowedRoles={['Interviewer']} />,
    },

   
    {
      path: '/reviewerDashboard',
      element: <PrivateRoute element={<ReviewerDashboard />} allowedRoles={['Reviewer']} />,
    },
    {
      path: '/reviewCandidate/:positionCandidateId/:jobId',
      element: <PrivateRoute element={<ReviewCandidate />} allowedRoles={['Reviewer', 'Recruiter']} />,
    },
    {
      path: '/candidateStatus/:candidateId/:jobId',
      element: <PrivateRoute element={<CandidateStatus />} allowedRoles={['Reviewer', 'Recruiter', 'HR']} />,
    },

   
    {
      path: '/viewApplications/:candidateId',
      element: <PrivateRoute element={<ViewApplications />} allowedRoles={['Candidate']} />,
    },
    {
      path: '/candidateDashboard',
      element: <PrivateRoute element={<CandidateDashboard />} allowedRoles={['Candidate']} />,
    },
    {
      path: '/uploadDocuments/:candidateId',
      element: <PrivateRoute element={<UploadDocuments />} allowedRoles={['Candidate']} />,
    },
    {
      path: '/updateJob/:jobId',
      element: <PrivateRoute element={<UpdateJob />} allowedRoles={['Recruiter']} />,
    },
    {
      path:'/shortlistCandidates',
      element:<PrivateRoute element={<ShortlistCandidate/>} allowedRoles={['Recruiter', 'HR']}/>
    }
  ]);

  return (
    <AuthProvider>
      <RouterProvider router={router} />
    </AuthProvider>
  );
}

export default App;
