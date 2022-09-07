# Grafana k6 performance test ws

## Kjøre api lokalt

Gå til 'K6.Api' katalogen. Om du har .NET CLI så kan du starte api'et med kommandoen `dotnet run .`


## Kjøre Grafana og InfluxDB lokalt [Valgfritt]

Dersom du ønsker å teste visning av testresultater i Grafana, så kan du kjøre Grafana og InfluxDB lokalt. Det krever at du har Docker og Docker Compose installert (om du har Docker Desktop så har du begge).
Grafana k6 har laget en docker-compose setup for dette (link);

`git clone 'https://github.com/grafana/k6'

cd k6

docker-compose up -d influxdb grafana

docker-compose run -v $PWD/samples:/scripts k6 run /scripts/es6sample.js`
