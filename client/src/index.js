import React from 'react';
import ReactDOM from 'react-dom';

//global styles imports
import "./assets/fonts/roboto/stylesheet.css";
import "./assets/css/reset.scss";
import "./assets/css/global.scss";
import App from './App';


ReactDOM.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>,
  document.getElementById('root')
);
