import React from "react";
import "../News/News.css";
import NavigationBar from '../Navbar/Navbar'
import Footer from '../Footer/Footer'


const News = () => (
    <>
    <NavigationBar></NavigationBar>
    <div>
      <h1>Página de noticias</h1>
    </div>
    <div>
    <Footer/>
    </div>
    
  </>
);

export default News;