import React, { useState, useEffect } from 'react';
import { 
  Row,
  Col,
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
  const [formData, setFormData] = useState({});

  const handleFetchBtnClick = async () => {
    setLoading(true);
    const defaultFormData = {
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
          body: JSON.stringify(formData),
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
        <Row>
          <Col md={6}>
            <FormGroup>
              <Label for="dob">
                Date Of Birth
              </Label>
              <Input defaultValue={"12/12/1990"}/>
            </FormGroup>
          </Col>
          <Col md={6}>
            <FormGroup>
              <Label for="gender">
                Gender
              </Label>
              <Input
                id="exampleSelect"
                name="select"
                type="select"
              >
                <option>
                  Male
                </option>
                <option>
                  Female
                </option>
              </Input>
            </FormGroup>
          </Col>
        </Row>

        <Row>
          <Col md={6}>
            <FormGroup>
              <Label for="firstName">
                First Name
              </Label>
              <Input defaultValue={"John"}/>
            </FormGroup>
          </Col>
          <Col md={6}>
            <FormGroup>
              <Label for="lastName">
                Last Name
              </Label>
              <Input defaultValue={"Doe"}/>
            </FormGroup>
          </Col>
        </Row>

        <Row>
          <Col md={6}>
            <FormGroup className="position-relative">
              <Label for="initial">
                Initial
              </Label>
              <Input defaultValue={"JD"}/>
            </FormGroup>
          </Col>
          <Col md={6}>
            <FormGroup className="position-relative">
              <Label for="onlyNameIndicatior">
                Only Name Indicator
              </Label>
              <Input
                id="onlyNameIndicatior"
                name="onlyNameIndicatiorSelect"
                type="select"
              >
                <option>
                  Yes
                </option>
                <option>
                  No
                </option>
              </Input>
            </FormGroup>
          </Col>
        </Row>
        
        <Row>
          <Col md={6}>
            <FormGroup className="position-relative">
              <Label for="examplePassword">
                Medicare Card Number
              </Label>
              <Input defaultValue={"123"}/>
            </FormGroup>
          </Col>

          <Col md={6}>
            <FormGroup className="position-relative">
              <Label for="examplePassword">
                Medicare IRN
              </Label>
              <Input defaultValue={"1"}/>
            </FormGroup>
          </Col>
        </Row>

        <Row>
          <Col md={6}>
            <FormGroup className="position-relative">
              <Label for="examplePassword">
                postCode
              </Label>
              <Input defaultValue={"3000"}/>
            </FormGroup>
          </Col>
          <Col md={6}>
            <FormGroup className="position-relative">
              <Label for="examplePassword">
                IHI Number
              </Label>
              <Input defaultValue={"123"}/>
            </FormGroup>
          </Col>
        </Row>
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

