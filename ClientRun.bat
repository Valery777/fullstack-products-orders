@echo off
echo Starting React client...
cd client-ts
start cmd /k "npm start"

echo Starting Node.js orders API...
cd ../orders-api
start cmd /k "npm start"

echo All services started.
pause

