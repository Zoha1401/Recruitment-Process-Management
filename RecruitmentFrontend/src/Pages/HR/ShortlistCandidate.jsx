import { useEffect, useState } from "react"
import axiosInstance from "../../axios/axiosInstance"
import ShortlistCandidateDetails from "../../Components/ShortlistCandidateDetails"

const ShortlistCandidate = () => {
    const [shortlistCandidates, setShortlistCandidates]=useState([])
    const token=localStorage.getItem("token")
    useEffect(() => {
      const fetchShortlistCandidates = async () => {

      const response = await axiosInstance.get('/shortlistCandidate/getShortlistedCandidates',
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      )
      console.log(response.data);
      setShortlistCandidates(response.data)

    }
    fetchShortlistCandidates();
    }, [token])
    
  return (
    <div>ShortlistCandidate
           <div className="m-2 max-w-full min-h-screen">
          {shortlistCandidates.map((shortlistCandidate) => (
            <div key={shortlistCandidate.PositionId}><ShortlistCandidateDetails key={shortlistCandidate.PositionId} shortlistCandidate={shortlistCandidate} /></div>
          ))}
        </div>
    </div>
  )
}

export default ShortlistCandidate