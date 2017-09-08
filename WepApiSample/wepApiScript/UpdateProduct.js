$(function () {

    function getProduct() {
        $.getJSON("../api/products/getall",
            function (data) {
               // var selectHtml = '<select id="selectId"  style="width: 130px">';
                var selectHtml = '<option value="select">선택</option>';
                $('#selectId').append(selectHtml);
                $.each(data, function (key, val) {
                    selectHtml = '<option value=' + val.ProductModelsID + '>' + val.ProductModelsID + '</optrion>';
                    $('#selectId').append(selectHtml);
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

    $('#selectId').change(function () {
        var id = $('#selectId option:selected').val();

        $.getJSON('../api/products/getid/' + id,
                function (data) {
                    $.each(data, function (key, value) {
                        $('input[name=name]').val(value.Name);
                        $('input[name=category]').val(value.Category);
                        $('input[name=price]').val(value.Price);
                    });
                })
            .fail(
                function (jqXhr) {
                    errorMessage(jqXhr);
                });
    });

    $('#updateSubmit').click(function() {
        var id = $('#selectId option:selected').val();
        var name = $.trim($('input[name=name]').val());
        var category = $.trim($('input[name=category]').val());
        var price = $.trim($('input[name=price]').val());

        if (name == '' || category == '' || price == '') {
            return false;
        }

        $.post('../api/products/put',
            { productModelsID: id, name: name, category: category, price: price })
            .success(function (data) {
                location.replace('index');
            })
            .error(function (jqXhr) {
                errorMessage(jqXhr);
            });
        return false;
    });

});