import "./App.css";
import styled from "styled-components";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Home from "./Pages/Home/Home"; 
import SortingVisualiser from "./Pages/SortingVisualiser/SortingVisualiser"; 
import NavigationBar from './components/Navigation/NavigationBar'
import Login from './Pages/Login/Login'
import Register from './Pages/Register/Register'

const AppContainer = styled.div`
  width: 100%;
  height: 100%;
`;

function App() {
  return (
    <AppContainer>
      <Router>
      <div>
        <NavigationBar />
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/sortingVisualiser" element={<SortingVisualiser />} />
          <Route path="/login" element={<Login />} />
          <Route path="/register" element={<Register />} />
        </Routes>
        </div>
      </Router>
    </AppContainer>
  );
}

export default App;