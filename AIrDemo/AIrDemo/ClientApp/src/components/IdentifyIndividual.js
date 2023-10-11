import React, { useState, useEffect } from 'react';
import { Spinner } from 'reactstrap';
import  identityIndividual from "../../src/mocks/identityIndividual"

function IdentifyIndividual() {
  const [individualDetails, setIndividualDetails] = useState(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
      async function populateWeatherData() {
          try {
              const response = await fetch('individual/details');
              const data = await response.json();
              setIndividualDetails(data);
              setLoading(false);
          } catch (error) {
              setLoading(false);
              console.error('Error fetching data:', error);
          }
      }

      populateWeatherData();
  }, []);

  return (
    <div>
      <h1>Individual Details</h1>
      {loading ? (<div style={{display: 'flex', justifyContent: 'center'}}><Spinner>Loading...</Spinner></div>) : <IndividualDetails data={identityIndividual}/>}
    </div>        
  );
}

const IndividualDetails = ({ data }) => {
  return (
    <div>
      <h1>Individual Details</h1>
      <p><strong>Status Code:</strong> {data.statusCode}</p>
      <p><strong>Code Type:</strong> {data.codeType}</p>
      <p><strong>Message:</strong> {data.message}</p>

      <h2>Individual Information</h2>
      <p><strong>Individual Identifier:</strong> {data.individualDetails.individualIdentifier}</p>

      <h3>Personal Details</h3>
      <p><strong>Date of Birth:</strong> {data.individualDetails.individual.personalDetails.dateOfBirth}</p>
      <p><strong>Last Name:</strong> {data.individualDetails.individual.personalDetails.lastName}</p>
      <p><strong>First Name:</strong> {data.individualDetails.individual.personalDetails.firstName}</p>
      <p><strong>Initial:</strong> {data.individualDetails.individual.personalDetails.initial}</p>
      <p><strong>Only Name Indicator:</strong> {data.individualDetails.individual.personalDetails.onlyNameIndicator.toString()}</p>

      <h3>Medicare Card</h3>
      <p><strong>Medicare Card Number:</strong> {data.individualDetails.individual.medicareCard.medicareCardNumber}</p>
      <p><strong>Medicare IRN:</strong> {data.individualDetails.individual.medicareCard.medicareIRN}</p>

      <h3>Address</h3>
      <p><strong>Address Line One:</strong> {data.individualDetails.individual.address.addressLineOne}</p>
      <p><strong>Address Line Two:</strong> {data.individualDetails.individual.address.addressLineTwo}</p>
      <p><strong>Locality:</strong> {data.individualDetails.individual.address.locality}</p>
      <p><strong>Post Code:</strong> {data.individualDetails.individual.address.postCode}</p>
    </div>
  );
};

export { IdentifyIndividual };

