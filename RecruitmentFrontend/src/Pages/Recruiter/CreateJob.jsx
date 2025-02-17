import { useEffect, useState } from 'react';
import { useAuth } from '../../Context/AuthProvider';
import { useNavigate } from 'react-router-dom';
import axiosInstance from '../../axios/axiosInstance';
import SidebarNav from '../../Components/Sidebar/SidebarNav';

const CreateJob = () => {
  const [position, setPosition] = useState({
    Name: "",
    MinExp: 0,
    MaxExp: 0,
    PositionStatusTypeId: 0,
    NoOfInterviews: "",
    Description: "",
    SkillRequests: [] // This will contain an array of skill objects with SkillId, IsRequired, and the description
  });

  const navigate = useNavigate();
  const [skills, setSkills] = useState([]);
  //const token = localStorage.getItem("token");

  useEffect(() => {
    const GetSkills = async () => {
      const skillResponse = await axiosInstance.get(`/skill`, {
        credentials: 'include',
        withCredentials: true
      });

      setSkills(skillResponse.data);
    };
    GetSkills();
  }, []);

  // const auth = useAuth();
  // if (!auth.isLoggedIn) {
  //   navigate("/login");
  // }

  const handleAddJob = async (e) => {
    e.preventDefault();
    try {
      const response = await axiosInstance.post(
        `/position`,
        position,
        {
          credentials: 'include',
          withCredentials: true
        }
      );
      console.log(response.data);
      alert("Job was successfully created");
      navigate(`/recruiterDashboard`);
    } catch (error) {
      console.error("Error saving job", error.message);
    }
  };

  const onChange = (e) => {
    setPosition({ ...position, [e.target.name]: e.target.value });
  };

  const handleCheckboxChange = (event, skillId) => {
    const updatedSkillRequests = [...position.SkillRequests];
  
    updatedSkillRequests.push({ SkillId: skillId, Required: '' });


    setPosition({ ...position, SkillRequests: updatedSkillRequests });
  };

  const handleDescriptionChange = (e, skillId) => {
    const updatedSkillRequests = [...position.SkillRequests];
    const skillIndex = updatedSkillRequests.findIndex(skill => skill.SkillId === skillId);

    if (skillIndex !== -1) {
      updatedSkillRequests[skillIndex].Required = e.target.value;
    }

    setPosition({ ...position, SkillRequests: updatedSkillRequests });
  };

  console.log(position.SkillRequests);

  return (
    <div className='flex flex-row'>
      <div><SidebarNav/></div>
    <div className="flex-1 flex-col justify-center px-6 py-10 lg:px-8 w-screen">
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
          <div>
            {skills.map((skill) => (
              <div key={skill.SkillId} className="flex items-center space-x-2 mb-2">
            
                <input
                  type="checkbox"
                  checked={position.SkillRequests.some(s => s.SkillId === skill.SkillId)}
                  onChange={(e) => handleCheckboxChange(e, skill.SkillId)} // True for Required
                />
                <span>{skill.Name}</span>
                
              
                <input
                  type="text"
                  placeholder="Required/Preferred"
                  value={position.SkillRequests.find(s => s.SkillId === skill.SkillId)?.Required || ''}
                  onChange={(e) => handleDescriptionChange(e, skill.SkillId)}
                  className="ml-2 border px-2 py-1 rounded-md"
                />
              </div>
            ))}
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
    </div>
  );
};

export default CreateJob;
