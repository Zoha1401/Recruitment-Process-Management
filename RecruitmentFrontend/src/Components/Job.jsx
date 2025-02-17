/* eslint-disable react/prop-types */
import { Button, IconButton } from "@mui/material";
import { Link } from "react-router-dom";
import { Delete} from "@mui/icons-material"; 
import { useContext, useEffect } from "react";
import { DataContext } from "../Context/Common";

const Job = ({ job }) => {
  const {fetchJobStatusById, jobStatus}=useContext(DataContext)
  console.log("Job Status", jobStatus)
  console.log("JobstatusId", job.PositionStatusTypeId)
  console.log("Job", job)
//   useEffect(() => {
//   fetchJobStatusById(job.PositionStatusTypeId);
    
// }, [job.PositionStatusTypeId] )
  return (
    <div className="bg-white shadow-md rounded-lg m-4 p-6">
      <div className="mb-4">
        <h3 className="text-xl font-semibold text-gray-800">{job.Name}</h3>
        <p className="text-gray-600 text-sm">Minimum Experience: {job.MinExp} years</p> 
        <h3 className="text-gray-600 text-sm">Status: {jobStatus.StatusName}</h3> 
      </div>

      <div className="mb-6">
        <p className="text-gray-700">{job.Description}</p>
      </div>

      <div className="flex justify-start items-center space-x-4">

<div className="p-2">
        <Button
          className="px-4 py-2bg-info text-white hover:bg-info-dark transition duration-200"
          variant="contained"
        > 
          <Link to={`/assignReviewer/${job.PositionId}`} className="flex items-center">
           Assign Reviewer
          </Link>
        </Button>
        </div>
        <div className="p-2">
        <Button
          className="px-4 py-2 bg-info text-white hover:bg-info-dark transition duration-200"
          variant="contained"
        >
          <Link to={`/viewApplicants/${job.PositionId}`} className="flex items-center">
          View Applicants
          </Link>
        </Button>
        </div>
       
        <div className="p-2">
        <Button
          className="px-4 py-2 bg-success text-white hover:bg-success-dark transition duration-200"
          variant="contained"
        >
          <Link to={`/updateJob/${job.PositionId}`} className="flex items-center">
           Update
          </Link>
        </Button>
        </div>

      
        <div className="p-2">

        <Button
          className="px-4 py-2 bg-info text-white hover:bg-info-dark transition duration-200"
          variant="contained"
        >
          <Link to={`/defineInterviewRounds/${job.PositionId}`} className="flex items-center">
            Define Rounds
          </Link>
        </Button>
        </div>
        {/* <div className="p-2">
        <IconButton
          className="p-2 text-red-600 hover:text-red-800 transition duration-200"
          color="error"
        >
          <Delete />
        </IconButton>
        </div> */}
      </div>
    </div>
  );
};

export default Job;
