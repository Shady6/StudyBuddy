import React from "react";
import "./App.css";

import { Switch, Route } from "react-router-dom";

import  Profile from "./components/Profile";
import { Home } from "./components/Home";

function App() {
  return (
 
      <div className="App">
        <Switch>
          <Route path="/" exact component={Home} />
          <Route path="/profile" component={Profile} />
        </Switch>
      </div>
  );
}

export default App;
