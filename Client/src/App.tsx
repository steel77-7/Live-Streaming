import { useState } from "react";
import { Routes, Route } from "react-router";
import "./App.css";
import { StreamerView } from "./Pages/StreamerView";
import { UserView } from "./Pages/UserView";


function App() {
  return (
    <>
      <Routes>
        <Route path="/" element={<StreamerView />} />
        <Route path="/user" element={<UserView />} />
      </Routes>
    </>
  );
}

export default App;
