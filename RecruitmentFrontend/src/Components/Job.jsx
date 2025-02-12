/* eslint-disable react/prop-types */
import { Button } from "@mui/material"
import { Link } from "react-router-dom"

// eslint-disable-next-line react/prop-types
const Job = ({job}) => {

  return (
    <div className='flex d-flex bg-gray-100 rounded-sm m-2 p-4 '>
      <div>
     <div className="m-2">{job.Name}</div>
     <div className="m-2">{job.MinExp}</div>
     <div className="m-2">{job.Description}</div>
     <div className="flex">
     <Button className="m-2 p-2 mx-2" variant='contained' color='info'><Link to={`/assignReviewer/${job.PositionId}`}>Assign Reviewer</Link></Button>
     <Button className="m-2 p-2" variant='contained' color='info'><Link to={`/viewApplicants/${job.PositionId}`}>View Applicants</Link></Button>
     <Button className="m-2 p-2 mx-2" variant='contained' color='success'>Update</Button>
     <Button className="m-2 p-2" variant='contained' color='error'>Delete</Button>
     <Button className="m-2 p-2 mx-2" variant='contained' color='info'><Link to={`/defineInterviewRounds/${job.PositionId}`}>Define Rounds</Link></Button>
     </div>
     </div>
    </div>
  )
}

export default Job