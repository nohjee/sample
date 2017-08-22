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
            url: '/Student/SearchID',
            data: { searchId: searchId },
            success: function (data) {
                $('#studentList tbody tr').remove();
                $('#studentList').append(data);           
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