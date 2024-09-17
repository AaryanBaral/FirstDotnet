# GameStore API
## Starting SQL Server
``` powershell
    $sa_password = "[SA Password Here]"
    docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Pass@word123" -e "MSSQL_PID=Evaluation" -p 1433:1433 -v sqlvolume:/var/pot/mssql  --name mssql --hostname sqlpreview -d --rm mcr.microsoft.com/mssql/server:2022-preview-ubuntu-22.04

```
``` powershell
    $sa_password = "[SA Password Here]"
    dotnet user-secrets set "ConnectionStrings:GameStoreContext" "Server=localhost; Database=GameStore; User Id = sa; Password =Pass@word123 ;TrueServerCertificate = True"

```


