import { useState } from "react";
import { Routes, Route } from "react-router";
import "./App.css";
import { StreamerView } from "./Pages/StreamerView";

function App() {
  const [count, setCount] = useState(0);

  return (
    <>
      <Routes>
        <Route path="/" element={<StreamerView />} />
      </Routes>
    </>
  );
}

export default App;
