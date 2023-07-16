/* eslint-disable @typescript-eslint/no-unsafe-assignment */
import React from 'react';
import { Link } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faTachometerAlt, faUser } from '@fortawesome/free-solid-svg-icons';

const TopNavbar: React.FC = () => {
    return (
        <nav className="navbar navbar-expand-lg navbar-light bg-light">
            <div className="container">

                <button
                    className="navbar-toggler"
                    type="button"
                    data-bs-toggle="collapse"
                    data-bs-target="#navbarNav"
                    aria-controls="navbarNav"
                    aria-expanded="false"
                    aria-label="Toggle navigation"
                >
                    <span className="navbar-toggler-icon"></span>
                </button>

                <div className="collapse navbar-collapse" id="navbarNav">
                    <ul className="navbar-nav ml-auto">
                        <li className="nav-item">
                            <Link to="/" className="nav-link">
                                <FontAwesomeIcon icon={faTachometerAlt} /> Dashboard
                            </Link>
                        </li>
                        <li className="nav-item">
                                <Link to="/new-client" className="nav-link">
                                    <FontAwesomeIcon icon={faUser} /> Add Client
                                </Link>
                                
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    );
};

export default TopNavbar;