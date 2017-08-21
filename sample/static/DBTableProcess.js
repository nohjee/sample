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
});