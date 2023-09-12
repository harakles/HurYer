function CaseValidate() {
    const Form = document.getElementById("FormAuth");
    Form.submit();
}
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
        ['link', 'formula'],
        ['clean']
    ];
    const fullEditor = new Quill('#full-editor', {
        bounds: '#full-editor',
        placeholder: 'metni giriniz',
        modules: {
            formula: true,
            toolbar: fullToolbar
        },
        theme: 'snow'
    });
    const hiddenInput = document.getElementById('BroadcastTextEditor');

    fullEditor.on('text-change', function () {
        hiddenInput.value = fullEditor.root.innerHTML;
    });
})();
$(document).ready(function () {
    $("#showFileInput").click(function () {
        $("#fileInput").click();
    });

    $("#fileInput").change(function () {
        var formData = new FormData();
        formData.append('file', this.files[0]);

        $.ajax({
            type: 'POST',
            url: '/Case/FileUpload',
            data: formData,
            processData: false,
            contentType: false,
            success: function (response) {
                console.log(response);
                var fileId = response.Id;
                var fileName = response.FileName;

                
                var newRow = `<tr><td>${fileName}</td><td><button type='button' class='deleteButton btn btn-primary' data-filename='${fileName}' data-fileid='${fileId}'>Sil</button></td></tr>`;
                $("#fileTable tbody").append(newRow);

                var container = document.getElementById("fileInputsContainer");
                var inputElement = document.createElement("input");
                inputElement.type = "text"; 
                inputElement.id = fileName+fileId;
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
            url: '/Case/FileDelete',
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