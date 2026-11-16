
using StudentCourseApi.Models;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// Serve HTML, CSS, and JavaScript files
app.UseDefaultFiles();
app.UseStaticFiles();

// Course List
var courses = new List<Course>
{
    new Course
    {
        Id = 1,
        Code = "BMGT221.OAON",
        Title = "Business Communications and Research",
        Credits = 3,
        Instructor = "John Lawrence"
    },

    new Course
    {
        Id = 2,
        Code = "CMPS360.OAON",
        Title = "Survey of Programming Languages",
        Credits = 3,
        Instructor = "Jeffrey Seaman"
    },

    new Course
    {
        Id = 3,
        Code = "CMPS361.DZ",
        Title = "Web Application Development",
        Credits = 3,
        Instructor = "Jeffrey Seaman"
    },

    new Course
    {
        Id = 4,
        Code = "ENGL252.OADL",
        Title = "The Art of Creative Nonfiction",
        Credits = 3,
        Instructor = "Christopher Girman"
    },

    new Course
    {
        Id = 5,
        Code = "HRM205.DD",
        Title = "People and the Environment",
        Credits = 3,
        Instructor = "Dr. Fyola"
    }
};

// Validate course information
bool IsValidCourse(Course course)
{
    return !string.IsNullOrWhiteSpace(course.Code)
        && !string.IsNullOrWhiteSpace(course.Title)
        && !string.IsNullOrWhiteSpace(course.Instructor)
        && course.Credits >= 1
        && course.Credits <= 6;
}

// GET: Retrieve all courses
app.MapGet("/api/courses", () =>
{
    return Results.Ok(courses);
});

// GET: Retrieve one course by ID
app.MapGet("/api/courses/{id}", (int id) =>
{
    var course = courses.FirstOrDefault(c => c.Id == id);

    if (course == null)
        return Results.NotFound();

    return Results.Ok(course);
});

// POST: Add a new course
app.MapPost("/api/courses", (Course newCourse) =>
{
    if (!IsValidCourse(newCourse))
        return Results.BadRequest("Invalid course information.");

    newCourse.Id = courses.Count == 0
        ? 1
        : courses.Max(c => c.Id) + 1;

    courses.Add(newCourse);

    return Results.Created($"/api/courses/{newCourse.Id}", newCourse);
});

// PUT: Update an existing course
app.MapPut("/api/courses/{id}", (int id, Course updatedCourse) =>
{
    var course = courses.FirstOrDefault(c => c.Id == id);

    if (course == null)
        return Results.NotFound();

    if (!IsValidCourse(updatedCourse))
        return Results.BadRequest("Invalid course information.");

    course.Code = updatedCourse.Code;
    course.Title = updatedCourse.Title;
    course.Credits = updatedCourse.Credits;
    course.Instructor = updatedCourse.Instructor;

    return Results.Ok(course);
});

// DELETE: Remove a course
app.MapDelete("/api/courses/{id}", (int id) =>
{
    var course = courses.FirstOrDefault(c => c.Id == id);

    if (course == null)
        return Results.NotFound();

    courses.Remove(course);

    return Results.NoContent();
});

// Start the application
app.Run();
