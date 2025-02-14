
import { useState } from "react"
import axiosInstance from "../../axios/axiosInstance";
//import { useParams } from "react-router-dom";
import { Button } from "@mui/material";


const UploadDocuments = () => {
    const [aadharFile, setAadharFile]=useState(null)
    //const {candidateId}=useParams()
    const handleAadharFileChange = (e) => {
        setAadharFile(e.target.files[0]);
      };
    const shortlistId=2
  const token=localStorage.getItem("token")
      const handleAadharUpload = async () => {
        if (!aadharFile) {
          alert("Please select a aadhar card file first");
          return;
        }
        const formData = new FormData();
        formData.append('FormFile', aadharFile);

    
        try {
          const response = await axiosInstance.post(
            `/document/${shortlistId}`,
            formData,
            {
              headers: {
                "Content-Type": "multipart/form-data, application/json",
                Authorization: `Bearer ${token}`,
              },
            }
          );
          console.log(response.data);
          alert("document uploaded")

          window.location.reload();
        } catch (error) {
          alert("Error uploading file: " + error.response?.data || error.message);
          console.log(error)
        }
      };
  return (
    <div>UploadDocuments
         <div className="flex mx-4">
    <input type="file" onChange={handleAadharFileChange} className="mt-2" />
    <Button
      variant="contained"
      onClick={handleAadharUpload}
      className="mb-2 mt-2 px-4"
    >
      Upload Aadhar Document
    </Button>
  </div>
    </div>
   
  )
}

export default UploadDocuments