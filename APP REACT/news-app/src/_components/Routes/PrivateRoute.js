import React from "react";
import { Route, Redirect } from "react-router-dom";
import { isAuthenticated } from "../../services/users";
import { Layout } from "../Layout/Layout";

function PrivateRoute({ component: Component, ...rest }) {
  console.log('Auth', isAuthenticated());
  return (
    <Route
      {...rest}
      render={(props) =>
        isAuthenticated() ? (
          <Layout>
            <Component {...props} />
          </Layout>
        ) : (
          <Redirect
            to={{ pathname: "/login", state: { from: props.location } }}
          />
        )
      }
    />
  );
}

export default PrivateRoute;
