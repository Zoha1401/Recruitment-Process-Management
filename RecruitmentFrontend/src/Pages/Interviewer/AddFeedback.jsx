import { useEffect, useState } from "react"
import { useAuth } from "../../Context/AuthProvider"
import axiosInstance from "../../axios/axiosInstance"
import { useNavigate, useParams } from "react-router-dom"
import { Button } from "@mui/material"

const AddFeedback = () => {
    const [interviewerInterview, setInterviewerInterview]=useState([])
    const [feedbacks, setFeedbacks]=useState([{SkillId:0, Rating:0, Feedback:""}])
    const token=localStorage.getItem("token")
    const {interviewId, candidateId}=useParams();
    const [candidateSkills, setCandidateSkills]= useState([])
    const auth=useAuth()
    const navigate=useNavigate();
    const user=auth.user
    console.log(user)
    useEffect(() => {
        const fetchInterviewerInterview=async ()=>{
          
            const response=await axiosInstance.get(`/interview/getInterviewerInterview/${interviewId}/${user.UserId}`,
                  {
                    headers: {
                      Authorization: `Bearer ${token}`,
                    },
                  }
            )
            console.log(response.data)
            setInterviewerInterview(response.data)
          }
          fetchInterviewerInterview();

          
    }, [user, token])


    useEffect(() => {
        const GetCandidateSkills=async()=>{
            const candidateSkillResponse= await axiosInstance.get(`/candidateSkill/candidateSkills/${candidateId}`,
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
    }, [candidateId, token])
    console.log(candidateSkills)
    console.log(candidateId)
    // const handleChange = (e) => {
    //     const { name, value } = e.target;
    //     setFeedback((prevFeedback) => ({
    //       ...prevFeedback,
    //       [name]: value,
    //     }));
       console.log(token)
    //   }
    const saveFeedbacks=async(e)=>{
        e.preventDefault();

        try {
            const response = await axiosInstance.post(
              `/interviewFeedback/addInterviewFeedback/${interviewerInterview.InterviewerInterviewId}`,
              feedbacks,
              {
                headers: {
                  Authorization: `Bearer ${token}`,
                },
              }
            );
            console.log(response.data);
          
              alert("Interview feedbacks are successfully saved");
              navigate('/interviewerDashboard')
            
          } catch (error) {
            console.error("Error saving interview feedback", error, error.message);
          }

    }

    const handleAddFeedback=()=>{
        setFeedbacks([...feedbacks, { SkillId:0, Rating:0, Feedback:"" }]);
    }


    const handleRemoveFeedback = (index) => {
        const updatedFeedbacks = feedbacks.filter((_, i) => i !== index);
        setFeedbacks(updatedFeedbacks);
    };
    
    const handleFeedbackChange = (index, field, value) => {
        const updatedFeedbacks = feedbacks.map((feedback, i) =>
          i === index ? { ...feedback, [field]: value } : feedback
        );
        setFeedbacks(updatedFeedbacks);
      };

    // const AddFeedback=()=>{
    //      setFeedbacks((prevFeedback) => [...prevFeedback, feedback]);
    // }
    console.log(feedbacks)
    
    console.log(interviewerInterview)
  return (
    <div>AddFeedback
        {feedbacks.map((feedback, index) => (
                <div key={index} className="flex items-center space-x-2 mb-2">
         <label htmlFor="skill" className="block font-medium">
              Skill
            </label>
            <select
              id="skillId"
              name="SkillId"
              value={feedback.SkillId}
              onChange={(e) =>
                handleFeedbackChange(index, "SkillId", e.target.value)
              }
              className="block w-full rounded-md border px-3 py-2"
              required
            >
              <option value="">Select Candidate Skill</option>
              {candidateSkills.map((cs) => (
                <option key={cs.SkillId} value={cs.SkillId}>
                  {cs.SkillName}
                </option>
              ))}
            </select>
            <div>
            <label htmlFor="Rating" className="block font-medium">
              Rating
            </label>
            <input
              id="Rating"
              name="Rating"
              type="number"
              value={feedback.Rating}
              onChange={(e) =>
                handleFeedbackChange(index, "Rating", e.target.value)
              }
              className="block w-full rounded-md border px-3 py-2"
              required
            />
          </div>

          <div>
            <label htmlFor="Feedback" className="block font-medium">
              Feedback
            </label>
            <input
              id="Feedback"
              name="Feedback"
              type="text"
              value={feedback.Feedback}
              onChange={(e) =>
                handleFeedbackChange(index, "Feedback", e.target.value)
              }
              className="block w-full rounded-md border px-3 py-2"
              required
            />
          </div>
          <Button
                    variant="error"
                    onClick={() => handleRemoveFeedback(index)}
                  >
                    Remove
                  </Button>
          </div>
        ))}

          <Button onClick={handleAddFeedback}>Add Feedback</Button>

          <Button onClick={saveFeedbacks}>Save Feedbacks</Button>
    </div>
    
  )
}

export default AddFeedback