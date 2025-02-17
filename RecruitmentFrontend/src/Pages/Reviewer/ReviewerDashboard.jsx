import { useEffect, useState } from 'react'
import { useAuth } from '../../Context/AuthProvider';
import { useNavigate } from 'react-router-dom';
import axiosInstance from '../../axios/axiosInstance';
import ReviewerJob from '../../Components/ReviewerJob';
import SidebarNav from '../../Components/Sidebar/SidebarNav';

const ReviewerDashboard = () => {
    const [jobs, setJobs] = useState([])
  const auth = useAuth();
  const user=auth.user

  console.log(auth.user)
  //const navigate = useNavigate();
  // if (!auth.isLoggedIn) {
  //   navigate("/login")
  // }
  // const token = localStorage.getItem("token")
  // console.log(token)
  console.log(jobs)
  useEffect(() => {
    const fetchJobs = async () => {

      const response = await axiosInstance.get(`/position/getPositionsForReviewer/${user.UserId}`,
        {
          credentials: 'include',
          withCredentials: true
        }
      )
      console.log(response.data);
      setJobs(response.data)

    }
    fetchJobs();
  }, [ user])

  return (
    <div className='flex flex-row'><div><SidebarNav/></div>
     
        <div className="m-2 w-screen">
          <div className='flex font-bold text-xl justify-center align-items items-center'>Assigned Jobs</div>
          {jobs.map((job) => (
            <div key={job.PositionId}><ReviewerJob key={job.PositionId} job={job} /></div>
          ))}
        </div>
           
    </div>
  )
}

export default ReviewerDashboard