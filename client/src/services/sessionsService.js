import { API_ADDRESS } from "../config";

export const getAuthHeader = () => {
    return "Bearer " + localStorage.getItem('jwt');
}

export const login = async (username, password) => {
    const response = await fetch(`${API_ADDRESS}/users/login`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({username, password})
    });

    if(response.status == 200)
    {
        const token = await response.text();
        localStorage.setItem('jwt', token);
        return true;
    }
    return false;
}



