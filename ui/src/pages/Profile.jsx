import React, { useEffect, useState } from 'react'
import {CreateCourseForm} from '../components/CreateCourseForm'
import { useParams } from 'react-router-dom';
import ProfileUpdateForm from '../components/ProfileUpdateForm';
import OrdersTable from '../components/OrdersTable';
import { Container, Row, Col, Card, CardHeader, CardBody } from "reactstrap";
import UserCourses from '../components/UserCourses';
import { jwtDecode } from 'jwt-decode';

function Profile() {
  const [isInstructor, setIsInstructor] = useState(false);
  const { userId } = useParams();
 useEffect(() => {
     
     const token = localStorage.getItem('token'); 
     if (token) {
       const decodedToken = jwtDecode(token);
       if (decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] === 'Instructor') {
         setIsInstructor(true);
       }
     }
   }, []);
  
  


  return (
    <Container className="mt-5">
      <h1 className="mb-4 text-center">Profile</h1>
      <Row>
       
        <Col md={6} className="mb-4">
          <Card>
            <CardHeader className="bg-primary text-white">
              <h5>Update Profile</h5>
            </CardHeader>
            <CardBody>
              <ProfileUpdateForm />
            </CardBody>
          </Card>
        </Col>

        
        <Col md={6} className="mb-4">
          <Card>
            <CardHeader className="bg-success text-white">
              <h5>My Orders</h5>
            </CardHeader>
            <CardBody>
              <OrdersTable />
            </CardBody>
          </Card>
        </Col>
      </Row>

      {isInstructor && (
      <Row>
        <Col md={12} className="mb-4">
          <Card>
            <CardHeader className="bg-info text-white">
              <h5>Create Course</h5>
            </CardHeader>
            <CardBody>
              <CreateCourseForm />
            </CardBody>
          </Card>
        </Col>
      </Row>
      )}
      <Row>
        <Col md={12} className="mb-4">
          <Card>
            <CardHeader className="bg-info text-white">
              <h5>My Courses</h5>
            </CardHeader>
            <CardBody>
              <UserCourses></UserCourses>
            </CardBody>
          </Card>
        </Col>
      </Row>
    </Container>
  )
}

export default Profile