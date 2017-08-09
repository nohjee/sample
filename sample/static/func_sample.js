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
    $('#btnOk').click(function() {

        val1 = document.TestParameter.value1.value;
        val2 = document.TestParameter.value2.value;

        $.ajax({
            type: 'GET',
            url: '/HOME/TestParam',
            data : {
                val1: val1, val2: val2
            },
            success: function(data) {
                result = data.split('/');
                document.TestParameter.value1_1.value = result[0];
                document.TestParameter.value2_1.value = result[1];
            }
        });
    });

});