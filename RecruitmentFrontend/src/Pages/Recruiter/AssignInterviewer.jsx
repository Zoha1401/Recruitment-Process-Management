import { useEffect, useState } from "react";
import axiosInstance from "../../axios/axiosInstance";


const AssignInterviewer = () => {
    const [interviewers, setInterviewers]=useState([]);
    const token=localStorage.getItem("token")

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

    return (
        <>
        
        </>
    )
}


export default AssignInterviewer