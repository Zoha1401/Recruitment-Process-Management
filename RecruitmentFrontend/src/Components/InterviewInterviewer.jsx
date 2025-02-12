/* eslint-disable react/prop-types */

import { useEffect, useState } from "react"
import axiosInstance from "../axios/axiosInstance";
import { useAuth } from "../Context/AuthProvider";
import { Link, useNavigate } from "react-router-dom";


const InterviewInterviewer = ({interview}) => {
    const [interviewType, setInterviewType]=useState({})
    const [candidateDetails, setCandidateDetails]= useState({})
    const [candidateSkills, setCandidateSkills]= useState([])
    const navigate=useNavigate();
    const auth=useAuth();
    if(!auth.isLoggedIn){
        navigate("/login")
    }
    const token=localStorage.getItem("token")
    console.log("These are candidate details", candidateDetails)
    useEffect(() => {
      const fetchInterviewType=async ()=>{
          
        const response=await axiosInstance.get(`/interviewType/getById/${interview.InterviewTypeId}`,
              {
                headers: {
                  Authorization: `Bearer ${token}`,
                },
              }
        )
        console.log(response.data)
        setInterviewType(response.data)
      }
      fetchInterviewType();

      const GetCandidateDetails=async()=>{
        const candidateResponse= await axiosInstance.get(`/positionCandidate/GetCandidateDetails/${interview.PositionCandidateId}`,
            {
                headers: {
                  Authorization: `Bearer ${token}`,
                },
            }

        )
        console.log(candidateResponse.data)
        setCandidateDetails(candidateResponse.data)
      }
      GetCandidateDetails();
    }, [token])

    useEffect(() => {
        const GetCandidateSkills=async()=>{
            const candidateSkillResponse= await axiosInstance.get(`/candidateSkill/candidateSkills/${candidateDetails.CandidateId}`,
                {
                    headers: {
                      Authorization: `Bearer ${token}`,
                    },
                }
    
            )
            console.log(candidateSkillResponse.data)
            setCandidateSkills(candidateSkillResponse.data)
          }
          GetCandidateSkills();
    }, [candidateDetails.CandidateId, token])
   
    
  return (
    <div>Interview
        <li>{interviewType.Type}
        </li>
        <li>{interview.RoundNumber}</li>
        <li>{candidateDetails.FirstName}</li>
        {candidateSkills.map((cs)=>{
            <li key={cs.CandidateId}>
                {cs.SkillName}
                {cs.Experience}
            </li>
        })}
        <Link to={`/assignInterviewFeedback/${interview.InterviewId}/${candidateDetails.CandidateId}`}>Add Interview Feedback</Link>
        
    </div>
  )
}

export default InterviewInterviewer