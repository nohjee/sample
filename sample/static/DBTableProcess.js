$(function() {
    console.log('Student');

    $('#InsertDB').click(function() {
        var id = $.trim($('#StudentModelsID').val());
        var L_Name = $.trim($('#LastName').val());
        var FM_Name = $.trim($('#FirstMidName').val());

        if (id == '' || L_Name == '' || FM_Name == '') {
            return;
        }

        $.ajax({
            type : 'POST',
            url : '/Student/DataInsert',
            data : {
                StudentModelsID: id, LastName: L_Name, FirstMidName: FM_Name
            },
            
            success: function (data) {
                location.reload();
            },
            error : function(xhr, status, error) {
                console.log('error :' + error);
            }
        });

    });

    $('#StudentModelsID').keyup(function () {
        check_id = $('#StudentModelsID').val();
        max_id = $('#StudentModelsID').attr('maxLength');
        if (check_id.length > max_id.length) {
            $('#StudentModelsID').val(check_id.slice(0, max_id));
        }
    });
});