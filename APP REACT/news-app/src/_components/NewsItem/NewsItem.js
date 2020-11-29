import React, { useState } from "react";
import { Link } from "react-router-dom";
import styles from "./NewsItem.css";

/*Por ahora que se muestren los títulos, después se arma la página completa, seguir modelo de la app de hipódromo */

const NewsItem = (props) => {
  return (
    <li>
        <h1>{props.title}</h1>
    </li>
  );
};

export default NewsItem;