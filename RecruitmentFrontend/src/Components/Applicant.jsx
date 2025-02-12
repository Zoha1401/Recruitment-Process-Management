/* eslint-disable react/prop-types */
import { Button } from "@mui/material"
import { Link } from "react-router-dom"
import { useAuth } from "../Context/AuthProvider"


const Applicant = ({applicant}) => {
  const auth=useAuth()
  const user=auth.user
  console.log(user)
  return (
    <div>{applicant.FirstName}
     <Button variant="contained" color="error" disabled={applicant.IsShortlisted || user.Role==='Reviewer'}><Link to={`/scheduleInterview/${applicant.PositionCandidateId}`}>Schedule Interview</Link></Button>
     <Button variant="contained" color="success"><Link to={`/reviewCandidate/${applicant.PositionCandidateId}`}>Review</Link></Button>
    </div>
   
   
  )
}

export default Applicant