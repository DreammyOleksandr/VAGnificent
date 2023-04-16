$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {url: 'brand/getall'},
        "columns": [
            {data: 'brandname', "width": "50%"},
            {data: 'ceo', "width" : "50%" }
            // {
            //     data: 'Id',
            //     "render": function (data) {
            //         return `<div class="w-75 btn-group" role="group">
            //          <a href="brand/edit?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Edit</a>               
            //          <a onClick=Delete('brand/delete/${data}') class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Delete</a>
            //         </div>`
            //     },
            //     "width": "10%"
                
            
        ]
    })
}