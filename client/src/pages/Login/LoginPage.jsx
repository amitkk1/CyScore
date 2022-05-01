import React, { useContext, useRef, useState } from 'react';
import "./LoginPage.scss";
import { validatePassword, validateUsername } from "../../services/validationService";
import { login } from "../../services/sessionsService";
import { AppContext } from '../../App';
import { useNavigate } from 'react-router-dom';
import Box from '@mui/material/Box';
import { Button, Checkbox, Container, FormControlLabel, TextField, Typography } from '@mui/material';
const LoginPage = () => {

  //used for loading while waiting for the server login request
  const [isLoading, setIsLoading] = useState(false);
  const { setIsLoggedIn } = useContext(AppContext)

  //used for page navigation
  const navigate = useNavigate();

  const handleSubmit = (event) => {
    event.preventDefault();
    const data = new FormData(event.currentTarget);
    let username = data.get('username');
    let password = data.get('password');

    //validating username
    let usernameValidationMessage = validateUsername(username);
    if (usernameValidationMessage !== null) {
      alert(usernameValidationMessage);
      return;
    }

    //validating password
    let passwordValidationMessage = validatePassword(password);
    if (passwordValidationMessage !== null) {
      alert(passwordValidationMessage);
      return;
    }

    setIsLoading(true);
    login(username, password).then(loginSuccess => {
      setIsLoading(false);

      if (loginSuccess) {
        alert("Login successful!");
        setIsLoggedIn(true);
        navigate("/");
      } else {
        alert("Wrong username or password");
      }
    })
  }

  return (
    <Container component='main' maxWidth="xs">
      <Box
        sx={{
          marginTop: 8,
          display: 'flex',
          flexDirection: 'column',
          alignItems: 'center'
        }}>
        <Typography component="h1" variant='h5'>
          Sign in
        </Typography>
        <Box component="form" onSubmit={handleSubmit} noValidate>
          <TextField
            required
            fullWidth
            id='username'
            label='Username'
            margin='normal'
            name='username'
            autoFocus
            autoComplete='username'
          />
          <TextField
            required
            fullWidth
            id='password'
            label='Password'
            margin='normal'
            name='password'
            autoComplete='password'
          />
          <FormControlLabel 
            control={<Checkbox value="remember" color="primary" />}
            label="Remember me"
          />
          <Button
            type="submit"
            fullWidth
            variant='contained'
            sx={{mt: 3, mb: 2}}
            disabled={isLoading}
          >
            {isLoading ? "Loading..." : "Sign In"}
          </Button>
        </Box>
      </Box>
    </Container>
  )
}

export default LoginPage