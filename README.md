# MyAngularSite
My angular site using webapi as a calculation service


To build you run (after running npm install)

cd MySiteAngular

dotnet publish -o published -c Release

cd ..

sudo docker-compose build

sudo docker-compose up -d