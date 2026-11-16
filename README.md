
# StudentCourseApi

## Description

StudentCourseApi is an ASP.NET Core Minimal API application built with C# and .NET 10.

The application allows users to view, add, update, and delete courses. It stores course information in an in-memory list and includes a simple HTML and JavaScript frontend.

## Technologies Used

- C#
- ASP.NET Core Minimal API
- .NET 10
- HTML
- CSS
- JavaScript
- Fetch API

## Setup Instructions

1. Clone or download the project.
2. Open the project folder in Visual Studio or VS Code.
3. Open a terminal in the project directory.
4. Run the following command:

```bash
dotnet restore
```

5. Start the application:

```bash
dotnet run
```

6. Open the localhost URL displayed in the terminal.

## API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | /api/courses | Retrieve all courses |
| GET | /api/courses/{id} | Retrieve a course by ID |
| POST | /api/courses | Add a new course |
| PUT | /api/courses/{id} | Update a course |
| DELETE | /api/courses/{id} | Delete a course |

## Example POST Request

```json
{
  "code": "CMPS360",
  "title": "Web Programming",
  "credits": 3,
  "instructor": "Professor Smith"
}
```

## Validation

The API checks that:

- Course code cannot be blank.
- Course title cannot be blank.
- Instructor cannot be blank.
- Credits must be between 1 and 6.

Invalid submissions return HTTP 400.

Requests for courses that do not exist return HTTP 404.

Successful course creation returns HTTP 201.

## Testing

The API can be tested using a browser, Postman, or curl.

Example:

```bash
curl http://localhost:5000/api/courses
```

The application also includes a webpage that automatically retrieves and displays courses using JavaScript fetch().

## Screenshots

Add screenshots of the following:

1. The Student Course Management webpage.
2. The GET request showing all courses.
3. A successful POST request.
4. A successful PUT request.
5. A successful DELETE request.
6. An invalid submission returning HTTP 400.
7. A request returning HTTP 404.

## Notes

Course information is stored in memory. Any changes will reset when the application is restarted.
