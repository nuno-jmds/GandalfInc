$(document).ready(function () {

    $('#tblPos').DataTable({
        "ajax": "ExemploDados.json",
        "columns": [
            { "data": "name" },
            { "data": "category" },
            { "data": "quantity" },
            { "data": "price" },
            { "defaultContent": "<a href='#'>Editar</a>" }
        ]
    });
});