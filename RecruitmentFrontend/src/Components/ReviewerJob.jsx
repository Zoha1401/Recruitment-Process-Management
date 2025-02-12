/* eslint-disable react/prop-types */
import { Button } from "@mui/material"
import { Link } from "react-router-dom"

// eslint-disable-next-line react/prop-types
const ReviewerJob = ({job}) => {

  return (
    <div className='flex d-flex bg-gray-100 rounded-sm m-2 p-4 '>
      <div>
     <div className="m-2">{job.Name}</div>
     <div className="m-2">{job.MinExp}</div>
     <div className="m-2">{job.Description}</div>
     <div className="flex">
     <Button className="m-2 p-2 mx-2" variant='contained' color='info'><Link to={`/viewApplicants/${job.PositionId}`}>View Applicants</Link></Button>
     </div>
     </div>
    </div>
  )
}

export default ReviewerJob