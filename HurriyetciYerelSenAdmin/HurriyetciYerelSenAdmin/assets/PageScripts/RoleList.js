﻿$(function () {
    window.dt = $("#datatable").DataTable({
        "proccessing": true,
        "serverSide": true,
        "responsive": true,
        "order": [0, "asc"],
        "language": {
            "url": "../../assets/Datatable/Turkish.json"
        },
        "ajax": {
            "url": "/Role/GetList",
            "data": function (data) {

            }
        },
        "columns": [
            { "title": "Rol Adı", "data": "UserClassName", "searchable": true },
            {
                "title": "Eylemler", "data": null, "searchable": false, "orderable": false,
                render: function (data, type, row) {
                    return `
                        <button type="button" class="btn btn-outline-primary dropdown-toggle" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Eylem
                        </button>
                        <div class="dropdown-menu dropdown-menu-end">
                            <a class="dropdown-item" href="/Role/Update?id=${data.Id}">Düzenle</a>
                            <div role="separator" class="dropdown-divider"></div>
                            <a class="dropdown-item sil" OnClick="RoleDelete(${data.Id});">Sil</a>
                        </div>
                    `;
                }
            }
        ]
    });
});


function RoleDelete(id) {
    window.Swal.fire({
        title: 'Silmek İstediğinizden Eminmisiniz',
        icon: 'info',
        showCancelButton: true,
        confirmButtonText: 'Evet',
        cancelButtonText: 'Hayır',
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: "/Role/Delete?Id=" + id,
                type: "POST",
                data: JSON.stringify(id),
                dataType: 'json',
                contentType: "application/json; charset=utf-8",
                success: function () {
                    dt.ajax.reload();
                    window.Swal.fire('silindi', '', 'success');
                },
                error: function () {
                    dt.ajax.reload();
                    window.Swal.fire('silindi', '', 'success');
                }
            });
        }
    });
}