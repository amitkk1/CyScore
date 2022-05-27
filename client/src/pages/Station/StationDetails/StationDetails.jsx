import { Paper, Table, TableBody, TableCell, TableContainer, TableRow } from '@mui/material'
import React from 'react'




const StationDetails = ({station}) => {
  const details = [
    {name: "ID", value: station.id},
    {name: "Hostname", value: station.hostname},
    {name: "IP Address", value: station.ip},
    {name: "MAC Address", value: station.mac},
    {name: "Security Score", value: `${station.score}/100`},
  ]

  return (
    <TableContainer sx={{bgcolor: "#b388ff"}} component={Paper}>
      <Table>
        <TableBody>
          {details.map((row) => (
            row &&
            <TableRow key={row?.name}>
              <TableCell component="th" scope="row">
                {row?.name}
              </TableCell>
              <TableCell>
                {row?.value}
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  )
}

export default StationDetails