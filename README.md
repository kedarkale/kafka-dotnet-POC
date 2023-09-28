# **Kafka-Dotnet-POC**

An example which showcases inter microservice communication using Kafka and REST API calls.

The messages and notifications are sent from the UserService to the MessageService and NotificationService respectively using the Kafka service.
The sent messages and notifications can be read back by the UserService using REST API calls to the MessageService and NotificationService.

Data can be generated and read using the API endpoints available on the Swagger documentation.

### Prerequisites to run the POC
- .NET 6 SDK
- Docker

### Setting up Kafka
- Start the Kafka server using the included compose file - `docker compose -f .\kafka-local-server-compose.yml up `
- Create required topics in Kafka
  - Copy the container Id of the Kafka container from the output of `docker ps`
  - Access a shell inside the container `docker exec -it <containerId> sh`
  - Navigate to the following path - opt/bitnami/kafka/bin
  - Create topics
    
    ```
    kafka-topics.sh --create --topic messages --bootstrap-server localhost:9092
    kafka-topics.sh --create --topic notifications --bootstrap-server localhost:9092
    ```

### Starting the services
- Start Kafka server if not already started - `docker compose -f .\kafka-local-server-compose.yml up `
- Run UserService, MessageService and NotificationService using `dotnet run`

### Accessing the services
- UserService: http://localhost:5001/swagger/index.html
- MessageService: http://localhost:5003/swagger/index.html
- NotificationService: http://localhost:5005/swagger/index.html
