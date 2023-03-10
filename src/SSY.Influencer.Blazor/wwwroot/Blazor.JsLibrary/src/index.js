import Swal from 'sweetalert2'


window.loadMultiSelectSearch = function() {
    $('.select-picker').selectpicker();
}

window.loadMultiSelectRefresh = function() {
    $('.select-picker').selectpicker('refresh');
}

window.confirm = function (icon, title, message) {
    return new Promise(resolve => {
        Swal.fire({
            icon: icon,
            title: title,
            text: message,
            showCloseButton: true,
            showCancelButton: true,
            confirmButtonColor: "#7B8E61",
            confirmButtonText: "Yes",
            cancelButtonText: 'No'
        }).then((result) => {
            resolve(result.isConfirmed);
        })
    });
}

window.defaultMessage = function(icon, title, message) {

    Swal.fire({
        icon: icon,
        title: title,
        text: message,
        confirmButtonColor: "#7B8E61",
    })

}

window.defaultMessageWithRedirect = function(icon, title, message, url) {

    Swal.fire({
        icon: icon,
        title: title,
        text: message,
        confirmButtonColor: "#7B8E61"
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = url;
        }
    })

}

window.registrationMessage = function(icon, title, message) {

    Swal.fire({
        icon: icon,
        title: title,
        text: message
    }).then((result) => {
        if (result.isConfirmed) {
            window.location.href = "https://fashforward.com";
        }
    })
}


window.errorMessage = function(icon, title, message) {

    Swal.fire({
        icon: icon,
        title: title,
        text: message,
        confirmButtonColor: "#7B8E61"
    })
}

// window.triggerFileDownload = function (fileName, url) {
//     // const anchorElement = document.createElement('a');
//     // anchorElement.href = url;
//     // anchorElement.download = fileName ?? '';
//     // anchorElement.click();
//     // anchorElement.remove();

//     // const fileName = source.split('/').pop();
//     var el = document.createElement("a");
//     el.setAttribute("href", "https://www.w3schools.com/images/myw3schoolsimage.jpg");
//     el.setAttribute("download",fileName);
//     document.body.appendChild(el);
//     el.click();
//     el.remove();
// }

// window.downloadFileFromStream = async function (fileName, contentStreamReference) {
//     const arrayBuffer = await contentStreamReference.arrayBuffer();
//     const blob = new Blob([arrayBuffer]);
//     const url = URL.createObjectURL(blob);

//     triggerFileDownload(fileName, url);

//     URL.revokeObjectURL(url);
// }

window.triggerFileDownload = function(fileName, url) {
    const anchorElement = document.createElement('a');
    anchorElement.href = url;
    anchorElement.download = fileName ?? '';
    anchorElement.click();
    anchorElement.remove();
}

window.SaveAsFile = function(FileName, byteBase64) {
    var link = document.createElement("a");
    link.download = FileName;
    link.href = 'data:application/vnd.openxmlformats-pfficedocument.spreadsheetml.sheet;base64,' + byteBase64;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}

window.DownloadFromBase64 = function(fileName, contentType, byteBase64) {
    var link = document.createElement("a");
    link.download = fileName;
    link.href = 'data:'+contentType+';base64,' + byteBase64;
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
}

window.JSInteropExt = {};
window.JSInteropExt.SaveAsFilex = function(filename, type, bytesBase64) {
    if (navigator.msSaveBlob) {
        var data = window.atob(bytesBase64);
        var bytes = new Uint8Array(data.length);
        for (let index = 0; index < data.length; index++) {
            bytes[i] = data.charCodeAt(i);
        }
        var blob = new Blob([bytes.buffer], { type, type });
        navigator.msSaveBlob(blob, filename);
    } else {
        var link = document.createElement("a");
        link.download = filename;
        link.href = 'data:' + type + ";base64," + bytesBase64;
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
    }
}