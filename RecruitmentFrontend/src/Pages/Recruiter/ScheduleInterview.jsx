import { useState, useEffect } from "react";
import axiosInstance from "../../axios/axiosInstance";
import { useAuth } from "../../Context/AuthProvider";
import { useParams } from "react-router-dom"; // Import useParams to get the candidate ID from URL

const ScheduleInterview = () => {
  const [interview, setInterview] = useState({
    Date: "",
    PositionCandidateId: "",
    InterviewTypeId: "",
    RoundNumber: "",
  });

  const [interviewTypes, setInterviewTypes] = useState([]);
  console.log(interview)
  const auth = useAuth();
  const recruiterId = auth.user.UserId;
  const token = localStorage.getItem("token");

  const { applicantId } = useParams();
  console.log(applicantId)

  useEffect(() => {
    const fetchInterviewTypes = async () => {
      try {
        const response = await axiosInstance.get("/interviewType/getAllInterviewTypes", {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        });
        setInterviewTypes(response.data);
        console.log(response.data)
      } catch (error) {
        console.error("Error fetching interview types", error.message);
      }
    };

    fetchInterviewTypes();
  }, [token]);

  // Handle form input change
  const handleChange = (e) => {
    const { name, value } = e.target;
    setInterview((prevInterview) => ({
      ...prevInterview,
      [name]: value,
    }));
  };
  

  // Handle form submit
  const handleOnSubmit = async (e) => {
    e.preventDefault(); // Prevent default form submission
    const date = new Date(interview.Date);
    const formattedDate = new Date(date.getTime() - date.getTimezoneOffset() * 60000).toISOString();
    const interviewRequest = {
      ...interview,
      Date: formattedDate,
      RecruiterId: recruiterId,
      PositionCandidateId: applicantId,
    };

    try {
      const response = await axiosInstance.post(
        `/interview/`,
        interviewRequest,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );
      console.log(response.data);
      if (response.status === 201) {
        alert("Interview successfully scheduled");
      }
    } catch (error) {
      console.error("Error saving interview", error, error.message);
    }
  };

  return (
    <div className="flex min-h-full flex-1 flex-col justify-center px-6 py-10 lg:px-8">
      <h2 className="mt-1 text-center text-2xl/9 font-bold tracking-tight text-gray-900">
        Schedule Interview
      </h2>

      <div className="mt-6 sm:mx-auto sm:w-full sm:max-w-sm bg-gray-100 px-4 rounded-lg py-2 shadow-xl">
        <form onSubmit={handleOnSubmit} className="mt-4 mb-10 space-y-5">
          <div>
            <label htmlFor="interviewType" className="block font-medium">
              Interview Type
            </label>
            <select
              id="interviewType"
              name="InterviewTypeId"
              value={interview.InterviewTypeId}
              onChange={handleChange}
              className="block w-full rounded-md border px-3 py-2"
              required
            >
              <option value="">Select Interview Type</option>
              {interviewTypes.map((type) => (
                <option key={type.InterviewTypeId} value={type.InterviewTypeId}>
                  {type.Type}
                </option>
              ))}
            </select>
          </div>

          <div>
            <label htmlFor="Date" className="block font-medium">
              Interview Date
            </label>
            <input
              type="datetime-local"
              id="Date"
              name="Date"
              value={interview.Date}
              onChange={handleChange}
              className="block w-full rounded-md border px-3 py-2"
              required
            />
          </div>

          <div>
            <label htmlFor="RoundNumber" className="block font-medium">
              Round Number
            </label>
            <input
              id="RoundNumber"
              name="RoundNumber"
              type="number"
              value={interview.RoundNumber}
              onChange={handleChange}
              className="block w-full rounded-md border px-3 py-2"
              required
            />
          </div>

          <button
            type="submit"
            className="w-full bg-indigo-600 text-white py-2 rounded-md"
          >
            Schedule Interview
          </button>
        </form>
      </div>
    </div>
  );
};

export default ScheduleInterview;
