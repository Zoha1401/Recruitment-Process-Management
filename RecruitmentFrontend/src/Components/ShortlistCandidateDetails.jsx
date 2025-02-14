/* eslint-disable react/prop-types */

import { Button } from "@mui/material"


const ShortlistCandidateDetails = ({shortlistCandidate}) => {
  return (
    <div>ShortlistCandidateDetails
         {shortlistCandidate.FirstName}
         <Button>Verify Documents</Button>
         <Button>Update Joining Date</Button>
         <Button>Upload Offer letter</Button>
    </div>
  )
}

export default ShortlistCandidateDetails