
import { useState } from 'react'
import axiosInstance from '../../axios/axiosInstance';
import { useNavigate } from 'react-router-dom';
import { Button } from '@mui/material';

const AddCandidate = () => {
  const [candidate, setCandidate] = useState({ CollegeName: "", Degree: "", WorkExperience: "", FirstName: "", LastName: "", Email: "", Phone: "" })
  const [resumeUrl, setResumeUrl]=useState("")
  const [resumeFile, setResumeFile]=useState(null)
  const onChange = (e) => {
    setCandidate({ ...candidate, [e.target.name]: e.target.value });
  }

  const navigate = useNavigate();

 // const token = localStorage.getItem("token")

  const handleAddCandidate = async (e) => {
    e.preventDefault();
    try {
      const response = await axiosInstance.post(
        `/candidate`,
        {
          ...candidate,
          ResumeUrl:resumeUrl
        },
        {
          credentials: 'include',
          withCredentials: true
        }
      );
      console.log(response.data)
      if (response.status == 201) {
        alert("Candidate was successfully created")
        navigate(`/viewCandidates`)
      }

    } catch (error) {
      console.error("Error saving job", error.message);
    }
  }

  const handleBulkUpload = async () => {

  }

  const handleFileChange=(e)=>{
    setResumeFile(e.target.files[0]);
  }
  const handleUpload=async()=>{
    if (!resumeFile) {
      alert("Please select a resume first");
      return;
    }
    


    try {
      const response = await axiosInstance.post(
        `/candidate/uploadResume`,
        {FormFile:resumeFile},
        {
          headers: {
            "Content-Type": "multipart/form-data, application/json",
           
          },
          credentials: 'include',
          withCredentials: true
        }
      );
      console.log(response.data);
      setResumeUrl(response.data)
      alert("Resume uploaded")
    } catch (error) {
      alert("Error uploading file: " + error.response?.data || error.message);
      console.log(error)
    }
  }


  return (
    <div className="flex min-h-full flex-1 flex-col justify-center px-6 py-10 lg:px-8">
      <h2 className="mt-1 text-center text-2xl/9 font-bold tracking-tight text-gray-900">
        Add Candidate
      </h2>
      <button onClick={handleBulkUpload}>Bulk Upload</button>

      <div className="mt-6 sm:mx-auto sm:w-full sm:max-w-sm bg-gray-100 px-4 rounded-lg py-2 shadow-xl">
        <form onSubmit={handleAddCandidate} className="mt-4 mb-10 space-y-5">
          <div>
            <label htmlFor="firstName" className="block font-medium">
              First Name
            </label>
            <input
              id="firstName"
              name="FirstName"
              required
              value={candidate.FirstName}
              onChange={onChange}
              className="block w-full rounded-md border px-3 py-2"
            />
            <label htmlFor="lastName" className="block font-medium">
              Last Name
            </label>
            <input
              id="lastName"
              name="LastName"
              required
              value={candidate.LastName}
              onChange={onChange}
              className="block w-full rounded-md border px-3 py-2"
            />
            <label htmlFor="maxExp" className="block font-medium">
              College Name
            </label>
            <input
              id="collegeName"
              name="CollegeName"
              required
              value={candidate.CollegeName}
              onChange={onChange}
              className="block w-full rounded-md border px-3 py-2"
            />
            <label htmlFor="workExperience" className="block font-medium">
              Work Experience
            </label>
            <input
              id="workExperience"
              name="WorkExperience"
              required
              value={candidate.WorkExperience}
              onChange={onChange}
              className="block w-full rounded-md border px-3 py-2"
            />
            <label htmlFor="email" className="block font-medium">
              Email
            </label>
            <input
              id="email"
              name="Email"
              required
              value={candidate.Email}
              onChange={onChange}
              className="block w-full rounded-md border px-3 py-2"
            />
            <label htmlFor="phone" className="block font-medium">
              Phone
            </label>
            <input
              id="phone"
              name="Phone"
              required
              value={candidate.Phone}
              onChange={onChange}
              className="block w-full rounded-md border px-3 py-2"
            />
            <label htmlFor="degree" className="block font-medium">
              Degree
            </label>
            <input
              id="degree"
              name="Degree"
              required
              value={candidate.Degree}
              onChange={onChange}
              className="block w-full rounded-md border px-3 py-2"
            />
            <input type="file" name="FormFile" onChange={handleFileChange} className="mt-2" />
            <Button
              variant="contained"
              onClick={handleUpload}
              className="mb-2 mt-2 px-4"
            >
              Upload Candidate Resume
            </Button>
          </div>
          <button
            type="submit"
            className="w-full bg-indigo-600 text-white py-2 rounded-md"
          >
            Add candidate
          </button>
        </form>
      </div>
    </div>
  )
}

export default AddCandidate