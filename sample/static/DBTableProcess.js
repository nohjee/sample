$(function() {

    $('#insertDB').click(function() {
        var id = $.trim($('#studentModelsID').val());
        var lastName = $.trim($('#lastName').val());
        var firstMidName = $.trim($('#firstMidName').val());

        if (id == '' || lastName == '' || firstMidName == '') {
            return;
        }

        $.ajax({
            type : 'POST',
            url : '/Student/DataInsert',
            data : {
                StudentModelsID: id, LastName: lastName, FirstMidName: firstMidName
            },
            
            success: function (data) {
                location.reload();
            },
            error : function(xhr, status, error) {
                console.log('error :' + error);
            }
        });

    });

    $('#studentModelsID').keyup(function () {
        var check_id = $('#studentModelsID').val();
        var max_id = $('#studentModelsID').attr('maxLength');
        if (check_id.length > max_id.length) {
            $('#studentModelsID').val(check_id.slice(0, max_id));
        }
    });


    $('#searchIdOk').click(function() {
        searchId = $('#searchId').val();
        $.ajax({
            type: 'POST',
            url: '/Student/StudentSelect',
            data: { searchId: searchId },
            success: function (data) {
                var obj = JSON.parse(data);
                $('#studentList thead tr').remove();
                $('#studentList tbody tr').remove();
                var insertHtml = '';

                insertHtml = '<tr>';
                insertHtml += '<td>StudentID</td>';
                insertHtml += '<td>LastName</td>';
                insertHtml += '<td>FirstMidName</td>';
                insertHtml += '<td>EnrollmentDate</td>';
                insertHtml += '</tr>';
                $('#studentList').append(insertHtml);
                if (obj == '')
                {
                    insertHtml = '<tr><td colspan='+4+'>찾는 id가 없습니다.</td></tr>';
                    
                }
                else {
                    for (var i = 0; i < obj.length; i++) {
                        insertHtml = '<tr>';
                        insertHtml += '<td>' + obj[i].StudentModelsID + '</td>';
                        insertHtml += '<td>' + obj[i].LastName + '</td>';
                        insertHtml += '<td>' + obj[i].FirstMidName + '</td>';
                        
                        var dateFormat =
                            new Date(parseInt(obj[i].EnrollmentDate.substring(6, obj[i].EnrollmentDate.length - 2)));
                        var date = (dateFormat.getMonth() + 1) + '/' + dateFormat.getDate() + '/' + dateFormat.getFullYear();

                        insertHtml += '<td>' + date + '</td>';
                        insertHtml += '</tr>';
                    }
                }
                $('#studentList').append(insertHtml);
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