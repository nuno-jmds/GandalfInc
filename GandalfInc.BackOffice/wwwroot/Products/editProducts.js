$(document).ready(function () {

    var url_string = window.location.href;
    var url = new URL(url_string);
    var id = url.searchParams.get("id");
    console.log(id);


    $.ajax({
        url: "https://localhost:44307/api/Product/api/Product/ById?id="+id,
        type: "GET",
    }).done(function (responseText) {
        console.log("ajax Success: status", responseText);
        $('#in_name').val(responseText.name);
        $('#in_reference').val(responseText.reference);
    }).fail(function (responseText) {
      
        $("#lblClientesNovos").text("NOK");
       
    });




    


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
                    "id": id,
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