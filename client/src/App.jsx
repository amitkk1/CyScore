import React, { useState } from 'react'
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import HomePage from './pages/Home/HomePage';
import LoginPage from './pages/Login/LoginPage'
import StationPage from './pages/Station/StationPage';


//application context
export const AppContext = React.createContext();

const App = () => {

  const [isLoggedIn, setIsLoggedIn] = useState(false);

  return (
    <AppContext.Provider value={{ isLoggedIn, setIsLoggedIn }}>
      <BrowserRouter>
        <Routes>
          <Route exact path='login' element={<LoginPage />}></Route>
          <Route exact path='/' element={<HomePage />}></Route>
          <Route exact path='stations/:stationId' element={<StationPage />} />
          <Route exact path='stations' element={<HomePage />} />
        </Routes>
      </BrowserRouter>
    </AppContext.Provider>
  )
}

export default App