import { useState } from 'react'
import CourseNavbar from './components/CourseNavbar'
import './App.css'
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Login from './pages/Login';
import Profile from './pages/Profile';
import Register from './pages/Register';
import Home from './pages/Home';
import CourseDetail from './pages/CourseDetail';
import PrivateRoute from './components/PrivateRoute';
import Footer from './components/Footer';
import Cart from './pages/Cart';
function App() {
 

  return (
   
      <div className='main-div'>
       
       <Router>
        <CourseNavbar />
        <div className="content courseList" >
        <Routes>
          <Route path="/" element={<Home/>}  />
          <Route path="/profile" element={<PrivateRoute><Profile/></PrivateRoute>} />
          <Route path="/login" element={<Login/>} />
          <Route path="/register" element={<Register/>} />
          <Route path="/course/:id" element={<CourseDetail/>}/>
          <Route path ="/cart" element={<PrivateRoute><Cart/></PrivateRoute>}/>
        </Routes>
        </div>
        <Footer/>
        </Router>
        
      </div>
        
    
  )
}

export default App
