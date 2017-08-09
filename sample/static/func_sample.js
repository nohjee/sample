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

	    var table = document.getElementById('valueTable');
	    var row_len = table.rows.length;

	    var inval = new Array();

	    for (var i = 1; i <= row_len; i++) {
	        var temp = document.getElementById('in_val' + [i]);
	        inval[i - 1] = temp.value;
	    }

	    $.ajax({
	        type: 'POST',
	        url: '/HOME/TestParam',
	        data: {
	            inval1: inval[0], inval2: inval[1], inval3: inval[2], inval4: inval[3], inval5: inval[4]
	        },

	        success: function (data) {
	            data = JSON.parse(data);
	            var number = 1;

	            for (key in data) {
	                temp = document.getElementById('output_val' + number);
	                temp.value = data[key];
	                number++;
                }
	        },
	        error: function (xhr, status, error) {
	            console.log('error : ' + error);
	        }
	    });
	});

});