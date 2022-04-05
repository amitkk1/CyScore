export const validatePassword = (password) => {
    if(password.length < 4 || password.length > 10)
    {
        return "Password must be between 4 and 10 characters long";
    }
    return null;
}

export const validateUsername = (username) => {
    if(username.length < 4 || username.length > 20){
        return "Username must be between 4 and 20 characters long";
    }
    
    return null;
}