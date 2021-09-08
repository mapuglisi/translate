# Translation Server

**Simple Translation** is a machine translation tool that can translate sentences between 3 popular languages (English, German and French).

This server was built using C# and provides a REST API with an endpoint to translate text between English, German and French, which encapsulates the usage of an [external translation library](https://www.nuget.org/packages/Wadereye.GoogleTranslateFreeApi/) based on Google Translate API (unofficial).




## Installation

Download the code from [repository](https://github.com/mapuglisi/translate-server.git)

You can run this project by using the command `dotnet run` while in the code folder, as long as you have the .NET SDK available in your machine.



## Docker

Build the server image by using the following command:

```bash
docker build -t translation-server:v1 .
```
Then run the image in a container

```bash
docker run -it --rm -p 8090:80 translation-server:v1
```



## Usage

The server will be running on [localhost:8090](http://localhost:8090/swagger/index.html)

![Server](https://raw.githubusercontent.com/mapuglisi/translate-server/main/Server.png)

## License
[MIT](https://choosealicense.com/licenses/mit/)
