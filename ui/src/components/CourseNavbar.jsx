import React, {useContext } from 'react';
import {
  Collapse,
  Navbar,
  NavbarToggler,
  NavbarBrand,
  Nav,
  NavItem,
  NavLink,
  Button 
} from 'reactstrap';
import { Link, useNavigate} from "react-router-dom"
import { AiOutlineShoppingCart } from "react-icons/ai";
import AuthContext, { AuthProvider } from "../context/AuthContext";

function CourseNavbar() {
   const navigate=useNavigate();
   const { isAuthenticated, logout } = useContext(AuthContext);
   const handleLogout=()=>{
    logout();
    navigate("/");
   }
  return (
    
   <Navbar color="#3D3D3D" dark expand="md" className="navbar ">
      <NavbarBrand href="/" className="navbarBrand">Course-App</NavbarBrand>
      <NavbarToggler  />
      <Collapse  navbar>
        <Nav className="me-auto" navbar>
          <NavItem>
            <NavLink className="nav-link" href="/">Home</NavLink>
          </NavItem>
          {isAuthenticated ?(
          <NavItem>
            <NavLink className="nav-link" href="/profile">Profile</NavLink>
          </NavItem>):(<></>)}
        </Nav>
        <div className="d-flex buttonWrapper">
        {isAuthenticated ?(<>
        
          <Link to="/cart" className='cartIcon'><AiOutlineShoppingCart /></Link>
        <Button onClick={handleLogout} color="danger" >
            LogOut
          </Button> 
       </>
        
        ):(<div><Button  color="#578E7E" className="me-2" >
            <Link className='linkButton' to="/login">Login </Link>
          </Button> 
          <Button color="#578E7E" >
            <Link className='linkButton' to= "/register">Sign Up</Link>
          
        </Button></div>
          )}
          
        </div>
      </Collapse>
    </Navbar>
  
  
  )
}

export default CourseNavbar