### Install report generator
```bash
dotnet tool install -g dotnet-reportgenerator-globaltool
```

### Generate Coverage results

```bash
# Run at the root on the repository
find . -path */TestResults/* -delete
dotnet test --collect:"XPlat Code Coverage;Format=cobertura"
reportgenerator -reports:"./tests/**/TestResults/**/coverage.cobertura.xml" -reporttypes:html -targetdir:"TestResults"
start ./TestResults/index.html
```