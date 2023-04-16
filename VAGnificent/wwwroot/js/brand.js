$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {"url": 'Brand/GetAll'},
        "columns": [
            {data: "brandName", "width": "40%"},
            {data: "ceo", "width": "40%"},
            {
                data: "id",
                "render": function (data) {
                    return `<div class="w-25 btn-group" role="group">
                <a href="/Brand/Edit?id=${data}" class="btn btn-primary mx-2">Edit</a>
                <a href="/Brand/Delete?id=${data}" class="btn btn-danger mx-2">Delete</a>
                </div>`
                },
                "width":"20%"
            },
        ],
    });
}