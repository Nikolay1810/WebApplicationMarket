$$r(function () {
    var id = 0;
    getTemperature();
    //setInterval(function () {
    //    getTemperature(id);
    //    id += 50 / 2;
    //}, 1000);
});

var all_data = [];
var arr_index = [];
var all_data2 = [
{ data: dataTemp4, label: "Температура 4", color: 'red', lines: { show: true, fill: true } }, ];

var dataTemp0;
var dataTemp1;
var dataTemp2;
var dataTemp3;
var dataTemp4;
var dataTemp5;
var dataTemp6;
var dataTemp7;
var dataTemp8;
var dataTemp9;
var dataTemp10;
var dataTemp11;
var dataTemp12;
var dataTemp13;
var dataTemp14;


var all_data = [
  { data: dataTemp0, label: "Температура 0", color: 'red', lines: { show: true, fill: false } },
  { data: dataTemp1, label: "Температура 0", color: 'blue', lines: { show: true, fill: false } },
  { data: dataTemp2, label: "Температура 2", color: 'black', lines: { show: true, fill: false } },
  { data: dataTemp3, label: "Температура 3", color: 'yellow', lines: { show: true, fill: false } },
  { data: dataTemp4, label: "Температура 4", color: 'green', lines: { show: true, fill: false } },
  { data: dataTemp5, label: "Температура 5", color: 'gray', lines: { show: true, fill: false } },
  { data: dataTemp6, label: "Температура 6", color: 'coral', lines: { show: true, fill: false } },
  { data: dataTemp7, label: "Температура 7", color: 'brown', lines: { show: true, fill: false } },
  { data: dataTemp8, label: "Температура 8", color: 'lightskyblue', lines: { show: true, fill: false } },
  { data: dataTemp9, label: "Температура 9", color: 'darkslateblue', lines: { show: true, fill: false } },
  { data: dataTemp10, label: "Температура 10", color: 'blueviolet', lines: { show: true, fill: false } },
  { data: dataTemp11, label: "Температура 11", color: 'chartreuse', lines: { show: true, fill: false } },
  { data: dataTemp12, label: "Температура 12", color: 'darkorange', lines: { show: true, fill: false } },
  { data: dataTemp13, label: "Температура 13", color: 'goldenrod', lines: { show: true, fill: false } },
  { data: dataTemp14, label: "Температура 14", color: 'olivedrab', lines: { show: true, fill: false } }];

function getTemperature(id) {
    var methodName = "GetDataByTemp";
    var request = {};
    request.ID = id;
    CallServerMethod(methodName, JSON.stringify(request), function (result) {

        dataTemp0 = [];
        dataTemp1 = [];
        dataTemp2 = [];
        dataTemp3 = [];
        dataTemp4 = [];
        dataTemp5 = [];
        dataTemp6 = [];
        dataTemp7 = [];
        dataTemp8 = [];
        dataTemp9 = [];
        dataTemp10 = [];
        dataTemp11 = [];
        dataTemp12 = [];
        dataTemp13 = [];
        dataTemp14 = [];

        if (result.length != 0) {
            result.forEach(function (item, i) {
                              var arXandY0 = [item.DateWrite, item.Temperature0];
                              dataTemp0.push(arXandY0);
                              var arXandY1 = [item.DateWrite, item.Temperature1];
                              dataTemp1.push(arXandY1);
                              var arXandY2 = [item.DateWrite, item.Temperature2];
                              dataTemp2.push(arXandY2);
                              var arXandY3 = [item.DateWrite, item.Temperature3];
                              dataTemp3.push(arXandY3);

                              var arXandY4 = [item.DateWrite, item.Temperature4];
                              dataTemp4.push(arXandY4);
                              var arXandY5 = [item.DateWrite, item.Temperature5];
                              dataTemp5.push(arXandY5);
                              var arXandY6 = [item.DateWrite, item.Temperature6];
                              dataTemp6.push(arXandY6);
                              var arXandY7 = [item.DateWrite, item.Temperature7];
                              dataTemp7.push(arXandY7);

                              var arXandY8 = [item.DateWrite, item.Temperature8];
                              dataTemp8.push(arXandY8);
                              var arXandY9 = [item.DateWrite, item.Temperature9];
                              dataTemp9.push(arXandY9);
                              var arXandY10 = [item.DateWrite, item.Temperature10];
                              dataTemp10.push(arXandY10);
                              var arXandY11 = [item.DateWrite, item.Temperature11];
                              dataTemp11.push(arXandY11);

                              var arXandY12 = [item.DateWrite, item.Temperature12];
                              dataTemp12.push(arXandY12);
                              var arXandY13 = [item.DateWrite, item.Temperature13];
                              dataTemp13.push(arXandY13);
                              var arXandY14 = [item.DateWrite, item.Temperature14];
                              dataTemp14.push(arXandY14);
                          });
        }
        var timeArr = [];
        var count = 0;
        var midlle = 0;
        for (var i = 0; i < dataTemp2.length; i++) {
            if (i + 1 == dataTemp2.length - 1) {
                break;
            }
            var time1 = dataTemp2[i][0].split(' ')[1];
            var hour1 = time1.split(':')[0];
            var minute1 = time1.split(':')[1];

            var time2 = dataTemp2[i + 1][0].split(' ')[1];
            var hour2 = time2.split(':')[0];
            var minute2 = time2.split(':')[1];
            if (hour1 + ":" + minute1 == hour2 + ":" + minute2) {
                if (i == 0) {
                    var temp1 = parseInt(dataTemp2[i][1]);
                    var temp2 = parseInt(dataTemp2[i + 1][1]);
                    midlle += temp1 + temp2;
                    count += 2;
                }
                else {
                    var temp2 = parseInt(dataTemp2[i + 1][1]);
                    midlle += temp2;
                    count += 1;
                }
            }
            else {
                
                var date = dataTemp2[i][0].split(' ')[0];

                var arXand = [date + ' ' + hour1 + ':' + minute1, midlle / count];
                timeArr.push(arXand);
                var temp2 = parseInt(dataTemp2[i + 1][1]);
                midlle = temp2;
                count =1
            }
        }
        for (var i = 0; i < timeArr.length; i++) {
            if (timeArr[i] == timeArr[i + 1]) {

            }
        }


                //// ВАЖНО: IE не понимает запятых на конце :(
                //      //];
                      //all_data[0].data = dataTemp0;
                      //all_data[1].data = dataTemp1;
                      //all_data[2].data = dataTemp2;
                      //all_data[3].data = dataTemp3;
                      //all_data[4].data = dataTemp4;
                      //all_data[5].data = dataTemp5;
                      //all_data[6].data = dataTemp6;
                      //all_data[7].data = dataTemp7;
                      //all_data[8].data = dataTemp8;
                      //all_data[9].data = dataTemp9;
                      //all_data[10].data = dataTemp10;
                      //all_data[11].data = dataTemp11;
                      //all_data[12].data = dataTemp12;
                      //all_data[13].data = dataTemp13;
                      //all_data[14].data = dataTemp14;
                //      // свойства графика
                //      var selection = [all_data[0].data[0][0], all_data[14].data[0][0]];
                //      for (var j = 0; j < all_data.length; ++j) {
                //          for (var i = 0; i < all_data[j].data.length; ++i)
                //              all_data[j].data[i][0] = Date.parse(all_data[j].data[i][0]);
                //      }

                //      for (var i = 0; i < selection.length; ++i)
                //          selection[i] = Date.parse(selection[i]);

                //      // выводим график
                //      //var plot = $("#placeholder").plot(all_data, plot_conf).data("plot");
                //      $.plot($("#placeholder"), all_data, {
                //          series: {
                //              lines: {
                //                  show: true,
                //                  //lineWidth: 2
                //              }
                //          },
                //          xaxis: {
                //              mode: "date",
                //              timeformat: "%y/%m/%d",
                //              min: selection[0],
                //              max: selection[1]
                //          },
                //          legend: {
                //              container: $("#legend")
                //          }
                //      });
                //    grid: {
                //        color: '#646464',
                //        borderColor: 'transparent',
                //        borderWidth: 20,
                //        hoverable: true
                //    },
                //    xaxis: {
                //        mode: "time",
                //        timeformat: "%y/%m/%d",
                //    },
                //}
                //);
                //redrawAll();
                //add_checkbox();

                // данные для графиков
               
        
                      //debugger;

        // данные для графиков
                      all_data = [
                        //{
                        //    data: dataTemp3,
                        //    points: { show: true, fill: false }
                        //},
                        {
                            data: dataTemp1,
                            lines: { show: false, spline:true,  fill: false },
                            splines: {
                                show: true,
                                tension: 0.3,
                                lineWidth: 1,
                                fill: 0.3
                            }
                        }];

        // преобразуем даты в UTC
                      convertToUTC();
                        //{
                        //    data: dataTemp2
                        //},
                        //{
                        //    data: dataTemp3
                        //},
                        //{
                        //    data: dataTemp4
                        //},
                        //{
                        //    data: dataTemp5
                        //},
                        //{
                        //    data: dataTemp6
                        //},
                        //{
                        //    data: dataTemp7
                        //},
                        //{
                        //    data: dataTemp8
                        //},
                        //{
                        //    data: dataTemp9
                        //},
                        //{
                        //    data: dataTemp10
                        //},
                        //{
                        //    data: dataTemp11
                        //},
                        //{
                        //    data: dataTemp12
                        //},
                        //{
                        //    data: dataTemp13
                        //},
                        //{
                        //    data: dataTemp14
                        //}
                      //];

                      //2017.05.01
                      //2017.05.10
                      //2017.05.5 
                      //2017.05.15

                
                // свойства графика
                var plot_conf = {
                    series: {
                        //lines: {
                        //    show: false
                        //}
                    },
                    xaxis: {
                        mode: "time",
                        timeformat: "%Y.%m.%d %H:%M:%S",
                    },
                    yaxis: {
                        max: 30,
                        min: 0//[0, 30]
                    },
                    legend: {
                        container: $("#legend")
                    }
                    
                };
                // выводим график
                $.plot($("#placeholder0"), all_data, plot_conf);
                //all_data[1].data = dataTemp10;
                //all_data[1].lines.fill = true;
                //all_data[1].lines.show = true;
                //all_data[0].points.show = true;

        // свойства графика
                var plot_conf1 = {
                    series: {
                        bars: {
                            show: true,
                            lineWidth: 2,
                            fill: true,
                            color:"blue"
                        },
                        color:"blue",
                        lines:{
                            show: true,
                            fill: true,
                            color: "blue"
                        },
                        //splines: {
                        //    show: true,
                        //    tension: 0.5,
                        //    lineWidth: 1,
                        //    fill: 0.1
                        //}
                    },
                    xaxis: {
                        mode: "time",
                        timeformat: "%Y.%m.%d %H:%M:%S",
                    },
                    //xaxis: { zoomRange: [0.1, 20], panRange: [-20, 20] },
                    yaxis: { zoomRange: [0.1, 20], panRange: [-20, 20] },
                    zoom: {
                        interactive: true
                    },
                    pan: {
                        interactive: true
                    },
                    legend: {
                        container: $("#legend3")
                    }
                    
                };
                all_data = [
                                {
                                    data: dataTemp4,
                                    //bars: {
                                    //    show: true,
                                    //    lineWidth: 2,
                                    //    fill:true
                                    //},
                                }
                ];

        // преобразуем даты в UTC
                convertToUTC();

        var placeholder = $("#placeholder1");
        var plot =  $.plot($("#placeholder1"), all_data, plot_conf1);
        placeholder.bind('plotpan', function (event, plot) {
            var axes = plot.getAxes();
            $(".message").html("Panning to x: " + axes.xaxis.min.toFixed(2)
                               + " &ndash; " + axes.xaxis.max.toFixed(2)
                               + " and y: " + axes.yaxis.min.toFixed(2)
                               + " &ndash; " + axes.yaxis.max.toFixed(2));
        });

        placeholder.bind('plotzoom', function (event, plot) {
            var axes = plot.getAxes();
            $(".message").html("Zooming to x: " + axes.xaxis.min.toFixed(2)
                               + " &ndash; " + axes.xaxis.max.toFixed(2)
                               + " and y: " + axes.yaxis.min.toFixed(2)
                               + " &ndash; " + axes.yaxis.max.toFixed(2));
        });

        // add zoom out button 
        $('<div class="button" style="right:20px;top:20px">zoom out</div>').appendTo(placeholder).click(function (e) {
            e.preventDefault();
            plot.zoomOut();
        });
        all_data = [
                          {
                              data: timeArr,
                          }
        ];
        // преобразуем даты в UTC
        convertToUTC();
                var plot_conf2 = {
                    series: {
                        bars: {
                            show: true,
                            lineWidth: 10,
                            fill: false,
                            align: "center",
                            //hoverable: true

                        }
                        //,
                        //splines: {
                        //    show: true,
                        //    tension: 0.3,
                        //    lineWidth: 1,
                        //    fill: 0.3
                        //}
                    },
                    xaxis: {
                        mode: "time",
                        timeformat: "%Y.%m.%d %H:%M",
                       
                        reserveSpace: true
                    },
                    yaxis:{
                        autoscaleMargin: 1,
                    },
                    legend: {
                        container: $("#legend2")
                    }
                };
                
                $.plot($("#placeholder2"), all_data, plot_conf2);
                var plot_conf1 = {
                    series: {
                        points:{show:false},
                        //lines: {show: false, fill: true },
                        splines: {
                            show: true,
                            tension: 0.4,
                            lineWidth: 2,
                            fill: 0
                        }
                    },
                    xaxis: {
                        mode: "time",
                        timeformat: "%Y.%m.%d %H:%M:%S",
                    },
                    legend: {
                        container: $("#legend2")
                    }
                };
                all_data = [
                                {
                                    data: dataTemp12,
                                    color: "black",
                                    
                                }
                ];

        // преобразуем даты в UTC
                convertToUTC();
                $.plot($("#placeholder3"), all_data, plot_conf1);
                //$.plot($("#placeholder4"), all_data, plot_conf);
            });
       
}

function convertToUTC() {
    for (var j = 0; j < all_data.length; ++j) {
        for (var i = 0; i < all_data[j].data.length; ++i)
            all_data[j].data[i][0] = Date.parse(all_data[j].data[i][0]);
    }
}

//var overview = $.plot($("#overview"), all_data, {
//    legend: { show: true, container: $("#overviewLegend") },
//    series: {
//        lines: { show: true, lineWidth: 1 },
//        shadowSize: 0
//    },
//    xaxis: { ticks: 4 },
//    yaxis: { ticks: 3, min: -2, max: 2 },
//    grid: { color: "#999" },
//    selection: { mode: "xy" }
//});

//$("#placeholder0").bind("plotselected", function (event, ranges) {
//    // clamp the zooming to prevent eternal zoom
//    if (ranges.xaxis.to - ranges.xaxis.from < 0.00001)
//        ranges.xaxis.to = ranges.xaxis.from + 0.00001;
//    if (ranges.yaxis.to - ranges.yaxis.from < 0.00001)
//        ranges.yaxis.to = ranges.yaxis.from + 0.00001;

//    // do the zooming
//    plot = $.plot($("#placeholder0"), getData(ranges.xaxis.from, ranges.xaxis.to),
//                  $.extend(true, {}, options, {
//                      //xaxis: { min: ranges.xaxis.from, max: ranges.xaxis.to },
//                      yaxis: { min: ranges.yaxis.from, max: ranges.yaxis.to }
//                  }));

//    // don't fire event on the overview to prevent eternal loop
//    overview.setSelection(ranges, true);
//});
//$("#overview").bind("plotselected", function (event, ranges) {
//    plot.setSelection(ranges);
//});




function add_checkbox() {
    var legend = document.getElementsByClassName('legend')[0];
    var legend_tbl = legend.getElementsByTagName('table')[0];
    var legend_html;
    if (arr_index.length == all_data.length) {
        legend_html = '<table style="font-size: smaller;' +
                     ' color: rgb(84, 84, 84);"><tbody><tr>' + '<td><input id="checkGrafAll" type="checkbox" onclick="redrawAll(this);"/>Все</td>'
             + '</tr>';
    }
    else {
        legend_html = '<table style="font-size: smaller;' +
                     ' color: rgb(84, 84, 84);"><tbody><tr>' + '<td><input id="checkGrafAll" type="checkbox" onclick="redrawAll(this);" checked="1"/>Все</td>'
             + '</tr>';
    }
   
    var test = false;
    for (var i = 0; i < legend_tbl.rows.length; i++) {
        for (var j = 0; j < arr_index.length; j++) {
            if (i == arr_index[j]) {
                test = true;
            }
        }
        if (test) {
            legend_html += '<tr>' +
              '<td><input id="checkGraf' + i + '" type="checkbox" onclick="redraw(' + i + ', this);"></td>'
              + legend_tbl.rows[i].innerHTML
              + '</tr>';
            test = false;
        }
        else {
            legend_html += '<tr>' +
              '<td><input id="checkGraf' + i + '" type="checkbox" onclick="redraw(' + i + ', this);" checked="1"></td>'
              + legend_tbl.rows[i].innerHTML
              + '</tr>';
        }
    }
    legend_html += "</tbody></table>";
    legend.lastChild.innerHTML = legend_html;
}

function redraw(item, elementOnClick) {
    if ($("#" + elementOnClick.id).prop('checked')) {
        all_data[item].lines.show = true;
        for (var i = 0; i < arr_index.length; i++) {
            if (item == arr_index[i]) {
                arr_index.splice(i, 1);
            }
        }
    }
    else {
        all_data[item].lines.show = false;
        arr_index.push(item);
    }
    $.plot($("#placeholder"), all_data);
    add_checkbox();
   
    // легенду рисуем только один раз
   // plot_conf.legend.show = false;
}


// перерисовываем все и вся :)
//function redraw() {
//    var data = [];
//    for (var j = 0; j < all_data.length; ++j)
//        if (!hide[j])
//            data.push(all_data[j]);

    
//}

function redrawAll(elementOnClick) {
    arr_index = [];
    if ($("#" + elementOnClick.id).prop('checked')) {
        for (var i = 0; i < all_data.length; i++) {
            all_data[i].lines.show = true;
        }
    }
    else {
        for (var i = 0; i < all_data.length; i++) {
            all_data[i].lines.show = false;
            arr_index.push(i);
        }
    }

    plot = $.plot($("#placeholder"), data, plot_conf);
    overview = $.plot($("#overview"), data, overview_conf);

    // легенду рисуем только один раз
    plot_conf.legend.show = false;

    // последний аргумент - чтобы избежать рекурсии
    overview.setSelection({ x1: selection[0], x2: selection[1] }, true);
}

function CallServerMethod(methodName, args, onsucces, onerror) {
    $.ajax({
        url: '/Graphics/' + methodName,
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