# base image for ASP.NET Core
# automatically exposes PORT 80
FROM microsoft/dotnet:2.1-sdk

# install nodejs for angular, webpack middleware
RUN apt-get update  
RUN apt-get -f install  
RUN apt-get install -y wget  
RUN wget -qO- https://deb.nodesource.com/setup_6.x | bash -  
RUN apt-get install -y build-essential nodejs

# set the working directory
WORKDIR /app

# set the environment to Production
ENV ASPNETCORE_URLS http://+:5000
EXPOSE 5000

# copy the published folder created using
# dotnet publish -o published -c Release
COPY published ./

# set the entrypoint of the application
ENTRYPOINT ["dotnet", "MySiteAngular.dll"] 