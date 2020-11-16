import React from 'react';
import { Link, Route, BrowserRouter as Router, Switch } from "react-router-dom";
import "../Navbar/Navbar.css";



export default function NavigationBar(){
    return(
    <div className="topnav">
      <Link to="/news">Noticias</Link>
      <Link to="/contact">Contacto</Link>
      <Link to="/login">Login</Link>
      <Link to="/manage-news">Manage News</Link>
      <Link to="/manage-contact">Manage Contact</Link>
  </div>
    );
}