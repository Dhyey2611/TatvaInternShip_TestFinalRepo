document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll(".edit-category-btn").forEach(btn => {
        btn.addEventListener("click", function () {
            const StudentId = this.getAttribute("data-id");

            fetch(`/Home/EditJobPost/${JobId}`)
                .then(response => response.json())
                .then(data => {
                    console.log("Data received from server:", data);
                    document.getElementById("EditJobId").value = data.jobId;
                    document.getElementById("EditCompanyName").value = data.name;
                    document.getElementById("EditRole").value = data.role;
                })
                .catch(error => {
                    console.error("Error fetching section data:", error);
                });
        });
    });
});
