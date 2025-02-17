/* eslint-disable react/prop-types */


const Candidate = ({candidate}) => {
  console.log(candidate)
  return (
    <div className="flex rounded-sm shadow-sm border-1 m-2 p-4 flex-row justify-between">
        
      
        <div className="m-2 p-2">
          <div className="font-bold">First Name:</div>
          <div> {candidate.FirstName}</div></div>
          <div className="m-2 p-2">
          <div className="font-bold">Last Name:</div>
          <div> {candidate.LastName}</div></div>
          <div className="m-2 p-2">
          <div className="font-bold">College Name:</div>
          <div> {candidate.CollegeName}</div></div>
          <div className="m-2 p-2">
          <div className="font-bold">ResumeUrl:</div>
          <div> {candidate.ResumeUrl}</div></div>
    </div>
  )
}

export default Candidate