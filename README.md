# urlShortenApi
this is a api project to shorten th url
## Creating database
you should add data bases before running the project so run this commands
```
dotnet tool install --global dotnet-ef
dotnet ef database update
```
## Run

to run the project write this command at the path of project/src
```
dotnet run
```
## Testing

if you want to run the tests ou should run this command in the directory of tests in the project:
```
dotnet test
```
## Usage

it has two method Post methos for givinig you the short url and a Get one to redirect you to the long of it:

#### Post

this one run with /urls routh and you should give the json file of your long url to do:
```
curl -X Post -d "longUrl" -H "Content-Type: application/json" http://localhost:5000/urls
```

#### Get

the route id /yourShort
```
curl -i -L -K localhost:5000/"the short"
```
