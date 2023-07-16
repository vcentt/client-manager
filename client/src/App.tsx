import './App.css'
import Navbar from './components/Navbar'

import TopNavbar from './components/TopNavbar'
import ClientList from './components/ClientList'
import { Route, Routes } from 'react-router-dom'
import { AddClient } from './components/AddClient'


function App() {
  return (
    <div className=''>
      <Navbar/>
      <TopNavbar/>
      <Routes>
        <Route path='/' element={<ClientList/>} />
        <Route path='new-client' element={<AddClient/> } />
      </Routes>
    </div>
  )
}

export default App
