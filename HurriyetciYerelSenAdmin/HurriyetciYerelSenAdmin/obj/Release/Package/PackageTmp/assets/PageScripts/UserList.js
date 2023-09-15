$(function () {
    window.dt = $("#datatable").DataTable({
        "proccessing": true,
        "serverSide": true,
        "responsive": true,
        "order": [1, "asc"],
        "language": {
            "url": "../../assets/Datatable/Turkish.json"
        },
        "ajax": {
            "url": "/User/GetList",
            "data": function (data) {
                
            }
        },
        "columns": [
            {
                "title": "Fotoğraf", "data": null, "searchable": false, "orderable": false, 
                render: function (data, type, row) {
                    return `
                        <ul class="list-unstyled users-list ms-3 avatar-group d-flex w-50">
                            <li
                              data-bs-toggle="tooltip"
                              data-popup="tooltip-custom"
                              data-bs-placement="top"
                              class="avatar avatar-md pull-up "
                              title="${data.UserName}"
                            >
                              <img src=${data.UserProfilePic} alt="Avatar" class="rounded-circle" />
                            </li>
                          </ul>
                    `;
                }
            },
            { "title": "Ad", "data": "UserName", "searchable": true },
            { "title": "Soyad", "data": "UserSurname", "searchable": true },
            { "title": "Telefon", "data": "UserPhoneNumber", "searchable": true },
            { "title": "E-Posta", "data": "UserEmail", "searchable": true },
            {
                "title": "Eylemler", "data": null, "searchable": false, "orderable": false,
                render: function (data, type, row) {
                    return `
                        <button type="button" class="btn btn-outline-primary dropdown-toggle" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Eylem
                        </button>
                        <div class="dropdown-menu dropdown-menu-end">
                            <a class="dropdown-item" href="/User/Update?id=${data.Id}">Düzenle</a>
                            <div role="separator" class="dropdown-divider"></div>
                            <a class="dropdown-item sil" OnClick="UserDelete(${data.Id});">Sil</a>
                        </div>
                    `;
                }
            }
        ]
    });
});


function UserDelete(id) {
    window.Swal.fire({
        title: 'Silmek İstediğinizden Eminmisiniz',
        icon: 'info',
        showCancelButton: true,
        confirmButtonText: 'Evet',
        cancelButtonText: 'Hayır',
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: "/User/Delete?Id=" + id,
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