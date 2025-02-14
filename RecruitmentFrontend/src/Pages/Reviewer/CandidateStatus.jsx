import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import axiosInstance from "../../axios/axiosInstance";
import { useAuth } from "../../Context/AuthProvider";

const CandidateStatus = () => {
  const [candidateStatus, setCandidateStatus] = useState({ StatusId: 0, Comments: "" });
  const [candidateStatusTypes, setCandidateStatusTypes] = useState([]);
  const { candidateId, jobId } = useParams();
  const auth = useAuth();
  const reviewerId = auth.user.UserId;
  const token = localStorage.getItem("token");

  useEffect(() => {
    const fetchCandidateStatusTypes = async () => {
      try {
        const response = await axiosInstance.get("/candidateStatus/getCandidateStatusTypes", {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        });
        setCandidateStatusTypes(response.data);
        console.log(response.data);
      } catch (error) {
        console.error("Error fetching candidate status types", error.message);
      }
    };

    fetchCandidateStatusTypes();

    const fetchCandidateStatus = async () => {
      try {
        const statusResponse = await axiosInstance.get(`/candidateStatus/getCandidateStatusFromIds/${candidateId}/${jobId}`, {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        });
        setCandidateStatus(statusResponse.data);
        console.log(statusResponse.data);
      } catch (error) {
        console.error("Error fetching candidate status", error.message);
      }
    };

    fetchCandidateStatus();
  }, [token, candidateId, jobId]);

  const handleOnSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await axiosInstance.put(`/candidateStatus/${candidateStatus.CandidateStatusId}`, 
       { ...candidateStatus,
        UpdatedBy:reviewerId},
      {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      });
      alert("Candidate status updated succesfully")
      
      console.log("Status updated successfully", response.data);
    } catch (error) {
      console.error("Error updating candidate status", error.message);
    }
  };
console.log(candidateStatus)
  const handleChange = (e) => {
    const { name, value } = e.target;
    setCandidateStatus((prevCandidateStatus) => ({
      ...prevCandidateStatus,
      [name]: value,
    }));
  };

  return (
    <div className="mt-6 sm:mx-auto sm:w-full sm:max-w-sm bg-gray-100 px-4 rounded-lg py-2 shadow-xl">
      <form onSubmit={handleOnSubmit} className="mt-4 mb-10 space-y-5">
        <div>
          <label htmlFor="candidateStatusType" className="block font-medium">
            Candidate Status Type
          </label>
          <select
            id="candidateStatusType"
            name="StatusId"
            value={candidateStatus.StatusId}
            onChange={handleChange}
            className="block w-full rounded-md border px-3 py-2"
            required
          >
            <option value="">Select Status Type</option>
            {candidateStatusTypes.map((type) => (
              <option key={type.CandidateStatusTypeId} value={type.CandidateStatusTypeId}>
                {type.Name}
              </option>
            ))}
          </select>
        </div>

        <div>
          <label htmlFor="Comments" className="block font-medium">
            Comments
          </label>
          <input
            id="Comments"
            name="Comments"
            type="text"
            value={candidateStatus.Comments}
            onChange={handleChange}
            className="block w-full rounded-md border px-3 py-2"
            required
          />
        </div>

        <button type="submit" className="w-full bg-indigo-600 text-white py-2 rounded-md">
          Update Candidate Status
        </button>
      </form>
    </div>
  );
};

export default CandidateStatus;
