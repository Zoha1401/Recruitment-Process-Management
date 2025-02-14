import { useEffect, useState } from "react"
import { useAuth } from "../../Context/AuthProvider"
import axiosInstance from "../../axios/axiosInstance"
import InterviewInterviewer from "../../Components/InterviewInterviewer"

const InterviewerDashboard = () => {
    const [interviews, setInterviews]=useState([])
    const token=localStorage.getItem("token")
    const auth=useAuth()
    const user=auth.user
    console.log(user)
    useEffect(() => {
        const fetchAllInterviews=async ()=>{
          
            const response=await axiosInstance.get(`/interview/getInterviewsForInterviewer/${user.UserId}`,
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
    }, [user, token])
    console.log(interviews)
    
  return (
    <div className="flex flex-col justify-content align-items items-center">
      <div className="font-bold m-4">Your Interviews</div>
      <div className="">
   {interviews.map((interview) => (
        <InterviewInterviewer key={interview.InterviewId} interview={interview}/>
      ))}
      </div>
    </div>
  )
}

export default InterviewerDashboard