$(function () {

    function getProduct() {
        $.getJSON("../api/products/getall",
            function (data) {
                $.each(data,
                    function(key, val) {
                        var inner = '<tr>';
                        inner += '<td class="col-md-2 control-label">' + val.ProductModelsID + '</td>';
                        inner += '<td>' + val.Name + '</td>';
                        inner += '<td>' + val.Category + '</td>';
                        inner += '<td>' + val.Price + '</td>';
                        inner += '</tr>';
                        $('#products').append(inner);
                    });
            });
    }
    getProduct();

    function errorMessage(jqXhr) {
        $('ul *').remove();
        var result = 'status : ' + jqXhr.status;
        $('<li/>', { text: result }).appendTo($('#result'));

        result = 'errorMessage : ' + jqXhr.statusText;
        $('<li/>', { text: result }).appendTo($('#result'));

        result = 'readyState : ' + jqXhr.readyState;
        $('<li/>', { text: result }).appendTo($('#result'));
    }

    $("#find").click(function () {
        var select = $('#value option:selected').val();
        var selectVlaue = $.trim($('#selectVlaue').val());

        if (selectVlaue == '') {
            return;
        }

        var param = '';
        if (select == 'id') {
            param = '../api/products/getid/' + selectVlaue;
        } else {
            param = '../api/products/getcategory?category=' + selectVlaue;
        }
        
        $.getJSON(param,
                function (data) {
                    $('ul *').remove();
                    $.each(data, function (key, value) {
                        var result = 'ID : ' + value.ProductModelsID;
                        $('<li/>', { text: result }).appendTo($('#result'));

                        result = 'Name : ' + value.Name;
                        $('<li/>', { text: result }).appendTo($('#result'));

                        result = 'Category : ' + value.Category;
                        $('<li/>', { text: result }).appendTo($('#result'));

                        result = 'Price : ' + value.Price;
                        $('<li/>', { text: result }).appendTo($('#result'));
                    });
                })
            .fail(
                function (jqXhr) {
                    errorMessage(jqXhr);

                });
    });

    $("#removeProduct").click(function () {
        $.ajax({
            type: 'POST',
            url: '../api/products/delete',
            data: { "": $('#selectVlaue').val() },
            contentType: "application/x-www-form-urlencoded; charset=UTF-8",
            success: function(data) {
                $('#result').text(data);
                location.reload();
            },
            error: function (jqXhr) {
                errorMessage(jqXhr);
            }
        });
    });

    $('#value').change(function() {
        $('#selectVlaue').val('');
        $('#selectVlaue').focus();
    });

});