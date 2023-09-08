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
            "url": "/Application/GetDistrictList",
            "data": function (data) {
                data.ProvinceID = provinceID;
            }
        },
        "columns": [
            { "title": "ilce", "data": "District", "searchable": true },
            {
                "title": "Eylemler", "data": null, "searchable": false, "orderable": false,
                render: function (data, type, row) {
                    return `
                        <button type="button" class="btn btn-outline-primary dropdown-toggle" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            Eylem
                        </button>
                        <div class="dropdown-menu dropdown-menu-end">
                            <a class="dropdown-item" href="/Application/DistrictUpdate?id=${data.Id}">D�zenle</a>
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
        title: 'Silmek �stedi�inizden Eminmisiniz',
        icon: 'info',
        showCancelButton: true,
        confirmButtonText: 'Evet',
        cancelButtonText: 'Hay�r',
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: "/Application/DistrictDelete?Id=" + id,
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