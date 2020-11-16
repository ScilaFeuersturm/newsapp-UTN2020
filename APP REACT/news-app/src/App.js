import React from "react";
import "./App.css";
import { Link, Route, BrowserRouter as Router, Switch , Redirect} from "react-router-dom";
import Login from './_components/Login/Login'
import NavigationBar from './_components/Navbar/Navbar'
import Footer from './_components/Footer/Footer'
import News from './_components/News/News'
import Contact from './_components/Contact/Contact'



function HomePage() {
  return (
    <>
      <NavigationBar></NavigationBar>
      <div>
        <h1>Welcome at Berkshire Country's news page</h1>
      </div>
      <div>
      <Footer/>
      </div>
      
    </>
  );
}
function NotFound() {
  return <h1>No se encontro lo que buscaba...</h1>;
}

function App () {
    return (
      <div className="App">
      <Router>
        <Switch>
        <Route exact path="/">
            <HomePage/>
          </Route>
          <Route exact path="/news">
            <News/>
          </Route>
          <Route exact path="/contact">
            <Contact/>
          </Route>
          <Route exact path="/login">
            <Login />
          </Route>

          <Route exact path="/manage-news">
          <Contact/>
          </Route>
          <Route exact path="/manage-contact">
          <Contact/>
          </Route>


          <Route path="*">
            <NotFound />
          </Route>
        </Switch>
      </Router>
    </div>

    );
}


export default App;
