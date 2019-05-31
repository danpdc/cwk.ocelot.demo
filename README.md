# Service oriented demo application with Ocelot API gateway
This is a demo application meant to showcase Ocelot features. It's meant as a getting started app for those who want to get familiar with Ocelot. 

# Run the app
Running the app should be as easy as cloning this repo, rebuilding the solution and running it. 
However, there is on caveat! Most of the projects are built to run on .Net Core 3.0. So if you want to run the application, you'll need the .Net Core 3.0 SDK

# Services
Gateway -> runs on localhost:5001
Auth -> runs on localhost:5002
Products -> runs on localhost:5003
Suppliers -> runs on localhost:5004
Users -> runs on localhost:5005

All services are running on HTTPS. 
Also all services are configured to start in the console. 
The solution is configured to run all services when debugging. For each service, you'll have one console. 

The role of the AuthService is simply to provide JWT tokens. Ocelot validates those tokens based on the specified configuration. 

NOTE: before calling the service endpoints you should first get an access token by making a POST request to api/tokens with a body consisting of "username" and "role". Then add that token as Authorization header to all subsequent requests. If calling the service endpoints without token you'll get a 401 repsoinse, which is expected since the API gateway is configured to check if call are authorized or not

# Ocelot features showcased here
1. Configuration
2. Routing
3. Authentication / authorization
4. Header transformation
