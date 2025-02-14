import { useEffect, useState } from "react";
import axiosInstance from "../axios/axiosInstance";
import { Button } from "@mui/material";
import { useNavigate } from "react-router-dom";

const Register = () => {
  const [user, setUser]=useState({FirstName:"", LastName:"", WorkExperience:"", RoleId:"", Email:"", Password:"", BirthDate:"", Phone:"", CollegeName:"", Degree:"", ResumeUrl:""})
  const [roles, setRoles]=useState([])
  const [resumeFile, setResumeFile]=useState(null)
  const [resumeUrl, setResumeUrl]=useState("")
  const [isCandidate, setIsCandidate]=useState(false);
  const navigate=useNavigate();
  const handleRegisterUser=async(e)=>{
    e.PreventDefault();
    try {
      const response = await axiosInstance.post(
        `/auth/register`,
        {
          ...user,
          ResumeUrl:resumeUrl
        },
      );
      console.log(response.data)
      if (response.status == 201) {
        alert("Candidate was successfully created")
        navigate(`/login`)
      }

    } catch (error) {
      console.error("Error saving job", error.message);
    }
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



  useEffect(() => {
    const getRoles = async () => {
    
      const response = await axiosInstance.get(`/role`,)
      console.log(response.data);
      setRoles(response.data)

    }
    getRoles();
  }, [])
  console.log(user)
  
  const onChange = (e) => {
    setUser({ ...user, [e.target.name]: e.target.value });
    console.log(e.target.name, e.target.value)
    
    const selectedRole = roles.find((role) => String(role.RoleId) === e.target.value);
    console.log(typeof(e.target.value))
    console.log(selectedRole)
    setIsCandidate(selectedRole?.RoleName === "Candidate");
     
  };
  console.log(isCandidate)

  console.log(roles)

  return (
    <div className="flex min-h-full flex-1 flex-col justify-center px-6 py-10 lg:px-8">
    <h2 className="mt-1 text-center text-2xl/9 font-bold tracking-tight text-gray-900">
      Register
    </h2>

    <div className="mt-6 sm:mx-auto sm:w-full sm:max-w-sm bg-gray-100 px-4 rounded-lg py-2 shadow-xl">
      <form onSubmit={handleRegisterUser} className="mt-4 mb-10 space-y-5">
        <div>
          <label htmlFor="name" className="block font-medium">
            First Name
          </label>
          <input
            id="name"
            name="FirstName"
            required
            value={user.FirstName}
            onChange={onChange}
            className="block w-full rounded-md border px-3 py-2"
          />
          <label htmlFor="name" className="block font-medium">
            Last Name
          </label>
          <input
            id="name"
            name="LastName"
            required
            value={user.LastName}
            onChange={onChange}
            className="block w-full rounded-md border px-3 py-2"
          />
           <label htmlFor="name" className="block font-medium">
            Email
          </label>
          <input
            id="name"
            name="Email"
            required
            value={user.Email}
            onChange={onChange}
            className="block w-full rounded-md border px-3 py-2"
          />
          <label htmlFor="maxExp" className="block font-medium">
            Password
          </label>
          <input
            id="password"
            name="Password"
            type="password"
            required
            value={user.Password}
            onChange={onChange}
            className="block w-full rounded-md border px-3 py-2"
          />
          <label htmlFor="phone" className="block font-medium">
            Phone
          </label>
          <input
            id="phone"
            name="Phone"
            type="number"
            value={user.Phone}
            onChange={onChange}
            className="block w-full rounded-md border px-3 py-2"
          />

       <label htmlFor="roleId" className="block font-medium">
              Role
            </label>
            <select
              id="roleId"
              name="RoleId"
              value={user.RoleId}
              onChange={onChange}
              className="block w-full rounded-md border px-3 py-2"
              required
            >
              <option value="">Select Role</option>
              {roles.map((role) => (
                <option key={role.RoleId} value={role.RoleId}>
                  {role.RoleName}
                </option>
              ))}
            </select>

            {isCandidate && (
              <>
                <label htmlFor="CollegeName" className="block font-medium">
                  College Name
                </label>
                <input
                  id="CollegeName"
                  name="CollegeName"
                  value={user.CollegeName}
                  onChange={onChange}
                  className="block w-full rounded-md border px-3 py-2"
                />
                <label htmlFor="Degree" className="block font-medium">
                  Degree
                </label>
                <input
                  id="Degree"
                  name="Degree"
                  value={user.Degree}
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
              </>
            )}
          
        </div>
        <button
          type="submit"
          className="w-full bg-indigo-600 text-white py-2 rounded-md"
        >
          Register
        </button>
      </form>
    </div>
  </div>
  )
}

export default Register