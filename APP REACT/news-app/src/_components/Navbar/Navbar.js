import React from 'react';
import { Link, Route, BrowserRouter as Router, Switch } from "react-router-dom";
import "../Navbar/Navbar.css";
import PublicRoute from "../../_components/Routes/PublicRoute";
import {Login,Register,News,HomePage} from "../../pages/index";

/*Ver cómo se puede mejorar esto. 
Hay links que solamente van a poder mostrarse si se está logueado, se puede agregar un link adicional? Consultar*/

const NavigationBar = () => {
    return(  
    <div className="topnav">
      <Link to="/news">Noticias</Link>
      <Link to="/contact">Contacto</Link>
      <Link to="/login">Login</Link>
    </div>
    );
}

export default NavigationBar;