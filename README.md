# Project Euler

My katas in many programming languages using [Project Euler's](https://projecteuler.net/) problems.

Instructions below were written with the following assumptions:
- OS: Windows 10
- IDE: [Visual Studio Code](https://code.visualstudio.com/).
- Commands ran in a Powershell terminal inside the IDE.

You may need slightly modifications to run this in other setups.

---

## C

Extras to the development environment:
1. Add [C/C++ plugin](https://marketplace.visualstudio.com/items?itemName=ms-vscode.cpptools) to VS Code.
2. Install [MinGW Distro](https://nuwen.net/mingw.html) (to get `gcc/gdb`).

Build & Run: 
1. Open a terminal window in the `~\C\` sub-folder
2. > `gcc *.c -o Euler ; ./Euler`

--- 

## C#

My development environment:
1. Add [C# plugin](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp) to VS Code.
2. Install [.NET SDK 6.0 x64](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) (to get `dotnet`).

Build & Run: 
1. Open a terminal window in the `~\CSharp\` sub-folder
2. > `dotnet run`

--- 

## Go

My development environment:
1. Add [Go](https://marketplace.visualstudio.com/items?itemName=golang.go) to VS Code.
2. Install [Go 1.17.5 or higher](https://go.dev/dl/) (to get `go`).

Build & Run: 
1. Open a terminal window in the `~\Go\` sub-folder
2. > `go run Euler.go`

--- 

## Java

My development environment:
1. Add [Extension Pack for Java](https://marketplace.visualstudio.com/items?itemName=vscjava.vscode-java-pack) to VS Code.
2. Install [OpenJDK 17.0.1 or higher](https://jdk.java.net/17/) (to get `java` and `javac`).
3. Add the `bin` folder containing `java` and `java` to the `PATH` (to run them in the terminal).
4. > `$env:Path = [System.Environment]::GetEnvironmentVariable("Path","Machine")` (to update the loaded PATH without a reboot)

Build & Run: 
1. Open a terminal window in the `~\Java\` sub-folder
2. > `javac Euler.java | java -cp . Euler`
   
---

## Python

My development environment:
1. Add [Python plugin](https://marketplace.visualstudio.com/items?itemName=ms-python.python) to VS Code.
2. Install [Python 3.9 or higher](https://www.python.org/downloads/).

Build & Run: 
1. Open a terminal window in the `~\Python\` sub-folder
2. > `python Euler.py`

---