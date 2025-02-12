/* eslint-disable react/prop-types */
import { Link } from "react-router-dom"

// eslint-disable-next-line react/prop-types
const Job = ({job}) => {
  return (
    <div className='flex d-flex bg-gray-100 rounded-sm '>
     {job.Name}
     {job.MinExp}
     <Link to={`/assignReviewer/${job.PositionId}`}>Assign Reviewer</Link>
     <Link to={`/viewApplicants/${job.PositionId}`}>View Applicants</Link>
    </div>
  )
}

export default Job