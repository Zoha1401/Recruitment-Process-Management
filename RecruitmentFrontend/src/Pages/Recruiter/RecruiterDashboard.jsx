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


  console.log("User", auth.user)
 // const navigate = useNavigate();
 
 
  useEffect(() => {
    const fetchJobs = async () => {

      const response = await axiosInstance.get('/position',
        {
          credentials: 'include',
          withCredentials: true
        }
      )
      console.log(response.data);
      setJobs(response.data)

    }
    fetchJobs();
  }, [])
  return (
    <div className="flex flex-row">

      <div><SidebarNav /></div>
      <div className="flex flex-col p-2 m-2 max-w-full w-screen h-screen">
      
        <div className="flex mt-4 flex-col ">
          <div className="flex p-2 justify-center align-items items-center font-bold">Current Job Openings</div>
        <div className="m-2 max-w-full min-h-screen">
          {jobs.map((job) => (
            <div key={job.PositionId}><Job key={job.PositionId} job={job} /></div>
          ))}
        </div>
      </div>
      </div>
    </div>
  )
}

export default RecruiterDashboard