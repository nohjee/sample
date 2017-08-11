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

        var id = document.getElementById('id');
        var name = document.getElementById('name');
        var email = document.getElementById('email');
        var address = document.getElementById('address');
        var phone = document.getElementById('phone');

        var bool = new Array();
        bool[0] = id;
        bool[1] = name;
        bool[2] = email;
        bool[3] = address;
        bool[4] = phone;

        for (var i = 0; i < bool.length; i++) {
            if (bool[i].value == '' || bool[i].value == null || bool[i].value == undefined ||
                (bool[i].value != null && typeof bool[i].value == 'object' &&
                !Object.keys(bool[i]).value.length)) {
                window.alert('모든 항목을 작성하세요.');
                
                $('#'+bool[i].id).focus();
                return;
            }
        }

        $.ajax({
            type: 'POST',
            url: '/HOME/TestParam',
            data: {
                id: id.value,
                name: name.value,
                email: email.value,
                address: address.value,
                phone: phone.value
            },

            success: function(data) {
                data = JSON.parse(data);
                for (key in data) {
                    var temp = document.getElementById('return_' + key.toLowerCase());
                    temp.value = data[key];
                }

            },
            error: function(xhr, status, error) {
                console.log('error : ' + error);
            }
        });
    });

    
    $('#id').keyup(function () {
        
        var id = document.getElementById('id');
        if (id.value.length > id.maxLength) {
            id.value = id.value.slice(0, id.maxLength);
        }
    });

});

  


