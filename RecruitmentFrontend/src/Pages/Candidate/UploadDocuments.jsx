
import { useState } from "react"
import axiosInstance from "../../axios/axiosInstance";
//import { useParams } from "react-router-dom";
import { Button } from "@mui/material";


const UploadDocuments = () => {
    const [file, setFile]=useState(null)
    const [documentUrls, setDocumentUrls]=useState([])
    //const {candidateId}=useParams()
    const shortlistId=2
    const handleFileChange = (e) => {
        setFile(e.target.files[0]);
      };
  const token=localStorage.getItem("token")

  const handleSaveDocuments=async(e)=>{
      e.preventDefault();
      try {
        const response = await axiosInstance.post(
          `/document/${shortlistId}`,
           
             documentUrls,
           
          {
            headers: {
              "Content-Type": "application/json",
              Authorization: `Bearer ${token}`,
            },
          }
        );
        console.log(response.data);
        alert("document uploaded")

      } catch (error) {
        alert("Error uploading file: " + error.response?.data || error.message);
        console.log(error)
      }
  }

  console.log("document urls", documentUrls)
      const handleUpload = async () => {
        if (!File) {
          alert("Please select a  file first");
          return;
        }

    
        try {
          const response = await axiosInstance.post(
            `/candidate/uploadDocument`,
            {FormFile:file},
            {
              headers: {
                "Content-Type": "multipart/form-data, application/json",
                Authorization: `Bearer ${token}`,
              },
            }
          );
          console.log(response.data);
          setDocumentUrls([...documentUrls, {DocumentUrl:response.data}])
        
          alert("document uploaded")

        } catch (error) {
          alert("Error uploading file: " + error.response?.data || error.message);
          console.log(error)
        }
      };
  return (
    <div>UploadDocuments
         <div className="flex mx-4">
    <input type="file" onChange={handleFileChange} className="mt-2" />
    <Button
      variant="contained"
      onClick={handleUpload}
      className="mb-2 mt-2 px-4"
    >
      Upload Aadhar/PAN Card
    </Button>
  </div>
  <div className="flex mx-4">
    <input type="file" onChange={handleFileChange} className="mt-2" />
    <Button
      variant="contained"
      onClick={handleUpload}
      className="mb-2 mt-2 px-4"
    >
      Upload Leaving cerificate
    </Button>
  </div>
  <div className="flex mx-4">
    <input type="file" onChange={handleFileChange} className="mt-2" />
    <Button
      variant="contained"
      onClick={handleUpload}
      className="mb-2 mt-2 px-4"
    >
      Upload Your Marksheets
    </Button>

    <Button className="" onClick={handleSaveDocuments}>Save All Documents</Button>
  </div>
    </div>
   
  )
}

export default UploadDocuments