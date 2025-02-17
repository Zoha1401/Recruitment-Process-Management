import { useEffect, useState } from 'react'
import axiosInstance from '../../axios/axiosInstance';
import { useParams } from 'react-router-dom';
import { Button } from '@mui/material';

const AssignReviewer = () => {
    const [reviewers, setReviewers]=useState([]);
    const [selectedReviewer, setSelectedReviewer]=useState({})
    const [assignedReviewer, setAssignedReviewer]=useState({})
    const [checkedState, setCheckedState] = useState({});
    // const token=localStorage.getItem("token")
    // console.log(token)
    const {jobId}=useParams();
    //Fetch already assigned reviewer and mark selected
    useEffect(() => {
      const fetchReviewers= async()=>{
        const response= await axiosInstance.get('/user/getAllReviewers',
              {
                credentials: 'include',
                withCredentials: true
              }
        )
        setReviewers(response.data);
      }
      fetchReviewers();

      const fetchAssignedReviewer=async()=>{
        const response= await axiosInstance.get(`/position/getAssignedReviewer/${jobId}`,
          {
            credentials: 'include',
                withCredentials: true
          }
    )
       setAssignedReviewer(response.data);
      }
      fetchAssignedReviewer();
    }, [])
    console.log("Assigned Reviewer",assignedReviewer)

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
    const handleAssignReviewer= async(e)=>{
      e.preventDefault();
      if(!selectedReviewer){
        console.error('No reviewer selected')
      }
        try {
            const response = await axiosInstance.post(
              `/position/assignReviewer/${jobId}/${selectedReviewer[0]?.UserId}`,
              {},
            {
              credentials: 'include',
                withCredentials: true
            }
            );
            console.log(response.data)
           
          } catch (error) {
            console.error("Error assigning reviewer", error, error.message);
          }
    }

    useEffect(() => {
      const initialCheckedState = {};
      initialCheckedState[assignedReviewer.UserId]=true
      setCheckedState(initialCheckedState);
  }, [assignedReviewer]);
  
    

  return (
    <div className="flex flex-col justify-content align-items items-center">
      <div className="font-bold mt-4 text-lg">Assign Reviewer</div>
      <ul>
        {reviewers.map((reviewer) => (
            <div key={reviewer.UserId} className="flex flex-row border-1 rounded-sm p-4 m-4">
        <div className="m-1">{reviewer.FirstName}</div>
        <div className="m-1">{reviewer.LastName}</div>
        <div className="m-1"><input type="checkbox"  onChange={() => handleCheckboxChange(reviewer.UserId)} checked={checkedState[reviewer.UserId] || false} ></input></div>
        </div>

      ))}
      </ul>
      <Button variant='contained' onClick={handleAssignReviewer}>Assign Reviewer</Button>
    </div>
    
  )
}

export default AssignReviewer