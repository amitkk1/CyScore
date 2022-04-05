export const login = async (username, password) => {
    //made to act like a server, waits a second and then replies
    await new Promise(t => setTimeout(t, 1000));

    //simulates a login, future logic should be on the server
    if(username === "admin" && password === "password"){
        //TODO: retrieve JWT from server
        return true;
    } else {
        return false;
    }
}

