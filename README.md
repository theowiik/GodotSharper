# GodotSharper

Utility library for Godot C# projects.

<div align="center">
    <img width="350" src="Meta/logo.png">
</div>

- [GodotSharper](#godotsharper)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Features](#features)
    - [Autowiring](#autowiring)
  - [Old version](#old-version)

## Prerequisites

- Godot 4.1.1
- .NET 7.0

## Installation

1. Build dll file with `dotnet build`
2. Move `GodotSharper.dll` file (located in `obj/Debug/net7.0/GodotSharper.dll`) into your Godot project
3. Update your `.csproj` file to include the dll file

```xml
<ItemGroup>
    <Reference Include="GodotSharper">
        <HintPath>PathToFile/GodotSharper.dll</HintPath>
    </Reference>
</ItemGroup>
```

## Features

- Autowiring

### Autowiring

TODO 🚧 👷 👷

## Old version

Old version with LOTS of more features: https://github.com/theowiik/GodotSharper/tree/pre-package-freeze
