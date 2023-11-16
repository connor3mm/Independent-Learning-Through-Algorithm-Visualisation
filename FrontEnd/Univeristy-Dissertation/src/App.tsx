import "./App.css";
import styled from "styled-components";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Home from "./Pages/Home/Home"; 
import SortingVisualiser from "./Pages/SortingVisualiser/SortingVisualiser"; 

const AppContainer = styled.div`
  width: 100%;
  height: 100%;
`;

function App() {
  return (
    <AppContainer>
      <Router>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/sortingVisualiser" element={<SortingVisualiser />} />
        </Routes>
      </Router>
    </AppContainer>
  );
}

export default App;