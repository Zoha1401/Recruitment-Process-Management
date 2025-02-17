import { Button } from "@mui/material"
import { useContext, useEffect, useState } from "react"
import { useNavigate, useParams } from "react-router-dom";
import axiosInstance from "../../axios/axiosInstance";
import { DataContext } from "../../Context/Common";
import { useAuth } from "../../Context/AuthProvider";


const DefineInterviewRounds = () => {
    const [interviewRounds, setInterviewRounds] = useState([{TypeId:0, NoOfInterviews:0}])
    // const [interviewTypes, setInterviewTypes] = useState([]);
    const { jobId } = useParams();
    const {interviewTypes, fetchInterviewTypes}=useContext(DataContext)
    const {isAuthenticated}=useAuth()
    const navigate=useNavigate();
    //const token = localStorage.getItem("token")
    //Print if already defined

    useEffect(() => {
        if(!isAuthenticated){
           navigate("/login")
        }
        else{
      fetchInterviewTypes();
        }
    }, [])
    
    const handleDefineInterviewRounds = async (e) => {
        e.preventDefault()

        try {
            const response = await axiosInstance.post(`/position/defineInterviewRounds/${jobId}`, 
            interviewRounds,
            {
              headers: {
               
                "Content-Type":"application/json"
              },
              credentials: 'include',
              withCredentials: true
            });
            alert("Interview rounds were defined")
            navigate("/recruiterDashboard")
            console.log("Interview rounds updated successfully", response.data);
          } catch (error) {
            console.error("Interview rounds updated error", error.message);
          }

    }

    console.log(interviewRounds)
    // useEffect(() => {
    //     const fetchInterviewTypes = async () => {
    //         try {
    //             const response = await axiosInstance.get("/interviewType/getAllInterviewTypes", {
    //                 credentials: 'include',
    //                 withCredentials: true
    //             });
    //             setInterviewTypes(response.data);
    //             console.log(response.data)
    //         } catch (error) {
    //             console.error("Error fetching interview types", error.message);
    //         }
    //     };

    //     fetchInterviewTypes();
    // }, []);
    const handleAddInterviewRound = () => {
        setInterviewRounds([...interviewRounds, { TypeId: "", NoOfInterviews: "" }]);
    };

    const onChange = (index, e) => {
        const updatedRounds = [...interviewRounds];
        updatedRounds[index][e.target.name] = parseInt(e.target.value);
        setInterviewRounds(updatedRounds);
    };

    const handleRemoveRound = (index) => {
        const updatedInterviewRounds = interviewRounds.filter((_, i) => i !== index);
        setInterviewRounds(updatedInterviewRounds);
    };
    return (
        <div className="flex flex-col items-center align-items justify-center">
            <div className="font-bold text-xl m-4">DefineInterviewRounds</div>
            <div>
                <h4>Please specify the rounds</h4>
                {interviewRounds.map((interviewRound, index) => (
                    <div key={index} className="flex items-center space-x-2 mb-2">
                        <label htmlFor="interviewType" className="block font-medium">
                            Interview Type
                        </label>
                        <select
                            id="interviewType"
                            name="TypeId"
                            value={interviewRound.TypeId}
                            onChange={(e)=>onChange(index, e)}
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
                        <label htmlFor="interviewType" className="block font-medium">
                            Number of Interviews
                        </label>
                        <input
                            id="noOfInterviews"
                            name="NoOfInterviews"
                            type='number'
                            value={interviewRound.NoOfInterviews}
                            onChange={(e)=>onChange(index, e)}
                            className="block w-full rounded-md border px-3 py-2"
                            required
                        ></input>
                        <Button
                            variant="contained"
                            color="error"
                            className="p-2 mx-2"
                            onClick={() => handleRemoveRound(index)}
                        >
                            Remove
                        </Button>
                    </div>
                ))}
                <Button variant="contained" color="secondary" onClick={handleAddInterviewRound}>
                    Add Interview Round
                </Button>
            </div>
            <Button variant="contained" onClick={handleDefineInterviewRounds}>Save Interview Rounds</Button>

        </div>

    )
}

export default DefineInterviewRounds