$(function () {
    $('#submit').click(function () {
        var name = $.trim($('input[name=name]').val());
        var category = $.trim($('input[name=category]').val());
        var price = $.trim($('input[name=price]').val());
        if (name == '' || category == '' || price == '') {
            console.log('input');
            return false;
        }

        $.post('../api/products/add', { name: name, category: category, price: price })
            .success(function (data) {
                location.replace('index');
            })
            .error(function (jqXhr) {
                $('ul *').remove();
                var result = 'status : ' + jqXhr.status;
                $('<li/>', { text: result }).appendTo($('#result'));

                result = 'errorMessage : ' + jqXhr.statusText;
                $('<li/>', { text: result }).appendTo($('#result'));

                result = 'readyState : ' + jqXhr.readyState;
                $('<li/>', { text: result }).appendTo($('#result'));
            });
        return false;
    });

});