import React ,{useEffect ,useState}from 'react'
import axios from 'axios';
import { CardText,Card,CardBody,CardTitle,CardSubtitle,Button } from 'reactstrap';
import { Navigate, useNavigate } from 'react-router-dom';
import { axiosInstance } from '../api/api';

function CourseCart({ courses }) {
  
  const [loading, setLoading] = useState(true);
  const navigate=useNavigate();
  useEffect(() => {
      if (courses && courses.length > 0) {
        setLoading(false);
        } 
    
  }, [courses]);

  const isAuthenticated = () => {
    const token = localStorage.getItem("token"); 
    return !!token;
  };

  const truncateText = (text, maxLength) => {
    if (text.length > maxLength) {
      return text.substring(0, maxLength) + "...";
    }
    return text;
  };
  const handleDetail = (courseId) => {
    
      navigate(`/course/${courseId}`);
    
    
  };
  if (loading) {
    
    return (
      <div className="d-flex justify-content-center align-items-center" style={{ height: "100vh" }}>
        <div className="spinner-border text-primary" role="status">
          <span className="visually-hidden">Loading...</span>
        </div>
      </div>
    );
  }
  

  return (
    <div className="row courseList">
      {courses.length > 0 ? (
        courses.map((course) => (
          
          <div className="col-md-4 mb-4" key={course.id}>
            <Card>
              <img alt={course.title} src="https://picsum.photos/300/200" />
              <CardBody>
                <CardTitle tag="h5">{course.title}</CardTitle>
                <CardSubtitle className="mb-2 text-muted course-category" tag="h6">
                <strong>Category:</strong> {course.category.name}
                </CardSubtitle>
                <CardSubtitle className="mb-2 text-muted" tag="h6">
                <strong>Instructor:</strong> {course.instructor.userName}
                </CardSubtitle>
                <CardText className="course-description">{truncateText(course.description, 90)}</CardText>
                <Button onClick={() => handleDetail(course.id)} color="success" className="detail-button">Detail</Button>
              </CardBody>
            </Card>
          </div>
        ))
      ) : (
        <p>No courses found.</p>
      )}
    </div>
  )
}

export default CourseCart