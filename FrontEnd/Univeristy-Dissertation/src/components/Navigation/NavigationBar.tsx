import React from 'react';
import { Link } from 'react-router-dom';
import './NavigationBar.css';

interface NavigationBarProps {
  isLoggedIn: boolean;
  handleLogout: () => void;
}

const NavigationBar: React.FC<NavigationBarProps> = ({ isLoggedIn, handleLogout }) => {
  return (
    <nav>
      <ul className="navbar">
        <li><Link to="/">Home</Link></li>
        <li><Link to="/sortingVisualiser">Sorting Visualiser</Link></li>
        {!isLoggedIn && (
          <>
            <li className='rightButton'><Link to="/register">Register</Link></li>
            <li className='rightButton'><Link to="/login">Login</Link></li>
          </>
        )}
        {isLoggedIn && (
          <>
          <li className='rightButton'><Link to="/profile">Profile</Link></li>
          <li className='rightButton' onClick={handleLogout}>
            <Link to="/">Logout</Link>
          </li>
          </>
        )}
      </ul>
    </nav>
  );
};

export default NavigationBar;
