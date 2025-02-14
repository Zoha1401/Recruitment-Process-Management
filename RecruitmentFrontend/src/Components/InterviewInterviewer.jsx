/* eslint-disable react/prop-types */

import { useEffect, useState } from "react"
import axiosInstance from "../axios/axiosInstance";
import { useAuth } from "../Context/AuthProvider";
import { Link, useNavigate } from "react-router-dom";
import { Button } from "@mui/material";


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
    <div className="">
    <div className="flex flex-row rounded-sm border-1 m-2 p-4">
    <div className="flex flex-row">
        <div className="m-2 font-bold">Interview Type:</div>
        <div className="m-2">{interviewType.Type}</div>
    </div>
        
        <div className="flex flex-row">
          <div className="m-2 font-bold">Round Number</div>
          <div className="m-2">{interview.RoundNumber}</div>
          </div>
        <div className="flex flex-row">
          <div className="m-2 font-bold">Candidate Name:</div>
          <div className="m-2">{candidateDetails.FirstName}</div></div>
        {candidateSkills.map((cs)=>{
            <li key={cs.CandidateId}>
                {cs.SkillName}
                {cs.Experience}
            </li>
        })}
         <div className="m-1"><Button variant="contained"><Link to={`/assignInterviewFeedback/${interview.InterviewId}/${candidateDetails.CandidateId}`}>Add Interview Feedback</Link></Button></div>
      </div>
       
        
    </div>
  )
}

export default InterviewInterviewer