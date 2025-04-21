const hamBurger = document.querySelector(".toggle-btn");

hamBurger.addEventListener("click", function () {
    document.querySelector("#sidebar").classList.toggle("expand");
});

document.addEventListener("DOMContentLoaded", function () {

    const addStudentBtn = document.getElementById("add-student-btn");
    const groupLinks = document.querySelectorAll(".group-link");

    groupLinks.forEach(link => {
        link.addEventListener("click", function (e) {
            e.preventDefault();

            const groupId = this.getAttribute("data-group-id");
            const courseId = document.getElementById("courseId").value;

            addStudentBtn.href = `/Student/Create?courseId=${courseId}&groupId=${groupId}`

            fetch(`/Group/GetStudents?groupId=${groupId}&courseId=${courseId}`)
                .then(response => response.text())
                .then(html => {
                    document.querySelector("#students-container").innerHTML = html;
                });
        });
    });
});

