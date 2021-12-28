$(document).ready(function () {

    $('#btn_submit').click(function () {
        console.log("click button submit");

        $.ajax({
            type: "POST",
            url: "https://localhost:44307/api/Product",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            data: JSON.stringify({
                "nome": "XXXXXX",
            })
        });
    });

});