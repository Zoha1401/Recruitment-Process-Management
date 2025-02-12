import { Button } from "@mui/material"
import { useEffect, useState } from "react"
import { useParams } from "react-router-dom";
import axiosInstance from "../../axios/axiosInstance";


const DefineInterviewRounds = () => {
    const [interviewRounds, setInterviewRounds] = useState([])
    const [interviewTypes, setInterviewTypes] = useState([]);
    const { jobId } = useParams();
    const token = localStorage.getItem("token")
    const handleDefineInterviewRounds = async () => {

    }

    console.log(interviewRounds)
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
    const handleAddInterviewRound = () => {
        setInterviewRounds([...interviewRounds, { TypeId: "", NoOfInterviews: "" }]);
    };

    const onChange = (index, e) => {
        const updatedRounds = [...interviewRounds];
        updatedRounds[index][e.target.name] = e.target.value;
        setInterviewRounds(updatedRounds);
    };

    const handleRemoveRound = (index) => {
        const updatedInterviewRounds = interviewRounds.filter((_, i) => i !== index);
        setInterviewRounds(updatedInterviewRounds);
    };
    return (
        <div>DefineInterviewRounds
            <div>
                <h4>Rounds</h4>
                {interviewRounds.map((interviewRound, index) => (
                    <div key={index} className="flex items-center space-x-2 mb-2">
                        <label htmlFor="interviewType" className="block font-medium">
                            Interview Type
                        </label>
                        <select
                            id="interviewType"
                            name="InterviewTypeId"
                            value={interviewRound.InterviewTypeId}
                            onChange={onChange}
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
                            Number of Rounds
                        </label>
                        <input
                            id="noOfRounds"
                            name="NoOfRounds"
                            type='number'
                            value={interviewRound.NoOfRounds}
                            onChange={onChange}
                            className="block w-full rounded-md border px-3 py-2"
                            required
                        ></input>
                        <Button
                            variant="danger"
                            onClick={() => handleRemoveRound(index)}
                        >
                            Remove
                        </Button>
                    </div>
                ))}
                <Button variant="secondary" onClick={handleAddInterviewRound}>
                    Add Interview Round
                </Button>
            </div>

        </div>

    )
}

export default DefineInterviewRounds