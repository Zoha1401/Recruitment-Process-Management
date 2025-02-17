import { useEffect, useState } from "react";
import axiosInstance from "../../axios/axiosInstance";
import { Link, useNavigate } from "react-router-dom";
import { useAuth } from "../../Context/AuthProvider";
import CandidateJob from "../../Components/CandidateJob";
import { Button } from "@mui/material";
import SidebarNav from "../../Components/Sidebar/SidebarNav";

const CandidateDashboard = () => {
  const [jobs, setJobs] = useState([])
  const [applications, setApplications] = useState([])
  const [shortlisted, setShortlisted] = useState([])
  const [candidate, setCandidate] = useState({})
  const auth = useAuth();
  const userId = auth.user.UserId;

  console.log(auth.user)
  //const navigate = useNavigate();
  useEffect(() => {
    const fetchJobs = async () => {

      const response = await axiosInstance.get('/position',
        {},
        {
          credentials: 'include',
          withCredentials: true
        }
      )
      console.log(response.data);
      setJobs(response.data)

    }
    fetchJobs();

    const getCandidate = async () => {

      const response = await axiosInstance.get(`/candidate/getCandidate/${userId}`,
        {
          credentials: 'include',
          withCredentials: true
        }
      )
      console.log(response.data);
      setCandidate(response.data)

    }
    getCandidate();

  }, [userId])

  useEffect(() => {
    if (candidate.CandidateId) {
      const getApplications = async () => {
        const response = await axiosInstance.get(`/positionCandidate/ViewApplications/${candidate.CandidateId}`, {
          credentials: 'include',
          withCredentials: true
        });
        setApplications(response.data);
      };

      getApplications();
      const ifShortlisted = async () => {
        const response = await axiosInstance.get(`/shortlistCandidate/isShortlisted/${candidate.CandidateId}`, {
          credentials: 'include',
          withCredentials: true
        });
        setShortlisted(response.data);
        console.log(response.data)
      };

      ifShortlisted();
    }
  }, [candidate.CandidateId])


  console.log(candidate)
  return (
    <div className="flex flex-row">
      <div>  <SidebarNav candidate={candidate} shortlisted={shortlisted} /></div>
      <div className="flex flex-col p-2 m-2 max-w-full w-screen h-screen">

        <div className="flex mx-2 font-bold justify-content align-items items-center">Current Job Openings</div>
        <div className="m-2 max-w-full min-h-screen">
          {jobs.map((job) => (
            <div key={job.PositionId}><CandidateJob key={job.PositionId} job={job} candidate={candidate} isApplied={applications.some(application => application.PositionId === job.PositionId)} /></div>
          ))}
        </div>
      </div>



    </div>
  )
}

export default CandidateDashboard


// isApplied={applications.some(application => application.PositionId === job.PositionId)} 
