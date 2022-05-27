import { Container } from '@mui/material'
import { DataGrid } from '@mui/x-data-grid'
import React from 'react'

const StationPolicies = ({ policies }) => {

    const columns = [
        { field: 'id', headerName: 'ID', flex: 1, headerAlign: 'center', align: 'center' },
        { field: 'name', headerName: 'Name', flex: 1, headerAlign: 'center', align: 'center' },
        { field: 'description', headerName: 'Description', flex: 1, headerAlign: 'center', align: 'center' },
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
                    bgcolor: "#80deea"
                  }}
            />
        </Container>
    )
}

export default StationPolicies