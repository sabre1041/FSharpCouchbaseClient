# FSharpCouchbaseClient
Simple example using the Couchbase travel-sample

## Start Couchbase
    docker pull couchbase:4.6.3

    docker run -d --name couch --rm -p 8091-8094:8091-8094 -p 11210:11210 couchbase:4.6.3

1. follow quickstart and load travel-sample: https://hub.docker.com/r/library/couchbase/
    

## Get client code
    git clone https://github.com/cowlike/FSharpCouchbaseClient
    
    cd FSharpCouchbaseClient/
    
    dotnet restore
    
    dotnet run

## If 'dotnet run' fails, run Dockerized
    dotnet publish -o publish -c release -r linux-x64
    
    docker build -t app .
    
    docker run --rm app FSharpCouchbaseClient http://<my ip addr>:8091
