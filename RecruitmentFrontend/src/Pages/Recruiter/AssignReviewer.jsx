import { useEffect, useState } from 'react'
import axiosInstance from '../../axios/axiosInstance';
import { useParams } from 'react-router-dom';

const AssignReviewer = () => {
    const [reviewers, setReviewers]=useState([]);
    const [selectedReviewer, setSelectedReviewer]=useState({})
    const [assignedReviewer, setAssignedReviewer]=useState({})
    const [checkedState, setCheckedState] = useState({});
    const token=localStorage.getItem("token")
    console.log(token)
    const {jobId}=useParams();
    //Fetch already assigned reviewer and mark selected
    useEffect(() => {
      const fetchReviewers= async()=>{
        const response= await axiosInstance.get('/user/getAllReviewers',
              {
                headers: {
                  Authorization: `Bearer ${token}`,
                },
              }
        )
        setReviewers(response.data);
      }
      fetchReviewers();

      const fetchAssignedReviewer=async()=>{
        const response= await axiosInstance.get(`/position/getAssignedReviewer/${jobId}`,
          {
            headers: {
              Authorization: `Bearer ${token}`,
            },
          }
    )
       setAssignedReviewer(response.data);
      }
      fetchAssignedReviewer();
    }, [token])
    console.log(assignedReviewer)

    const updateReviewer =  (updatedState) => {
        const selected = reviewers.filter((reviewer) => updatedState[reviewer.UserId]);
        setSelectedReviewer(selected);
      };
    
    console.log(selectedReviewer);

    const handleCheckboxChange = (id) => {
        setCheckedState((prevState) => {
          const updatedState = { ...prevState, [id]: !prevState[id] };
          updateReviewer(updatedState);
          return updatedState;
        });
      };
    console.log(selectedReviewer)
    const handleAssignReviewer= async()=>{
      if(!selectedReviewer){
        console.error('No reviewer selected')
      }
        try {
            const response = await axiosInstance.post(
              `/position/assignReviewer/${jobId}/${selectedReviewer[0]?.UserId}`,
              {},
              {
                headers: {
                  Authorization: `Bearer ${token}`,
                  "Content-Type":"application/json",
                },
              }
            );
            console.log(response.data)
            if(response.data){
              const reviewerId=selectedReviewer[0]?.UserId;
              setCheckedState((prevState)=>({
                ...prevState,
                [reviewerId]:true
              }))
            }
           
          } catch (error) {
            console.error("Error assigning reviewer", error, error.message);
          }
    }
    

  return (
    <div>Assign Reviewer
        {reviewers.map((reviewer) => (
            <div key={reviewer.UserId}>
        <li>{reviewer.FirstName}</li>
        <input type="checkbox"  onChange={() => handleCheckboxChange(reviewer.UserId)} checked={checkedState[assignedReviewer.UserId] || false} ></input>
        </div>

      ))}
      <button onClick={handleAssignReviewer}>Assign Reviewer</button>
    </div>
    
  )
}

export default AssignReviewer