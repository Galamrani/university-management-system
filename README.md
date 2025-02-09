# README

# University Management System

## Overview

The **University Management System** is a C# console application designed to manage a university's students, professors, and administrative tasks. It allows users to add and manage students and professors, assign subjects, enroll students in courses, and determine graduation eligibility based on performance.

## Features

- **Add Students & Professors**: Register new students and professors in the system.
- **Assign Subjects**: Assign subjects to professors.
- **Enroll Students**: Students can be enrolled in courses with grades.
- **Display People**: List all students and professors in the university.
- **Graduate Students**: Identify and remove students who meet graduation criteria.

## Usage

Run the `Program.cs` file to start the system. The user is prompted with a menu to perform various management actions.

## Changing the Data Store in `University` Class

The `University` class is designed to be flexible with its data store by using the `IUniversityRepository` interface. This allows switching between different data storage implementations without modifying the core logic of the application.

### How to Change the Data Store

1. **Create a new repos class and Implement the `IUniversityRepository` Interface**

   - Create a new class that implements `IUniversityRepository`.
   - Ensure it provides implementations for all required methods.

2. **Replace `DictionaryUniversityRepository` in `Program.cs`**
   - Locate the `Main` method in `Program.cs`.
   - Replace:
     ```
     IUniversityRepository repository = new DictionaryUniversityRepository();
     ```
     with (for example):
     ```
     IUniversityRepository repository = new MongoUniversityRepository();
     ```

### Example Implementations

- `ListUniversityRepository`: Uses a `List<Person>` instead of a `Dictionary`.
- `MongoUniversityRepository`: Uses MongoDB for document-based storage.
- `RadixUniversityRepository`: Uses a radix tree for efficient searching.

## Adding a New User Action (Command)

To add a new command to the system, follow these steps:

1. **Define a new `UserAction` in the `UserAction` Enum**

   - Locate the `UserAction` enum and add a new value, e.g., `CustomAction`.
     ```
     public enum UserAction
     {
         Quit = 0,
         AddStudent,
         AddProfessor,
         EnrollStudent,
         AssignSubject,
         DisplayAllPeople,
         GraduateStudents,
         CustomAction // New action
     }
     ```

2. **Create a New Command Class**

   - Define a new class that inherits from `BaseCommand`.
   - Implement the `Execute()` method.

     ```
     public class CustomActionCommand : BaseCommand
     {
         public CustomActionCommand(University university) : base(university) { }

         public override void Execute()
         {
            // Action logic here!!
         }
     }
     ```

3. **Register the New Command in `CommandFactory`**

   - Modify `CommandFactory.GetCommand` to return the new command:
     ```
     public static BaseCommand GetCommand(UserAction action, University university)
     {
         return action switch
         {
             UserAction.Quit => throw new InvalidOperationException("Quit action should be handled separately."),
             UserAction.AddStudent => new AddStudentCommand(university),
             UserAction.AddProfessor => new AddProfessorCommand(university),
             UserAction.EnrollStudent => new EnrollStudentCourseCommand(university),
             UserAction.AssignSubject => new AssignProfessorSubjectCommand(university),
             UserAction.DisplayAllPeople => new DisplayPeopleCommand(university),
             UserAction.GraduateStudents => new GraduateStudentsCommand(university),
             UserAction.CustomAction => new CustomActionCommand(university), // New command
             _ => throw new InvalidActionException(action)
         };
     }
     ```

4. **Ensure `ConsoleUI` Supports the New Action**

   - Modify `ConsoleUI.PromptForUserAction()` to include the new action in user prompts.

Now, when the user selects the new action, the `CustomActionCommand` will be executed.
