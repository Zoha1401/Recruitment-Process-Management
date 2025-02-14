/* eslint-disable react/prop-types */
import { Button, IconButton } from "@mui/material";
import { Link } from "react-router-dom";
import { Delete} from "@mui/icons-material"; 

const Job = ({ job }) => {
  return (
    <div className="bg-white shadow-md rounded-lg m-4 p-6">
      <div className="mb-4">
        <h3 className="text-xl font-semibold text-gray-800">{job.Name}</h3>
        <p className="text-gray-600 text-sm">Minimum Experience: {job.MinExp} years</p> 
      </div>

      <div className="mb-6">
        <p className="text-gray-700">{job.Description}</p>
      </div>

      <div className="flex justify-start items-center space-x-4">
      
        <Button
          className="px-4 py-2 bg-info text-white hover:bg-info-dark transition duration-200"
          variant="contained"
        >
          <Link to={`/assignReviewer/${job.PositionId}`} className="flex items-center">
           Assign Reviewer
          </Link>
        </Button>
        <Button
          className="px-4 py-2 bg-info text-white hover:bg-info-dark transition duration-200"
          variant="contained"
        >
          <Link to={`/viewApplicants/${job.PositionId}`} className="flex items-center">
          View Applicants
          </Link>
        </Button>

        <Button
          className="px-4 py-2 bg-success text-white hover:bg-success-dark transition duration-200"
          variant="contained"
        >
          <Link to={`/updateJob/${job.PositionId}`} className="flex items-center">
           Update
          </Link>
        </Button>

        <IconButton
          className="p-2 text-red-600 hover:text-red-800 transition duration-200"
          color="error"
        >
          <Delete />
        </IconButton>

        <Button
          className="px-4 py-2 bg-info text-white hover:bg-info-dark transition duration-200"
          variant="contained"
        >
          <Link to={`/defineInterviewRounds/${job.PositionId}`} className="flex items-center">
            Define Rounds
          </Link>
        </Button>
      </div>
    </div>
  );
};

export default Job;
