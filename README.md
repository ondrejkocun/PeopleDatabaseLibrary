# PeopleDatabaseLibrary

A small C#/.NET project demonstrating a reusable people database library and a console application built on top of it.

## Features

- Person, teacher and student domain models
- Generated sample people data
- Sorting and indexed access to people
- Filtering teachers and students
- Name-based lookup
- Tuple returns and object deconstruction
- Console output of the stored records

## Project structure

- `PeopleDatabaseLibrary` - reusable class library
- `PeopleDatabaseApp` - console application demonstrating the library
- `PeopleDatabaseLibrary.slnx` - solution file

## Requirements

- .NET 10 SDK

## Run

From the repository root:

```bash
dotnet run --project PeopleDatabaseApp/PeopleDatabaseApp.csproj
```

To build the complete solution:

```bash
dotnet build PeopleDatabaseLibrary.slnx
```

## Purpose

This project was created as a C# learning exercise focused on classes, collections, indexers, sorting, generated data and reusable library design.