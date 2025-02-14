import { useEffect, useState } from "react";
import axiosInstance from "../../axios/axiosInstance";
import { Link, useNavigate } from "react-router-dom";
import { useAuth } from "../../Context/AuthProvider";
import CandidateJob from "../../Components/CandidateJob";

const CandidateDashboard = () => {
    const [jobs, setJobs] = useState([])
    const [applications, setApplications]=useState([])
    const [shortlisted, setShortlisted]=useState([])
    const [candidate, setCandidate]=useState({})
    const auth = useAuth();
    const userId = auth.user.UserId;
  
    console.log(auth.user)
    const navigate = useNavigate();
    if (!auth.isLoggedIn) {
      navigate("/login")
    }
    const token = localStorage.getItem("token")
    console.log(token)
    useEffect(() => {
      const fetchJobs = async () => {
  
        const response = await axiosInstance.get('/position',
            {}, 
      {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      }
        )
        console.log(response.data);
        setJobs(response.data)
  
      }
      fetchJobs();

      const getCandidate = async () => {
  
        const response = await axiosInstance.get(`/candidate/getCandidate/${userId}`,
          {
            headers: {
              Authorization: `Bearer ${token}`,
            },
          }
        )
        console.log(response.data);
        setCandidate(response.data)
  
      }
      getCandidate();

    }, [token, userId])

    useEffect(() => {
        if(candidate.CandidateId){
        const getApplications = async () => {
            const response = await axiosInstance.get(`/positionCandidate/ViewApplications/${candidate.CandidateId}`, {
                headers: {
                  Authorization: `Bearer ${token}`,
                },
              });
              setApplications(response.data);
            };
    
        getApplications();
            const ifShortlisted = async () => {
                const response = await axiosInstance.get(`/shortlistCandidate/isShortlisted/${candidate.CandidateId}`, {
                    headers: {
                      Authorization: `Bearer ${token}`,
                    },
                  });
                  setShortlisted(response.data); 
                  console.log(response.data)
                };
        
                ifShortlisted();
        }
    }, [candidate.CandidateId, token])
    

console.log(candidate)
  return (
    <div><div className="flex font-bold items-center align-items justify-content">View Job Openings</div>
         <div className="m-2">
          {jobs.map((job) => (
            <div key={job.PositionId}><CandidateJob key={job.PositionId} job={job} candidate={candidate} isApplied={applications.some(application => application.PositionId === job.PositionId)}  /></div>
          ))}
        </div>
        <Link to={`/viewApplications/${candidate.CandidateId}`}>View Applications</Link>
        <Link to={`/uploadDocuments/${candidate.CandidateId}`} disabled={!shortlisted}>Upload Documents</Link>
    </div>
  )
}

export default CandidateDashboard


// isApplied={applications.some(application => application.PositionId === job.PositionId)} 
 