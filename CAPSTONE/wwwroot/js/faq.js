document.addEventListener("DOMContentLoaded", function () {

    const items = document.querySelectorAll(".faq-item");

    items.forEach(item => {
        const question = item.querySelector("h3");
        const answer = item.querySelector("p");

        question.addEventListener("click", () => {

            const isOpen = answer.style.display === "block";

            // close all
            document.querySelectorAll(".faq-item p").forEach(p => p.style.display = "none");
            document.querySelectorAll(".faq-item h3").forEach(h => h.classList.remove("active"));

            if (!isOpen) {
                answer.style.display = "block";
                question.classList.add("active");
            }

        });
    });

});