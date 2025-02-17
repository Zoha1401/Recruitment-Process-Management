import { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom';
import { useAuth } from '../../Context/AuthProvider';
import axiosInstance from '../../axios/axiosInstance';
import Applicant from '../../Components/Applicant';
import SidebarNav from '../../Components/Sidebar/SidebarNav';

const ViewApplicants = () => {
    const [applicants, setApplicants]=useState([])
    const navigate=useNavigate();
    const auth=useAuth();
    // if(!auth.isLoggedIn){
    //     navigate("/login")
    // }
    const {jobId}=useParams();
   // const token=localStorage.getItem("token")

    useEffect(() => {
      const fetchAllApplicants=async ()=>{
          
        const response=await axiosInstance.get(`/positionCandidate/viewApplicants/${jobId}`,
              {
                credentials: 'include',
                withCredentials: true
              }
        )
        console.log(response.data)
        setApplicants(response.data)
      }
      fetchAllApplicants();
    }, [])
    console.log(jobId)
  return (
    <div className="flex flex-row">
      <div><SidebarNav/></div>
      {applicants.length>0 ? (
          <div className='flex flex-col justify-content align-items items-center w-screen'>
          <div className="flex mt-4 font-bold justify-content align-items items-center">
           View Applicants </div>
          <div className="m-2 max-w-full min-h-screen">
                    {applicants.map((applicant) => (
                        <Applicant key={applicant.Email} applicant={applicant} jobId={jobId}/>
                    ))}
              </div>
        </div>
      ):(
        <div className='flex font-bold justify-conten align-items items-center'>No Applicants found</div>
      )

      }
    
    </div>
  
  
  )
}

export default ViewApplicants