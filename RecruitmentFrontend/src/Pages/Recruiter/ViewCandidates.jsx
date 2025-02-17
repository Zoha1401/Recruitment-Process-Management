import { useEffect, useState } from "react"
import { Link, useNavigate } from "react-router-dom";
import { useAuth } from "../../Context/AuthProvider";
import axiosInstance from "../../axios/axiosInstance";
import Candidate from "../../Components/Candidate";
import SidebarNav from "../../Components/Sidebar/SidebarNav";
import { Button } from "@mui/material";


const ViewCandidates = () => {
    const [candidates, setCandidates]=useState([])
    // const navigate=useNavigate();
    // const auth=useAuth();
    // if(!auth.isLoggedIn){
    //     navigate("/login")
    // }
    // const token=localStorage.getItem("token")

    useEffect(() => {
      const fetchAllCandidates=async ()=>{
          
        const response=await axiosInstance.get("/candidate/getCandidates",
              {
                credentials: 'include',
                withCredentials: true
              }
        )
        console.log(response.data)
        setCandidates(response.data)
      }
      fetchAllCandidates();
    }, [])
    
  return (
    <div className="flex flex-row align-items justify-center">
      <div><SidebarNav/></div>
   
      <div className='flex flex-col mt-4 justify-content align-items items-center w-screen'>
    <div className="flex flex-col items-center align-items justify-center">
      <div className="font-bold text-xl mb-4">Candidates</div> 
      <Button className="m-4" variant="contained"><Link to={`/addCandidate`}>Add Candidate</Link></Button>
      <div>
      {candidates.map((candidate) => (
        <Candidate key={candidate.CandidateId} candidate={candidate} className="mt-2" />
      ))}
      </div>
      </div>
      

    
    </div>
    </div>
  )
}

export default ViewCandidates