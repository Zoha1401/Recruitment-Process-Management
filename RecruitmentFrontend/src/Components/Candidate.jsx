/* eslint-disable react/prop-types */


const Candidate = ({candidate}) => {
  console.log(candidate)
  return (
    <div className="rounded-sm shadow-sm border-1 m-2 p-4">
        
        {candidate.FirstName}
        {candidate.CollegeName}
    </div>
  )
}

export default Candidate