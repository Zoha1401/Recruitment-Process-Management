import { useEffect, useState } from 'react'
import axiosInstance from '../../axios/axiosInstance';
import { useParams } from 'react-router-dom';

const AssignReviewer = () => {
    const [reviewers, setReviewers]=useState([]);
    const [selectedReviewer, setSelectedReviewer]=useState({})
    const [checkedState, setCheckedState] = useState({});
    const token=localStorage.getItem("token")
    const {jobId}=useParams();
    console.log(jobId)
    console.log(selectedReviewer)
    useEffect(() => {
      const fetchReviewers= async()=>{
        const response= await axiosInstance.get('/user/getAllReviewers',
              {
                headers: {
                  Authorization: `Bearer ${token}`,
                },
              }
        )
        console.log(response.data)
        setReviewers(response.data);
      }
      fetchReviewers();
    }, [token])

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

    const handleAssignReviewer= async()=>{
        try {
            const response = await axiosInstance.post(
              `/position/${jobId}/${selectedReviewer}`,
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
    <div>Assign Reviewer
        {reviewers.map((reviewer) => (
            <div key={reviewer.UserId}>
        <li>{reviewer.FirstName}</li>
        <input type="checkbox"  onChange={() => handleCheckboxChange(reviewer.UserId)} checked={checkedState[reviewer.UserId] || false} ></input>
        </div>

      ))}
      <button onClick={handleAssignReviewer}>Assign Reviewer</button>
    </div>
    
  )
}

export default AssignReviewer