import React, { useState,useEffect  } from 'react'
import { useNavigate, useParams} from 'react-router-dom'

import { Card,CardBody,CardText,CardImg ,CardTitle, Button ,Container,Col,Row} from 'reactstrap';
import { axiosInstance } from '../api/api';
import { useCart } from '../context/CartContext';
import alertify from 'alertifyjs';

function CourseDetail() {
  const {id}=useParams();
  const [course,setCourse]=useState(null);
  const [userCourses, setUserCourses] = useState([]);
  const [isOwned, setIsOwned] = useState(false);
  const { addToCart } = useCart();
  const navigate=useNavigate();

  const isAuthenticated = () => {
    const token = localStorage.getItem("token"); 
    return !!token;
  };

  useEffect(() => {
    const fetchCourse = async () => {
      try {
        const response = await axiosInstance.get(`/courses/${id}`);
        setCourse(response.data);
        console.log(response)

        const userId = localStorage.getItem("userId");
        const userCoursesResponse = await axiosInstance.get(`/User/courses/${userId}`);
        setUserCourses(userCoursesResponse.data);
        const owned = userCoursesResponse.data.some((userCourse) => userCourse.id ==id);
        console.log(`owned:${owned}`)
        setIsOwned(owned);

      } catch (error) {
        console.error("Error fetching course details:", error);
      }
    };
    fetchCourse();
    
  }, [id]);

  const handleAddToCart=(course)=>{
    if (isAuthenticated()) {
      addToCart(course)
    
      navigate(`/`);
    } else {
      navigate("/login");
      
    }
    
    
  }
  if (!course) {
    return (
      <div className="d-flex justify-content-center align-items-center" style={{ height: "100vh" }}>
        <div className="spinner-border text-primary" role="status">
          <span className="visually-hidden">Loading...</span>
        </div>
      </div>
    );
  }
  return (
    <>
  
    <Container fluid className="course-detail-container" >
    <Row>
  <Col md="6">
    <div
      className="course-image"
      style={{
        backgroundImage: `url(https://picsum.photos/1200/600)`,
      }}
    />
  </Col>
  <Col md="6" className="d-flex flex-column justify-content-center">
    <h1 className="course-title">{course.title}</h1>
    <p className="course-description"><strong>Instructor:</strong> {course.instructor.userName}</p>
    <p className="course-description"><strong>Category:</strong> {course.category.name}</p>
    <p className="course-description">{course.description}</p>
    <h3 className="course-price"><strong>Price:</strong> {course.price} TL</h3>
    {isOwned ? (
              <div className="text-success">
                <strong>You already own this course</strong>
              </div>
            ) : (
    <Button color='success' className="course-button" onClick={() => handleAddToCart(course)}>
      Add To Cart
    </Button>
            )}
  </Col>
</Row>

<Row className="about-section">
  <Col>
    <h2>About This Course</h2>
    <p>
      Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam
      suscipit nisl nec dui faucibus, ut fringilla lorem euismod. 
      Pellentesque accumsan convallis ipsum, et ultrices erat malesuada a.
    </p>
    <p>
      Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam
      suscipit nisl nec dui faucibus, ut fringilla lorem euismod. 
      Pellentesque accumsan convallis ipsum, et ultrices erat malesuada a.
      Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam
      suscipit nisl nec dui faucibus, ut fringilla lorem euismod. 
      Pellentesque accumsan convallis ipsum, et ultrices erat malesuada a.
    </p>
    
  </Col>
</Row>
    </Container>
</>
  )
}

export default CourseDetail