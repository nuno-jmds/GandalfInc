$(document).ready(function () {


    // Add event listener for opening and closing details
    $('#tblProducts').on('click', 'tbody td.dt-control', function () {

        

        var tr = $(this).closest('tr');
        var row = table.row(tr);

        var id = row.data().id;

        var link = "editProducts.html?id=" + id;
        console.log(link);
        window.location.replace(link);
        
    });


    var table= $('#tblProducts').DataTable({
        "ajax": "https://localhost:44307/api/Product", 
        "rowId": 'id',
        "stateSave": true,
        "columns": [
            { "data": "name" },
            { "data": "reference" },
            { "data": "brand" },
            { "data": "category" },
            { "data": "quantity" },
            { "data": "price" },
            { "data": "active" },
            {
                "className": 'dt-control',
                "orderable": false,
                "data": "",
                "defaultContent": '...'
            },
            //{ "defaultContent": "<a href='editProduct.html?id=${1234}'>...</a>" }
        ]
    });
});