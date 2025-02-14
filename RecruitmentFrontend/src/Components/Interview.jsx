/* eslint-disable react/prop-types */

import { useEffect, useState } from "react"
import axiosInstance from "../axios/axiosInstance";
import { useAuth } from "../Context/AuthProvider";
import { Link, useNavigate } from "react-router-dom";
import { Button } from "@mui/material";


const Interview = ({interview}) => {
    const [interviewType, setInterviewType]=useState({})
    const [candidateDetails, setCandidateDetails]= useState({})
    const [candidateSkills, setCandidateSkills]= useState([])
    const navigate=useNavigate();
    const auth=useAuth();
    if(!auth.isLoggedIn){
        navigate("/login")
    }
    const token=localStorage.getItem("token")

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
    <div className="flex flex-row mt-4 border-1 rounded-sm">
      <div className="font-bold m-2 p-6">Interview</div>
        <div className="m-2 p-6 flex flex-row">
          <div className="font-bold mx-2">Interview Type:</div>
          <div className="mx-2">{interviewType.Type}</div>
        </div>
        <div className="m-2 p-6 flex flex-row">
        <div className="font-bold mx-2">Round Number:</div>
        <div className=""> {interview.RoundNumber}</div>
        </div>
        
        <div className="m-2 p-6 flex flex-row">
          <div className="font-bold mx-2">First Name:</div> 
          <div className="">{candidateDetails.FirstName}</div>
        </div>
        {/* <div>Candidate Skills
        {candidateSkills.map((cs)=>{
            <div key={cs.CandidateId}>
                {cs.SkillName}
                {cs.Experience}
            </div>
        })}
        </div> */}
       <div className="m-6"> <Button variant="contained"><Link to={`/assignInterviewer/${interview.InterviewId}`}>Assign Interviewers</Link></Button></div>
    </div>
  )
}

export default Interview