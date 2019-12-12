# PicoYPlacaPredictor
Pico Y Placa Predictor ASP.NET CORE API with SWAGGER

###Visit this route to see the Swagger UI to test the API
`/swagger/index.html
`

###Follow this link on azure for a live demo of the API 

https://picoyplacapredictor.azurewebsites.net/swagger/index.html


--Example of Request
POST `/api/v1/predictor/validate`

```json
{
  "plateNumber": "pcf-3901",
  "date": "2019-12-12T03:05:59.171Z"
}
```
Rules and Validations for the Request Body
`
plateNumber*	string
pattern: [a-z]{3}-[0-9]{4}
`

`date	string($date-time)`
# Configuration and Rules for Predictor
##### Car can drive on holidays
##### Car can with the following configuration by Licence Plates

      "PicoYPlacaOptions": {
        "Rules": {
          "ByPlateNumber": "LastDigit",
          "LincensePlateOptions": [
            {
              "Day": "Mon",
              "Digits": [ 1,2 ]
            },
            {
              "Day": "Tue",
              "Digits": [ 3, 4 ]
            },
            {
              "Day": "Wed",
              "Digits": [ 5, 6 ]
            },
            {
              "Day": "Thu",
              "Digits": [ 7, 8 ]
            },
            {
              "Day": "Fri",
              "Digits": [ 9, 0 ]
            }
          ],
          "Ranges": {
            "First": {
              "From": "07:00",
              "To": "09:30"
            },
            "Second": {
              "From": "16:00",
              "To": "19:30"
            }
          },
          "HolidaysExceptions": [ // Month/Day -- Holidays FROM 2019 UPDATE to 2020
            {
              "Description": "NewYearsDay",
              "Date": "01/01"
            },
            {
              "Description": "CarnivalMonday",
              "Date": "03/04"
            },
            {
              "Description": "CarnivalTuesday",
              "Date": "03/05"
            },
            {
              "Description": "GoodFriday",
              "Date": "04/19"
            },
            {
              "Description": "EasterDay",
              "Date": "04/21"
            },
            {
              "Description": "LabourDay",
              "Date": "05/21"
            },
            {
              "Description": "BattleOfPichincha",
              "Date": "05/21"
            },
            {
              "Description": "IndependenceDay1",
              "Date": "08/09"
            },
            {
              "Description": "IndependenceDay2",
              "Date": "08/10"
            },
            {
              "Description": "IndependenceOfGuayaquil",
              "Date": "09/11"
            },
            {
              "Description": "AllSoulsDays1",
              "Date": "11/01"
            },
            {
              "Description": "AllSoulsDays2",
              "Date": "11/02"
            },
            {
              "Description": "IndependenceOfCuenca",
              "Date": "11/04"
            },
            {
              "Description": "FoundationOfQuito",
              "Date": "11/06"
            },
            {
              "Description": "ChristmasDay",
              "Date": "12/25"
            }
          ]
        }
      }
    