import { Container } from '@mui/material'
import { DataGrid } from '@mui/x-data-grid'
import React from 'react'

const StationPolicies = ({ policies }) => {

    const columns = [
        { field: 'name', headerName: 'Name', flex: 2, headerAlign: 'center', align: 'center' },
        { field: 'description', headerName: 'Description', flex: 4, headerAlign: 'center', align: 'center' },
        { field: 'lastChanged', headerName: 'Last Changed', flex: 1, headerAlign: 'center', align: 'center'},
        { field: 'status', headerName: 'Status', flex: 1, headerAlign: 'center', align: 'center' }
    ]

    return (
        <Container sx={{minHeight: 500}}>
            <DataGrid 
                autoHeight
                rows={policies}
                columns={columns}
                pageSize={10}
                rowsPerPageOptions={[10]}
                disableSelectionOnClick
                sx={{
                    bgcolor: "#80deea",
                  }}
            />
        </Container>
    )
}

export default StationPolicies