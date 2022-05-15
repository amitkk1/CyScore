import stations from "./mock/stations.json";
export const getStations = async () => {
    //made to act like a server, waits a second and then replies
    await new Promise(t => setTimeout(t, 1000));

    return stations;
}

export const getStation = async (id) => {
    await new Promise(t => setTimeout(t, 1000));

    const station = stations.find(s => s.id === id);
    return station;
}
