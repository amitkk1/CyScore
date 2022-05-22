import { Container, Typography } from '@mui/material';
import React, { useEffect, useState } from 'react';
import { getGeneralInfo, getStations } from '../../services/stationsService';
import GeneralInfo from './GeneralInfo/GeneralInfo';
import StationsTable from './StationsTable/StationsTable';
const HomePage = () => {

  const [stations, setStations] = useState([]);
  const [generalInfo, setGeneralInfo] = useState(null);
  useEffect(() => {

    const fetchData = async () => {
      const stationsData = await getStations();
      const generalInfoData = await getGeneralInfo();
      setStations(stationsData);
      setGeneralInfo(generalInfoData);
    }

    fetchData();
  }, [])

  return (
    <Container
      sx={{
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
      }}>
      <Typography component="h1" variant='h1'>
        CyScore
      </Typography>
      {generalInfo && generalInfo.totalStations &&
        <GeneralInfo
          totalStations={generalInfo.totalStations}
          totalActiveStations={generalInfo.totalActiveStations}
          totalStationsNotCommunicating={generalInfo.totalStationsNotCommunicating}
          totalFaultyStations={generalInfo.totalFaultyStations}
          totalOkStations={generalInfo.totalOkStations}
          networkScore={generalInfo.networkScore}
        />
      }

      <StationsTable stations={stations} />
    </Container>
  )
}

export default HomePage