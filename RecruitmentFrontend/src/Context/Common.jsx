/* eslint-disable react/prop-types */
import { createContext,useState } from 'react'
import axiosInstance from '../axios/axiosInstance';

const DataContext=createContext()

const DataProvider=({children})=> {

    const [interviewTypes, setInterviewTypes] = useState([]);
    const [positionStatusTypes, setPositionStatusTypes]=useState([])
    const [jobStatus, setJobStatus]=useState("");

    const fetchInterviewTypes = async () => {
        try {
            const response = await axiosInstance.get("/interviewType/getAllInterviewTypes", {
                credentials: 'include',
                withCredentials: true
            });
            setInterviewTypes(response.data);
            console.log(response.data)
        } catch (error) {
            console.error("Error fetching interview types", error.message);
        }
    };

    const fetchPositionStatusTypes = async () => {
        try {
            const response = await axiosInstance.get("/position/getPositionStatusTypes", {
                credentials: 'include',
                withCredentials: true
            });
            setPositionStatusTypes(response.data);
            console.log("PositionStatusTypes", response.data)
        } catch (error) {
            console.error("Error fetching position status types", error.message);
        }
    };


    const fetchJobStatusById = async (statusId) => {
        try {
            const response = await axiosInstance.get(`/position/getPositionStatusTypeById/${statusId}`, {
                credentials: 'include',
                withCredentials: true
            });
            setJobStatus(response.data);
            console.log("Job status in function", response.data)
        } catch (error) {
            console.error("Error fetching job by status", error.message);
        }
    };
    
    const context={ fetchInterviewTypes, interviewTypes, fetchPositionStatusTypes, positionStatusTypes,
     fetchJobStatusById, jobStatus
    }
    return (
        <DataContext.Provider value={context}>
            {children}
        </DataContext.Provider>
      )
    }




export{DataContext,DataProvider}