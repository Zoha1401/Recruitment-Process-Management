/* eslint-disable react/prop-types */
import { Link } from "react-router-dom"


const Applicant = ({applicant}) => {
  return (
    <div>{applicant.FirstName}
     <Link to={`/scheduleInterview/${applicant.PositionCandidateId}`}>Schedule Interview</Link>
    </div>
   
   
  )
}

export default Applicant