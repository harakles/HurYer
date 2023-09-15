$(function () {
    window.dt = $("#SubBranchdatatable").DataTable({
        "proccessing": true,
        "serverSide": true,
        "responsive": true,
        "order": [0, "asc"],
        "language": {
            "url": "../../assets/Datatable/Turkish.json"
        },
        "ajax": {
            "url": "/Branch/GetSubBranchList",
            "data": function (data) {
                data.BranchID = BranchID;
            }
        },
        "columns": [
            { "title": "Ad", "data": "SubBranchName", "searchable": true },
            { "title": "Mail", "data": "Email", "searchable": true },
            { "title": "Telefon", "data": "PhoneNumber", "searchable": true },
            {
                "title": "Eylemler", "data": null, "searchable": false, "orderable": false,
                render: function (data, type, row) {
                    return `
                        <button type="button" class="btn btn-outline-primary dropdown-toggle" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Eylem
                        </button>
                        <div class="dropdown-menu dropdown-menu-end">
                            <a class="dropdown-item" href="/Branch/SubBranchUpdate?id=${data.Id}">Düzenle</a>
                            <div Application="separator" class="dropdown-divider"></div>
                            <a class="dropdown-item sil" OnClick="ApplicationDelete(${data.Id});">Sil</a>
                        </div>
                    `;
                }
            }
        ]
    });
});


function ApplicationDelete(id) {
    window.Swal.fire({
        title: 'Silmek İstediğinizden Eminmisiniz',
        icon: 'info',
        showCancelButton: true,
        confirmButtonText: 'Evet',
        cancelButtonText: 'Hayır',
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: "/Branch/SubBranchDelete?Id=" + id,
                type: "POST",
                data: JSON.stringify(id),
                dataType: 'json',
                contentType: "application/json; charset=utf-8",
                success: function () {
                    $("#SubBranchdatatable").DataTable().ajax.reload();
                    window.Swal.fire('silindi', '', 'success');
                },
                error: function () {
                    $("#SubBranchdatatable").DataTable().ajax.reload();
                    window.Swal.fire('silindi', '', 'success');
                }
            });
        }
    });
}
$(function () {
    window.dt = $("#BranchMemberdatatable").DataTable({
        "proccessing": true,
        "serverSide": true,
        "responsive": true,
        "order": [0, "desc"],
        "language": {
            "url": "../../assets/Datatable/Turkish.json"
        },
        "ajax": {
            "url": "/Branch/GetBranchMemberList",
            "data": function (data) {
                data.BranchID = BranchID;
            }
        },
        "columns": [
            { "title": "İsim", "data": "Name", "searchable": true },
            { "title": "Mail", "data": "EMailAdress", "searchable": true },
            { "title": "Pozisyon", "data": "Position", "searchable": true },
            { "title": "Telefon", "data": "PhoneNumber", "searchable": true },
            {
                "title": "Eylemler", "data": null, "searchable": false, "orderable": false,
                render: function (data, type, row) {
                    return `
                        <button type="button" class="btn btn-outline-primary dropdown-toggle" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Eylem
                        </button>
                        <div class="dropdown-menu dropdown-menu-end">
                            <a class="dropdown-item" href="/Branch/BranchMemberUpdate?id=${data.Id}">Düzenle</a>
                            <div Application="separator" class="dropdown-divider"></div>
                            <a class="dropdown-item sil" OnClick="Delete(${data.Id});">Sil</a>
                        </div>
                    `;
                }
            }
        ]
    });
});


function Delete(id) {
    window.Swal.fire({
        title: 'Silmek İstediğinizden Eminmisiniz',
        icon: 'info',
        showCancelButton: true,
        confirmButtonText: 'Evet',
        cancelButtonText: 'Hayır',
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: "/Branch/BranchMemberDelete?Id=" + id,
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