import React, { useState, useEffect } from 'react';
import { Spinner, Table } from 'reactstrap';

function AirHistory() {
    const [airRecords, setAirRecords] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        async function populateWeatherData() {
            try {
                const response = await fetch('individual/history');
                const data = await response.json();
                setAirRecords(data);
                setLoading(false);
            } catch (error) {
                console.error('Error fetching data:', error);
            }
        }

        populateWeatherData();
    }, []);

    function renderForecastsTable() {
        const airRecordMock = []
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Vaccine/Brand[Batch number]</th>
                        <th>Serial Number</th>
                        <th>School Name</th>
                        <th>Status</th>
                        <th>Reason Code</th>
                    </tr>
                </thead>
                <tbody>
                    {airRecords.map(airRecord => (
                        <tr key={airRecord.date}>
                            <td>{airRecord.date}</td>
                            <td>{airRecord.temperatureC}</td>
                            <td>{airRecord.temperatureF}</td>
                            <td>{airRecord.summary}</td>
                            <td>{airRecord.summary}</td>
                            <td>{airRecord.summary}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        );
    }

    return (
        <div>
            <h1 id="tabelLabel">Immunisation History</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {renderForecastsTable()}
            {loading ? (<Spinner>Loading...</Spinner>) : (
                renderForecastsTable()
            )}
        </div>
    );
}

export { AirHistory };

