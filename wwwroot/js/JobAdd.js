document.addEventListener("DOMContentLoaded", function () {
    console.log("🚀 JS loaded and DOM is ready!");
    document.querySelectorAll(".apply-btn").forEach(btn => {
        console.log("🔗 Found Apply Button:", btn);
        btn.addEventListener("click", function () {
            const jobId = this.dataset.jobid;
            const company = this.dataset.company;
            const role = this.dataset.role;

            console.log("🔍 Setting Job ID:", jobId);

            document.getElementById("ApplyJobId").value = jobId;
            document.getElementById("ApplyCompany").innerText = company;
            document.getElementById("ApplyRole").innerText = role;
        });
    });
});
