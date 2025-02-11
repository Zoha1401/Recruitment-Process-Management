import { useEffect, useState } from "react"
import { Link, useNavigate, useParams } from "react-router-dom";
import { useAuth } from "../../Context/AuthProvider";
import axiosInstance from "../../axios/axiosInstance";


const ViewCandidates = () => {
    const [candidates, setCandidates]=useState([])
    const navigate=useNavigate();
    const auth=useAuth();
    if(!auth.isLoggedIn){
        navigate("/login")
    }
    const {userId}=useParams();
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
    <div>ViewCandidates
        {candidates.map((c) => (
        <li key={c.CandidateId}>{c.CollegeName}</li>
      ))}

      <Link to={`/addCandidate/${userId}`}>Add Candidate</Link>
    </div>
  )
}

export default ViewCandidates