/* eslint-disable react/prop-types */
import { useContext, createContext, useState } from "react";
// import { useNavigate } from "react-router-dom";

const AuthContext = createContext();

const AuthProvider = ({ children }) => {
  const [user, setUser] = useState(null);
  const [role, setRole] = useState("Recruiter");
  const [isAuthenticated, setIsAuthenticated] = useState(false);

  // useNavigate to redirect user after login/logout (uncomment if needed)
  // const navigate = useNavigate();

  // useEffect(() => {
  //   // Fetch the user data from the backend (via cookies automatically sent by browser)
  //   getUserFromToken();
  // }, []);

  const loginAction = async (data) => {
    try {
      const response = await fetch("http://localhost:5172/api/auth/login", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
        credentials: 'include',  // Include cookies in the request
      });
  
      console.log(response);
  
      if (response.ok) {
        setIsAuthenticated(true)
        const responseData = await response.json();  // Parse JSON response
        console.log("Response Data", responseData);
        console.log("Role", responseData.Role)
        setUser(responseData); 
       // Store user data
        localStorage.setItem("role", responseData.Role)
        console.log(localStorage.getItem("role"))
        setRole(responseData.Role);  // Store user role
      } else {
        console.error("Login failed.");
      }
    } catch (err) {
      console.error("Login error: ", err);
    }
  
  };

  const logOut = async () => {
    try {
      await fetch("http://localhost:5172/api/auth/logout", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
      });

      // Reset user and role states after logout
      localStorage.removeItem("role") 
      setUser(null);
      setRole("");
      setIsAuthenticated(false);
    } catch (err) {
      console.error("Logout error: ", err);
    }
  };



  return (
    <AuthContext.Provider value={{ user, role, isAuthenticated, loginAction, logOut }}>
      {children}
    </AuthContext.Provider>
  );
};

export default AuthProvider;

export const useAuth = () => {
  return useContext(AuthContext);
};
