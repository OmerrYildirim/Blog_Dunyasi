// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener("DOMContentLoaded", function () {
    const checkbox = document.getElementById("isCustomCategory");
    const customInput = document.getElementById("customCategoryName");
    const dropdown = document.getElementById("categoryDropdown");

    function toggleInputs() {
        const isChecked = checkbox.checked;
        customInput.disabled = !isChecked;
        dropdown.disabled = isChecked;
    }

    checkbox.addEventListener("change", toggleInputs);

   
    toggleInputs();
});
