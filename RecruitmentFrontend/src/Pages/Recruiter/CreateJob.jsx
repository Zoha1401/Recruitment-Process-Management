import { useState } from 'react'
import { useAuth } from '../../Context/AuthProvider';
import { useNavigate } from 'react-router-dom';
import axiosInstance from '../../axios/axiosInstance';

//After creation redirect to a page where you can add skills required for this position and save, backend api for save skills for this job
const CreateJob = () => {
    const [position, setPosition]=useState({Name:"", MinExp:0, MaxExp:0, PositionStatusTypeId:0 , NoOfInterviews:"", Description:""})
    const navigate=useNavigate();
    
    const auth=useAuth();
    if(!auth.isLoggedIn){
        navigate("/login")
    }
    const token=localStorage.getItem("token")

    const handleAddJob=async(e)=>{
      e.preventDefault();
        try {
            const response = await axiosInstance.post(
              `/position`,
              {
                ...position
              },
              {
                headers: {
                  Authorization: `Bearer ${token}`,
                },
              }
            );
            console.log(response.data)
            if(response.status==201){
                alert("Job was successfully created")
                navigate(`/recruiterDashboard`)
            }
           
          } catch (error) {
            console.error("Error saving job", error.message);
          }
        };
    


    const onChange=(e)=>{
        setPosition({ ...position, [e.target.name]: e.target.value });
    }

   

  return (

    <div className="flex min-h-full flex-1 flex-col justify-center px-6 py-10 lg:px-8">
        <h2 className="mt-1 text-center text-2xl/9 font-bold tracking-tight text-gray-900">
          Add Position
        </h2>

        <div className="mt-6 sm:mx-auto sm:w-full sm:max-w-sm bg-gray-100 px-4 rounded-lg py-2 shadow-xl">
          <form onSubmit={handleAddJob} className="mt-4 mb-10 space-y-5">
            <div>
              <label htmlFor="name" className="block font-medium">
                Job Position Name
              </label>
              <input
                id="name"
                name="Name"
                required
                value={position.Name}
                onChange={onChange}
                className="block w-full rounded-md border px-3 py-2"
              />
               <label htmlFor="minExp" className="block font-medium">
                Min Experience
              </label>
               <input
                id="minExp"
                name="MinExp"
                required
                value={position.MinExp}
                onChange={onChange}
                className="block w-full rounded-md border px-3 py-2"
              />
               <label htmlFor="maxExp" className="block font-medium">
                Max Experience
              </label>
               <input
                id="maxExp"
                name="MaxExp"
                required
                value={position.MaxExp}
                onChange={onChange}
                className="block w-full rounded-md border px-3 py-2"
              />
               <label htmlFor="noOfInterviews" className="block font-medium">
                NoOfInterviews
              </label>
               <input
                id="noOfInterviews"
                name="NoOfInterviews"
                required
                value={position.NoOfInterviews}
                onChange={onChange}
                className="block w-full rounded-md border px-3 py-2"
              />
               <label htmlFor="description" className="block font-medium">
                Description
              </label>
               <input
                id="description"
                name="Description"
                required
                value={position.Description}
                onChange={onChange}
                className="block w-full rounded-md border px-3 py-2"
              />
            </div>


            <button
              type="submit"
              className="w-full bg-indigo-600 text-white py-2 rounded-md"
            >
              Create Job
            </button>
          </form>
        </div>
      </div>
  )
}

export default CreateJob