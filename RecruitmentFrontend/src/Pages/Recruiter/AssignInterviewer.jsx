import { useEffect, useState } from "react";
import axiosInstance from "../../axios/axiosInstance";
import { useParams } from "react-router-dom";


const AssignInterviewer = () => {
    const [interviewers, setInterviewers]=useState([]);
    const token=localStorage.getItem("token")
    const {interviewId}=useParams();
    const [selectedInterviewer, setSelectedInterviewer]=useState({})
    const [checkedState, setCheckedState] = useState({});


    useEffect(() => {
      const fetchInterviewers= async()=>{
        const response= await axiosInstance.get('/user/getAllInterviewers',
              {
                headers: {
                  Authorization: `Bearer ${token}`,
                },
              }
        )
        console.log(response.data)
        setInterviewers(response.data);
      }
      fetchInterviewers();
    }, [token])


    const updateInterviewer =  (updatedState) => {
      const selected = interviewers.filter((interviewer) => updatedState[interviewer.UserId]);
      setSelectedInterviewer(selected);
    };
  
  console.log(selectedInterviewer);

  const handleCheckboxChange = (id) => {
      setCheckedState((prevState) => {
        const updatedState = { ...prevState, [id]: !prevState[id] };
        updateInterviewer(updatedState);
        return updatedState;
      });
    };
  console.log(selectedInterviewer)
  const handleAssignInterviewer= async()=>{
      try {
          const response = await axiosInstance.post(
            `/position/${interviewId}/${selectedInterviewer.UserId}`,
            {
              headers: {
                Authorization: `Bearer ${token}`,
              },
            }
          );
          console.log(response.data)
         
        } catch (error) {
          console.error("Error saving job", error, error.message);
        }
  }

    return (
        <>
          <div>Assign Interviewer
        {interviewers.map((interviewer) => (
            <div key={interviewer.UserId}>
        <li>{interviewer.FirstName}</li>
        <input type="checkbox"  onChange={() => handleCheckboxChange(interviewer.UserId)} checked={checkedState[interviewer.UserId] || false} ></input>
        </div>

      ))}
      <button onClick={handleAssignInterviewer}>Assign Interviewer</button>
    </div>
        </>
    )
}


export default AssignInterviewer