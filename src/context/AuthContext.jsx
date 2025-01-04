import React, { createContext, useState, useEffect } from "react";
import { jwtDecode } from 'jwt-decode';
import { Navigate, useNavigate } from "react-router-dom";

const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
    const [isAuthenticated, setIsAuthenticated] = useState(false);
    const [user, setUser] = useState(null);
    
   

    useEffect(() => {
        const token = localStorage.getItem("token");
        if (token) {
            try {
                const decoded = jwtDecode(token);
                if (decoded.exp * 1000 > Date.now()) {
                    setUser(decoded);
                    setIsAuthenticated(true);
                } else {
                    localStorage.removeItem("token"); 
                }
            } catch (error) {
                console.error("Invalid token");
                localStorage.removeItem("token");
            }
        }
    }, []);

    const login = (token) => {
        localStorage.setItem("token", token);
        
        const decoded = jwtDecode(token);
        
        setUser(decoded);
        setIsAuthenticated(true);
        localStorage.setItem("userId",decoded.sub);
    };

    const logout = () => {
        localStorage.removeItem("token");
        setUser(null);
        setIsAuthenticated(false);
       
        
    };

    return (
        <AuthContext.Provider value={{ isAuthenticated, user, login, logout }}>
            {children}
        </AuthContext.Provider>
    );
};

export default AuthContext;