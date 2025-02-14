import { useEffect, useState } from "react"
import { Link, useNavigate } from "react-router-dom";
import { useAuth } from "../../Context/AuthProvider";
import axiosInstance from "../../axios/axiosInstance";
import Candidate from "../../Components/Candidate";


const ViewCandidates = () => {
    const [candidates, setCandidates]=useState([])
    const navigate=useNavigate();
    const auth=useAuth();
    if(!auth.isLoggedIn){
        navigate("/login")
    }
    const token=localStorage.getItem("token")

    useEffect(() => {
      const fetchAllCandidates=async ()=>{
          
        const response=await axiosInstance.get("/candidate",
              {
                headers: {
                  Authorization: `Bearer ${token}`,
                },
              }
        )
        console.log(response.data)
        setCandidates(response.data)
      }
      fetchAllCandidates();
    }, [token])
    
  return (
    <div className="flex flex-col items-center p-2 m-2 align-items justify-center">
      <div className="font-bold text-xl">Candidates</div>
      <div>
      {candidates.map((candidate) => (
        <Candidate key={candidate.CandidateId} candidate={candidate} />
      ))}
      </div>
      

      <Link to={`/addCandidate`}>Add Candidate</Link>
    </div>
  )
}

export default ViewCandidates