$(function() {
	console.log('in');


	function bonusCheck(ch) {
		$.ajax({
			type: 'GET',
			data: {
				BonusCode: 'test-nohjee'
			},
			url: '/Home/GetBonusCheck',
			success: function (data) {
				console.log('SuccessCode: ' + data);
			},
			error: function (xhr, status, error) {
				console.log('error : ' + error);
			}
		});
	}



    

    for (var i = 0; i < 3; i++) {
        var row = '<tr>';
        row += '<td>아이디</td>';
        row += '<td><input type="number" name="id" maxlength="10"/></td>';
        row += '<td><input name="return_id" disabled="true"/></td>';
        row += '</tr><tr><td></td></tr><tr>';   
        row += ' <td>이름</td>';
        row += ' <td><input name="name"/></td>';
        row += ' <td><input name="return_name" disabled="true"/></td>';
        row += '</tr><tr><td></td></tr><tr>';
           
        row += '<td>이메일</td>';
        row += ' <td><input name="email"/></td>';
        row += '<td><input name="return_email" disabled="true"/></td>';
        row += '</tr>';
        $('#valueTable').append(row);
    }



    //	bonusCheck();
    $('#btnOk').click(function () {

	 
	    var id_len = $('input[name=id]');
	    var id = new Array();
	    var name = new Array();
	    var email = new Array();

	    for (var i = 0; i < id_len.length; i++) {
	        id[i] = $.trim($('input[name=id]').eq(i).val());
	        name[i] = $.trim($('input[name=name]').eq(i).val());
	        email[i] = $.trim($('input[name=email]').eq(i).val());

	        if (id[i] == '' || name[i] == '' || email[i] == '') {
	            window.alert('모든 문항을 입력해주세요.');
	            return;
	        }
	    }


	   
	    $.ajax({
	        type: 'POST',
	        url: '/HOME/TestParam',      
	        data: {
	            idArr: id, nameArr: name, emailArr: email
	        },

	        success: function (data) {

	            data = JSON.parse(data);
                for (var j = 0; j < data.length; j++) {
                    $('input[name=return_id').eq(j).val(data[j].Id);
                    $('input[name=return_name').eq(j).val(data[j].Name);
                    $('input[name=return_email').eq(j).val(data[j].Email);
                }

	        },
	        error: function (xhr, status, error) {
	            console.log('error : ' + error);
	        }
	    });
	});

    $('input[name=id]').keyup(function () {
        var id = $(this).val();
        var maxLen = $(this).attr('maxLength');
        if (id.length > maxLen.length) {
            $(this).val(id.slice(0, maxLen));
        }
    });

});