$(function() {
    console.log('in');


    function bonusCheck(ch) {
        $.ajax({
            type: 'GET',
            data: {
                BonusCode: 'test-nohjee'
            },
            url: '/Home/GetBonusCheck',
            success: function(data) {
                console.log('SuccessCode: ' + data);
            },
            error: function(xhr, status, error) {
                console.log('error : ' + error);
            }
        });
    }

    //	bonusCheck();
    $('#btnOk').click(function() {

        var id = document.getElementById('id').value;
        var name = document.getElementById('name').value;
        var email = document.getElementById('email').value;
        var address = document.getElementById('address').value;
        var phone = document.getElementById('phone').value;

        // 공백제거
        name = $.trim(name); 
        email = $.trim(email);
        address = $.trim(address);
        phone = $.trim(phone);
        if (id == '' || name == '' || email == '' || address == '' || phone == '') {
        window.alert('모든 항목을 작성하세요.');        
        return;
        }
 
       

        $.ajax({
            type: 'POST',
            url: '/HOME/TestParam',
            data: {
                id: id,
                name: name,
                email: email,
                address: address,
                phone: phone
            },

            success: function(data) {
                data = JSON.parse(data);
                for (key in data) {
                    $('#return_' + key.toLowerCase()).val(data[key]);  
                }

            },
            error: function(xhr, status, error) {
                console.log('error : ' + error);
            }
        });
    });

    
    $('#id').keyup(function () {
        var id = $('#id').val();
        var lengh_limit = $(this).attr('maxlength');
        if (id.length > lengh_limit) {
            $('#id').val(id.slice(0, lengh_limit));
        }
    });

});

  


