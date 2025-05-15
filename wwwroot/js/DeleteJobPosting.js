document.addEventListener("DOMContentLoaded", function () {
    document.querySelectorAll("[data-bs-target='#deleteModal']").forEach(btn => {
        btn.addEventListener("click", function () {
            const JobId = this.getAttribute("data-id");
            console.log("data-id to be deleted is: ", JobId);
            document.getElementById("JobId").value = JobId;
        });
    });
});
