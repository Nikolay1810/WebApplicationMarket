function Autentication() {
    var methodName = "Autentication";
    
    var request = {};
   
    request.UserLogin = $("#login").val();
    request.UserPassword = $("#password").val();
    request.IsPersistent = $("#IsPersistent").prop('checked');
    CallServerMethodForAccount(methodName, JSON.stringify(request), function (result) {
        if (result.length != "") {
            var href = "/";
            window.location.href = href;
        }
    });
}


function WriteLog() {
    var methodName = "WriteLog";
    CallServerMethodForAccount(methodName, null, function (result) {
        if (result != "") {
            var href = "/Account/Login";
            window.location.href = href;
        }
    });
}

function LogOut() {
    WriteLog();
    var methodName = "Logout";
    CallServerMethodForAccount(methodName, null, function (result) {

        if (result != "") {
            var href = "/Account/Login";
            window.location.href = href;
        }
    });
}


function CallServerMethodForAccount(methodName, args, onsucces, onerror) {
    $.ajax({
        url: '/Account/' + methodName,
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


