import "./App.css";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Home from "./pages/Home/Home";
import SortingVisualiser from "./pages/SortingVisualiser/SortingVisualiser";
import NavigationBar from "./components/Navigation/NavigationBar";
import Login from "./pages/Login/Login";
import Register from "./pages/Register/Register";
import Profile from "./pages/Profile/Profile";
import { useEffect, useState } from "react";
import LearningZone from "./pages/LearningZone/LearningZone";
import TestingZone from "./pages/TestingZone/TestingZone";

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  const handleLogin = () => {
    setIsLoggedIn(true);
  };

  const handleLogout = () => {
    setIsLoggedIn(false);
    localStorage.removeItem("loggedInUser");
  };

  useEffect(() => {
    const loggedInUser = localStorage.getItem("loggedInUser");
    if (loggedInUser) {
      handleLogin();
    }
  }, []);

  return (
    <div className="AppContainer">
      <Router>
        <div>
          <NavigationBar isLoggedIn={isLoggedIn} handleLogout={handleLogout} />
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/sortingVisualiser" element={<SortingVisualiser />} />
            <Route path="/learningZone" element={<LearningZone />} />
            <Route path="/testingZone" element={<TestingZone />} />
            {!isLoggedIn && (
              <>
                <Route
                  path="/login"
                  element={<Login handleLogin={handleLogin} />}
                />
                <Route path="/register" element={<Register />} />
              </>
            )}
            <Route path="/profile" element={<Profile />} />
          </Routes>
        </div>
      </Router>
    </div>
  );
}

export default App;
