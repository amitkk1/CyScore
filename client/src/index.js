import React from 'react';
import { createRoot } from 'react-dom/client';

//global styles imports
import "./assets/fonts/roboto/stylesheet.css";
import "./assets/css/reset.scss";
import "./assets/css/global.scss";
import App from './App';


const container = document.getElementById('root');
const root = createRoot(container);
root.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
)
