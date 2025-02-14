import { useEffect, useState } from "react"
import axiosInstance from "../../axios/axiosInstance"
import { Link, useNavigate, useParams } from "react-router-dom"

const ReviewCandidate = () => {
     const [candidateDetails, setCandidateDetails]= useState({})
     const [markSkills, setMarkSkills]=useState([{SkillId:0, Experience:0}])
     const [skills, setSkills]=useState([])
     const token=localStorage.getItem("token")
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
                  headers: {
                    Authorization: `Bearer ${token}`,
                  },
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
                    headers: {
                      Authorization: `Bearer ${token}`,
                    },
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
      }, [token, positionCandidateId])
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
                headers: {
                  Authorization: `Bearer ${token}`,
                },
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
    <div>ReviewCandidate
    {candidateDetails.CollegeName}
    {candidateDetails.Degree}
    {candidateDetails.FirstName}
    {candidateDetails.LastName}
    {candidateDetails.WorkExperience}
    {candidateDetails.ResumeUrl}
    
    <ul>
                {skills.map((skill, index) => (
                   <div key={skill.SkillId}>
                    <div >Skill Name:  {skill.Name}
                    </div>
                    <div>Experience 
                        <input type="number" name="Experience" id="experience" value={markSkills[index].Experience}    onChange={(e) =>
                handleMarkSkillChange(index, "Experience", e.target.value)
              }className="rounded-sm border-1"/>
                    </div>
                    </div>
                ))}
            </ul>

    <button onClick={handleMarkSkillSubmit}>Mark Candidate Skills</button>
    <input type='checkbox' name="shortlist" id="shortlist" onChange={setCheckedState} checked={shortlisted}/>Shortlist Candidate for interview
    <button><Link to={`/candidateStatus/${candidateDetails.CandidateId}/${jobId}`}>Update Candidate Status</Link></button>

    
    </div>
  )
}

export default ReviewCandidate
