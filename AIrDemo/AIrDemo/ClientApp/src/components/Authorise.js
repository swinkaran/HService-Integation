import React, { useState, useEffect } from 'react';
import { Spinner, Table } from 'reactstrap';
import { authoriseData } from '../mocks/authorise'
function Authorise() {
    const [airRecords, setAirRecords] = useState(null);
    const [loading, setLoading] = useState(false);

    useEffect(() => {
        async function populateWeatherData() {
            try {
                const response = await fetch('individual/authorise');
                const data = await response.json();
                setAirRecords(data);
                setLoading(false);
            } catch (error) {
                setLoading(false);
                console.error('Error fetching data:', error);
            }
        }

        populateWeatherData();
    }, []);
    const { statusCode, codeType, message, accessList } = authoriseData;
    return (
        <>
            { loading ? (<div style={{display: 'flex', justifyContent: 'center'}}><Spinner>Loading...</Spinner></div>) : (
                <div>
                    <h1>Status Code: {statusCode}</h1>
                    <h2>Code Type: {codeType}</h2>
                    <p>{message}</p>
                    <h3>Access List</h3>
                    <ul>
                        {accessList.map((item, index) => (
                        <li key={index}>
                            {item.code}: {item.name} - {item.hasAccess ? 'Has Access' : 'No Access'}
                        </li>
                        ))}
                    </ul>
                </div>
            )}
        </>
    );
}

export { Authorise };
