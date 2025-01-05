import React, { useState, useEffect } from 'react';
import HomeFilter from '../components/HomeFilter';
import CourseCart from '../components/CourseCart';
import { axiosInstance } from '../api/api';
import FeaturedCoursesCarousel from '../components/FeaturedCoursesCarosel';
import CategoryButtons from '../components/CategoryButtons';

function Home() {
  const [courses, setCourses] = useState([]);
  const [categories, setCategories] = useState([]);
  const [searchTerm, setSearchTerm] = useState('');
  const [selectedCategory, setSelectedCategory] = useState('');

  useEffect(() => {
    
    axiosInstance.get('/courses')
      .then((response) => {
        console.log(response)
        setCourses(response.data);
      })
      .catch((error) => {
        console.error('Kurslar yüklenirken hata oluştu:', error);
      });

      axiosInstance.get('/categories')
      .then((response) => {
        console.log(response)
        setCategories(response.data);
      })
      .catch((error) => {
        console.error('Kategoriler yüklenirken hata oluştu:', error);
      });
      
  }, []);

  const filteredCourses =  courses.filter((course) => {
    const matchesSearch = course.title.toLowerCase().includes(searchTerm.toLowerCase());
    const matchesCategory = !selectedCategory  || course.category.id=== selectedCategory;
    return matchesSearch && matchesCategory;  
   
  }); 

  return (
    <>
    <FeaturedCoursesCarousel courses={courses} />
    <div className="container mt-4 ">
    <CategoryButtons
  categories={categories}
  selectedCategory={selectedCategory}
  setSelectedCategory={setSelectedCategory}
/>

      <HomeFilter
        searchTerm={searchTerm}
        setSearchTerm={setSearchTerm}
        selectedCategory={selectedCategory}
        setSelectedCategory={setSelectedCategory}
        categories={categories}
      />
      <CourseCart courses={filteredCourses} />
    </div>
    </>
  )
}

export default Home