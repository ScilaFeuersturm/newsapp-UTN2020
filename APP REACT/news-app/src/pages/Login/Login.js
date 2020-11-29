import React, { useState } from "react";
import { Link, useHistory } from 'react-router-dom';
import "../Login/Login.css"
import { login } from '../../services/users';
import Navbar from "../../_components/Navbar/Navbar";
import Footer from "../../_components/Footer/Footer";


const Login= () => {
  const history = useHistory();
  const [email, setEmail] = useState('');
  const [emailError, setEmailError] = useState('');
  const [password, setPassword] = useState('');

  const handleSubmit = async (e) => {
    e.preventDefault();
    const response = await login(email, password);
    if(response.status) {
      history.push('/news');
      console.log(response.status)
    }else{
      console.log(response.status)
    }
  }
  

  const handleChange = (event) => {
    setEmail(event.target.value);
    if(event.target.value.length < 4) {
      setEmailError('El mail debe tener minimo de 4 letras');
    } else {
      setEmailError('');
    }
  }
  /* Diseño : Ver el margen, está quedando muy pegado al navbar */

    return (
      <>
      <Navbar/>
      <h2>Login</h2>
      <form onSubmit={handleSubmit}>
        <input className={emailError ? 'invalid' : ''} type="email" value={email} onChange={handleChange} placeholder="Email" />
        <span>{emailError}</span>
        <input type="password" value={password} onChange={(e) => setPassword(e.target.value)} placeholder="Password" />
        <input type="submit" value="Ingresar!"/>
      </form>
        <Link to={'/register'} >
          Registrate!
        </Link>
     <Footer/>   
    </>
    );
  }

export default Login;