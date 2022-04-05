import React from 'react';
import "./StationsTable.scss";
const StationsTable = ({stations}) => {
  return (
    <section className='stations-table'>
      <div className='row'>
        <div className='col'>IP Address</div>
        <div className='col'>Station Id</div>
        <div className='col'>Alerts</div>
        <div className='col'>Score</div>
      </div>
      {stations.map(station => {
        return(
          <div className='row'>
          <div className='col'>{station.ip}</div>
          <div className='col'>{station.id}</div>
          <div className='col'>{station.alertsCount}</div>
          <div className='col'>{station.score}</div>
        </div>
        )
      })}
    </section>
  )
}

export default StationsTable