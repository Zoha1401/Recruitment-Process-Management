import { useState } from "react"
import { useNavigate } from "react-router-dom";
import { useAuth } from "../Context/AuthProvider";

const Login = () => {
  const navigate=useNavigate();
  const auth=useAuth();
  const [credentials, setCredentials] = useState({email:"", password:""})
  const [user, setUser]=useState();
  const onChange = (e) => {
    setCredentials({ ...credentials, [e.target.name]: e.target.value });
};
const handleSubmit=(e)=>{
    if(credentials.password!="" && credentials.email!=""){
        e.preventDefault();
    
        console.log("Calling login function")
        if (credentials.email != "" && credentials.password != "") {
            auth.loginAction(credentials);
            console.log(user);
            setUser(auth.user)
          }
        
        console.log(credentials.email)
        
        if(localStorage.getItem("token")!=null){
          alert("User successfully logged in")
        // navigate(`/recruiterDashboard`)
        //navigate(`/interviewerDashboard`)
        navigate(`/reviewerDashboard`)
        setCredentials({})
        }
        else{
            alert("Invalid email and password")
        }
       
    }
    
    else{
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
        <input value={credentials.email} onChange={onChange} name="email" className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" id="email" type="text" placeholder="Email"/>
      </div>
      <div className="mb-6">
        <label className="block text-gray-700 text-sm font-bold mb-2" htmlFor="password">
          Password
        </label>
        <input name="password" onChange={onChange} value={credentials.password} className="shadow appearance-none border border-red-500 rounded w-full py-2 px-3 text-gray-700 mb-3 leading-tight focus:outline-none focus:shadow-outline" id="password" type="password" placeholder="Enter password" min={8}/>
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