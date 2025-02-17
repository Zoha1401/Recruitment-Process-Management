import { useEffect, useState } from "react"
import axiosInstance from "../../axios/axiosInstance"
import { Link, useNavigate, useParams } from "react-router-dom"
import { Button } from "@mui/material"
import SidebarNav from "../../Components/Sidebar/SidebarNav"

const ReviewCandidate = () => {
     const [candidateDetails, setCandidateDetails]= useState({})
     const [markSkills, setMarkSkills]=useState([{SkillId:0, Experience:0}])
     const [skills, setSkills]=useState([])
    // const token=localStorage.getItem("token")
     const [shortlisted, setShortlisted]=useState(false)
     const {positionCandidateId}=useParams()
     const {jobId}=useParams()
     const navigate=useNavigate();
     //If skills already marked display
     console.log("Job Id, ", jobId)
     useEffect(() => {
        const GetCandidateDetails=async()=>{
          const candidateResponse= await axiosInstance.get(`/positionCandidate/GetCandidateDetails/${positionCandidateId}`,
              {
                credentials: 'include',
                withCredentials: true
              }
  
          )
          setCandidateDetails(candidateResponse.data)
          console.log(candidateResponse.data)
          setShortlisted(candidateResponse.data.IsShortlisted)
        }
        GetCandidateDetails();

        const GetSkills=async()=>{
            const skillResponse= await axiosInstance.get(`/skill`,
                {
                  credentials: 'include',
                  withCredentials: true
                }
    
            )
           
            setSkills(skillResponse.data)
            const initialMarkedSkills=skillResponse.data.map((skill)=>({
                SkillId:skill.SkillId,
                Experience:0
,
            }))
            setMarkSkills(initialMarkedSkills)
          }
          GetSkills();
      }, [positionCandidateId])
     console.log(markSkills)

     const handleMarkSkillChange = (index, field, value) => {
        const updatedMarkSkills = markSkills.map((skill, i) =>
            i === index ? { ...skill, [field]: parseFloat(value) } : skill
          );
          setMarkSkills(updatedMarkSkills);
      };
     console.log(shortlisted)
    const handleMarkSkillSubmit=async(e)=>{
        e.preventDefault();
        try {
            const response = await axiosInstance.post(
              `/positionCandidate/reviewCandidate/${positionCandidateId}/${shortlisted}`,
              
              markSkills,
              
              {
                credentials: 'include',
                withCredentials: true
              }
            );
            console.log(response.data)
           
                alert("Candidate skills were successfully marked")
                navigate(`/reviewerDashboard`)
            
           
          } catch (error) {
            console.error("Error saving job", error, error.message);
          }
    }


    

    const setCheckedState=()=>{
        setShortlisted(prevState => !prevState); 
    }
  return (
    <div className="flex flex-row">
      <div><SidebarNav/></div>
    <div className="flex flex-col justify-content align-items items-center"><div className="font-bold m-4 text-lg">Review Candidate</div>
    <div className="flex flex-row m-2 p-2">
       <div className="m-2 p-2 font-bold">Degree: {candidateDetails.Degree}</div>
        <div className="m-2 p-2 font-bold">College Name: {candidateDetails.CollegeName}</div>
        <div className="m-2 p-2 font-bold">First Name :{candidateDetails.FirstName}</div></div>
        <div className="m-2 p-2 font-bold">Last Name:{candidateDetails.LastName}</div>
        <div className="m-2 p-2 font-bold">Work Experience: {candidateDetails.WorkExperience}</div>
        <div className="m-2 p-2 font-bold">Resume Url: {candidateDetails.ResumeUrl}</div>
    
     <div >
                {skills.map((skill, index) => (
                   <div key={skill.SkillId} className="flex flex-row m-2 p-2">
                    <div className="font-bold m-2 p-2" >Skill Name:</div><div className="m-2 p-2">  {skill.Name}
                    </div>
                    <div className="font-bold m-2 p-2">Experience </div><div>
                        <input type="number" name="Experience" id="experience" value={markSkills[index].Experience}    onChange={(e) =>
                handleMarkSkillChange(index, "Experience", e.target.value)
              }className="rounded-sm border-1 m-2 p-2"/>
                    </div>
                    </div>
                ))}
      </div>
          
    <div className="m-2 p-2 flex flex-row">
    <div className="m-2 p-2"><Button onClick={handleMarkSkillSubmit} variant="contained">Mark Candidate Skills</Button></div>
    <div className="p-4 rounded-sm border-1"> <input type='checkbox' className="" name="shortlist" id="shortlist" onChange={setCheckedState} checked={shortlisted}/>Shortlist Candidate for interview</div>
    <div className="m-2 p-2"><Button variant="contained" className=""><Link to={`/candidateStatus/${candidateDetails.CandidateId}/${jobId}`}>Update Candidate Status</Link></Button></div>
    </div>
    
    </div>
    </div>
  )
}

export default ReviewCandidate
