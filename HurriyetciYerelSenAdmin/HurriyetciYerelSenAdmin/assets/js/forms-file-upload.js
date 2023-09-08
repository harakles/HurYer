/**
 * File Upload
 */

'use strict';

(function () {
    // previewTemplate: Updated Dropzone default previewTemplate
    // ! Don't change it unless you really know what you are doing
    const previewTemplate = `<div class="dz-preview dz-file-preview">
<div class="dz-details">
  <div class="dz-thumbnail">
    <img data-dz-thumbnail>
    <span class="dz-nopreview">No preview</span>
    <div class="dz-success-mark"></div>
    <div class="dz-error-mark"></div>
    <div class="dz-error-message"><span data-dz-errormessage></span></div>
    <div class="progress">
      <div class="progress-bar progress-bar-primary" role="progressbar" aria-valuemin="0" aria-valuemax="100" data-dz-uploadprogress></div>
    </div>
  </div>
  <div class="dz-filename" data-dz-name></div>
  <div class="dz-size" data-dz-size></div>
</div>
</div>`;

    // ? Start your code from here

    // Basic Dropzone
    // --------------------------------------------------------------------

    Dropzone.autoDiscover = false;

    const myDropzone = new Dropzone('#dropzone-basic', {
        previewTemplate: previewTemplate,
        url: "../../Upload/Member/Photo",
        autoProcessQueue: true,
        parallelUploads: 1,
        maxFilesize: 10,
        addRemoveLinks: true,
        maxFiles: 1,
        dictRemoveFile: "Dosyay� Sil",
        dictMaxFilesExceeded: "Daha Fazla Dosya Y�kleyemezsin.",
        dictCancelUploadConfirmation: "Y�klemeyi Durdurmak istedi�ine Eminmisin?",
        dictFileTooBig : "Dosya �ok B�y�k ({{filesize}}MiB). Maksimum Dosya B�y�kl���: {{maxFilesize}}MiB.",
    });

    myDropzone.on("addedfile", function (file) {
        var newFileName = new Date().toISOString().replace(/:/g, '_') + "_" + file.name;
        file.upload.filename = newFileName;
    });

    myDropzone.on("complete", function (file) {
        console.log("Dosya y�kleme tamamland�: " + file.name);
        if (file.status == "success") {
            const fotoinput = document.getElementById("MemberPhoto");
            fotoinput.value = file.dataURL;
        } else {
            window.Swal.fire({
                title: 'Foto�raf Y�klemesi Ba�ar�s�z Oldu',
                icon: 'error',
                showCancelButton: false,
                showConfirmButton: false,
            });
        }
    });

})();
