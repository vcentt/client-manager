/* eslint-disable @typescript-eslint/no-misused-promises */
/* eslint-disable @typescript-eslint/no-floating-promises */
/* eslint-disable @typescript-eslint/restrict-template-expressions */
/* eslint-disable @typescript-eslint/no-unsafe-assignment */
/* eslint-disable @typescript-eslint/no-unsafe-member-access */
/* eslint-disable @typescript-eslint/no-unsafe-argument */
import { useState, useEffect } from 'react';
import axios from 'axios';
import { FaEdit, FaTrash, FaInfoCircle } from 'react-icons/fa';
import { Alert } from 'react-bootstrap';
import { IClient, IClientDetails } from '../utils/Interfaces';
import { EditClientModal } from './EditClientModal';

const InvoiceList = () => {
  const [clients, setClients] = useState<IClient[]>([]);
  const [clientDetails, setClientDetails] = useState<IClientDetails>();
  const [modalOpen, setModalOpen] = useState(false);
  const [getId, setGetId] = useState<number>();

  useEffect(() => {
    getClients();
  }, []);

  const getClients = async () => {
    try {
      const response = await axios.get('https://clientsmanager.azurewebsites.net/Client/All-Clients');
      setClients(response.data);
    } catch (error) {
      console.error('Error al obtener los clientes:', error);
    }
  };

  const handleViewDetails = async (clientId: number) => {
    try {
      const response = await axios.get(`https://clientsmanager.azurewebsites.net/Client/${clientId}`);
      setClientDetails(response.data);
      setModalOpen(true);
    } catch (error) {
      console.error('Error al obtener los detalles del cliente:', error);
    }
  };


  const [showModal, setShowModal] = useState(false);

  const handleCloseModal = () => {
    setShowModal(false)
  };

  const handleShowModal = (clientId: number) => {
    setGetId(clientId);
    setShowModal(true);
  };

  const handleToDelete = (clientId: number | undefined) => {
    try {
      axios.delete(`https://clientsmanager.azurewebsites.net/Client/${clientId}`);
      <Alert key={'success'} variant='success'>Client Deleted Sucesfully</Alert>
    } catch (e) {
      <Alert key={'sucess'} variant='danger'>Error</Alert>
    }
  }

  return (
    <div className="container mt-4">
      {/* PRINCIPAL TABLE WITH BASIC INFO OF CLIENT */}
      <h1 className="text-center">Clients List</h1>

      <table className="table">
        <thead>
          <tr>
            <th>Client ID</th>
            <th>Full Name</th>
            <th>Email</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {clients.map((client) => (
            <tr key={client.clientId}>
              <td>{client.clientId}</td>
              <td>{`${client.firstName} ${client.lastName}`}</td>
              <td>{client.email}</td>
              <td>
                <div className="btn-group" role="group">
                  <button
                    type="button"
                    className="btn btn-secondary"
                    onClick={() => handleViewDetails(client.clientId)}>
                    <FaInfoCircle />
                  </button>
                  <button type="button" className="btn btn-secondary" onClick={() => { handleShowModal(client.clientId) } }>
                    <FaEdit />
                  </button>
                  <button type="button"
                    className="btn btn-secondary"
                    onClick={() => handleToDelete(client.clientId)}
                  >
                    <FaTrash />
                  </button>
                </div>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
      

      {/* MODAL TO GET MORE INFO OF CLIENT */}
      {showModal && (<EditClientModal
        clientId={getId!}
        showModal={showModal}
        handleCloseModal={() => {
          handleCloseModal();
        }}
      />)}
      {modalOpen && (
        <div className="modal" style={{ display: 'block' }}>
          <div className="modal-dialog">
            <div className="modal-content">
              <div className="modal-header">
                <h5 className="modal-title">Client Details</h5>
                <button type="button" className="btn-close" onClick={() => setModalOpen(false)}></button>
              </div>
              <div className="modal-body">
                <p>
                  <strong>Client Name:</strong> {`${clientDetails?.firstName} ${clientDetails?.lastName}`}
                </p>
                <p>
                  <strong>Email:</strong> {clientDetails?.email}
                </p>
                <h2><b>Profile</b></h2>
                <p>
                  <strong>Age:</strong> {clientDetails?.profile.age}
                </p>
                <p>
                  <strong>Gender:</strong> {clientDetails?.profile.gender}
                </p>
                <p>
                  <strong>Marital Status:</strong> {clientDetails?.profile.maritalStatus}
                </p>
                <h2><b>Address</b></h2>
                <p>
                  <strong>Country:</strong> {clientDetails?.address.country}
                </p>
                <p>
                  <strong>Street Address:</strong> {clientDetails?.address.streetAddress}
                </p>
                <p>
                  <strong>City:</strong> {clientDetails?.address.city}
                </p>
                <p>
                  <strong>Zip:</strong> {clientDetails?.address.zip}
                </p>
              </div>
              <div className="modal-footer">
                <button type="button" className="btn btn-secondary" onClick={() => setModalOpen(false)}>
                  Close
                </button>
              </div>
            </div>
          </div>
        </div>
      )}
    </div>
  );
};

export default InvoiceList;
