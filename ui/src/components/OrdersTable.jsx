import React, { useEffect, useState } from "react";
import { Table, Spinner ,Modal,ModalFooter, ModalHeader, ModalBody, Button} from "reactstrap";
import { axiosInstance } from "../api/api";

function OrdersTable() {
  const [orders, setOrders] = useState([]);
  const [loading, setLoading] = useState(true);
  const userId = localStorage.getItem("userId");
  const [modal, setModal] = useState(false);
  const [selectedOrder, setSelectedOrder] = useState(null);
  const [courses, setCourses] = useState([]);
  const [loadingCourses, setLoadingCourses] = useState(false);

  useEffect(() => {
    const fetchOrders = async () => {
      try {
        const response = await axiosInstance.get(`/order/user/${userId}`);
        setOrders(response.data);
      } catch (error) {
        console.error("Error fetching orders:", error);
      } finally {
        setLoading(false);
      }
    };

    fetchOrders();
  }, [userId]);

  const toggleModal = () => {
    setModal(!modal);
  };

  const handleOrderClick = async (order) => {
    setSelectedOrder(order); 
    setLoadingCourses(true);
    setCourses([]);
    toggleModal(); 

    try {
      const response =await axiosInstance.get(`/order/${order.orderId}`);
      setCourses(response.data.courses); 
    } catch (error) {
      console.error("Error fetching courses for order:", error);
    } finally {
      setLoadingCourses(false); 
    }
  };

  if (loading) {
    return (
      <div className="d-flex justify-content-center align-items-center">
        <Spinner color="primary" />
      </div>
    );
  }

  return (
    <div className="mt-5">
      <h3>My Orders</h3>
      <Table bordered hover responsive>
        <thead>
          <tr>
            <th>#</th>
            <th>Order</th>
            <th>Order Date</th>
            <th>Price (TL)</th>
          </tr>
        </thead>
        <tbody>
          {orders.length > 0 ? (
            orders.map((order, index) => (
              <tr key={order.orderId} onClick={() => handleOrderClick(order)}>
                <th scope="row">{index + 1}</th>
                <td>{order.orderId}</td>
                <td>{new Date(order.orderDate).toLocaleDateString()}</td>
                <td>{order.totalPrice}</td>
              </tr>
            ))
          ) : (
            <tr>
              <td colSpan="4" className="text-center">
                No orders found.
              </td>
            </tr>
          )}
        </tbody>
      </Table>

      
      {selectedOrder && (
        <Modal isOpen={modal} toggle={toggleModal}>
          <ModalHeader toggle={toggleModal}>Order Details</ModalHeader>
          <ModalBody>
            <h5>Order ID: {selectedOrder.orderId}</h5>
            <p><strong>Order Date:</strong> {new Date(selectedOrder.orderDate).toLocaleDateString()}</p>
            <p><strong>Total Price:</strong> {selectedOrder.totalPrice} TL</p>
            <h6>Courses in this Order:</h6>
            {loadingCourses ? (
              <p>Loading courses...</p>
            ) : courses.length > 0 ? (
              <ul>
                {courses.map((course, index) => (
                  <li key={index}>
                    <strong>{course.title}</strong> - {course.price} TL
                  </li>
                ))}
              </ul>
            ) : (
              <p>No courses found for this order.</p>
            )}
          </ModalBody>
          <Button color="secondary" onClick={toggleModal}>Close</Button>
        </Modal>
      )}
    </div>
  );
}

export default OrdersTable;