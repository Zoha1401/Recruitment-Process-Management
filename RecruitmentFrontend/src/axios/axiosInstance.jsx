import axios from 'axios';

const axiosInstance = axios.create({
  baseURL: 'http://localhost:5172/api',
  headers: {
    'Content-Type': 'application/json',
  },
});
// axiosInstance.interceptors.request.use(
//   (config) => {
//     config.headers.Authorization("")
//     return config;
//   },
//   (error) => {
    
//     return Promise.reject(error);
//   }
// );

export default axiosInstance;