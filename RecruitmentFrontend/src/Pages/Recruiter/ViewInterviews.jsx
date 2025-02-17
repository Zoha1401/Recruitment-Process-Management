import { useEffect, useState } from "react"
import { useAuth } from "../../Context/AuthProvider";
import { useNavigate } from "react-router-dom";
import axiosInstance from "../../axios/axiosInstance";
import Interview from "../../Components/Interview";
import SidebarNav from "../../Components/Sidebar/SidebarNav";


const ViewInterviews = () => {
    const [interviews, setInterviews]= useState([])
    //const navigate=useNavigate();
    // const auth=useAuth();
    // if(!auth.isLoggedIn){
    //     navigate("/login")
    // }
    const token=localStorage.getItem("token")

    useEffect(() => {
      const fetchAllInterviews=async ()=>{
          
        const response=await axiosInstance.get("/interview",
              {
                credentials: 'include',
                withCredentials: true
              }
        )
        console.log(response.data)
        setInterviews(response.data)
      }
      fetchAllInterviews();
    }, [token])
   
  return (
    <div className="flex flex-row">
      <div><SidebarNav/></div>
    <div className="flex flex-col justify-content items-center align-items m-2">
      <div className='flex flex-col mt-4 justify-content align-items items-center w-screen'>
      <div className="font-bold text-xl">ViewInterviews</div>
<div className="m-4">{interviews.map((interview) => (
        <Interview key={interview.InterviewId} interview={interview}/>
      ))}</div>
    </div>
    </div>
    </div>
    
  )
}

export default ViewInterviews