### CURL COMMAND
- Undermentioned Commands only works with Bash
- Before Using that you have to Stop Https Middleware
- Running your app with http in Visual Studio
```bash
curl -X 'POST' 'http://localhost:5294/auth/register' -H 'accept: */*' -H 'Content-Type: App/json' -d '{   "firstName": "string", "lastName": "string", "email": "string", "password": "string" }'
curl -X 'POST' 'http://localhost:5294/auth/login' -H 'accept: */*' -H 'Content-Type: App/json' -d '{ "email": "string", "password": "string" }'
curl -X 'GET' 'http://localhost:5294/Web/Dinners' -H 'accept: */*' -H 'Authorization: Bearer token.full.goeshere'
```