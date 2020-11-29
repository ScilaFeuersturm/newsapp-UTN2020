import React from 'react';
import {Link} from "react-router-dom";


const NotFound = () => {
  return (
    <div>
        <h1>La página que usted busca no existe</h1>
        <Link to="/">Volver al inicio</Link>
    </div>

  );
}

export default NotFound;