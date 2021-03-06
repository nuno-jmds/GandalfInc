$(document).ready(function () {

    $('#btn_submit').click(function (event) {
        event.preventDefault();
        
        if ($('#in_name').val() != "" || $('#in_price').val() != "" || $('#in_reference').val()!="") {

            $.ajax({
                type: "POST",
                url: "https://localhost:44307/api/Product",
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                data: JSON.stringify({
                    "name": $('#in_name').val(),
                    "reference": $('#in_reference').val(),
                    "brand": $('#in_brand').val(),
                    "category": $('#in_category').val(),
                    "quantity": $('#in_quantity').val(),
                    "price": $('#in_price').val(),
                    "active": $('#in_active').prop('checked'),
                })
            });
        } else {

            $('#in_name').attr("placeholder","Need a Name");
        }



       
    });

});