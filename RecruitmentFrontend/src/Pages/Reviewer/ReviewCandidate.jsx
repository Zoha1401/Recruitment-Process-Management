import { useEffect, useState } from "react"
import axiosInstance from "../../axios/axiosInstance"
import { Link, useParams } from "react-router-dom"

const ReviewCandidate = () => {
     const [candidateDetails, setCandidateDetails]= useState({})
     const [markSkills, setMarkSkills]=useState([{SkillId:0, Experience:0}])
     const [skills, setSkills]=useState([])
     const token=localStorage.getItem("token")
     const {positionCandidateId}=useParams()
    
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
          }
          GetSkills();
      }, [token, positionCandidateId])
     console.log(markSkills)

      const handleMarkSkillChange = (index, field, value) => {
        const updatedMarkSkills = markSkills.map((skill, i) =>
            i === index ? { ...skill, [field]: value } : skill
          );
          setMarkSkills(updatedMarkSkills);
      };
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
                   <div key={index}>
                    <div >Skill Name:  {skill.Name}
                    </div>
                    <div>Experience 
                        <input type="text" name="Experience" id="experience" value={skill.Experience}    onChange={(e) =>
                handleMarkSkillChange(index, "Experience", e.target.value)
              }className="rounded-sm border-1"/>
                    </div>
                    </div>
                ))}
            </ul>

    <button>Mark Candidate Skills</button>
    <button><Link to={`/candidateStatus/${candidateDetails.CandidateId}`}>Update Candidate Status</Link></button>

    
    </div>
  )
}

export default ReviewCandidate