import axios from 'axios';
import { useNavigate } from 'react-router-dom';


const baseUrl = 'https://localhost:7273/api'; 


export const axiosInstance = axios.create({baseURL: baseUrl});

axiosInstance.interceptors.request.use(
  (config) => {
    const token = localStorage.getItem('token'); 
    config.headers['Content-Type']=" application/json"
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
      
    }
    return config;
  },
  (error)=>Promise.reject(error)
);


axiosInstance.interceptors.response.use(
  (response) => response,
  (error) => {
    if (error.response?.status === 401) {
      console.error('Unauthorized: Please log in again.');
      
      localStorage.removeItem("token");
      window.location.href = '/login';
    }
    return Promise.reject(error);
  }
);




// API endpoints
export const api = {
  // Auth endpoints
  login: (credentials) => axiosInstance.post('/auth/login', credentials),
  
  // User endpoints
  getUsers: () => axiosInstance.get('/users'),
  getUserById: (id) => axiosInstance.get(`/users/${id}`),
  updateUser: (id, data) => axiosInstance.put(`/users/${id}`, data),
  deleteUser: (id) => axiosInstance.delete(`/users/${id}`),

  // Course endpoints
  getCourses: () => axiosInstance.get('/courses'),
  getCourseById: (id) => axiosInstance.get(`/courses/${id}`),
  createCourse: (data) => axiosInstance.post('/courses', data),
  updateCourse: (id, data) => axiosInstance.put(`/courses/${id}`, data),
  deleteCourse: (id) => axiosInstance.delete(`/courses/${id}`),

  // Order endpoints
  getOrders: () => axiosInstance.get('/orders'),
  getOrderById: (id) => axiosInstance.get(`/orders/${id}`),
  createOrder: (data) => axiosInstance.post('/orders', data),

  // Payment endpoints
  processPayment: (data) => axiosInstance.post('/payments', data),
};



