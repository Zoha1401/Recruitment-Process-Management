/* eslint-disable react/prop-types */
import { Button } from "@mui/material"
import axiosInstance from "../axios/axiosInstance"
import { useNavigate } from "react-router-dom";

// eslint-disable-next-line react/prop-types
const CandidateJob = ({job, candidate, isApplied}) => {
    const navigate=useNavigate();
    const token=localStorage.getItem("token")
    const handleApplyToPosition= async(e)=>{
      e.preventDefault()
      try{
      const response=await axiosInstance.post(`/candidate/applyToPosition/${candidate.CandidateId}/${job.PositionId}`,
        {},
      {
        headers: {
            Authorization: `Bearer ${token}`,
          },
      })
      console.log(response)
      alert("Successfully applied to job")
      navigate("/candidateDashboard")
    }
    catch(error){
        console.error("Error applying to job", error.message);
    }
    }
  return (
    <div className='flex d-flex bg-gray-100 rounded-sm m-2 p-4 '>
      <div>
     <div className="m-2">{job.Name}</div>
     <div className="m-2">{job.MinExp}</div>
     <div className="m-2">{job.Description}</div>
     <div className="flex">
     <Button className="m-2 p-2 mx-2" variant='contained' color='info' disabled={isApplied} onClick={handleApplyToPosition}>Apply</Button>
     </div>
     </div>
    </div>
  )
}

export default CandidateJob