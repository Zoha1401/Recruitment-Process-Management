import { Link, useNavigate } from "react-router-dom"
import SidebarNav from "../../Components/Sidebar/SidebarNav"
// import { useAuth } from "../../Context/AuthProvider"
import Navbar from "../../Components/Navbar";
import axiosInstance from "../../axios/axiosInstance";
import { useAuth } from "../../Context/AuthProvider";
import { useEffect, useState } from "react";
import Job from "../../Components/Job";


const RecruiterDashboard = () => {
    // const auth=useAuth();
    const [jobs, setJobs]=useState([])
    const auth=useAuth();
    
    
console.log(auth.user)
    const navigate=useNavigate();
    if(!auth.isLoggedIn){
       navigate("/login")
    }
    const token=localStorage.getItem("token")
    console.log(token)
    useEffect(() => {
       const fetchJobs=async()=>{

        const response=await axiosInstance.get('/position',
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
    <div>
        <div><Navbar/></div><SidebarNav/>
    <Link to={`/createJob`}><button>Create Job</button></Link>
{jobs.map((job) => (
        <li key={job.PositionId}>{job.Name}</li>
      ))}
    <Link to={`/viewCandidates`}>View Candidates</Link>

    {jobs.map((job) => (
        <div key={job.PositionId}><Job key={job.PositionId} job={job}/></div>
      ))}
    </div>
  )
}

export default RecruiterDashboard