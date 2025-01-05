import React, { useEffect, useState } from "react";
import { Container, Row, Col, Card, CardBody, CardTitle, CardText, Spinner } from "reactstrap";
import { axiosInstance } from "../api/api";

function UserCourses() {
  const [courses, setCourses] = useState([]);
  const [loading, setLoading] = useState(true);
  const userId = localStorage.getItem("userId"); 

  useEffect(() => {
    const fetchCourses = async () => {
      try {
        const response = await axiosInstance.get(`/User/courses/${userId}`);
        setCourses(response.data);
        console.log(response)
      } catch (error) {
        console.error("Error fetching courses:", error);
      } finally {
        setLoading(false);
      }
    };

    fetchCourses();
  }, [userId]);

  if (loading) {
    return (
      <div className="d-flex justify-content-center align-items-center" style={{ height: "100vh" }}>
        <Spinner color="primary" />
      </div>
    );
  }

  return (
    <Container className="mt-5">
      
      <Row>
        {courses.length > 0 ? (
          courses.map((course) => (
           
            <Col md="4" sm="6" xs="12" className="mb-4" key={course.id}>
              <Card >
                <CardBody>
                  <CardTitle tag="h5">{course.title}</CardTitle>
                  <CardText>
                    <strong>Price:</strong> {course.price} TL
                  </CardText>
                  <CardText>
                    <strong>Description:</strong> {course.description}
                  </CardText>
                </CardBody>
              </Card>
            </Col>
            
          ))
        ) : (
          <div className="text-center w-100">
            <p>No courses found.</p>
          </div>
        )}
      </Row>
    </Container>
  );
}

export default UserCourses;