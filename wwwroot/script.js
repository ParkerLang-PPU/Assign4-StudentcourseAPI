
async function loadCourses() {
    var courseList = document.getElementById("courseList");
    var message = document.getElementById("message");

    courseList.innerHTML = "Loading courses...";
    message.textContent = "";

    try {
        var response = await fetch("/api/courses");

        if (!response.ok) {
            throw new Error("Could not retrieve courses.");
        }

        var courses = await response.json();

        courseList.innerHTML = "";

        if (courses.length === 0) {
            courseList.innerHTML = "<p>No courses available.</p>";
            return;
        }

        courses.forEach(function(course) {
            var card = document.createElement("div");
            card.className = "course-card";

            var code = document.createElement("h3");
            code.textContent = course.code;

            var title = document.createElement("p");
            title.textContent = course.title;

            var credits = document.createElement("p");
            credits.textContent = "Credits: " + course.credits;

            card.appendChild(code);
            card.appendChild(title);
            card.appendChild(credits);

            courseList.appendChild(card);
        });

        message.textContent = courses.length + " courses found.";

    } catch (error) {
        courseList.innerHTML = "";
        message.textContent = error.message;
    }
}

// Load courses when the page opens
loadCourses();
