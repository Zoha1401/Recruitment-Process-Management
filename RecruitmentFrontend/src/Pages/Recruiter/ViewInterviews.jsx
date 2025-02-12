import { useEffect, useState } from "react"
import { useAuth } from "../../Context/AuthProvider";
import { useNavigate } from "react-router-dom";
import axiosInstance from "../../axios/axiosInstance";
import Interview from "../../Components/Interview";


const ViewInterviews = () => {
    const [interviews, setInterviews]= useState([])
    const navigate=useNavigate();
    const auth=useAuth();
    if(!auth.isLoggedIn){
        navigate("/login")
    }
    const token=localStorage.getItem("token")

    useEffect(() => {
      const fetchAllInterviews=async ()=>{
          
        const response=await axiosInstance.get("/interview",
              {
                headers: {
                  Authorization: `Bearer ${token}`,
                },
              }
        )
        console.log(response.data)
        setInterviews(response.data)
      }
      fetchAllInterviews();
    }, [token])
   
  return (
    <div>ViewInterviews
{interviews.map((interview) => (
        <Interview key={interview.InterviewId} interview={interview}/>
      ))}
    </div>
    
  )
}

export default ViewInterviews