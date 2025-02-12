/* eslint-disable react/prop-types */
import { useContext, createContext, useState, useEffect } from "react";
// import { useNavigate } from "react-router-dom";

const AuthContext = createContext();

const AuthProvider = ({ children }) => {
  const [user, setUser] = useState(null);
  const [token, setToken] = useState(localStorage.getItem("token") || "");
//   const navigate = useNavigate();
useEffect(() => {
    if (token) {
      getUserFromToken(token); // Automatically fetch user data if token exists
    }
  }, [token]);
  const loginAction = async (data) => {
    try {
      const response = await fetch("http://localhost:5172/api/auth/login", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(data),
      });
      const res = await response.json();
      console.log(res);
      console.log("Response fetched from token" , res.Token)
      if (res.Token) {
        setToken(res.Token);
        localStorage.setItem("token", res.Token);
       
        // navigate("/dashboard");
        return;
      }
    } catch (err) {
      console.error(err);
    }
  };
  const logOut = () => {
    setToken("");
    localStorage.removeItem("token");
  };

  const isLoggedIn=()=>{
    const token=localStorage.getItem("token")
    if(!token){
        return false;
    }
    return true;
  }

  const getUserFromToken = async (token) => {
    try {
      const response = await fetch("http://localhost:5172/api/user/me", {
        method: "GET",
        headers: {
          "Authorization": `Bearer ${token}`,
          "Content-Type": "application/json",
        },
      });
      const res = await response.json();
      if (res) {
        setUser(res);
      }
    } catch (err) {
      console.error(err);
    }
  };

  return (
    <AuthContext.Provider value={{ token, user, getUserFromToken, loginAction, logOut, isLoggedIn}}>
      {children}
    </AuthContext.Provider>
  );
}

export default AuthProvider;

export const useAuth = () => {
  return useContext(AuthContext);
};