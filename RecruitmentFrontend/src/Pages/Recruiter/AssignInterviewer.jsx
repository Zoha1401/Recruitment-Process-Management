import { useEffect, useState } from "react";
import axiosInstance from "../../axios/axiosInstance";
import { useParams } from "react-router-dom";
import { Button } from "@mui/material";

const AssignInterviewer = () => {
    const [interviewers, setInterviewers] = useState([]);
    //const token = localStorage.getItem("token");
    const { interviewId } = useParams();
    const [selectedInterviewers, setSelectedInterviewers] = useState([]);
    const [checkedState, setCheckedState] = useState({});
    const [assignedInterviewers, setAssignedInterviewers]=useState([])

    useEffect(() => {
        const fetchInterviewers = async () => {
            const response = await axiosInstance.get('/user/getAllInterviewers', {
                credentials: 'include',
                withCredentials: true
            });
            setInterviewers(response.data);
        };
        fetchInterviewers();
    }, []);

    useEffect(() => {
      const fetchAssignedInterviewers = async () => {
          const response = await axiosInstance.get(`/interview/getAssignedInterviewers/${interviewId}`, {
            credentials: 'include',
            withCredentials: true
          });
          setAssignedInterviewers(response.data);
          
      };
      fetchAssignedInterviewers();
  }, [interviewId]);
  console.log(assignedInterviewers)
  useEffect(() => {
    const initialCheckedState = {};
    assignedInterviewers.forEach((interviewer) => {
        initialCheckedState[interviewer.InterviewerId] = true;
    });
    setCheckedState(initialCheckedState);
}, [assignedInterviewers]);


    const handleCheckboxChange = (id) => {
        setCheckedState((prevState) => {
            const updatedState = { ...prevState, [id]: !prevState[id] };

            if (updatedState[id]) {
                setSelectedInterviewers((prev) => {
                    if (!prev.some((interviewer) => interviewer.InterviewerId === id)) {
                        return [...prev, { InterviewerId: id }];
                    }
                    return prev; 
                });
            } else {
                setSelectedInterviewers((prev) =>
                    prev.filter((interviewer) => interviewer.InterviewerId !== id)
                );
            }
            return updatedState;
        });
    };

    const handleAssignInterviewer = async () => {
        try {
            const response = await axiosInstance.post(
                `/interview/assignInterviews/${interviewId}`,
                selectedInterviewers,
                {
                    headers: {
                       
                        'Content-Type': 'application/json',
                    },
                    credentials: 'include',
                    withCredentials: true
                }
            );
            alert("Interviewers are successfully assigned")
            console.log(response.data);
        } catch (error) {
            console.error("Error assigning interviewers", error, error.message);
        }
    };

    console.log(selectedInterviewers); 

    return (
        <>
            <div className="flex flex-col justify-content align-items items-center">
                <h3 className="font-bold mt-4 text-lg">Assign Interviewer</h3>
                <ul>
                    {interviewers.map((interviewer) => (
                        <div key={interviewer.UserId} className="flex flex-row border-1 rounded-sm p-4 m-4">
                            <div className="m-1">{interviewer.FirstName}</div>
                            <div className="m-1">{interviewer.LastName}</div>
                            <div className="m-1"><input
                                type="checkbox"
                                onChange={() => handleCheckboxChange(interviewer.UserId)}
                                checked={checkedState[interviewer.UserId] || false}
                            /></div>
                        </div>
                    ))}
                </ul>
                <Button variant="contained" onClick={handleAssignInterviewer}>Assign Interviewers</Button>
            </div>
        </>
    );
};

export default AssignInterviewer;
