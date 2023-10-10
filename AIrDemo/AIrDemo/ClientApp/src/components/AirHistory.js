import React, { useState, useEffect } from 'react';
import { Spinner, Table } from 'reactstrap';
import { airRecords } from '../mocks/airRecords';

function AirHistory() {
    // const [airRecords, setAirRecords] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        // async function populateWeatherData() {
        //     try {
        //         const response = await fetch('individual/history');
        //         const data = await response.json();
        //         setAirRecords(data);
        //         setLoading(false);
        //     } catch (error) {
        //         console.error('Error fetching data:', error);
        //     }
        // }

        // populateWeatherData();
    }, []);

    function renderForecastsTable() {
        const airRecordMock = []
        return (
            <>
                <h2>Immunisation Details</h2>
                <Table>
                    <thead>
                        <tr>
                        <th>Episode ID</th>
                        <th>Vaccine Batch</th>
                        <th>Vaccine Code</th>
                        <th>Vaccine Dose</th>
                        <th>Serial Number</th>
                        <th>Funding Type</th>
                        <th>Route of Administration</th>
                        <th>Status</th>
                        <th>Editable</th>
                        <th>Action Required</th>
                        </tr>
                    </thead>
                    <tbody>
                        {airRecords.immunisationDetails.encounters.map((encounter) =>
                        encounter.episodes.map((episode) => (
                            <tr key={episode.id}>
                            <td>{episode.id}</td>
                            <td>{episode.vaccineBatch}</td>
                            <td>{episode.vaccineCode}</td>
                            <td>{episode.vaccineDose}</td>
                            <td>{episode.vaccineSerialNumber}</td>
                            <td>{episode.vaccineFundingType}</td>
                            <td>{episode.routeOfAdministration}</td>
                            <td>{episode.information.status}</td>
                            <td>{episode.editable ? 'Yes' : 'No'}</td>
                            <td>{episode.actionRequiredIndicator ? 'Yes' : 'No'}</td>
                            </tr>
                        ))
                        )}
                    </tbody>
                </Table>
            </>
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

