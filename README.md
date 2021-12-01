# Url-Forwarder
Intercepts a specified URL and forward to a specified destination URL. 

# Prerequisites
This application uses .NET core and required .NET core SDK to be downloaded and installed.

# How to run
1. Clone code.
2. Run the application using your favourite IDE.
3. When prompted enter the URL to intercept (e.g. http://localhost:5000/api/intercept)
4. When prompted enter the URL to forward (e.g. http://localhost:6000/api/forward)

The application will intercept incoming requests based on the provided URL and forward the requests to the forward URL, including any query parameters.

