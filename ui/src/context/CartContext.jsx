import React, { createContext, useState, useContext, useEffect } from 'react';
import alertify from 'alertifyjs';
const CartContext = createContext();

export const useCart = () => {
  return useContext(CartContext);
};

export const CartProvider = ({ children }) => {
  const [cart, setCart] = useState(() => {
    // localStorage'dan cart durumunu yükle
    const savedCart = localStorage.getItem('cart');
    return savedCart ? JSON.parse(savedCart) : [];
  });

  // Sepet güncellenince localStorage'a kaydet
  useEffect(() => {
    localStorage.setItem('cart', JSON.stringify(cart));
  }, [cart]);

  const addToCart = (course) => {
    const isCourseInCart = cart.some((item) => item.id === course.id);
    if (isCourseInCart) {
      alertify.error("This course is already in your cart!");
    } else {
      setCart((prevCart) => [...prevCart, course]);
      alertify.success("Course successfully added to cart!");
    }
  };

  const removeFromCart = (id) => {
    setCart((prevCart) => prevCart.filter((item) => item.id !== id));
  };

  const getTotalPrice = () => {
    return cart.reduce((total, item) => total + item.price, 0);
  };

  const clearCart = () => {
    setCart([]);
  };

  return (
    <CartContext.Provider value={{ cart, addToCart, removeFromCart, getTotalPrice, clearCart }}>
      {children}
    </CartContext.Provider>
  );
};