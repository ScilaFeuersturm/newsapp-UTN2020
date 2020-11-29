import React, { Fragment, useEffect, useState } from "react";
import "../News/News.css";
import Loader from '../../_components/Loader/Loader'
import {getNews, getNewsList} from '../../services/Services';
import NewsItem from "../../_components/NewsItem/NewsItem";
import Navbar from "../../_components/Navbar/Navbar"
import Footer from "../../_components/Footer/Footer";


/* La edición se puede manejar en la misma página o es necesario crear una página diferente para la gestion de las mismas? */
const News = ({ header, history }) => {
  return (
    <div>
      <Navbar/>
      <h1>Hola desde noticias</h1>
      <Footer/>
    </div>
  );
  }

export default News;