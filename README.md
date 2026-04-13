# Chess Engine Project

A C# based implementation of the classic game of Chess, structured as a modular library with a dedicated console interface and testing suite.

[![C#](https://img.shields.io/badge/Language-C%23-blue.svg)](https://dotnet.microsoft.com/) [![Status](https://img.shields.io/badge/Status-Development-yellow.svg)]()

## Table of Contents
- [About](#about)
- [Features](#features)
- [Project Structure](#project-structure)
- [Installation](#installation)
- [Usage](#usage)
- [Contributing](#contributing)

## About
This project provides a robust framework for managing a chess game, including piece logic, board state management, and move validation. It is designed with a separation of concerns, splitting core game logic into a class library for potential integration into other UIs.

## Features
-  **Modular Architecture**: Separate class library for game engine logic.
-  **Core Piece Logic**: Encapsulated rules for chess pieces and board interaction.
-  **Test-Ready**: Includes a dedicated project for unit testing game states.
-  **Console Interface**: Basic entry point for running the game locally.

## Project Structure
```text
chess/
├── ClassLib/           # Core game engine and logic
│   ├── chessField.cs   # Board representation
│   ├── figure.cs       # Base classes for chess pieces
│   └── figureLogic.cs  # Move validation rules
├── Program/            # Console application entry point
├── Test/               # Unit testing suite
└── chess.slnx          # Solution configuration
```

##  Installation
1. Ensure you have the [.NET SDK](https://dotnet.microsoft.com/download) installed.
2. Clone the repository:
   ```bash
   git clone https://github.com/FabianJ-L/chess
   ```
3. Navigate to the root directory and build the solution:
   ```bash
   dotnet build
   ```

##  Usage
To run the application, navigate to the `Program` directory and execute:
```bash
dotnet run --project Program/Program.csproj
```

##  Contributing
Contributions are welcome! Please feel free to open issues or submit pull requests to help improve the game logic or add new features.
