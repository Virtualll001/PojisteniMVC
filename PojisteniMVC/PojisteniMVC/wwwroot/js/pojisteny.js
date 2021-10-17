var dataTable;
//v _Layout u scriptů musí být odkaz na DataTable!
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $("#tblData").DataTable({
        "ajax": {
            "url": "/Admin/Pojisteny/GetAll" //viz cesta k metodě v controlleru pro daný view
        },
        "columns": [ //sloupce musí sedět s modelem a s view! 
            { "data": "jmeno", "width": "15%" }, //pozor-první písmena jsou malá! "camelCase"!
            { "data": "prijmeni", "width": "20%" },
            { "data": "adresa", "width": "40%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/Admin/Pojisteny/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i> 
                                </a>
                                <a onclick=Delete("/Admin/Pojisteny/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                    <i class="fas fa-trash-alt"></i> 
                                </a>
                            </div>
                           `;
                }, "width": "25%"
            }
        ]
    }); 
}

function Delete(url) {
    swal({
        title: "Jste si jistí, že chcete záznam smazat?",
        text: "Záznam nebude možné obnovit!",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}