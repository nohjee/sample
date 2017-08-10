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

    //	bonusCheck();
	$('#btnOk').click(function () {

	    var id = document.getElementById('id').value;
	    var name = document.getElementById('name').value;
	    var email = document.getElementById('email').value;
	    var address = document.getElementById('address').value;
	    var phone = document.getElementById('phone').value;
      
	    $.ajax({
	        type: 'POST',
	        url: '/HOME/TestParam',
	        data: {
	            id : id , name : name , email : email , address : address , phone : phone
	        },

	        success: function (data) {
	            data = JSON.parse(data);
	            for (key in data) {
	                var temp = document.getElementById('return_' + key.toLowerCase());
	                temp.value = data[key];
	            }
	           
	        },
	        error: function (xhr, status, error) {
	            console.log('error : ' + error);
	        }
	    });
	});

/*
	function emptyCheck(value) {
        if (value == '' ||
            value == null ||
            value == undefined ||
            (value != null && typeof value == 'object' && !Object.keys(value).length)) {
            return true;
        } else {
            return false;
        }
    };
*/

    

});