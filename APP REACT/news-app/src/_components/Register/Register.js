
import React, { useState } from "react";
import NavigationBar from '../Navbar/Navbar'
import "../Register/Register.css"
import Footer from '../Footer/Footer'


export default function Login() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
  
    function validateForm() {
      return email.length > 0 && password.length > 0;
    }
  
    function handleSubmit(event) {
      event.preventDefault();
    }
  
    return (
      <div>
        <NavigationBar></NavigationBar>
      <div className="Register">
        <form onSubmit={handleSubmit}>
          <div className="form-group">
            <label>Email</label>
            <input type="email" className="form-control" aria-describedby="emailHelp" placeholder="Enter your email"></input>
          </div>
          <div className="form-group">
            <label>Password</label>
            <input className="form-control" placeholder="Password"></input>
          </div>
          <button className="btn btn-primary">Registrar</button>
        </form>
      </div>
      <Footer></Footer>
      </div>
    );
  }