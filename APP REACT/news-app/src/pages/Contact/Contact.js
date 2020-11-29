import React from 'react';
import NavigationBar from '../../_components/Navbar/Navbar'
import Footer from '../../_components/Footer/Footer'
import "../Contact/Contact.css"

/* Diseño : Ver el margen, está quedand muy pegado al navbar */
const Contact = () => {

    return(
        <div>
        <NavigationBar/>
        <div className="Contact">
        <form>
        <div className="form-group">
          <label>Nombre y apellido</label>
          <input className="form-control" placeholder="Nombre"></input>
        </div>
        <div className="form-group">
          <label>Dirección de mail</label>
          <input type="email" className="form-control" placeholder="mail@mail.com"></input>
        </div>
        <div className="form-group">
          <label>Numero de teléfono</label>
          <input className="form-control" placeholder="11111111111"></input>
        </div>
        <div className="form-group">
          <label>Dirección de mail</label>
          <textarea className="form-control" rows="5" ></textarea>
        </div>
        </form>
        <button className="btn btn-primary">Enviar tus datos</button>
      </div>
      <Footer/>
        </div>
    );
}
export default Contact;