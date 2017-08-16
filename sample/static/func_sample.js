$(function() {
	console.log('in');


	function bonusCheck(ch) {
		$.ajax({
			type: 'GET',
			data: {
				BonusCode: 'test-nohjee'
			},
			url: '/PersonalInfo/GetBonusCheck',
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

       
            id = $.trim($('input[name=Id]').val());
            name = $.trim($('input[name=Name]').val());
            email = $.trim($('input[name=Email]').val());
            address = $.trim($('input[name=Address]').val());
            phone = $.trim($('input[name=Phone]').val());


            if (id == '' || name == '' || email== '' || address =='' || phone =='') {
                window.alert('모든 문항을 입력해주세요.');
                return;
            }

 
            $.ajax({
                type: 'POST',
                url: '/PersonalInfo/TestDTO',
                data: {
                    Id: id, Name: name, Email: email, Address: address, Phone: phone
                },
            success: function (data) {

                data = JSON.parse(data);
                console.log(data);
               for (key in data) {
                   $('#return_' + key.toLowerCase()).html(data[key]);
               }

            },
            error: function (xhr, status, error) {
                console.log('error : ' + error);
            }
        });
    });

    $('input[name=Id]').keyup(function () {
        var id = $(this).val();
        var maxLen = $(this).attr('maxLength');
        if (id.length > maxLen.length) {
            $(this).val(id.slice(0, maxLen));
        }
    });



});