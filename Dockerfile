FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
EXPOSE 80

# Copy the published application files to the container
COPY /Presentation/bin/Release/net7.0/publish/ /app

# Set the entry point to your application DLL

ENTRYPOINT ["./Presentation"]