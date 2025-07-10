
# Console Todo List Application (C#)

This is a simple and functional Todo List application built in C# using a console-based interface. It allows you to create, update, delete, edit and view detail tasks with support for due dates, completion status, and detailed metadata.

## Features
Create a new task with a title and due date
View all tasks in a simple list format
View details of a specific task (Created date, Due date, Completed date, Last modified date)
Edit task title or status (Open/Complete)
Delete tasks by ID
Detect and block duplicate IDs or IDs not found
Automatically tracks when a task was:
  - Created
  - Completed
  - Last modified

## How It Works

This application uses a design with the following structure:

- TodoItem.cs: Represents a single todo task
- TodoManager.cs: Contains core logic for managing tasks (create, delete, update, etc.)
- TaskViewer.cs: Handles rendering tasks to the console
- App.cs: Controls the user interface and handles user input
- Status.cs: Handles status value of todo task like "Open" or "Complete"
- InputParser.cs: Parses edit commands like title=Gym or status=complete
- EditToItemInstruction.cs: Holds property-value pairs for editing a task
- Global.cs: Holds input commands

## Getting Started
Prerequisites
 .NET 8 SDK 
 Any C# compatible IDE (Visual Studio, VS Code)

Run the Application

 Clone this repo:
   git clone https://github.com/muhammadou1/ToDoList.git

Created by [Muhammadou Drammeh](https://github.com/Muhammadou1) as a console-based practice project for understanding object-oriented design and clean code principles.
Monitored by [John Cruz](https://github.com/JCruz6725)

