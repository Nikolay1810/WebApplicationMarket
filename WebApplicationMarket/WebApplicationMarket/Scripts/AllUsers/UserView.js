function deleteUser(elementOnClick) {
    var idElement = elementOnClick.id;
    var idUser = idElement.replace("deleteUser_", "");
    var methodName = "DeleteUser";
    var request = {};
    if (idUser == "") {
        return;
    }
    request.ID = idUser;
    CallServerMethod(methodName, JSON.stringify(request), function (result) {
        if (result == "1") {
            $("#" + idElement).parent().parent().remove();
        }
    });

}


function CallServerMethod(methodName, args, onsucces, onerror) {
    $.ajax({
        url: '/AllUsers/' + methodName,
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