import React, { useEffect, useState } from 'react';
import { getStations } from '../../services/stationsService';
import GeneralInfo from './GeneralInfo/GeneralInfo';
import "./HomePage.scss";
import StationsTable from './StationsTable/StationsTable';
const HomePage = () => {

  const [stations, setStations] = useState([]);

  useEffect(() => {

    const fetchData = async () => {
      const data = await getStations();
      setStations(data);
    }
    fetchData();
  })
  return (
    <main className='homepage'>
        <GeneralInfo
        totalStations={30}
        totalActiveStations={18}
        totalStationsNotCommunicating={12}
        totalFaultyStations={3}
        totalOkStations={27}
        networkScore={75}
         />

        <StationsTable stations={stations}/>
    </main>
  )
}

export default HomePage