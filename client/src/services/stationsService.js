import stations from "./mock/stations.json";
export const getStations = async () => {
    //made to act like a server, waits a second and then replies
    await new Promise(t => setTimeout(t, 1000));

    return stations;
}
