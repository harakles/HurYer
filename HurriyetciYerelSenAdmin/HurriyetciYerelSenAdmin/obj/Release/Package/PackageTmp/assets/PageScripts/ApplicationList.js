$(document).ready(function () {
    $('#Filter').select2({
        placeholder: "Durum Filtresi",
        allowClear: true,
        language: "tr"
    });
});
$(function () {
    window.dt = $("#datatable").DataTable({
        "proccessing": true,
        "serverSide": true,
        "responsive": true,
        "order": [0, "desc"],
        "language": {
            "url": "../../assets/Datatable/Turkish.json"
        },
        "ajax": {
            "url": "/Application/GetList",
            "data": function (data) {
                if (window.CaseID !== null) {
                    data.CaseID = $("#CaseID").val().toString();
                }
            }
        },
        "columns": [
            { "title": "Ad", "data": "ApplicationName", "searchable": true },
            { "title": "Soyad", "data": "ApplicationSurname", "searchable": true },
            { "title": "Telefon", "data": "ApplicationPhoneNumber", "searchable": true },
            { "title": "E-Posta", "data": "ApplicationEmail", "searchable": true },
            { "title": "Durum", "data": "Case", "searchable": false, "orderable": false },
            {
                "title": "Eylemler", "data": null, "searchable": false, "orderable": false,
                render: function (data, type, row) {
                    return `
                        <button type="button" class="btn btn-outline-primary dropdown-toggle" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Eylem
                        </button>
                        <div class="dropdown-menu dropdown-menu-end">
                            <a class="dropdown-item" href="/Application/Update?id=${data.Id}">Düzenle</a>
                            <div role="separator" class="dropdown-divider"></div>
                            <a class="dropdown-item sil" OnClick="ApplicationDelete(${data.Id});">Sil</a>
                        </div>
                    `;
                }
            }
        ]
    });
});

$("#CaseID").on("change", function () {
    dt.draw();
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
                url: "/Application/Delete?Id=" + id,
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

$(function () {
    const select2 = $('.select2');

    // Select2
    // --------------------------------------------------------------------

    // Default
    if (select2.length) {
        select2.each(function () {
            var $this = $(this);
            $this.wrap('<div class="position-relative"></div>').select2({
                dropdownParent: $this.parent()
            });
        });
    }
});