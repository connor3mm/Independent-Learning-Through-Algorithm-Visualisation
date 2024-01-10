import React from "react";
import { Link } from "react-router-dom";
import "./NavigationBar.css";

interface NavigationBarProps {
  isLoggedIn: boolean;
  handleLogout: () => void;
}

const NavigationBar: React.FC<NavigationBarProps> = ({
  isLoggedIn,
  handleLogout,
}) => {
  return (
    <nav>
      <ul className="navbar">
        <div className="firstNavSection">
          <li>
            <Link to="/">Home</Link>
          </li>
          <li>
            <Link to="/sortingVisualiser">Sorting Visualiser</Link>
          </li>
          <li>
            <Link to="/sortingVisualiser">Learning</Link>
          </li>
          <li>
            <Link to="/sortingVisualiser">Testing</Link>
          </li>
        </div>

        <div className="secondNavSection">
          {!isLoggedIn && (
            <>
              <li className="rightButton">
                <Link to="/register">Register</Link>
              </li>
              <p> | </p>
              <li className="rightButton">
                <Link to="/login"> Login</Link>
              </li>
            </>
          )}
          {isLoggedIn && (
            <>
              <li className="rightButton">
                <Link to="/profile">Profile</Link>
              </li>
              <p> | </p>
              <li className="rightButton" onClick={handleLogout}>
                <Link to="/">Logout</Link>
              </li>
            </>
          )}
        </div>
      </ul>
    </nav>
  );
};

export default NavigationBar;
