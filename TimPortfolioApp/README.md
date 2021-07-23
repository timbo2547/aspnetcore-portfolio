### Running the App with Docker Compose

1. dotnet restore

1. restore front end libraries (right ciick libman in VS)

1. Install Docker

1. Move back up a level to the `AspNetCorePostgreSQLDockerApp` in the terminal window:

    - Run `docker-compose build`

    - Run `docker-compose up`

1. Navigate to http://localhost:5000 in your browser to view the site.

## Using the Web App for Container Services on Azure

1. Run `docker-compose -f docker-compose.prod.yml build`.
1. Tag the `aspnetcoreapp` image as `[yourDockerHubUserAccount]/aspnetcoreapp`. Make sure you substitute your Docker Hub user account for `[yourDockerHubUserAccount]`.
1. Push the image to Docker Hub using `docker push [yourDockerHubUserAccount]/aspnetcoreapp`.
1. Open `docker-compose azure.yml` file and change the image for the `web` service to `[yourDockerHubUserAccount]/aspnetcoreapp`.
1. Create a new `Web App for Containers` service in Azure. You'll need to add it to a new or existing Resource Group.
1. On the `Docker` tab, switch `Options` to `Docker Compose`, `Image Source` to `Docker Hub` and upload the `docker-compose azure.yml` file using the `Configuration File` section of the screen.
1. Wait for the service to start (it may take a few minutes to pull the image and fire up the Web App Service) and then click the web link it provides in the `Overview` section to hit the app.
