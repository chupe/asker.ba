# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/aspnet:5.0
EXPOSE 80
EXPOSE 443
ENV ASPNET_DBCONNECTION="Server=tcp:AskerSQL.database.windows.net,1433;Database=coreDB;User ID=chupe;Password=askerMssql123!;Encrypt=true;Connection Timeout=30;MultipleActiveResultSets=true"
COPY AskerTracker/bin/Release/net5.0/ app/
WORKDIR /app
ENTRYPOINT ["dotnet", "AskerTracker.dll"]