# SimPE

An editor designed for modding The Sims 2, rewritten and remastered.

## Contributing

Contributions are always welcome!

### Compiling

#### Visual Studio

Inside the `fullsimpe` folder is the file `SimPe.sln`, which can be opened with Visual Studio.

#### VSCode

Use the build task to compile the program.

#### Command line

Go to the `SimPe` folder and run either `dotnet build` to build it or `dotnet run` to build and run the program.

### Prerequisites

- [.NET SDK 9.0](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- For code editing: Either Visual Studio 2022 or Visual Studio Code (or compatible forks)
  - When using VSCodium or other open-source VSCode forks: As Microsoft has their C# tooling as closed-source,
    you need to install the [C# with NetCoreDbg](https://open-vsx.org/extension/blipk/csharp) extension for debugging.
  - Recommended extensions in Code are Avalonia (as this uses Avalonia UI), C# and the XAML Styler.
