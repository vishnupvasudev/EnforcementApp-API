# EnforcementApp API
[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)
### Enforcement is a QR code solution for anti-fraud and security checks. 
This application can be used for inspection of goods in transit or while transporting goods to customer. This repository contains the API services for the enforcement app. API contains the following methods




![N|Solid](https://raw.githubusercontent.com/vishnupvasudev/EnforcementApp-API/master/EnforcementAppAPI/wwwroot/readme/endpoint1.png)
![N|Solid](https://raw.githubusercontent.com/vishnupvasudev/EnforcementApp-API/master/EnforcementAppAPI/wwwroot/readme/endpoint2.png)

## API Usage
### 1. /api/User/Login

The Login service provides a REST endpoint for logging in and out, including getting an authentication token and renewing an authorization token.

#### Request
```sh
curl -X 'POST' \
  'https://localhost:44325/api/User/Login' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "username": "vishnu.v@gmail.com",
  "password": "Initial#01"
}'
```

#### Response
```sh
{
  "Output": {
    "encUserID": "Qh1rs_Vfb$4@",
    "name": "Vishnu Vasudevan",
    "accessToken": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlZpc2hudSBWYXN1ZGV2YW4iLCJuYW1laWQiOiJRaDFyc19WZmIkNEAiLCJuYmYiOjE2MzM5ODc5MDksImV4cCI6MTc1ODQwMzkwOSwiaWF0IjoxNjMzOTg3OTA5fQ.HXErwKw-UwvA8NTVH5pdtTtOizaiy9i4e9z8bigVie4",
    "emailID": "vishnu.v@gmail.com",
    "phoneNumber": "43543535345345"
  },
  "status": true,
  "errorCode": "",
  "errorMessage": "",
  "statusCode": "200",
  "statusMessage": "Success",
  "responseDate": "12/Oct/2021 03:01:49",
  "version": "V1"
}

```

### 2. /api/Enforcement/AddNewEnforcement

Add new item details and return the QR code image as base64. Enforcement APIs required authentication. Need to pass the Authorization Token from Login/ Registration services. In swagger use "Authorize" button at the top right corner.

#### Request

```sh
curl -X 'POST' \
  'https://localhost:44325/api/Enforcement/AddNewEnforcement' \
  -H 'accept: text/plain' \
  -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlZpc2hudSBWYXN1ZGV2YW4iLCJuYW1laWQiOiJRaDFyc19WZmIkNEAiLCJuYmYiOjE2MzM5ODc5MDksImV4cCI6MTc1ODQwMzkwOSwiaWF0IjoxNjMzOTg3OTA5fQ.HXErwKw-UwvA8NTVH5pdtTtOizaiy9i4e9z8bigVie4' \
  -H 'Content-Type: multipart/form-data' \
  -F 'ItemName=Item name' \
  -F 'CaseID=234' \
  -F 'Description=des 022' \
  -F 'Images=@IMG_3682_edited.jpg;type=image/jpeg'

```

#### Response

```sh
{
  "Output": {
    "qrcode": "iVBORw0KGgoAAAANSUhEUgAABRQAAAUUCAYAAACu5p7oAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAP+lSURBVHhe7NjBqmzHtiTR9/8/XdW7LduwhDlK1wwfYG0P5sotwfm// /tHxRnZmZmZmZmZmbms/2D4szMzMzMzMzMzHy2f1CcmZmZmZmZmZmZz/YPijMzMzMzMzMzM/PZ/kFxZmZmZmZmZmZmPts/KM7MzMzMzMzMzMxn+wfFmZmZmZmZmZmZ+Wz/oDgzMzMzMzMzMzOf7R8UZ2ZmZmZmZmZm5rP9g+LMzMzMzMzMzMx8tn9QnJmZmZmZmZmZmc/2D4ozMzMzMzMzMzPz2f…./YfijMzMzMzMzMzM/PZ/kNxZmZmZmZmZmZmPtt/KM7MzMzMzMzMzMxn+w/FmZmZmZmZmZmZ+Wz/oTgzMzMzMzMzMzMf/d///T9jMI7RXW2BQQAAAABJRU5ErkJggg==",
    "qrCodeID": "CfDJ8D9mv0_e-vJEmWIypAIzAgg2q_P5aCzp3S4emyb2_TNCN8P8DfUV752-sHqiFWHsK6ykw0nUiLkXXLr-P9BLRJdW8OHTCPbpGOrTkPE_k64BQHq9_babvZjRUUDFwzb4gw"
  },
  "status": true,
  "errorCode": "",
  "errorMessage": "",
  "statusCode": "200",
  "statusMessage": "Success",
  "responseDate": "12/Oct/2021 03:11:34",
  "version": "V1"
}
```

### 3. /api/Enforcement/GetEnforcementDetails

The enforcement details are retrieved by passing the reference ID after scanning the QR code. The response contains item details like name, id and images etc.

#### Request

```sh
curl -X 'GET' \
  'https://localhost:44325/api/Enforcement/GetEnforcementDetails?itemCode=CfDJ8D9mv0_e-vJEmWIypAIzAgg2q_P5aCzp3S4emyb2_TNCN8P8DfUV752-sHqiFWHsK6ykw0nUiLkXXLr-P9BLRJdW8OHTCPbpGOrTkPE_k64BQHq9_babvZjRUUDFwzb4gw' \
  -H 'accept: text/plain' \
  -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlZpc2hudSBWYXN1ZGV2YW4iLCJuYW1laWQiOiJRaDFyc19WZmIkNEAiLCJuYmYiOjE2MzM5ODc5MDksImV4cCI6MTc1ODQwMzkwOSwiaWF0IjoxNjMzOTg3OTA5fQ.HXErwKw-UwvA8NTVH5pdtTtOizaiy9i4e9z8bigVie4'

```

#### Response

```sh
{
  "Output": {
    "itemName": "Item name",
    "caseNumber": null,
    "caseID": 123123,
    "caseTitle": null,
    "description": "des 022",
    "images": [
      {
        "url": "https://localhost:44325/api/Enforcement/ItemImage?file=a43c3da3-382b-430b-8bca-80da84b37769.jpg"
      }
    ]
  },
  "status": true,
  "errorCode": "",
  "errorMessage": "",
  "statusCode": "200",
  "statusMessage": "Success",
  "responseDate": "12/Oct/2021 03:14:56",
  "version": "V1"
}
```

### 4. /api/Enforcement/ItemImage

A secure endpoint to retrieve item images from server.

#### Request

```sh
curl -X 'GET' \
  'https://localhost:44325/api/Enforcement/ItemImage?file=a43c3da3-382b-430b-8bca-80da84b37769.jpg' \
  -H 'accept: */*' \
  -H 'Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlZpc2hudSBWYXN1ZGV2YW4iLCJuYW1laWQiOiJRaDFyc19WZmIkNEAiLCJuYmYiOjE2MzM5ODc5MDksImV4cCI6MTc1ODQwMzkwOSwiaWF0IjoxNjMzOTg3OTA5fQ.HXErwKw-UwvA8NTVH5pdtTtOizaiy9i4e9z8bigVie4'
```
