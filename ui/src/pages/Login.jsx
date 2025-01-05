import React from 'react'
import { Form,FormGroup,Input,Label,Button } from 'reactstrap'
import AuthContext from '../context/AuthContext';
import { useContext,useState } from 'react';
import axios from 'axios';
import alertify from 'alertifyjs';
import { Link } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';

function Login() {
  const { login } = useContext(AuthContext);
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const navigate=useNavigate();

  const handleLogin = async () => {
    try {
        const response = await axios.post("https://localhost:7273/api/Auth/login", 
            {email,
            password}
            
        );
        
        const token = response.data.accessToken; 
        login(token.accessToken); 
        navigate("/");
        alertify.success("Login successful!");
       
    } catch (error) {
        console.error("Login failed:", error);
        alertify.error("Invalid credentials");
    }
};
    
  return (
    <div className='loginform'>
      <h5>Login</h5>
         <Form>
    <FormGroup floating>
      <Input
        id="exampleEmail"
        name="email"
        placeholder="Email"
        type="email"
        onChange={(e)=>setEmail(e.target.value)}
      />
      <Label for="exampleEmail">
        Email
      </Label>
    </FormGroup>
  
    <FormGroup floating>
      <Input
        id="examplePassword"
        name="password"
        placeholder="Password"
        type="password"
        onChange={(e)=>setPassword(e.target.value)}
      />
      <Label for="examplePassword">
        Password
      </Label>
    </FormGroup>
    
    <Button  className="btn btn-success"onClick={handleLogin} >
      Login
    </Button>
  </Form>

  <div className="text-center mt-3">
          <p>
            
           Don't have an account? <Link to="/register">Register here</Link>
          </p>
        </div>
    </div>
  )
}

export default Login