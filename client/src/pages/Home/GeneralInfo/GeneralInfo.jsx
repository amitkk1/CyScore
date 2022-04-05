import React from 'react'
import "./GeneralInfo.scss"
const GeneralInfo = ({totalStations, totalOkStations, totalFaultyStations, totalStationsNotCommunicating, totalActiveStations, networkScore}) => {
  return (
    <section className='general-info'>
        <h1>CyScore</h1>

        <div className='info-box'>
            <h2>Total stations</h2>
            <h3>{totalStations}</h3>
        </div>

        <div className='info-box'>
            <h2>Total ok stations</h2>
            <h3>{totalOkStations}/{totalStations}</h3>
        </div>

        <div className='info-box'>
            <h2>Total faulty stations</h2>
            <h3>{totalFaultyStations}/{totalStations}</h3>
        </div>

        <div className='info-box'>
            <h2>Total stations not communicating</h2>
            <h3>{totalStationsNotCommunicating}/{totalStations}</h3>
        </div>

        <div className='info-box'>
            <h2>Total active stations</h2>
            <h3>{totalActiveStations}/{totalStations}</h3>
        </div>

        <div className='info-box'>
            <h2>Network score</h2>
            <h3>{networkScore}/100</h3>
        </div>
    </section>
  )
}

export default GeneralInfo