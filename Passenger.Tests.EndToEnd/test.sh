#!/bin/bash
projects=(Passenger.Tests2 Passenger.Tests.EndToEnd)
for project in ${projects[*]}
do
	echo Running tests for: $project
	dotnet test $project/$project.csproj
done
