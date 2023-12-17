import { Link } from 'react-router-dom';
import './NavigationBar.css';

const NavigationBar = () => {
  return (
    <nav>
      <ul className="navbar">
        <li><Link to="/">Home</Link></li>
        <li><Link to="/sortingVisualiser">Sorting Visualiser</Link></li>
        <li className='rightButton'><Link to="/register">Register</Link></li>
        <li className='rightButton'><Link to="/login">Login</Link></li>
      </ul>
    </nav>
  );
};

export default NavigationBar;
