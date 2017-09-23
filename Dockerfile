FROM microsoft/dotnet:2-runtime
WORKDIR /app
ADD publish .
ENV PATH="/app:${PATH}"
CMD ["FSharpCouchbaseClient"]
