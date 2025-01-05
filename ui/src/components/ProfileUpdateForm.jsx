import React, { useState, useEffect } from "react";
import { Form, FormGroup, Label, Input, Button, Spinner } from "reactstrap";
import { jwtDecode } from "jwt-decode";
import { axiosInstance } from "../api/api";
import alertify from "alertifyjs";

function ProfileUpdateForm() {
  const [user, setUser] = useState({
    id: "",
    userName: "",
    email: "",
  });

  const [loading, setLoading] = useState(true);
  const [updating, setUpdating] = useState(false);

  useEffect(() => {
    const token = localStorage.getItem("token");
    if (token) {
      try {
        const decodedToken = jwtDecode (token);
        setUser({
          id: decodedToken.sub,
          userName: decodedToken.given_name,
          email: decodedToken.email,
        });
        setLoading(false);
      } catch (error) {
        console.error("Invalid token:", error);
        setLoading(false);
      }
    } else {
      setLoading(false);
    }
  }, []);

  const handleChange = (e) => {
    const { name, value } = e.target;
    setUser((prevUser) => ({
      ...prevUser,
      [name]: value,
    }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setUpdating(true);
    try {
      await axiosInstance.put(`/user`, user);
      alertify.success("Profile updated successfully!");
    } catch (error) {
      alertify.error("Error updating profile. Please try again.");
    } finally {
      setUpdating(false);
    }
  };

  if (loading) {
    return (
      <div className="d-flex justify-content-center align-items-center" style={{ height: "100vh" }}>
        <Spinner color="primary" />
      </div>
    );
  }

  return (
    <div className="container mt-5">
      <h2 className="mb-4">Update Profile</h2>
      <Form onSubmit={handleSubmit}>
        <FormGroup>
          <Label for="userName">Username</Label>
          <Input
            id="userName"
            name="userName"
            type="text"
            value={user.userName}
            onChange={handleChange}
            required
          />
        </FormGroup>
        <FormGroup>
          <Label for="email">Email</Label>
          <Input
            id="email"
            name="email"
            type="email"
            value={user.email}
            onChange={handleChange}
            required
          />
        </FormGroup>
        <Button color="primary" type="submit" disabled={updating}>
          {updating ? <Spinner size="sm" /> : "Update"}
        </Button>
      </Form>
    </div>
  );
}

export default ProfileUpdateForm;