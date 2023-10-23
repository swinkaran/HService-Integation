import React, { useState, useEffect } from 'react';
import { Spinner } from 'reactstrap';

function Authorise() {
    const [authoriseData, setAuthoriseData] = useState(null);
    const [loading, setLoading] = useState(false);
    const [identifier, setIdentifier] = useState('');

    const handleFetchBtnClick = async () => {
        setLoading(true);
        const bodyData = `{
            "identifier": ${identifier}
            "informationProvider": {
                "providerNumber": "2447051B",
                "hpioNumber": "8003623233370062",
                "hpiiNumber": "8003611566712356"
            }
        }`;

        try {
            const response = await fetch('https://localhost:7085/api/Individual/authorise', {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
                body: JSON.stringify(bodyData),
            });

            const data = await response.json();
            console.log(data)
            setAuthoriseData(data);
            setLoading(false);
        } catch (error) {
            setLoading(false);
            console.error('Error fetching data:', error);
        }
    }

    const AuthoriseDetails = ({ authoriseData }) => {
        if (authoriseData === null) return <p>Data is empty</p>;
        return (
            <div>
                <h1>Status Code: {authoriseData.statusCode || ""}</h1>
                <h2>Code Type: {authoriseData.codeType || ""}</h2>
                <p>{authoriseData.message || ""}</p>
                <h3>Access List</h3>
                <ul>
                    {authoriseData && authoriseData.accessList && authoriseData.accessList.map((item, index) => (
                    <li key={index}>
                        {item.code}: {item.name} - {item.hasAccess ? 'Has Access' : 'No Access'}
                    </li>
                    ))}
                </ul>
            </div>
        )
    } 

    return (
        <div>
            <h1>Authorise Details</h1>
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
            {loading ? (<div style={{display: 'flex', justifyContent: 'center'}}><Spinner>Loading...</Spinner></div>) : <AuthoriseDetails authoriseData={authoriseData}/>}
        </div>
    )
}

export { Authorise };
