import React, { useState, useEffect } from 'react';
import { Spinner, Table } from 'reactstrap';

function AirHistory() {
    const [airRecords, setAirRecords] = useState(null);
    const [loading, setLoading] = useState(false);
    const [identifier, setIdentifier] = useState('');

    const handleFetchBtnClick = async () => {
        setLoading(true);
        
        const bodyData = {
            "individualIdentifier": identifier,
            "informationProvider": {
                "providerNumber": "2447051B",
                "hpioNumber": "8003623233370062",
                "hpiiNumber": "8003611566712356"
            }
        };

        try {
            const response = await fetch('https://localhost:7085/api/Individual/history', {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(bodyData),
            });
            const data = await response.json();
            console.log(data)
            setAirRecords(data);
            setLoading(false);
        } catch (error) {
            setLoading(false);
            console.error('Error fetching data:', error);
        }
    }

    function AirHistoryTable({ airRecords }) {
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
                        {airRecords && airRecords.immunisationDetails && airRecords.immunisationDetails.encounters.map((encounter) =>
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
            <div className="input-group mb-3 w-25">
                <input 
                    type="text"
                    className="form-control"
                    placeholder="Individual Identifier"
                    aria-label="Individual Identifier"
                    aria-describedby="basic-addon1"
                    value={identifier}
                    onChange={(e) => setIdentifier(e.target.value)}
                />
            </div>
            <button type="button" className="btn btn-primary" onClick={handleFetchBtnClick}>Fetch Data</button>
            {loading ? (<div style={{display: 'flex', justifyContent: 'center'}}><Spinner>Loading...</Spinner></div>) : (
                <AirHistoryTable airRecords={airRecords}/>
            )}
        </div>
    );
}

export { AirHistory };
