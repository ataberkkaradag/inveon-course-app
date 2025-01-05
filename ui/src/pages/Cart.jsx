import React, { useState } from "react";
import {
  Container,
  Row,
  Col,
  Form,
  FormGroup,
  Label,
  Input,
  Button,
  Card,
  CardBody,
  CardTitle,
  CardText,
  ListGroup,
  ListGroupItem,
} from "reactstrap";
import { useCart } from '../context/CartContext';
import { axiosInstance } from "../api/api";
import alertify from "alertifyjs";
import { useNavigate } from "react-router-dom";





function Cart() {
  const { cart, removeFromCart, getTotalPrice, clearCart } = useCart();
  const [paymentDetails, setPaymentDetails] = useState({
    cardNumber: '',
    cardHolder: '',
    expirationDate: '',
    cvv: '',
  });
  const navigate=useNavigate();
  console.log(cart)

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setPaymentDetails({ ...paymentDetails, [name]: value });
  };

  const handleRemoveFromCart = (id) => {
    removeFromCart(id);
  };

  const handlePayment = async (e) => {
    e.preventDefault();
    const orderData = {
      userId: localStorage.getItem('userId'),
      courseIds: cart.map((course) => course.id),
    };


   try {
      // Create Order API request
      const orderResponse = await axiosInstance.post('/order', orderData);
      console.log(orderResponse)
      const order = orderResponse.data;

      // Create Payment API request
      const paymentData = {
        orderId: order.id,
        price: getTotalPrice(),
      };

      await axiosInstance.post('/payment', paymentData);
         navigate("/")
      
      alertify.success('Payment successful!');
      clearCart(); 
    } catch (error) {
      console.error('Error during checkout process', error);
      alertify.error('Cart is Empty or your credit card info is incorrect ')
    }
  };

  const formatTotalPrice = (price) => {
    return price.toFixed(2); 
  };

  return (
    <Container>
      <Row className="mt-4">
        
        <Col md="6">
          <h4>Payment Details</h4>
          <Form onSubmit={handlePayment}>
            <FormGroup>
              <Label for="cardNumber">Card Number</Label>
              <Input
                type="text"
                name="cardNumber"
                id="cardNumber"
                placeholder="Enter card number"
                value={paymentDetails.cardNumber}
                onChange={handleInputChange}
                required
              />
            </FormGroup>
            <FormGroup>
              <Label for="cardHolder">Card Holder Name</Label>
              <Input
                type="text"
                name="cardHolder"
                id="cardHolder"
                placeholder="Enter card holder name"
                value={paymentDetails.cardHolder}
                onChange={handleInputChange}
                required
              />
            </FormGroup>
            <FormGroup>
              <Label for="expirationDate">Expiration Date</Label>
              <Input
                type="month"
                name="expirationDate"
                id="expirationDate"
                value={paymentDetails.expirationDate}
                onChange={handleInputChange}
                required
              />
            </FormGroup>
            <FormGroup>
              <Label for="cvv">CVV</Label>
              <Input
                type="password"
                name="cvv"
                id="cvv"
                placeholder="Enter CVV"
                value={paymentDetails.cvv}
                onChange={handleInputChange}
                required
              />
            </FormGroup>
            <Button color="success" block>
              Pay Now
            </Button>
          </Form>
        </Col>

        
        <Col md="6">
          <h4>Cart</h4>
          <Card>
            <CardBody>
              <CardTitle tag="h5">Your Selected Courses</CardTitle>
              <ListGroup>
                {cart.length === 0 ? (
                  <CardText className="text-muted">Your cart is empty.</CardText>
                ) : (
                  cart.map((item) => ( 
                    <ListGroupItem key={item.id} className="d-flex justify-content-between align-items-center">
                      <div>
                        <strong>{item.title}</strong>
                        <br />
                        <span>{item.price} TL</span>
                      </div>
                      <Button color="danger" size="sm" onClick={() => handleRemoveFromCart(item.id)}>
                        Remove
                      </Button>
                    </ListGroupItem>
                  ))
                )}
              </ListGroup>
              {cart.length > 0 && (
                <div className="mt-3 text-end">
                  <strong>Total:</strong> {formatTotalPrice(getTotalPrice())}TL
                </div>
              )}
            </CardBody>
          </Card>
        </Col>
      </Row>
    </Container>
  );
}
export default Cart