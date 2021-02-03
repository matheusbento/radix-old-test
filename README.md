# Desafio para vaga de analista pleno/sênior

## Final considerations

### How to run in a unique step

run: `make setup`

:) great!! Project runnning, now it's time to access

### How to access Dashboard

url: `http://localhost`

### How to send events

url: `POST http://localhost:5000/api/event`

JSON BODY:
`{
  "tag": "brasil.sul.sensor02",
  "value": "1231123",
  "timestamp": 123123123123
}`

### How to access Swagger and see all methods

url: `http://localhost:5000/swagger/index.html`

## Commands

### Start Project

run: `make start`

### Start Project with Logs

run: `make start-with-log`

### Setup project

run: `make setup`

### Access APP Shell

run: `make shell-app`

### Access API Shell

run: `make shell-api`

### Access MSSQL Shell

run: `make shell-mssql`

### Stop Project

run: `make stop`

### Uninstall Project

run: `make destroy`

