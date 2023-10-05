import React, { useState, useEffect } from 'react';
import { Spinner } from 'reactstrap';

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
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Temp. (C)</th>
                        <th>Temp. (F)</th>
                        <th>Summary</th>
                    </tr>
                </thead>
                <tbody>
                    {airRecords.map(airRecord => (
                        <tr key={airRecord.date}>
                            <td>{airRecord.date}</td>
                            <td>{airRecord.temperatureC}</td>
                            <td>{airRecord.temperatureF}</td>
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
            {loading ? (<Spinner>Loading...</Spinner>) : (
                renderForecastsTable()
            )}
        </div>
    );
}

export { AirHistory };

