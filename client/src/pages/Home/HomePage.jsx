import { Container, Typography } from '@mui/material';
import React, { useEffect, useState } from 'react';
import { getStations } from '../../services/stationsService';
import GeneralInfo from './GeneralInfo/GeneralInfo';
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
    <Container
      sx={{
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
      }}>
      <Typography component="h1" variant='h1'>
        CyScore
      </Typography>
      <GeneralInfo
        totalStations={30}
        totalActiveStations={18}
        totalStationsNotCommunicating={12}
        totalFaultyStations={3}
        totalOkStations={27}
        networkScore={75}
      />

      <StationsTable stations={stations} />
    </Container>
  )
}

export default HomePage