build:
	dotnet restore
	dotnet build --no-restore

tests:
	dotnet tests

run:
	dotnet run --project src/Playground.Service.LatencyIssue


