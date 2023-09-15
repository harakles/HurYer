/**
 * Form Editors
 */

'use strict';
$(document).ready(function () {
    $("#showFileInput").click(function () {
        $("#fileInput").click();
    });

    $("#fileInput").change(function () {
        var formData = new FormData();
        formData.append('file', this.files[0]);

        $.ajax({
            type: 'POST',
            url: '/Media/FileUpload',
            data: formData,
            processData: false,
            contentType: false,
            success: function (response) {
                console.log(response);
                var fileId = response.Id;
                var fileName = response.FileName;

                var newRow = `<tr><td class='img-rew'><img src='${response.Url}'/></td><td>${fileName}</td><td><button type='button' class='deleteButton btn btn-primary' data-filename='${fileName}' data-fileid='${fileId}'>Sil</button></td></tr>`;
                $("#fileTable tbody").append(newRow);

                var container = document.getElementById("fileInputsContainer");
                var inputElement = document.createElement("input");
                inputElement.type = "text";
                inputElement.id = fileName + fileId;
                inputElement.value = fileId;
                inputElement.name = `files`;
                inputElement.hidden = "hidden";
                container.appendChild(inputElement);
            },
            error: function (xhr) {
                console.log(xhr.responseText);
            }
        });
    });

    $("#fileTable").on("click", ".deleteButton", function () {
        var data = $(this).data("fileid");
        var name = $(this).data("filename");
        var row = $(this).closest("tr");
        $.ajax({
            type: 'POST',
            url: '/Media/FileDelete',
            data: { Id: data },
            success: function () {
                row.remove();
                var select = name + data;
                var input = document.getElementById(select);
                input.remove();
            },
            error: function (xhr) {
                console.log(xhr.responseText);
            }
        });
    });
});


(function () {
    // Full Toolbar
    // --------------------------------------------------------------------
    const fullToolbar = [
        [
            {
                font: []
            },
            {
                size: []
            }
        ],
        ['bold', 'italic', 'underline', 'strike'],
        [
            {
                color: []
            },
            {
                background: []
            }
        ],
        [
            {
                script: 'super'
            },
            {
                script: 'sub'
            }
        ],
        [
            {
                header: '1'
            },
            {
                header: '2'
            },
            'blockquote',
            'code-block'
        ],
        [
            {
                list: 'ordered'
            },
            {
                list: 'bullet'
            },
            {
                indent: '-1'
            },
            {
                indent: '+1'
            }
        ],
        [{ direction: 'rtl' }],
        ['link','formula'],
        ['clean']
    ];
    const fullEditor = new Quill('#full-editor', {
        bounds: '#full-editor',
        placeholder: 'Medya detay metni giriniz',
        modules: {
            formula: true,
            toolbar: fullToolbar
        },
        theme: 'snow'
    });
    const hiddenInput = document.getElementById('MediaTextEditor');

    fullEditor.on('text-change', function () {
        hiddenInput.value = fullEditor.root.innerHTML;
        console.log(hiddenInput.value)
    });
})();

document.addEventListener('DOMContentLoaded', function (e) {
    (function () {
        let accountUserImage = document.getElementById('uploadedAvatar');
        const fileInput = document.querySelector('.account-file-input'),
            resetFileInput = document.querySelector('.account-image-reset');

        if (accountUserImage) {
            const resetImage = accountUserImage.src;
            fileInput.onchange = () => {
                if (fileInput.files[0]) {
                    accountUserImage.src = window.URL.createObjectURL(fileInput.files[0]);
                }
            };
            resetFileInput.onclick = () => {
                fileInput.value = '';
                accountUserImage.src = resetImage;
            };
        }

    })();
});

(function () {
    // Flat Picker
    // --------------------------------------------------------------------
    const 
        MediaDate = document.querySelector('#MediaDate'),
        MediaLastDate = document.querySelector('#MediaLastDate');

    // Human Friendly
    if (MediaLastDate) {
        MediaLastDate.flatpickr({
            dateFormat: 'd-m-Y'
        });
    }

    if (MediaDate) {
        MediaDate.flatpickr({
            dateFormat: 'd-m-Y'
        });
    }
    
})();

function MediaValidate() {
    const Form = document.getElementById("FormAuth");
    const Tittle = document.getElementById("MediaTittle");
    const DateInput = document.getElementById("MediaDate");
    if (Tittle.value == null || Tittle.value == "") {
        window.Swal.fire({
            title: 'Media Başlığını Boş Geçemezsiniz',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    }
    if (DateInput.value == null || DateInput.value == "") {
        window.Swal.fire({
            title: 'Tarihi Boş Geçemezsiniz',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    }
    Form.submit();
}