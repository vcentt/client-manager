import React from 'react';
import { Link } from 'react-router-dom';

const Navbar: React.FC = () => {
    return (
        <nav className="navbar navbar-light bg-dark">
          <div className="container">
            <Link to="/" className="navbar-brand">
              
                MANAGEMENT CLIENTS
            </Link>
          </div>
        </nav>
      );
};

export default Navbar