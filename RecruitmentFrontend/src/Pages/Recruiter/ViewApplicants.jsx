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
    console.log(jobId)
  return (
    <div className='flex flex-col items-center align-items justify-center p-2 m-2'><div className='font-bold m-2'>ViewApplicants</div>
          <div className='flex flex-col'>
                {applicants.map((applicant) => (
                    <Applicant key={applicant.Email} applicant={applicant} jobId={jobId}/>
                ))}
          </div>
    </div>
  )
}

export default ViewApplicants