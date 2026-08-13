# Exception Handling in C#

## Overview

This console application demonstrates various exception handling techniques in C#. The application uses a menu-driven interface that allows users to execute different tasks showcasing exception generation, handling, propagation, custom exceptions, stack trace analysis, and unhandled exception handling.

---

## Tasks Implemented

### Task 1: Divide by Zero Exception

This task demonstrates handling a `DivideByZeroException`.

#### Implementation
- Accepts two integer inputs from the user.
- Performs division using the `Divide` class.
- Retrieves the quotient through a calculated property.
- Uses exception handling to prevent application crashes.

#### Exceptions Handled
- `FormatException` for invalid numeric input.
- `DivideByZeroException` when the divisor is zero.

#### Key Concepts
- Arithmetic exception handling.
- `try-catch-finally` blocks.
- User input validation.

---

### Task 2: Array Index Out of Bounds with Custom Message

This task demonstrates handling attempts to access an array using an invalid index.

#### Implementation
- Creates an array of random integers.
- Accepts an index from the user.
- Retrieves the element at the specified index.
- Re-throws an exception with a custom message when the index is invalid.

#### Exceptions Handled
- `FormatException`
- `OverflowException`
- `IndexOutOfRangeException`

#### Key Concepts
- Exception wrapping.
- Custom error messages.
- Preserving original exception information using inner exceptions.

---

### Task 3: Array Index Out of Bounds with Custom Exception

This task expands on Task 2 by introducing a custom exception type.

#### Implementation
- Defines a custom exception named `InvalidUserInputException`.
- Converts framework exceptions into domain-specific exceptions.
- Preserves the original exception using the `InnerException` property.

#### Exceptions Handled
- `InvalidUserInputException`

#### Key Concepts
- Creating custom exceptions.
- Exception inheritance.
- Encapsulating lower-level exceptions.

---

### Task 4: AppDomain Unhandled Exception Event

This task demonstrates global exception handling.

#### Implementation
- Subscribes to the `AppDomain.CurrentDomain.UnhandledException` event.
- Generates a random exception.
- Displays exception information when an unhandled exception occurs.

#### Key Concepts
- Global exception handling.
- Event-driven exception monitoring.
- Application-level diagnostics.

---

### Task 5: Displaying Exception Stack Trace

This task demonstrates exception propagation and debugging using stack traces.

#### Implementation
- Calls `TaskTwoRunner.RunWithoutExceptionHandling()`.
- Allows exceptions to propagate through the call stack.
- Captures and displays the stack trace when an exception is caught.

#### Information Displayed
- Exception Type
- Exception Message
- Stack Trace

#### Key Concepts
- Exception propagation.
- Debugging techniques.
- Understanding execution flow through stack traces.

---

## Stack Trace Interpretation (Task 5)

A stack trace records the sequence of method calls made before an exception occurred.

### Sample Stack Trace

```text
System.IndexOutOfRangeException: Couldn't access element, index is out of range.
   at ExceptionHandling.TaskTwo.TaskTwoRunner.ExecuteTask()
   at ExceptionHandling.TaskTwo.TaskTwoRunner.RunWithoutExceptionHandling()
   at ExceptionHandling.TaskFive.TaskFiveRunner.Run()
```

### Interpretation

The stack trace can be interpreted as follows:

1. The exception originated in `ExecuteTask()`.
   - An invalid array index was used while accessing an array element.

2. The exception propagated to `RunWithoutExceptionHandling()`.
   - No exception handling was performed in this method.

3. The exception continued to propagate to `TaskFiveRunner.Run()`.
   - The exception was finally caught and displayed.

### Why Stack Traces Are Important

Stack traces help developers:

- Identify the exact location where an exception occurred.
- Understand the sequence of method calls leading to the failure.
- Troubleshoot and debug applications efficiently.
- Determine the root cause of runtime errors.

---

## Exception Handling Concepts Demonstrated

- `try-catch-finally`
- Runtime exception handling
- Custom exception creation
- Exception wrapping
- Inner exceptions
- Exception propagation
- Global exception handling
- Stack trace analysis
- Diagnostic logging
