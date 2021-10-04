# Sample Mono DNNE embedding

## What is it

This is an example of using [DNNE](https://github.com/AaronRobinsonMSFT/DNNE) to invoke a MonoVM runtime.

## Requirements

.NET 7

## Building

```console

$ dotnet build
$ dotnet publish --self-contained -r osx-x64

$ make -C consumer
```

To use Mono, pass `-p:UseMonoRuntime=true` to both `dotnet` calls

## Running

```console
$ ./consumer/consumer
Hello World from CoreCLR!
System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e

.NET 6.0.0-rc.2.21470.23
```

## With local mono

Build with

```console
$ dotnet publish --self-contained -r osx-x64 -p:UseMonoRuntime=true
```

```console
$ make -C consumer copymono R=/path/to/artifacts/bin/mono/OSX.x64.Release
```


