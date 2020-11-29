import React from "react";
import { Route, Redirect } from "react-router-dom";
import { isAuthenticated } from "../../services/users";

function PublicRoute({ component: Component, ...rest }) {
  return (
    <Route
      {...rest}
      render={(props) =>
        !isAuthenticated() ? (
          <Component {...props} />
        ) : (
          <Redirect to={{ pathname: "/" }} />
        )
      }
    />
  );
}

export default PublicRoute;
