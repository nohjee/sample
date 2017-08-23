$(function () {

    $.ajax({
        type: 'GET',
        url: '/Student/GetSchoolList',
        success: function (data) {
            var jsonSchoolList = JSON.parse(data);     
            for (var i = 0; i < jsonSchoolList.length; i++) {
                var innerHtml = '<tr>';
                innerHtml += '<td>' + jsonSchoolList[i].EnrollmentModelsID + '</td>';
                innerHtml += '<td>' + jsonSchoolList[i].CourseModelsID + '</td>';
                innerHtml += '<td>' + jsonSchoolList[i].StudentModelsID + '</td>';
                innerHtml += '<td>' + jsonSchoolList[i].Grade + '</td>';
                innerHtml += '<td>' + jsonSchoolList[i].Title + '</td>';
                innerHtml += '<td>' + jsonSchoolList[i].Credits + '</td>';
                innerHtml += '<td>' + jsonSchoolList[i].LastName + '</td>';
                innerHtml += '<td>' + jsonSchoolList[i].FirstMidName + '</td>';
                innerHtml += '<td>' + jsonSchoolList[i].EnrollmentDate + '</td>';
                innerHtml += '</tr>';
                $('#studentList').append(innerHtml);
            }
            
        },
        error: function (xhr, status, error) {
            console.log('error :' + error);
        }
    });


    $('#searchIdOk').click(function() {
        searchId = $('#searchId').val();
        $.ajax({
            type: 'POST',
            url: '/Student/GetSelectStudent',
            data: { searchId: searchId },
            success: function (data) {
                $('#studentList tbody tr').remove();
                var selectScholl = JSON.parse(data);
                if (selectScholl.length==0)
                {
                    insertHtml = '<tr><td colspan='+9+'>찾는 id가 없습니다.</td></tr>';
                    $('#studentList').append(insertHtml);
                }
                else {
                    for (var i = 0; i < selectScholl.length; i++) {
                        var innerHtml = '<tr>';
                        innerHtml += '<td>' + selectScholl[i].EnrollmentModelsID + '</td>';
                        innerHtml += '<td>' + selectScholl[i].CourseModelsID + '</td>';
                        innerHtml += '<td>' + selectScholl[i].StudentModelsID + '</td>';
                        innerHtml += '<td>' + selectScholl[i].Grade + '</td>';
                        innerHtml += '<td>' + selectScholl[i].Title + '</td>';
                        innerHtml += '<td>' + selectScholl[i].Credits + '</td>';
                        innerHtml += '<td>' + selectScholl[i].LastName + '</td>';
                        innerHtml += '<td>' + selectScholl[i].FirstMidName + '</td>';
                        innerHtml += '<td>' + selectScholl[i].EnrollmentDate + '</td>';
                        innerHtml += '</tr>';
                        $('#studentList').append(innerHtml);
                    }
                }
                
            },
            error: function(xhr, status, error) {
                console.log('error : ' + error);
            }

        });
    });

    $('#studentListOk').click(function () {
        location.reload();
    });


    $('#searchId').keyup(function () {

        var checkid = $('#searchId').val();
        var maxid = $('#searchId').attr('maxLength');
        if (checkid.length > maxid.length) {
            $('#searchId').val(checkid.slice(0, maxid));
        }

        if (checkid.length > 0) {
            $('#searchIdOk').attr('disabled', false);
        }
        else
        {
            $('#searchIdOk').attr('disabled', true);
        }
    });

});