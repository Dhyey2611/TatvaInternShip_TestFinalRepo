document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll(".edit-category-btn").forEach(btn => {
        btn.addEventListener("click", function () {
            const JobId = this.getAttribute("data-id");

            fetch(`/Home/EditJobPost/${JobId}`)
                .then(response => response.json())
                .then(data => {
                    console.log("Data received from server:", data);
                    document.getElementById("EditJobId").value = data.id;
                    document.getElementById("EditCompanyName").value = data.companyName;
                    document.getElementById("EditRole").value = data.jobRole;
                })
                .catch(error => {
                    console.error("Error fetching section data:", error);
                });
        });
    });
});
