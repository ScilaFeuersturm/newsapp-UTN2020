import React from "react";
import "./App.css";
import { Link, Route, BrowserRouter as Router, Switch , Redirect} from "react-router-dom";
import PublicRoute from "./_components/Routes/PublicRoute";
import PrivateRoute from "./_components/Routes/PrivateRoute"; 
import {Login,Register,News,HomePage, Contact,NewsManagement} from "./pages/index";

function App () {
    return (
      <div className="App">
      <Router>
        <Switch>
          <PublicRoute path= "/login" exact component = {Login}/>
          <PublicRoute path ="/register" exact component = {Register} />
          <PublicRoute path="/news" exact component = {News} />
          <PublicRoute path="/contact" exact component = {Contact} />
          <PrivateRoute path="/management" exact component = {NewsManagement}/>
          <Route exact path="/" component = {HomePage} />
        </Switch>
      </Router>
    </div>

    );
}


export default App;
