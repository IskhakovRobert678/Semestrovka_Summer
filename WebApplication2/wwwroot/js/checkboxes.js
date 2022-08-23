const checkboxes = Array.from(document.getElementsByTagName("input"))
    .filter(input => input.type === "checkbox");

const onChecked = (e) => {
    checkboxes.forEach(checkbox => checkbox.checked = false);
    e.currentTarget.checked = true;
}

const init = () => {
    checkboxes.forEach(checkbox => checkbox.addEventListener("click", onChecked));
}

window.addEventListener("load", init);