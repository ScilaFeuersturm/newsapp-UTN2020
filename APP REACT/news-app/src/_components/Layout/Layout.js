import React, { useContext } from "react";
import { useHistory } from "react-router-dom";
import { isAuthenticated, logout } from "../../services/users";
import BackButton from "../BackButton/BackButton"
import Navbar from "../Navbar/Navbar";
import Footer from "../Footer/Footer";


export function Layout({ props, children }) {
  const history = useHistory();
  const handleLogout = () => {
    logout();
    history.push("/login");
  };
  //No renderiza cuando se le agregan navbar y footer
  //Tampoco sin ellos, consultar

  return (
    <>
    <BackButton />
    <Navbar/>
    {isAuthenticated() && <button onClick={handleLogout}>Salir</button>}
    {children}
  </>
  );
}
