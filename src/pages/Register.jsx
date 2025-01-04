import alertify from 'alertifyjs';
import axios from 'axios';
import React from 'react'
import { useState } from 'react'
import { Form ,FormGroup,Input,Label,Button } from 'reactstrap'
import { Link, useNavigate } from 'react-router-dom';

function Register() {
  const [userName,setUserName]=useState(null);
  const [email,setEmail]=useState(null);
  const [password,setPassword]=useState(null);
  const navigate=useNavigate();
  

  const handleRegister= async ()=>{
         try{
          const response=await axios.post("https://localhost:7273/api/Auth/register",
              {userName,email,password}
          );
          alertify.success("Register successful!"); 
            navigate("/login")
         }
         catch(error){
          alertify.error("Invalid credentials");
         }
  };
  return (
    <>
    <div className='loginform'>
    <h5>Register</h5>
    <Form>
      <FormGroup floating>
      <Input
        id="username"
        name="username"
        placeholder="Username"
        type="text"
        onChange={(e)=>setUserName(e.target.value)}
      />
      <Label for="username">
        Username
      </Label>
    </FormGroup>
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
    
    <Button color='warning' onClick={handleRegister}>
      Submit
    </Button>
  </Form>
  <div className="text-center mt-3">
          <p>
            Already have an account? <Link to="/login">Login here</Link>
          </p>
        </div>
</div>

 </>
  )
}

export default Register