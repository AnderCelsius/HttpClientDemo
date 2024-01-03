# HttpClientDemo API Client Generator

## About
The `HttpClientDemo` project demonstrates how to automatically generate a REST API client during the build process using NSwag and MSBuild. This approach streamlines the development workflow by ensuring that the API client is always up-to-date with the latest API changes.

## Getting Started
To get started with the `HttpClientDemo` project, clone this repository to your local machine using the following command:

```bash
git clone https://github.com/AnderCelsius/HttpClientDemo.git
```

Navigate to the `src` directory where the project files are located:

```bash
cd HttpClientDemo/src
```

## Prerequisites
Make sure you have the following installed:
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- [NSwag](https://github.com/RicoSuter/NSwag) (version 13.20.0 or later)

## Building the Project
To build the project and generate the API client, use the following command:

```bash
dotnet build
```

This command will invoke MSBuild, which is configured to run NSwag to generate the API client based on the Swagger specification.

## Configuration
The NSwag generation is configured in the `.csproj` file of the project. For more details, refer to the `csharpClient.nswag` configuration file in the repository.

## Usage
After building the project, the generated API client will be available for use within your application. You can instantiate the client and begin making API calls to the corresponding REST endpoints.

## Contributing
Contributions to the `HttpClientDemo` project are welcome. Please feel free to submit issues, pull requests, or suggest improvements via the GitHub repository.

## License
This project is licensed under the [MIT License](LICENSE). Feel free to use it, contribute, or share it as per the license terms.

## Acknowledgments
A special thanks to the NSwag toolchain for making API client generation seamless and to all the contributors of the `HttpClientDemo` project.

## Contact
For any additional information or questions, you can reach out through the repository's [issue tracker](https://github.com/AnderCelsius/HttpClientDemo/issues).

## Resources
- [Project Repository](https://github.com/AnderCelsius/HttpClientDemo)
- [Source Code](https://github.com/AnderCelsius/HttpClientDemo/tree/master/src)
- [MSBuild Documentation](https://learn.microsoft.com/en-us/visualstudio/msbuild/tutorial-rest-api-client-msbuild?view=vs-2022)
```

