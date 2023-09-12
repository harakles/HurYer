'use strict';

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

function MemberValidate() {
    const Form = document.getElementById("FormAuth");
    const MemberName = document.getElementById('MemberName');
    const MemberSurname = document.getElementById('MemberSurname');
    const MemberEmail = document.getElementById('MemberEmail');
    const MemberPhoneNumber = document.getElementById('MemberPhoneNumber');
    if (MemberName.value == null) {
        window.Swal.fire({
            title: 'Üye Adını Boş Geçemezsiniz',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    } else if (MemberName.value.length <= 2 || MemberName.value.length >= 20) {
        window.Swal.fire({
            title: 'Üye Adı 2 Karakterden Kısa 20 Karakterden Uzun Olamaz',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    }
    if (MemberSurname.value == null) {
        debugger
        window.Swal.fire({
            title: 'Üye Soyadını Boş Geçemezsiniz',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    } else if (MemberSurname.value.length <= 2 || MemberSurname.value.length >= 20) {
        window.Swal.fire({
            title: 'Üye Soyadı 2 Karakterden Kısa 20 Karakterden Uzun Olamaz',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    }
    if (MemberEmail.value == null || MemberEmail.value == "") {
        window.Swal.fire({
            title: 'E-Posta Adresi Boş Geçilemez',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    } else if (!MemberEmail.value.includes("@") || !MemberEmail.value.includes(".com")) {
        window.Swal.fire({
            title: 'Lütfen Geçerli Bir E-Posta Adresi Giriniz',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    }
    if (MemberPhoneNumber.value == null || MemberPhoneNumber.value == "") {
        window.Swal.fire({
            title: 'Lütfen Bir Telefon Numarası Giriniz',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    } else if (MemberPhoneNumber.value.length < 13 || MemberPhoneNumber.value.length > 14) {
        window.Swal.fire({
            title: 'Lütfen Geçerli Bir Telefon Numarası Giriniz',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    }
    Form.submit();
}


const phoneMaskList = document.querySelectorAll('.phone-mask');

// Phone Number
if (phoneMaskList) {
    phoneMaskList.forEach(function (phoneMask) {
        new Cleave(phoneMask, {
            phone: true,
            phoneRegionCode: 'TR'
        });
    });
}


// select2 (jquery)
$(function () {
    // Form sticky actions
    var topSpacing;
    const stickyEl = $('.sticky-element');

    // Init custom option check
    window.Helpers.initCustomOptionCheck();

    // Set topSpacing if the navbar is fixed
    if (Helpers.isNavbarFixed()) {
        topSpacing = $('.layout-navbar').height() + 7;
    } else {
        topSpacing = 0;
    }

    // sticky element init (Sticky Layout)
    if (stickyEl.length) {
        stickyEl.sticky({
            topSpacing: topSpacing,
            zIndex: 9
        });
    }

    // Select2 Country
    var select2 = $('.select2');
    if (select2.length) {
        select2.each(function () {
            var $this = $(this);
            $this.wrap('<div class="position-relative"></div>').select2({
                placeholder: '- Seçiniz -',
                dropdownParent: $this.parent()
            });
        });
        select2.val(Perms).trigger('change');
    }
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
        ['link', 'formula'],
        ['clean']
    ];
    const fullEditor = new Quill('#full-editor', {
        bounds: '#full-editor',
        placeholder: 'detay metni giriniz',
        modules: {
            formula: true,
            toolbar: fullToolbar
        },
        theme: 'snow'
    });
    const hiddenInput = document.getElementById('TextEditor');

    fullEditor.on('text-change', function () {
        hiddenInput.value = fullEditor.root.innerHTML;
        console.log(hiddenInput.value)
    });
})();