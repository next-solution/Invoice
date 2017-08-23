#!/bin/bash
cp Invoice.Api/appsettings.json .
cp Invoice.Api/nlog.config .
dotnet run -p Invoice.Api/Invoice.Api.csproj
