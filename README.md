# simple-dotnet-docker-service
A simple example of a .NET hosted service with a Dockerfile. When started, the service makes an HTTP GET request to https://httpbin.org/GET every 5 seconds, and log the 
response to the console using Serilog.

To build the app and create the Docker image, run this command from the **parent directory** -- i.e. the folder containing `TestApp`, *not* the folder containing the `Dockerfile`

```bash
docker build -f TestApp/Dockerfile -t testapp .
```

Then to run TestApp inside Docker, use

```
docker run -it testapp
```

> Note the `-it` switch here will run the Docker app with an interactive terminal. If you omit this switch, then it'll start just fine, but you won't be able to stop it with Ctrl-C; you'll need to find the running Docker instance and stop it via the Docker dashboard or the instance ID.



