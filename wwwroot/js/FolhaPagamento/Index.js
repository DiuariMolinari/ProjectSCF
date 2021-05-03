window.onload = function () {
    document.getElementById("btnClear").onclick = function () {
        document.getElementById("maxDate").value = "";
        document.getElementById("minDate").value = "";
        document.getElementById("btnFilter").click();
    };
}