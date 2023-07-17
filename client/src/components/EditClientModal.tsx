/* eslint-disable @typescript-eslint/no-unsafe-assignment */
/* eslint-disable @typescript-eslint/no-unsafe-member-access */
/* eslint-disable @typescript-eslint/no-floating-promises */
/* eslint-disable @typescript-eslint/no-unsafe-argument */
import React, { useEffect, useState } from 'react';
import { Button, Form, Modal, Alert } from 'react-bootstrap';
import axios from 'axios';
import { IClientDetails } from '../utils/Interfaces';
import './AddClient.css';

type Props = {
    clientId: number;
    handleCloseModal: () => void;
    showModal: boolean;
};

export function EditClientModal({ showModal, handleCloseModal, clientId }: Props) {
    const [clientDetails, setClientDetails] = useState<IClientDetails>({} as IClientDetails);
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
          zip: 0,
        },
        profile: {
          clientId: 0,
          age: 0,
          gender: '',
          maritalStatus: '',
        },
      });
    
      useEffect(() => {
        getDetails(clientId);
      }, [clientId]);
    
      useEffect(() => {
        setClient((prevClient) => ({
          ...prevClient,
          clientId: clientDetails?.clientId || 0,
          firstName: clientDetails?.firstName || '',
          lastName: clientDetails?.lastName || '',
          email: clientDetails?.email || '',
          address: {
            ...prevClient.address,
            clientId: clientDetails?.clientId || 0,
            country: clientDetails?.address?.country || '',
            streetAddress: clientDetails?.address?.streetAddress || '',
            city: clientDetails?.address?.city || '',
            zip: clientDetails?.address?.zip || 0,
          },
          profile: {
            ...prevClient.profile,
            clientId: clientDetails?.clientId || 0,
            age: clientDetails?.profile?.age || 0,
            gender: clientDetails?.profile?.gender || '',
            maritalStatus: clientDetails?.profile?.maritalStatus || '',
          },
        }));
      }, [clientDetails]);

    const getDetails = async (clientId: number) => {
        try {
            const response = await axios.get(`http://clientsmanager.azurewebsites.net/Client/${clientId}`);
            setClientDetails(response.data);   
        } catch (error) {
            console.error('Error al obtener los detalles del cliente:', error);
        }
    };
    console.log(clientDetails);

    const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();

        axios
            .put('http://clientsmanager.azurewebsites.net/Client', client)
            .then((response) => {
                console.log(response.data);
                setSuccess(true);
                setTimeout(() => {
                    setSuccess(false);
                    handleCloseModal();
                }, 2000);
            })
            .catch((error) => {
                console.error(error);
                setError(true);
            });
    };

    return (
        <Modal show={showModal} onHide={handleCloseModal} centered>
            <Modal.Header closeButton>
                <Modal.Title>Edit Client</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <Form onSubmit={handleSubmit}>
                    <Form.Group>
                        <Form.Label>First Name</Form.Label>
                        <Form.Control
                            type="text"
                            placeholder="Enter the first name"
                            value={client.firstName}
                            onChange={(e) => setClient({ ...client, firstName: e.target.value })}
                        />
                    </Form.Group>
                    <Form.Group>
                        <Form.Label>Last Name</Form.Label>
                        <Form.Control
                            type="text"
                            placeholder="Enter the last name"
                            value={client.lastName}
                            onChange={(e) => setClient({ ...client, lastName: e.target.value })}
                        />
                    </Form.Group>
                    <Form.Group>
                        <Form.Label>Email</Form.Label>
                        <Form.Control
                            type="email"
                            placeholder="Enter the email"
                            value={client.email}
                            onChange={(e) => setClient({ ...client, email: e.target.value })}
                        />
                    </Form.Group>

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

                    <div className="text-center">
                        <Button variant="primary" type="submit">
                            Send
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
            </Modal.Body>
        </Modal>
    );
}
