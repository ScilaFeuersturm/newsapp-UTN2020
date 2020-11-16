import React from "react";
import "../Footer/Footer.css";
import facebook_icon from '../../assets/icons/facebook_icon.png'
import Instagram_icon from '../../assets/icons/Instagram_icon.png'
import twitter_icon from '../../assets/icons/twitter_icon.png'

const Footer = () => (
  <div className="footer">
    <div>
      <div >
      <p>Siguenos en nuestras redes sociales</p>
      <a href="http://facebook.com">
      <img className="icons" src={facebook_icon} />
    </a>
    <a  href="http://www.instagram.com">
      <img className="icons" src={Instagram_icon}/>
    </a>
    <a href="http://www.twitter.com">
      <img className="icons" src={twitter_icon}/>
    </a>
    </div>
    </div>
  </div>
);

export default Footer;