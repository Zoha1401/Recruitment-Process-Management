import { useEffect, useState } from 'react'
import axiosInstance from '../../axios/axiosInstance';

const AssignReviewer = () => {
    const [reviewers, setReviewers]=useState([]);
    const token=localStorage.getItem("token")

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
    

  return (
    <div>AssignReviewer</div>
  )
}

export default AssignReviewer