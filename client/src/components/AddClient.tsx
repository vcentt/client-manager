import React, { useState } from 'react';
import { Alert, Button, Form } from 'react-bootstrap';
import axios from 'axios';
import { IClientDetails } from '../utils/Interfaces';
import './AddClient.css'

export function AddClient() {
    const [success, setSuccess] = useState(false);
    const [error, setError] = useState(false);
    const [client, setClient] = useState<IClientDetails>({
        clientId: 0,
        firstName: '',
        lastName: '',
        email: '',
        address: {
            clientId: 0,
            country: '',
            streetAddress: '',
            city: '',
            zip: 0
        },
        profile: {
            clientId: 0,
            age: 0,
            gender: '',
            maritalStatus: ''
        }
    });

    const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();

        axios.post('https://clientsmanager.azurewebsites.net/Client', client)
            .then(response => {
                console.log(response.data);
                setSuccess(true);
                setClient({
                    clientId: 0,
                    firstName: '',
                    lastName: '',
                    email: '',
                    profile: {
                        clientId: 0,
                        age: 0,
                        gender: '',
                        maritalStatus: '',
                    },
                    address: {
                        clientId: 0,
                        country: '',
                        streetAddress: '',
                        city: '',
                        zip: 0,
                    },
                });
            })
            .catch(error => {
                console.error(error);
                setError(true);
            });
    };

    return (
        <div className="form-container">
            <h3><center>Create Client</center></h3>
            <Form onSubmit={handleSubmit}>
                <div className="form-row">
                    <div className="form-column">
                        <h5>Cliente</h5>
                        <Form.Group>
                            <Form.Label>First Name</Form.Label>
                            <Form.Control
                                type="text"
                                placeholder="Enter the first name"
                                value={client.firstName}
                                onChange={(e) => setClient({ ...client, firstName: e.target.value })}
                                className="form-control"
                            />
                        </Form.Group>
                        <Form.Group>
                            <Form.Label>Last Name</Form.Label>
                            <Form.Control
                                type="text"
                                placeholder="Enter the last name"
                                value={client.lastName}
                                onChange={(e) => setClient({ ...client, lastName: e.target.value })}
                                className="form-control"
                            />
                        </Form.Group>
                        <Form.Group>
                            <Form.Label>Email</Form.Label>
                            <Form.Control
                                type="email"
                                placeholder="Enter the email"
                                value={client.email}
                                onChange={(e) => setClient({ ...client, email: e.target.value })}
                                className="form-control"
                            />
                        </Form.Group>
                    </div>

                    <div className="form-column">
                        <h5>Profile</h5>
                        <Form.Group>
                            <Form.Label>Age</Form.Label>
                            <Form.Control
                                type="number"
                                placeholder="Enter the age"
                                value={client.profile.age !== null ? client.profile.age : ""}
                                onChange={(e) =>
                                    setClient({
                                        ...client,
                                        profile: { ...client.profile, age: e.target.value !== "" ? parseInt(e.target.value) : 0 }
                                    })
                                }
                                className="form-control"
                            />
                        </Form.Group>
                        <Form.Group>
                            <Form.Label>Gender</Form.Label>
                            <Form.Control
                                type="text"
                                placeholder="Enter the gender"
                                value={client.profile.gender}
                                onChange={(e) => setClient({ ...client, profile: { ...client.profile, gender: e.target.value } })}
                                className="form-control"
                            />
                        </Form.Group>
                        <Form.Group>
                            <Form.Label>Marital Status</Form.Label>
                            <Form.Control
                                type="text"
                                placeholder="Enter the marital status"
                                value={client.profile.maritalStatus}
                                onChange={(e) => setClient({ ...client, profile: { ...client.profile, maritalStatus: e.target.value } })}
                                className="form-control"
                            />
                        </Form.Group>
                    </div>

                    <div className="form-column">
                        <h5>Address</h5>
                        <Form.Group>
                            <Form.Label>Country</Form.Label>
                            <Form.Control
                                type="text"
                                placeholder="Enter the country"
                                value={client.address.country}
                                onChange={(e) => setClient({ ...client, address: { ...client.address, country: e.target.value } })}
                                className="form-control"
                            />
                        </Form.Group>
                        <Form.Group>
                            <Form.Label>Street Address</Form.Label>
                            <Form.Control
                                type="text"
                                placeholder="Enter the street address"
                                value={client.address.streetAddress}
                                onChange={(e) => setClient({ ...client, address: { ...client.address, streetAddress: e.target.value } })}
                                className="form-control"
                            />
                        </Form.Group>
                        <Form.Group>
                            <Form.Label>City</Form.Label>
                            <Form.Control
                                type="text"
                                placeholder="Enter the city"
                                value={client.address.city}
                                onChange={(e) => setClient({ ...client, address: { ...client.address, city: e.target.value } })}
                                className="form-control"
                            />
                        </Form.Group>
                        <Form.Group>
                            <Form.Label>Zip</Form.Label>
                            <Form.Control
                                type="number"
                                placeholder="Enter the zip"
                                value={isNaN(client.address.zip) ? "" : client.address.zip}
                                onChange={(e) => setClient({ ...client, address: { ...client.address, zip: parseInt(e.target.value) || 0 } })}
                                className="form-control"
                            />
                        </Form.Group>
                    </div>
                </div>
                <div className="text-center">
                    <Button variant="primary" type="submit">
                        Create
                    </Button>
                </div>
                {success && (
                    <Alert variant="success" className="mt-3">
                        Successfully sent the form.
                    </Alert>
                )}

                {error && (
                    <Alert variant="danger" className="mt-3">
                        Error occurred while sending the form.
                    </Alert>
                )}
            </Form>

        </div>
    );



}
