import React from 'react';
import { Input, Form, FormGroup, Label, Row, Col, Button } from 'reactstrap';

const HomeFilter = ({ searchTerm, setSearchTerm, selectedCategory, setSelectedCategory, categories }) => {
  return (
    <Form className="mb-4 home-filter-form">
      <Row>
        <Col md={6}>
          <FormGroup>
            <Label for="search"className="form-label">Search by Name</Label>
            <Input
              type="text"
              id="search"
              placeholder="Search courses..."
              value={searchTerm}
              onChange={(e) => setSearchTerm(e.target.value)}
            />
          </FormGroup>
        </Col>
        <Col md={6}>
          <FormGroup>
            <Label for="category"className="form-label">Filter by Category</Label>
            <Input
              type="select"
              id="category"
              value={selectedCategory}
              onChange={(e) => setSelectedCategory(e.target.value)}
            >
                <option value=""></option>
              {categories.map((category) => (
                <option key={category.id} value={category.id}>
                  {category.name}
                </option>
              ))}
            </Input>
          </FormGroup>
        </Col>
      </Row>
      <Button color="primary" onClick={() => setSearchTerm('')}>
        Clear Search
      </Button>
    </Form>
  );
};

export default HomeFilter;