$$r(function () {
    var pageUrl = document.URL;
    var userId = _GetParametrFromUrl(pageUrl, 'Id');
    var buttonEdit = document.getElementById("editUser");
    var title = document.getElementById("pageTitle");

    var select = document.getElementById("roles");
    getRoles(select);
    if (userId != null && userId != "") {
        getUser(userId);
        buttonEdit.value = "Изменить";
        title.textContent = "Изменить пользователя";
        buttonEdit.setAttribute("onclick", "Edit(" + userId + ")");
    }
    else {
        buttonEdit.value = "Добавить";
        title.textContent = "Добавить пользователя";
        buttonEdit.setAttribute("onclick", "createRole()");
    }
});

function getRoles(select) {
    var methodName = "GetAllRoles";
    CallServerMethodRole(methodName, null, function (result) {
        if (result.length != 0) {
            var option = document.createElement("option");
            option.value = -1;
            option.textContent = "";
            select.appendChild(option);
            result.forEach(function (item, i) {
                var option = document.createElement("option");
                option.value = item.ID;
                option.textContent = item.RoleName;
                select.appendChild(option);
            });
        }
    });
}

function getUser(userId) {
    var methodName = "GetUerById";
    var request = {};
    request.ID = userId;
    CallServerMethod(methodName, JSON.stringify(request), function (result) {
        if (result != "") {
            $("#FirstName").val(result.FirstName);
            $("#Patronymic").val(result.Patronymic);
            $("#LastName").val(result.LastName);
            $("#roles").val(result.RoleId);
            $("#Login").val(result.Login);
            $("#PersonPassword").val(result.PersonPassword);
        }
    });
}

function createRole() {
    methodName = "AddUser";
    var request = {};
    request.FirstName = $("#FirstName").val();
    if (request.FirstName == "") {
        $("#messFirstName").css({ "display": "block" });
        $("#messFirstName").text("Введите имя пользователя");
        return;
    }
    request.Patronymic = $("#Patronymic").val();
    if (request.Patronymic == "") {
        $("#messPatronymic").css({ "display": "block" });
        $("#messPatronymic").text("Введите отчество пользователя");
        return;
    }
    request.LastName = $("#LastName").val();
    if (request.LastName == "") {
        $("#messLastName").css({ "display": "block" });
        $("#messLastName").text("Введите фамилию пользователя");
        return;
    }
    request.RoleId = $("#roles").val();
    if (request.RoleId == "" || request.RoleId == "-1") {
        $("#messRoleId").css({ "display": "block" });
        $("#messRoleId").text("Выберете роль пользователя");
        return;
    }
    request.Login = $("#Login").val();
    if (request.Login == "") {
        $("#messLogin").css({ "display": "block" });
        $("#messLogin").text("Введите логин пользователя");
        return;
    }
    request.PersonPassword = $("#PersonPassword").val();
    if (request.PersonPassword == "") {
        $("#messPersonPassword").css({ "display": "block" });
        $("#messPersonPassword").text("Введите пароль пользователя");
        return;
    }
    var message = document.getElementById("message");

    CallServerMethod(methodName, JSON.stringify(request), function (result) {
        debugger;
        if (result.Message == "") {
            var href = "/AllUsers/AllUsers";
            window.location.reload(href);
        }
        else
        {
            $("#FirstName").val(result.FirstName);
            $("#Patronymic").val(result.Patronymic);
            $("#LastName").val(result.LastName);
            $("#roles").val(result.RoleId);
            $("#Login").val(result.Login);
            $("#PersonPassword").val(result.PersonPassword);
            message.textContent = result.Message;
        }
    });
}

function Edit(userId) {
    var methodName = "AddUser";
    var request = {};
    request.ID = userId;
    request.FirstName = $("#FirstName").val();
    request.Patronymic = $("#Patronymic").val();
    request.LastName = $("#LastName").val();
    request.roles = $("#roles").val();
    request.Login = $("#Login").val();
    request.PersonPassword = $("#PersonPassword").val();
    CallServerMethod(methodName, JSON.stringify(request), function (result) {
        if (result = "1") {
            var href = "/AllUsers/AllUsers";
            window.location.reload(href);
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

function CallServerMethodRole(methodName, args, onsucces, onerror) {
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