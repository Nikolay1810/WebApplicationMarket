$$r(function () {
    GetAllUser();
});

function GetAllUser() {
    var select = document.getElementById("filterUser");
    var methodName = "GetAllUsers";
    CallServerMethodForUser(methodName, null, function (result) {
        if (result.Count != 0) {
            result.forEach(function (item, i) {
                var option = document.createElement("option");
                option.value = item.ID;
                option.textContent = item.DisplayName;
                select.appendChild(option);
            });
        }
    });
    
}

function GetTableLogs() {
    var divTable = document.getElementById("tableLogs");
    var methodName = "GetLogs";
    var request = {};
    request.UserId = $("#filterUser").val();
    request.StartDate = $("#startDate").val();
    request.EndDate = $("#endDate").val();
    debugger;
    var table = document.getElementById("LogsTable");
    if (table != null && table != undefined) {
        table.remove();
    }
    CallServerMethod(methodName, JSON.stringify(request), function (result) {
        if (result.Count != 0) {
            var table = document.createElement('table');
            table.style.width = "100%";
            table.id = "LogsTable";

            var trHead = document.createElement('tr');

            var thUser = document.createElement('th');
            thUser.textContent = "ФИО Сотрудника";

            var thAction = document.createElement('th');
            thAction.textContent = "Действие";

            var thDate = document.createElement('th');
            thDate.textContent = "Дата действия";

            var thRole = document.createElement('th');
            thRole.textContent = "Роль";

            trHead.appendChild(thUser);
            trHead.appendChild(thAction);
            trHead.appendChild(thDate);
            trHead.appendChild(thRole);

            var tbody = document.createElement('tbody');

            result.forEach(function (item, i) {
                var trBody= document.createElement('tr');

                var tdUser = document.createElement('td');
                tdUser.textContent = item.Username;

                var tdAction = document.createElement('td');
                tdAction.textContent = item.Actions;

                var tdDate = document.createElement('td');
                tdDate.textContent = item.DateofactionsStr;

                var tdRole = document.createElement('td');
                tdRole.textContent = item.Rolename;

                trBody.appendChild(tdUser);
                trBody.appendChild(tdAction);
                trBody.appendChild(tdDate);
                trBody.appendChild(tdRole);

                tbody.appendChild(trBody);

                table.appendChild(trHead);
                table.appendChild(tbody);

                divTable.appendChild(table);
            });
        }
    });

}


function CallServerMethod(methodName, args, onsucces, onerror) {
    $.ajax({
        url: '/Logs/' + methodName,
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

function CallServerMethodForUser(methodName, args, onsucces, onerror) {
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