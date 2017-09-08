$(function () {
     $('#schoolList').DataTable({
        "processing": true,
        "serverSide": true,
        "dom": '<"top"i>rt<"botton"lp><"clear">',
        "orderMulti": false,
        "ajax": {
            "url": "/Student/LoadSchoolList",
            "type": "POST",
            "datatype": "json"
        },
        "columns": [
            { "data": "EnrollmentModelsID", "name": "EnrollmentModelsID", "autoWidth": true },
            { "data": "StudentModelsID", "name": "StudentModelsID", "autoWidth": true },
            { "data": "CourseModelsID", "name": "CourseModelsID", "autoWidth": true },
            { "data": "LastName", "name": "LastName", "autoWidth": true },
            { "data": "FirstMidName", "name": "FirstMidName", "autoWidth": true },
            {
                "data": "EnrollmentDate",
                "name": "EnrollmentDate",
                "autoWidth": true,
                "render": function (data) {
                    var str = moment(data).format("YYYY-MM-DD"); //json string
                    return str.toString();
                }
            },
            { "data": "Title", "name": "Title", "autoWidth": true },
            { "data": "Credits", "name": "Credits", "autoWidth": true },
            { "data": "Grade", "name": "Grade", "autoWidth": true },
            {
                "data": "EnrollmentModelsID",
                "bSortable": false,
                "width": "50px",
                "render": function (data) {
                    return '<a class="popup" href="/Student/Save?enrollId=' + data + '">Edit</a>';
                }
            },
            {
                "data": "EnrollmentModelsID",
                "width": "50px",
                "bSortable": false,
                "render": function (data) {
                    return '<a class="popup" href="/Student/Delete?enrollId=' + data + '">Delete</a>';
                }
            }
        ],
        "language": {
            "emptyTable": "There are no Student at present.",
            "zeroRecords": "There were no matching Student found."
        }
    });


    var schoolTable = $('#schoolList').DataTable();
    $('#btnSearch').click(function () {
        schoolTable.columns(1).search($('#searchID').val().trim());
        schoolTable.columns(6).search($('#searchTitle').val().trim());
        schoolTable.draw();
    });

    $('.tablecontainer').on('click',
        'a.popup',
        function (e) {
            e.preventDefault();
            openPopup($(this).attr('href'));
        });


    function openPopup(pageUrl) {
        var $pageContent = $('<div/>');
        $pageContent.load(pageUrl,
            function () {
                $('#popupForm', $pageContent).removeData('validator');
                $('#popupForm', $pageContent).removeData('unobtrusiveValidation');
                $.validator.unobtrusive.parse('form');

            });

        var $dialog = $('<div class="popupWindow" style="overflow:auto"></div>')
            .html($pageContent)
            .dialog({
                draggable: false,
                autoOpen: false,
                resizable: false,
                model: true,
                title: 'Popup Dialog',
                height: 550,
                width: 600,
                close: function () {
                    $dialog.dialog('destroy').remove();
                }
            });

        $('.popupWindow').on('submit',
            '#popupForm',
            function (e) {
                var url = $('#popupForm')[0].action;
                $.ajax({
                    type: "POST",
                    url: url,
                    data: $('#popupForm').serialize(),
                    success: function (data) {
                        if (data) {
                            $dialog.dialog('close');
                            schoolTable.ajax.reload();
                        }
                    },
                    error : function(jqxhr) {
                        $('#error').innerHTML(jqxhr.responseText);
                    }
                });

                e.preventDefault();
            });
        $dialog.dialog('open');
    }

    function getTitleList() {
        $.ajax({
            type: 'GET',
            url: '/Student/GetTitles',
            datatype: 'json',
            success: function (data) {
                for (var i = 0; i < data.Data.length; i++) {
                    var titleOption = '<option value="' + data.Data[i] + '">' + data.Data[i] + '</option>';
                    $('#searchTitle').append(titleOption);
                }
            },
            error: function (jqxhr) {
                console.log(jqxhr.responseText);
            }
        });
    }

    getTitleList();
});