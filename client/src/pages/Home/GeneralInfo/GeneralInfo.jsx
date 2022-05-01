import { Box, Container, Grid, Paper, styled, Typography } from '@mui/material'
import React from 'react'



const InfoBox = ({ title, content }) => {

    const InfoBoxContainer = styled(Paper)(({ theme }) => ({
        backgroundColor: '#fff',
        ...theme.typography.body2,
        padding: theme.spacing(1),
        textAlign: 'center',
        color: theme.palette.text.secondary,
        minHeight: '90px',
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center',
        flexDirection: 'column'
    }));
    return (
        <InfoBoxContainer>
            <Typography component="h2" variant='h6' fontSize={18}>
                {title}
            </Typography>
            <Typography component="h3" variant='h6' fontSize={16}>
                {content}
            </Typography>
        </InfoBoxContainer>
    )
}

const GeneralInfo = (
    { totalStations,
        totalOkStations,
        totalFaultyStations,
        totalStationsNotCommunicating,
        totalActiveStations,
        networkScore }) => {

    const infoBoxes = [
        { title: 'Total stations', content: totalStations },
        { title: 'Total ok stations', content: `${totalOkStations}/${totalStations}` },
        { title: 'Total faulty stations', content: `${totalFaultyStations}/${totalStations}` },
        { title: 'Total stations not communicating', content: `${totalStationsNotCommunicating}/${totalStations}` },
        { title: 'Total active stations', content: `${totalActiveStations}/${totalStations}` },
        { title: 'Network score', content: `${networkScore}/100` },
    ];
    return (
        <Container component="section">
            <Box
                sx={{
                    display: 'flex',
                    flexDirection: 'column',
                    alignItems: 'center',
                    backgroundColor: '#fff',
                    minWidth: "100%",
                    marginBottom: 5,
                    marginTop: 3
                }}
            >
                <Grid container spacing={2}>
                    {
                        infoBoxes.map(box => {
                            return (
                                <Grid item xs={4}>
                                    <InfoBox title={box.title} content={box.content} key={box.title} />
                                </Grid>
                            );
                        })
                    }
                </Grid>
            </Box>
        </Container>
    )
}

export default GeneralInfo