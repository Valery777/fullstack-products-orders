@echo off

echo Starting React client...
cd client-ts
start cmd /k "npm start"

echo Starting Node.js orders API...
cd ../orders-api
start cmd /k "npm start"

echo Starting .NET Product API...
cd ../DotNetProductApi
start cmd /k "dotnet run"

echo All services started.
pause
