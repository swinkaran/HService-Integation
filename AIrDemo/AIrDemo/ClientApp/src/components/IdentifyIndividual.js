import React, { useState } from 'react';
import { 
  Row,
  Col,
  Form,
  Input,
  Label,
  Spinner,
  FormGroup
} from 'reactstrap';
import { defaultFormData } from "../mocks/formData.ts";

function IdentifyIndividual() {
  const [individualDetails, setIndividualDetails] = useState(null);
  const [loading, setLoading] = useState(false);
  const [formData, setFormData] = useState(defaultFormData);

  const handleSubmit = async () => {
    setLoading(true);
    
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

  const handleInputChange = (e) => {
    const { name, value } = e.target;

    setFormData((prevFormData) => {
        const keys = name.split('.');
        let data = { ...prevFormData };
        keys.reduce((o, k, i) => {
            if (i === keys.length - 1) {
                o[k] = value;
            } else {
                o[k] = o[k] || {};
            }
            return o[k];
        }, data);

        return data;
    });
  }

  const handleSelectChange = (e) => {
    const { name, value } = e.target;
    const booleanValue = value === "true";

    setFormData((prevFormData) => {
        const keys = name.split('.');
        let data = { ...prevFormData };
        keys.reduce((o, k, i) => {
            if (i === keys.length - 1) {
                o[k] = booleanValue;
            } else {
                o[k] = o[k] || {};
            }
            return o[k];
        }, data);

        return data;
    });
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
              <Input 
                name="individual.personalDetails.dateOfBirth"
                defaultValue={defaultFormData.individual.personalDetails.dateOfBirth}
                onChange={handleInputChange}
              />
            </FormGroup>
          </Col>
          <Col md={6}>
            <FormGroup>
              <Label for="gender">
                Gender
              </Label>
              <Input
                id="exampleSelect"
                name="individual.personalDetails.gender"
                type="select"
                onChange={handleSelectChange}
                defaultValue={defaultFormData.individual.personalDetails.gender}
              >
                <option value="Male">
                  Male
                </option>
                <option value="Female">
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
              <Input 
                name="individual.personalDetails.firstName"
                defaultValue={defaultFormData.individual.personalDetails.firstName}
                onChange={handleInputChange}
              />
            </FormGroup>
          </Col>
          <Col md={6}>
            <FormGroup>
              <Label for="lastName">
                Last Name
              </Label>
              <Input
                name="individual.personalDetails.lastName"
                defaultValue={defaultFormData.individual.personalDetails.lastName}
                onChange={handleInputChange}
              />
            </FormGroup>
          </Col>
        </Row>

        <Row>
          <Col md={6}>
            <FormGroup className="position-relative">
              <Label for="initial">
                Initial
              </Label>
              <Input
                name="individual.personalDetails.initial"
                defaultValue={defaultFormData.individual.personalDetails.initial}
                onChange={handleInputChange}
              />
            </FormGroup>
          </Col>
          <Col md={6}>
            <FormGroup className="position-relative">
              <Label for="onlyNameIndicator">
                Only Name Indicator
              </Label>
              <Input
                id="onlyNameIndicatior"
                name="individual.personalDetails.onlyNameIndicator"
                type="select"
                onChange={handleSelectChange}
                defaultValue={defaultFormData.individual.personalDetails.onlyNameIndicator}
              >
                <option value="true">
                  true
                </option>
                <option value="false">
                  false
                </option>
              </Input>
            </FormGroup>
          </Col>
        </Row>
        
        <Row>
          <Col md={6}>
            <FormGroup className="position-relative">
              <Label for="medicareCardNumber">
                Medicare Card Number
              </Label>
              <Input
                name="individual.medicareCard.medicareCardNumber"
                defaultValue={defaultFormData.individual.medicareCard.medicareCardNumber}
                onChange={handleInputChange}
              />
            </FormGroup>
          </Col>

          <Col md={6}>
            <FormGroup className="position-relative">
              <Label for="examplePassword">
                Medicare IRN
              </Label>
              <Input
                name="individual.medicareCard.medicareIRN"
                defaultValue={defaultFormData.individual.medicareCard.medicareIRN}
                onChange={handleInputChange}
              />
            </FormGroup>
          </Col>
        </Row>

        <Row>
          <Col md={6}>
            <FormGroup className="position-relative">
              <Label for="postCode">
                postCode
              </Label>
              <Input
                name="individual.address.postCode"
                defaultValue={defaultFormData.individual.address.postCode}
                onChange={handleInputChange}
              />
            </FormGroup>
          </Col>
          <Col md={6}>
            <FormGroup className="position-relative">
              <Label for="ihiNumber">
                IHI Number
              </Label>
              <Input
                name="individual.ihiNumber"
                defaultValue={defaultFormData.individual.ihiNumber}
                onChange={handleInputChange}
              />
            </FormGroup>
          </Col>
        </Row>
        <button type="button" onClick={handleSubmit} className="btn btn-primary">Submit</button>
      </Form>

      
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

