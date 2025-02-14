import { useEffect, useState } from "react"
import axiosInstance from "../../axios/axiosInstance"
import { useParams } from "react-router-dom";

const ViewApplications = () => {
    //Candidate can view their interviews for a particular application
     const [applications, setApplications]=useState([])
     const {candidateId}=useParams();
    const token=localStorage.getItem("token")
    useEffect(() => {
        const fetchApplications= async()=>{
          const response= await axiosInstance.get(`/positionCandidate/viewApplications/${candidateId}`,
                {
                  headers: {
                    Authorization: `Bearer ${token}`,
                  },
                }
          )
          setApplications(response.data);
        }
        fetchApplications();
      }, [token])
  return (
    <div>ViewApplications
         {applications.map((application) => (
        <li key={application.PositionId}>{application.Name}
        {application.StatusName}</li>
      ))}
        </div>
  )
}

export default ViewApplications