import React, { useState } from 'react'
import { BrowserRouter, Route, Routes } from 'react-router-dom'
import LoginPage from './pages/Login/LoginPage'


//application context
export const AppContext = React.createContext();

const App = () => {

  const [isLoggedIn, setIsLoggedIn] = useState(false);

  return (
    <AppContext.Provider value={{isLoggedIn, setIsLoggedIn}}>
      <BrowserRouter>
        <Routes>
          <Route path='login' element={<LoginPage />}></Route>
        </Routes>
      </BrowserRouter>
    </AppContext.Provider>
  )
}

export default App