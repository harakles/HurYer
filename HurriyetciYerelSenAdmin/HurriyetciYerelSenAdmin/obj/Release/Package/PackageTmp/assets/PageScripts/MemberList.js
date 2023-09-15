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
            "url": "/Member/GetList",
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
                              title="${data.MemberName}"
                            >
                              <img src=${data.MemberPhoto} alt="Avatar" class="rounded-circle" />
                            </li>
                          </ul>
                    `;
                }
            },
            { "title": "Üye Adı", "data": "MemberName", "searchable": true },
            { "title": "Üye Soyadı", "data": "MemberSurname", "searchable": true },
            { "title": "Üye Pozisyonu", "data": "MemberPosition", "searchable": true },
            { "title": "Telefon Numarası", "data": "MemberPhoneNumber", "searchable": true },
            {
                "title": "Eylemler", "data": null, "searchable": false, "orderable": false,
                render: function (data, type, row) {
                    return `
                        <button type="button" class="btn btn-outline-primary dropdown-toggle" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Eylem
                        </button>
                        <div class="dropdown-menu dropdown-menu-end">
                            <a class="dropdown-item" href="/Member/Update?id=${data.Id}">Düzenle</a>
                            <div Member="separator" class="dropdown-divider"></div>
                            <a class="dropdown-item sil" OnClick="MemberDelete(${data.Id});">Sil</a>
                        </div>
                    `;
                }
            }
        ]
    });
});


function MemberDelete(id) {
    window.Swal.fire({
        title: 'Silmek İstediğinizden Eminmisiniz',
        icon: 'info',
        showCancelButton: true,
        confirmButtonText: 'Evet',
        cancelButtonText: 'Hayır',
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: "/Member/Delete?Id=" + id,
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