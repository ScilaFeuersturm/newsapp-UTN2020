import React from "react";
import { useHistory } from "react-router-dom";

const BackButton = () => {
  const history = useHistory();
  const goBack = () => history.goBack();

  return (
    <div style={{ textAlign: "start" }}>
      <button className="backButton" type="button" onClick={goBack}>
        {" "}
        Volver
      </button>
    </div>
  );
};

export default BackButton;
