import { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom';
import { useAuth } from '../../Context/AuthProvider';
import axiosInstance from '../../axios/axiosInstance';
import Applicant from '../../Components/Applicant';

const ViewApplicants = () => {
    const [applicants, setApplicants]=useState([])
    const navigate=useNavigate();
    const auth=useAuth();
    if(!auth.isLoggedIn){
        navigate("/login")
    }
    const {jobId}=useParams();
    const token=localStorage.getItem("token")

    useEffect(() => {
      const fetchAllApplicants=async ()=>{
          
        const response=await axiosInstance.get(`/positionCandidate/viewApplicants/${jobId}`,
              {
                headers: {
                  Authorization: `Bearer ${token}`,
                },
              }
        )
        console.log(response.data)
        setApplicants(response.data)
      }
      fetchAllApplicants();
    }, [token])
    
  return (
    <div>ViewApplicants
          <ul>
                {applicants.map((applicant) => (
                    <Applicant key={applicant.Email} applicant={applicant}/>
                ))}
            </ul>
    </div>
  )
}

export default ViewApplicants