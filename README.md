# ReceiptsRepo # 

### Installation Instructions ###

1. Please make sure that Docker has beeen installed on your machine and is running
2. Clone the respository and cd to the project location
3. A Dockerfile has been added to the project
4. Run "docker build -t receipt-processor . " to build a docker image of the application
5. Run "docker run -p 8080:80 receipt-processor" to run the docker image that is built.
6. The application is now running and can be accessed at port 8080
7. You can access the APIs at "https://localhost:8080/swagger/index.html"


Summary of API Specification
Endpoint: Process Receipts
Path: /receipts/process
Method: POST
Payload: Receipt JSON
Response: JSON containing an id for the receipt.
Description:

## Summary of API Specification

### Endpoint: Process Receipts

* Path: `/receipts/process`
* Method: `POST`
* Payload: Receipt JSON
* Response: JSON containing an id for the receipt.

Description:

Takes in a JSON receipt (see example in the example directory) and returns a JSON object with an ID generated by your code.

The ID returned is the ID that should be passed into `/receipts/{id}/points` to get the number of points the receipt
was awarded.

How many points should be earned are defined by the rules below.

Reminder: Data does not need to survive an application restart. This is to allow you to use in-memory solutions to track any data generated by this endpoint.

Example Response:
```json
{ "id": "7fb1377b-b223-49d9-a31a-5a02701dd310" }
```

## Endpoint: Get Points

* Path: `/receipts/{id}/points`
* Method: `GET`
* Response: A JSON object containing the number of points awarded.

A simple Getter endpoint that looks up the receipt by the ID and returns an object specifying the points awarded.

Example Response:
```json
{ "points": 32 }
```

---


