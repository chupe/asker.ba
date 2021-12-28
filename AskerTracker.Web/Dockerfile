# syntax=docker/dockerfile:1
ARG SECRET
ENV ASKER_DBCONNECTION=$SECRET
FROM mcr.microsoft.com/dotnet/aspnet:5.0
EXPOSE 80
EXPOSE 443
COPY AskerTracker/bin/Release/net5.0/ app/
WORKDIR /app
ENTRYPOINT ["dotnet", "AskerTracker.dll"]