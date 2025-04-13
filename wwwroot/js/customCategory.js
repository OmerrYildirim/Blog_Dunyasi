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