$$r(function () {
    var pageUrl = document.URL;
    var roleId = _GetParametrFromUrl(pageUrl, 'Id');
    var buttonEdit = document.getElementById("buttonEdit");
    var title = document.getElementById("pageTitle");

    if (roleId != null && roleId != "") {
        getRole(roleId);
        buttonEdit.value = "Изменить";
        title.textContent = "Изменить роль";
        buttonEdit.setAttribute("onclick", "Edit(" + roleId + ")");
    }
    else {
        buttonEdit.value = "Добавить";
        title.textContent = "Добавить роль";
        buttonEdit.setAttribute("onclick", "createRole()");
    }
});


function getRole(roleId)
{
    var methodName = "GetRoleById";
    var request = {};
    request.ID = roleId;
    CallServerMethod(methodName, JSON.stringify(request), function (result) {
        if (result != "") {
            $("#roleName").val(result.RoleName);
        }
    });
}

function createRole() {
    methodName = "CreateRole";
    var request = {};
    request.RoleName = $("#roleName").val();
    CallServerMethod(methodName, JSON.stringify(request), function (result) {
        if (result = "1") {
            var href = "/";
            window.location.reload(href);
        }
    });
}

function Edit(roleId) {
    var methodName = "Edit";
    var request = {};
    request.ID = roleId;
    request.RoleName = $("#roleName").val();
    CallServerMethod(methodName, JSON.stringify(request), function (result) {
        if (result = "1") {
            var href = "/";
            window.location.reload(href);
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

function _GetParametrFromUrl(locationString, name) {
    name = name.replace(/[\[]/, '\\\[').replace(/[\]]/, '\\\]');
    var regexS = '[\\?&]' + name + '=([^&#]*)';
    var regex = new RegExp(regexS);
    var results = regex.exec(locationString);
    if (results == null)
        return '';
    else
        return decodeURIComponent(results[1].replace(/\+/g, ' '));
}