import { useState } from 'react'
import './App.css'
import Header from './components/Header'
import HouseList from './components/HouseList'
import { BrowserRouter, Routes, Route } from 'react-router-dom'
import HouseDetail from './components/HouseDetail'
import HouseAdd from './components/HouseAdd'
import HouseEdit from './components/HouseEdit'

function App() {
  return (
    <>
      <BrowserRouter>
        <div className="container">
          <Header subtitle="Providing houses all over the world" />

          <Routes>
            <Route path="/" element={<HouseList />} />
            <Route path="/house/:id" element={<HouseDetail />} />
            <Route path="/house/add" element={<HouseAdd />} />
            <Route path="/house/edit/:id" element={<HouseEdit />} />
          </Routes>
        </div>
      </BrowserRouter>
    </>
  )
}

export default App
