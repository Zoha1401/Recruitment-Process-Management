import { useEffect, useState } from "react";
import axiosInstance from "../../axios/axiosInstance";
import { useParams } from "react-router-dom";

const AssignInterviewer = () => {
    const [interviewers, setInterviewers] = useState([]);
    const token = localStorage.getItem("token");
    const { interviewId } = useParams();
    const [selectedInterviewers, setSelectedInterviewers] = useState([]);
    const [checkedState, setCheckedState] = useState({});

    useEffect(() => {
        const fetchInterviewers = async () => {
            const response = await axiosInstance.get('/user/getAllInterviewers', {
                headers: {
                    Authorization: `Bearer ${token}`,
                },
            });
            setInterviewers(response.data);
        };
        fetchInterviewers();
    }, [token]);

  //   useEffect(() => {
  //     const fetchAssignedInterviewers = async () => {
  //         const response = await axiosInstance.get(`/interview/assignedInterviewers/${interviewId}`, {
  //             headers: {
  //                 Authorization: `Bearer ${token}`,
  //             },
  //         });
  //         setAssignedInterviewers(response.data);
  //     };
  //     fetchAssignedInterviewers();
  // }, [interviewId, token]);

//   useEffect(() => {
//     const initialCheckedState = {};
//     assignedInterviewers.forEach((interviewer) => {
//         initialCheckedState[interviewer.InterviewerId] = true;
//     });
//     setCheckedState(initialCheckedState);
// }, [assignedInterviewers]);


    const handleCheckboxChange = (id) => {
        setCheckedState((prevState) => {
            const updatedState = { ...prevState, [id]: !prevState[id] };

            if (updatedState[id]) {
                // Add the interviewer as an object with InterviewerId to the selectedInterviewers array
                setSelectedInterviewers((prev) => {
                    if (!prev.some((interviewer) => interviewer.InterviewerId === id)) {
                        return [...prev, { InterviewerId: id }];
                    }
                    return prev; // Prevent adding duplicates
                });
            } else {
                // Remove the interviewer object from the selectedInterviewers array
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
                        Authorization: `Bearer ${token}`,
                        'Content-Type': 'application/json',
                    },
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
            <div>
                <h3>Assign Interviewer</h3>
                <ul>
                    {interviewers.map((interviewer) => (
                        <li key={interviewer.UserId}>
                            {interviewer.FirstName}
                            <input
                                type="checkbox"
                                onChange={() => handleCheckboxChange(interviewer.UserId)}
                                checked={checkedState[interviewer.UserId] || false}
                            />
                        </li>
                    ))}
                </ul>
                <button onClick={handleAssignInterviewer}>Assign Interviewer</button>
            </div>
        </>
    );
};

export default AssignInterviewer;
