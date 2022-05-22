import stations from "./mock/stations.json";
import { API_ADDRESS } from "../config";
import {getAuthHeader} from "./sessionsService";
export const getStations = async () => {
    const response = await fetch(`${API_ADDRESS}/stations`, {
        headers: {
            Authorization: getAuthHeader()
        }
    }).then(res => res.json());

    return response;
}

export const getStation = async (id) => {
    const response = await fetch(`${API_ADDRESS}/stations/${id}`, {
        headers: {
            Authorization: getAuthHeader()
        }
    }).then(res => res.json());

    return response;
}

export const getGeneralInfo = async () => {
    const response = await fetch(`${API_ADDRESS}/info`, {
        headers: {
            Authorization: getAuthHeader()
        }
    }).then(res => res.json());

    return response;
}