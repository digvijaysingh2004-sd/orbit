function showToast(message, type) {
    var toastContainer = document.getElementById("toastContainer");
    if (!toastContainer) {
        toastContainer = document.createElement("div");
        toastContainer.id = "toastContainer";
        toastContainer.style.position = "fixed";
        toastContainer.style.top = "50px";
        toastContainer.style.right = "20px";
        toastContainer.style.display = "flex";
        toastContainer.style.flexDirection = "column";
        toastContainer.style.alignItems = "flex-end";
        toastContainer.style.gap = "10px";
        toastContainer.style.zIndex = "9999";
        document.body.appendChild(toastContainer);
    }

    var toast = document.createElement("div");
    toast.className = "toast show " + type;
    toast.style.position = "relative";
    toast.style.transform = "translateX(150%)";
    toast.style.opacity = "0";
    toast.style.transition = "transform 0.6s cubic-bezier(0.25, 1, 0.5, 1), opacity 0.4s ease-in-out";
    toast.innerHTML = `
            <span class="toast-icon">${getIcon(type)}</span>
            <span class="toast-message">${message}</span>
            <div class="progress-bar"></div>
            <button class="close-btn">&times;</button>
        `;

    toastContainer.appendChild(toast);

    setTimeout(() => {
        toast.style.transform = "translateX(0)";
        toast.style.opacity = "1";
    }, 100);

    var progressBar = toast.querySelector(".progress-bar");
    progressBar.style.width = "100%";
    progressBar.style.transition = "width 3s linear";
    setTimeout(() => {
        progressBar.style.width = "0%";
    }, 10);

    var timeout = setTimeout(() => {
        hideToast(toast);
    }, 3000);

    toast.querySelector(".close-btn").onclick = function () {
        clearTimeout(timeout);
        hideToast(toast);
    };

    toast.onclick = function () {
        clearTimeout(timeout);
        hideToast(toast);
    };
}

function hideToast(toast) {
    toast.style.transform = "translateX(150%)";
    toast.style.opacity = "0";
    setTimeout(() => {
        toast.remove();
    }, 600);
}

function getIcon(type) {
    switch (type) {
        case "error": return "&#x26A0;";
        case "danger": return "&#x274C;";
        case "warning": return "&#x26A0;";
        case "success": return "&#x2705;";
        default: return "";
    }
}