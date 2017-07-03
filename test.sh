#!/bin/bash
projects=(Invoice.Tests Invoice.Tests.EndToEnd)
for  project in ${projects[*]}
do
 echo Test running:
 echo $project/$project.csproj
 dotnet test ${project}/${project}.csproj
done
