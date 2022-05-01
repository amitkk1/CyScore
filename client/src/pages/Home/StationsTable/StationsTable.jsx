import React from 'react';
import { DataGrid } from '@mui/x-data-grid';
import { Container } from '@mui/material';

const StationsTable = ({ stations }) => {

  const columns = [
    { field: 'id', headerName: 'ID', flex: 1, headerAlign: 'center', align: 'center' },
    { field: 'ip', headerName: 'IP Address', flex: 1, headerAlign: 'center', align: 'center', sortable: false },
    { field: 'alertsCount', headerName: 'Number of Alerts', type: 'number', flex: 1, headerAlign: 'center', align: 'center' },
    { field: 'score', headerName: 'Score', type: 'number', flex: 1, headerAlign: 'center', align: 'center' },
  ]


  return (
    <Container sx={{
      minHeight: 500
    }}>
      <DataGrid
        autoHeight
        rows={stations}
        columns={columns}
        pageSize={10}
        rowsPerPageOptions={[10]}

      />
    </Container>
  )
}

export default StationsTable