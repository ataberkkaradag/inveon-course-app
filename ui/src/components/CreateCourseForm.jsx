import React, { useState, useEffect } from 'react';
import {
  Button,
  Form,
  FormGroup,
  Label,
  Input,
} from 'reactstrap';
import axios from 'axios';
import { jwtDecode } from 'jwt-decode';
import { axiosInstance } from '../api/api';
import alertify from 'alertifyjs';

export const CreateCourseForm = ({ instructorId }) => {
  const [categories, setCategories] = useState([]);
  const userId = localStorage.getItem("userId");
  const [formData, setFormData] = useState({
    title: '',
    description: '',
    price: '',
    categoryId: '',
    instructorId: userId, 
  });
  const [isInstructor, setIsInstructor] = useState(false); 

  useEffect(() => {
    
    const token = localStorage.getItem('token'); 
    if (token) {
      const decodedToken = jwtDecode(token);
      if (decodedToken["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"] === 'Instructor') {
        setIsInstructor(true);
      }
    }
  }, []);

  useEffect(() => {
    
    axiosInstance
      .get('/categories')
      .then((response) => {
        setCategories(response.data);
      })
      .catch((error) => {
        console.error('An error occured while loading category:', error);
      });
  }, []);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    console.log("Form Verisi: ", formData);
    
    axiosInstance
      .post('/courses', formData)
      .then((response) => {
        alertify.success('Course successfuly created!');
        
        
        setFormData({
          title: '',
          description: '',
          price: '',
          categoryId: '',
          instructorId: userId,
        });
      })
      .catch((error) => {
        alertify.error("An error occurred while creating the course")
        console.error('An error occurred while creating the course:', error);
      });
  };

  if (!isInstructor) {
    return <></>;
  }

  return (
    <Form onSubmit={handleSubmit}>
      <FormGroup>
        <Label for="title">Title</Label>
        <Input
          type="text"
          name="title"
          id="title"
          placeholder="Enter course title"
          value={formData.title}
          onChange={handleChange}
          required
        />
      </FormGroup>

      <FormGroup>
        <Label for="description">Description</Label>
        <Input
          type="textarea"
          name="description"
          id="description"
          placeholder="Enter course description"
          value={formData.description}
          onChange={handleChange}
          required
        />
      </FormGroup>

      <FormGroup>
        <Label for="price">Price</Label>
        <Input
          type="number"
          name="price"
          id="price"
          placeholder="Enter course price"
          value={formData.price}
          onChange={handleChange}
          required
        />
      </FormGroup>

      <FormGroup>
        <Label for="categoryId">Category</Label>
        <Input
          type="select"
          name="categoryId"
          id="categoryId"
          value={formData.categoryId}
          onChange={handleChange}
          required
        >
          <option value="">Select a category</option>
          {categories.map((category) => (
            <option key={category.id} value={category.id}>
              {category.name}
            </option>
          ))}
        </Input>
      </FormGroup>

      <Button color="primary" type="submit">
        Create Course
      </Button>
    </Form>
  );
};

