import { useEffect, useState } from "react"
import axiosInstance from "../../axios/axiosInstance"
import { useParams } from "react-router-dom";

const ViewApplications = () => {
    //Candidate can view their interviews for a particular application
     const [applications, setApplications]=useState([])
     const {candidateId}=useParams();
    //const token=localStorage.getItem("token")
    useEffect(() => {
        const fetchApplications= async()=>{
          const response= await axiosInstance.get(`/positionCandidate/viewApplications/${candidateId}`,
                {
                  credentials: 'include',
                  withCredentials: true
                }
          )
          setApplications(response.data);
        }
        fetchApplications();
      }, [])
  return (
    <div className="">

      <div>ViewApplications</div>
         {applications.map((application) => (
        <li key={application.PositionId}>{application.Name}
        {application.StatusName}</li>
      ))}
        </div>
  )
}

export default ViewApplications