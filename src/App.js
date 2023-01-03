import React from 'react';
import Navbar from './components/Navbar';
import {BrowserRouter as Router, Route, Routes} from 'react-router-dom';
import './App.css';
import Home from './components/pages/Home';
import MainView from './components/MainView';

function App() {
  return (
    <>
    <Router>
    <Navbar />
    <Routes>

    <Route path="/" element={<Home />}></Route>
    </Routes>

    </Router>
    
    </>
     
     
   
  );
}

export default App;
