function deleteRole(elementOnClick) {
    var idElement = elementOnClick.id;
    var idRole = idElement.replace("deleteRole_", "");
    var methodName = "Delete";
    var request = {};
    if (idRole == "") {
        return;
    }
    request.ID = idRole;
    CallServerMethod(methodName, JSON.stringify(request), function (result) {
        if (result == "1") {
            $("#" + idElement).parent().parent().remove();
        }
    });

}


function CallServerMethod(methodName, args, onsucces, onerror) {
    $.ajax({
        url: '/Role/' + methodName,
        type: "POST",
        async: true,
        cache: false,
        dataType: "json",
        data: "{'args':'" + args + "'}",
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            onsucces(result);
        },
        error: function (e) {
            onerror(e);
        }
    });
}