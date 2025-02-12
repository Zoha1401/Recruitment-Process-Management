import { useNavigate } from "react-router-dom"
import SidebarNav from "../../Components/Sidebar/SidebarNav"
// import { useAuth } from "../../Context/AuthProvider"
import Navbar from "../../Components/Navbar";
import axiosInstance from "../../axios/axiosInstance";
import { useAuth } from "../../Context/AuthProvider";
import { useEffect, useState } from "react";
import Job from "../../Components/Job";


const RecruiterDashboard = () => {
  // const auth=useAuth();
  const [jobs, setJobs] = useState([])
  const auth = useAuth();


  console.log(auth.user)
  const navigate = useNavigate();
  if (!auth.isLoggedIn) {
    navigate("/login")
  }
  const token = localStorage.getItem("token")
  console.log(token)
  useEffect(() => {
    const fetchJobs = async () => {

      const response = await axiosInstance.get('/position',
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
  }, [token])
  return (
    <div className="flex flex-row">

      <div><SidebarNav /></div>
      <div className="flex flex-col p-2 m-2">
        <div><Navbar /></div>
        <div className="flex mt-4 font-bold justify-content align-items items-center">Current Job Openings</div>
        <div className="m-2">
          {jobs.map((job) => (
            <div key={job.PositionId}><Job key={job.PositionId} job={job} /></div>
          ))}
        </div>
      </div>
    </div>
  )
}

export default RecruiterDashboard