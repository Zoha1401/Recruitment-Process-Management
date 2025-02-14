import { useState } from "react"
import { useNavigate } from "react-router-dom";
import { useAuth } from "../Context/AuthProvider";

const Login = () => {
  const navigate = useNavigate();
  const auth = useAuth();
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [user, setUser] = useState();


  const handleSubmit = (e) => {
    e.preventDefault();
    if (password != "" && email != "") {
      console.log("Calling login function")
      if (email != "" && password != "") {
        auth.loginAction({email, password});
        
        console.log(user);
      }
      const token = auth.token
      // console.log(email)

      if (auth.token!= null) {
        alert("User successfully logged in")
        const parts = token.split('.');
        const decodedPayload = atob(parts[1]);

        const parsedPayload = JSON.parse(decodedPayload);
        console.log("response", parsedPayload)

        const { role } = parsedPayload;
        console.log("Role: "+ (role))
        if (role === 'Recruiter') {
          navigate('/recruiterDashboard');
        } else if (role === 'Interviewer') {
          navigate('/interviewerDashboard');
        } else if (role === 'Reviewer') {
          navigate('/reviewerDashboard');
        } else if (role === 'Candidate') {
          navigate('/candidateDashboard');
        }
        setEmail("")
        setPassword("")
      }
      else {
        alert("Invalid email and password")
      }

    }

    else {
      alert("Please provide a valid email and password")
    }
  }

  return (

    <div className="w-full max-w-xs justify-center align-items items-center">
      <form className="bg-white shadow-md rounded px-8 pt-6 pb-8 mb-4">
        <div className="mb-4">
          <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="email">
            Email
          </label>
          <input value={email} onChange={(e) => setEmail(e.target.value)} name="email" className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" id="email" type="text" placeholder="Email" />
        </div>
        <div className="mb-6">
          <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="password">
            Password
          </label>
          <input name="password" onChange={(e) => setPassword(e.target.value)} value={password} className="shadow appearance-none border border-red-500 rounded w-full py-2 px-3 text-gray-700 mb-3 leading-tight focus:outline-none focus:shadow-outline" id="password" type="password" placeholder="Enter password" min={8} />
        </div>
        <div className="flex items-center justify-between">
          <button className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline" type="button" onClick={handleSubmit}>
            Log In
          </button>
        </div>
      </form>
    </div>


  )
}

export default Login