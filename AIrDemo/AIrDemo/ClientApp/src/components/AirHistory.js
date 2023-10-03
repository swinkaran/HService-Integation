import React, { Component } from 'react';

export class AirHistory extends Component {
    static displayName = AirHistory.name;

    constructor(props) {
        super(props);
        this.state = { airRecords: [], loading: true };
    }

    componentDidMount() {
        this.populateWeatherData();
    }

    static renderForecastsTable(airRecords) {
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
                    {airRecords.map(airRecord =>
                        <tr key={airRecord.date}>
                            <td>{airRecord.date}</td>
                            <td>{airRecord.temperatureC}</td>
                            <td>{airRecord.temperatureF}</td>
                            <td>{airRecord.summary}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : AirHistory.renderForecastsTable(this.state.airRecords);

        return (
            <div>
                <h1 id="tabelLabel">Immunisation History</h1>
                <p>This component demonstrates fetching data from the server.</p>
                {contents}
            </div>
        );
    }

    async populateWeatherData() {
        const response = await fetch('individual/history');
        const data = await response.json();
        this.setState({ airRecords: data, loading: false });
    }
}
