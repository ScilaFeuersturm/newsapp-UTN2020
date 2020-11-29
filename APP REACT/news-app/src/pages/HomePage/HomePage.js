import React from 'react';
import { Link } from 'react-router-dom';

/*Diseño una introducción a la página, con lorem ipsum. */

const HomePage = () => {
  return (
    <>
      <h1>Lorem ipsum dolor sit amet, consectetur adipiscing elit</h1>
      <Link to="/login">Login</Link>
    </>
  );
}

export default HomePage;