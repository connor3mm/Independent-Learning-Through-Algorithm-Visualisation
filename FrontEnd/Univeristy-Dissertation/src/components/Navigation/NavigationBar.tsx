import React, { useState } from "react";
import { Link } from "react-router-dom";
import "./NavigationBar.css";
import LogoutAlerts from "../LogOutAlert/LogOutAlert";

// Interface for NavigationBarProps
interface NavigationBarProps {
  isLoggedIn: boolean;
  handleLogout: () => void;
}

// NavigationBar functional component
const NavigationBar: React.FC<NavigationBarProps> = ({
  isLoggedIn,
  handleLogout,
}) => {
  // State for controlling logout alert dialog visibility
  const [isLogoutAlertOpen, setIsLogoutAlertOpen] = useState(false);

  const handleLogoutClick = () => {
    setIsLogoutAlertOpen(true);
  };

  const handleLogoutConfirm = () => {
    setIsLogoutAlertOpen(false);
    handleLogout();
  };

  const handleLogoutCancel = () => {
    setIsLogoutAlertOpen(false);
  };

  // Rendering NavigationBar component
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
            <Link to="/learningZone">Learning Zone</Link>
          </li>
          <li>
            <Link to="/testingZone">Testing Zone</Link>
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
              <li className="rightButton" onClick={handleLogoutClick}>
                <Link to="">Logout</Link>
              </li>
            </>
          )}
          <LogoutAlerts
            open={isLogoutAlertOpen}
            onConfirm={handleLogoutConfirm}
            onCancel={handleLogoutCancel}
          />
        </div>
      </ul>
    </nav>
  );
};

export default NavigationBar;
