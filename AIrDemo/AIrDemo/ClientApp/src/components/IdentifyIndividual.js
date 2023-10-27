import React, { useState, useEffect } from 'react';
import { 
  Form,
  Input,
  Label,
  Spinner,
  FormText,
  FormGroup,
  FormFeedback
} from 'reactstrap';

function IdentifyIndividual() {
  const [individualDetails, setIndividualDetails] = useState(null);
  const [loading, setLoading] = useState(false);

  const handleFetchBtnClick = async () => {
    setLoading(true);
    const bodyData = {
      "individual": {
        "personalDetails": {
          "dateOfBirth": "string",
          "gender": "string",
          "firstName": "string",
          "lastName": "string",
          "initial": "string",
          "onlyNameIndicator": true
        },
        "medicareCard": {
          "medicareCardNumber": "string",
          "medicareIRN": "string"
        },
        "address": {
          "postCode": "string"
        },
        "ihiNumber": "string"
      },
      "informationProvider": {
        "providerNumber": "2447051B",
        "hpioNumber": "8003623233370062",
        "hpiiNumber": "8003611566712356"
      }
    };

    try {
        const response = await fetch('https://localhost:7085/api/Individual/details', {
          method: "POST",
          headers: {
              "Content-Type": "application/json",
          },
          body: JSON.stringify(bodyData),
      });
        const data = await response.json();
        setIndividualDetails(data);
        setLoading(false);
    } catch (error) {
        setLoading(false);
        console.error('Error fetching data:', error);
    }
  }

  return (
    <div>
      <h1>Individual Details</h1>

      <Form>
        <FormGroup>
          <Label for="exampleEmail">
            Date Of Birth
          </Label>
          <Input />
          <FormFeedback>
            You will not be able to see this
          </FormFeedback>
        </FormGroup>
        <FormGroup>
          <Label for="exampleEmail">
            Gender
          </Label>
          <Input valid />
          <FormFeedback valid>
            Sweet! that name is available
          </FormFeedback>
          <FormText>
            Example help text that remains unchanged.
          </FormText>
        </FormGroup>
        <FormGroup>
          <Label for="examplePassword">
            First Name
          </Label>
          <Input />
          <FormFeedback>
            Oh noes! that name is already taken
          </FormFeedback>
          <FormText>
            Example help text that remains unchanged.
          </FormText>
        </FormGroup>
        <FormGroup>
          <Label for="exampleEmail">
            Last Name
          </Label>
          <Input />
          <FormFeedback tooltip>
            You will not be able to see this
          </FormFeedback>
          <FormText>
            Example help text that remains unchanged.
          </FormText>
        </FormGroup>
        <FormGroup className="position-relative">
          <Label for="exampleEmail">
            Initial
          </Label>
          <Input/>
          <FormFeedback
            tooltip
            valid
          >
            Sweet! that name is available
          </FormFeedback>
          <FormText>
            Example help text that remains unchanged.
          </FormText>
        </FormGroup>
        <FormGroup className="position-relative">
          <Label for="examplePassword">
            Only Name Indicator
          </Label>
          <Input/>
          <FormText>
            Example help text that remains unchanged.
          </FormText>
        </FormGroup>
        <FormGroup className="position-relative">
          <Label for="examplePassword">
            Medicare Card Number
          </Label>
          <Input />
          <FormText>
            Example help text that remains unchanged.
          </FormText>
        </FormGroup>
        <FormGroup className="position-relative">
          <Label for="examplePassword">
            Medicare IRN
          </Label>
          <Input />
          <FormFeedback>
            Oh noes! that name is already taken
          </FormFeedback>
          <FormText>
            Example help text that remains unchanged.
          </FormText>
        </FormGroup>
        <FormGroup className="position-relative">
          <Label for="examplePassword">
            postCode
          </Label>
          <Input />
          <FormFeedback>
            Oh noes! that name is already taken
          </FormFeedback>
        </FormGroup>
        <FormGroup className="position-relative">
          <Label for="examplePassword">
            IHI Number
          </Label>
          <Input />
          <FormFeedback>
            Oh noes! that name is already taken
          </FormFeedback>
        </FormGroup>
      </Form>

      <button type="button" className="btn btn-primary" onClick={handleFetchBtnClick}>Fetch Data</button>
      {loading ? (<div style={{display: 'flex', justifyContent: 'center'}}><Spinner>Loading...</Spinner></div>) : <IndividualDetails data={individualDetails}/>}
    </div>        
  );
}

const IndividualDetails = ({ data }) => {
  if (data === null) return <p>Data is empty</p>;
  return (
    <div>
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

