import { useContext, useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'
import axiosInstance from '../axios/axiosInstance'
import { DataContext } from '../Context/Common'
import { useAuth } from '../Context/AuthProvider'

const UpdateJob = () => {
    //I have to get job skills and display as set. And then update will work.
    const [job, setJob]=useState({})
    const {fetchPositionStatusTypes, positionStatusTypes} = useContext(DataContext)
    const {isAuthenticated}=useAuth();
    //const token=localStorage.getItem("token")
    const {jobId}=useParams()
    const navigate=useNavigate();
    //const [jobStatusTypes, setJobStatusTypes]=useState([])

    useEffect(() => {
      if(!isAuthenticated){
         navigate("/login")
      }
      else{
    fetchPositionStatusTypes();
      }
  }, [])
    console.log(job)
    const updateJob=async(e)=>{
      e.preventDefault();
        try {
            const response = await axiosInstance.put(
              `/position/${jobId}`,
              {
                ...job
              },
              {
                credentials: 'include',
                withCredentials: true
              }
            );
            console.log(response.data)
            alert("Position was successfully updated")
            navigate(`/recruiterDashboard`)
            
           
          } catch (error) {
            console.error("Error saving job", error.message);
          }
    }
    const onChange=(e)=>{
        setJob({ ...job, [e.target.name]: e.target.value });
    } 
    useEffect(() => {
        const getJob = async () => {
    
          const response = await axiosInstance.get(`/position/${jobId}`,
            {
              credentials: 'include',
                withCredentials: true
            }
          )
          console.log(response.data);
          setJob(response.data)
    
        }
        getJob();

        // const getJobStatusTypes = async () => {
    
        //     const response = await axiosInstance.get(`/position/getPositionStatusTypes`,
        //       {
        //         credentials: 'include',
        //         withCredentials: true
        //       }
        //     )
        //     console.log(response.data);
        //     setJobStatusTypes(response.data)
      
        //   }
        //   getJobStatusTypes();
      }, [ jobId])

      const handleChange = (e) => {
        const { name, value } = e.target;
        setJob((prevJob) => ({
          ...prevJob,
          [name]: value,
        }));
      };
  return (
    <div>UpdateJob
        <div className="mt-6 sm:mx-auto sm:w-full sm:max-w-sm bg-gray-100 px-4 rounded-lg py-2 shadow-xl">
          <form onSubmit={updateJob} className="mt-4 mb-10 space-y-5">
            <div>
              <label htmlFor="name" className="block font-medium">
                Job Name
              </label>
              <input
                id="name"
                name="Name"
                required
                value={job.Name}
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
                value={job.MinExp}
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
                value={job.MaxExp}
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
                value={job.NoOfInterviews}
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
                value={job.Description}
                onChange={onChange}
                className="block w-full rounded-md border px-3 py-2"
              />
              <div>
          <label htmlFor="jobStatusType" className="block font-medium">
            Job Status
          </label>
          <select
            id="jobStatusType"
            name="StatusId"
            value={job.StatusId}
            onChange={handleChange}
            className="block w-full rounded-md border px-3 py-2"
            required
          >
            <option value="">Select Status Type</option>
            {positionStatusTypes.map((type) => (
              <option key={type.PositionStatusTypeId} value={type.PositionStatusTypeId}>
                {type.StatusName}
              </option>
            ))}
          </select>
        </div>


<label htmlFor="reason" className="block font-medium">
                Reason for closure
              </label>
               <input
                id="reason"
                name="ReasonForClosure"
                required
                value={job.ReasonForClosure}
                onChange={onChange}
                className="block w-full rounded-md border px-3 py-2"
              />
            </div>


            <button
              type="submit"
              className="w-full bg-indigo-600 text-white py-2 rounded-md"
            >
              Update Job
            </button>
            </form>
            </div>
    </div>
  )
}

export default UpdateJob