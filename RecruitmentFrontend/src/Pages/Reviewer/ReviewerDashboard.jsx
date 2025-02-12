import { useEffect, useState } from 'react'
import { useAuth } from '../../Context/AuthProvider';
import { useNavigate } from 'react-router-dom';
import axiosInstance from '../../axios/axiosInstance';
import ReviewerJob from '../../Components/ReviewerJob';

const ReviewerDashboard = () => {
    const [jobs, setJobs] = useState([])
  const auth = useAuth();
  const user=auth.user

  console.log(auth.user)
  const navigate = useNavigate();
  if (!auth.isLoggedIn) {
    navigate("/login")
  }
  const token = localStorage.getItem("token")
  console.log(token)
  console.log(jobs)
  useEffect(() => {
    const fetchJobs = async () => {

      const response = await axiosInstance.get(`/position/getPositionsForReviewer/${user.UserId}`,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      )
      console.log(response.data);
      setJobs(response.data)

    }
    fetchJobs();
  }, [token, user])

  return (
    <div>ReviewerDashboard
        <ul>
        <div className="m-2">
          {jobs.map((job) => (
            <div key={job.PositionId}><ReviewerJob key={job.PositionId} job={job} /></div>
          ))}
        </div>
            </ul>
    </div>
  )
}

export default ReviewerDashboard