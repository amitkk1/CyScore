import { Container, Typography } from '@mui/material';
import React, { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom'
import StationDetails from './StationDetails/StationDetails';
import { getStation } from "../../services/stationsService";
import StationPolicies from './StationPolicies/StationPolicies';
const StationPage = () => {
    const { stationId } = useParams();
    const [isLoading, setIsLoading] = useState(true);
    const [station, setStation] = useState();

    useEffect(() => {
        const fetchData = async () => {
            setIsLoading(true);
            const data = await getStation(stationId);
            setStation(data);
            setIsLoading(false);
        }

        fetchData();
    }, []);

    return (
        <Container
            sx={{
                display: 'flex',
                flexDirection: 'column',
                alignItems: 'center'
            }}>
            <Typography component="h1" variant='h1'>
                Station View
            </Typography>
            {isLoading && <Typography component="h2" variant="h4">Loading station...</Typography>}
            {!isLoading && <StationDetails station={station} />}
            {!isLoading &&
                <Typography component="h2" variant="h2" sx={{padding: 2}}>
                    Policies
                </Typography>
            }
            {!isLoading && <StationPolicies policies={station.policies} />}
        </Container>
    )
}

export default StationPage