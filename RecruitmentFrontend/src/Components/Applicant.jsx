/* eslint-disable react/prop-types */
import { Button } from "@mui/material"
import { Link, useNavigate} from "react-router-dom"
import { useAuth } from "../Context/AuthProvider"
import { useEffect, useState } from "react"
import axiosInstance from "../axios/axiosInstance"


const Applicant = ({applicant, jobId}) => {
  const auth=useAuth()
  const [scheduledInterviews, setScheduledInterviews]=useState([])
  // const [joiningDate, setJoiningDate]=useState(null)
  const navigate=useNavigate()
  const token=localStorage.getItem("token")
  useEffect(() => {
    const GetCandidateSkills=async()=>{
        const response= await axiosInstance.get(`/interview/getCandidateDoneInterviews/${applicant.PositionCandidateId}`,
            {
                headers: {
                  Authorization: `Bearer ${token}`,
                },
            }

        )
        console.log(response.data)
        setScheduledInterviews(response.data)
      }
      GetCandidateSkills();
}, [applicant.PositionCandidateId, token])

console.log("Applicant", applicant)
const MoveToSelected=async(e)=>{
  e.preventDefault();
  try {
    const response = await axiosInstance.post(
      `/shortlistCandidate`,
      {
        PositionId:applicant.PositionId,
        CandidateId:applicant.CandidateId,
      },
      {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      }
    );
    console.log(response.data)
   
    alert("Candidate was successfully moved")
    navigate(`/shortlistCandidates`)
    

  } catch (error) {
    console.error("Error saving job", error.message, error);
  }
}

  const user=auth.user
  console.log(user)
  console.log(applicant)
  console.log(scheduledInterviews)
  //To see if the applicant is already interviewed, fetch data of interviews from the backend and display for each candidate
  //Upload Resume endpoint
  return (
    <div className='flex flex-col bg-gray-100 rounded-sm m-2 p-4 '>
      
      <div className="m-2 p-2 flex flex-row">
        <div>{applicant.FirstName}</div>
        <div>{applicant.LastName}</div>
        <div>{applicant.IsShortlisted && <div>Green</div>}</div>
      </div>
      <div className="flex flex-row">
     <div className="m-2 p-2"><Button variant="contained" color="error" disabled={!applicant.IsShortlisted || user.Role=="Reviewer"}><Link to={`/scheduleInterview/${applicant.PositionCandidateId}`}>Schedule Interview</Link></Button></div>
     <div className="m-2 p-2"><Button variant="contained" color="success"><Link to={`/reviewCandidate/${applicant.PositionCandidateId}/${jobId}`}>Review</Link></Button></div>
     <div className="m-2 p-2"><Button variant="contained" color="primary"><Link to={`/candidateStatus/${applicant.CandidateId}/${jobId}`}>Update Candidate Status</Link></Button></div>
     <div className="m-2 p-2"><Button variant="contained" color="success" onClick={MoveToSelected}>Move to Selected</Button></div>
     </div>
     <h4>Interviews Scheduled</h4>
     <div className="flex">
     
     {scheduledInterviews.map((interview) => (
            <div className="p-2 m-2" key={interview.Date}><li>{interview.InterviewTypeName}</li>
            <li>{interview.Date}</li>
            <li>{interview.RoundNumber}</li></div>
          ))}
     </div>
    </div>
   
   
  )
}

export default Applicant