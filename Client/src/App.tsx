import React from "react";
import "./App.css";
import { Register } from "./components/Register";
import { Login } from "./components/Login";

function App() {
  return (
 
      <div className="App">
        <h1>REGISTER</h1>
        <Register />
        <br></br>
        <h1>LOGIN</h1>
        <Login />
      </div>
  );
}

export default App;
