$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#CarsData').DataTable({
        "ajax": {"url": "/Admin/Disposal/GetAll"},
        "columns": [
            {data: "brand.brandName", "width": "15%"},
            {data: "model", "width": "15%"},
            {data: "brandCountry", "width": "10"},
            {data: "colour", "width": "10%"},
            {data: "horsePower", "width": "10%"},
            {data: "transmisionType", "width": "10%"},
            {data: "year", "width": "10%"},
            {
                data: "id",
                "render": function (data) {
                    return `<div class="w-25 btn-group" role="group">
                <a href="Disposal/Edit?id=${data}" class="btn btn-primary mx-2">Edit</a>
                <a href="Disposal/Delete?id=${data}" class="btn btn-danger mx-2">Delete</a>
                </div>`
                },
                "width":"20%"
            },
        ],
    });
}