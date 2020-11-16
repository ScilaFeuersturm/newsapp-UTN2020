import axios from "axios";

const instance = axios.create({
  baseURL: "https://localhost:5001/api",
});

const token = localStorage.getItem('token');
if (token)
  instance.defaults.headers.common['Authorization'] = `Bearer ${token}`;


export const setClientToken = (token) => {
  instance.defaults.headers.common['Authorization'] = `Bearer ${token}`;
};

export default instance;