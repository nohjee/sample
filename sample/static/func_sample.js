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


        var id = $('#createId').val();
        $('#valueTable>tbody').remove();


            if (id == '') {
                window.alert('값을 입력해주세요');
                return;
            }

 
            $.ajax({
                type: 'POST',
                url: '/PersonalInfo/TestDTO',
                data: {
                    createId: id
                },
            success: function (data) {

                data = JSON.parse(data);
                
                for (var i=0; i<data.length; i++) {
                    var row = '<tr>';
                    row += '<td>아이디</td>';
                    row += '<td>'+data[i].Id+'</td>';
                    row += '</tr><tr>';

                    row += ' <td>이름</td>';
                    row += ' <td>'+data[i].Name+'</td>';
                    row += '</tr><tr>';

                    row += '<td>이메일</td>';
                    row += '<td>' + data[i].Email + '</td>';
                    row += '</tr><tr>';

                    row += '<td>주소</td>';
                    row += '<td>' + data[i].Address + '</td>';
                    row += '</tr><tr>';

                    row += '<td>전화번호</td>';
                    row += '<td>' + data[i].Phone + '</td>';
                    row += '</tr><tr>';

                    row += '<td style="border-bottom: 1px solid black;">현재 날짜</td>';
                    row += '<td style="border-bottom: 1px solid black;">' + data[i].NowDate + '</td>';
                    row += '</tr>';

                    $('#valueTable').append(row);
                }

            },
            error: function (xhr, status, error) {
                console.log('error : ' + error);
            }
        });
    });

    $('#createId').keyup(function () {
        
        var id = $('#createId').val();
        var max = $('#createId').attr('max');
        id = parseInt(id);
        max = parseInt(max);
        if (id > max) {
            $('#createId').val(max);
        }
    });



});