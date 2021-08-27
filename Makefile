#project variables

PROJECT_NAME ?= JustRecipi

.PHONY: migrations db hello

migrations:
		cd ./JustRecipi.Data && dotnet ef --startup-project ../JustRecipi.WebApi/ migrations add $(mname) && cd ..

db:
		cd ./JustRecipi.Data && dotnet ef --startup-project ../JustRecipi.WebApi/ database update && cd ..
start:
		cd ./JustRecipi.WebApi && dotnet build && dotnet run && cd ..
hello:
		echo 'hello!'