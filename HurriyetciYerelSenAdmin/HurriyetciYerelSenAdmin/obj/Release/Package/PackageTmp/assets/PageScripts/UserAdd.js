/**
 * Form Layout Vertical
 */
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

function PBC1() {
    var inputElement = document.getElementById('UserPassword');
    var inputElementicon = document.getElementById('UserPasswordIcon1');
    if (inputElement.type == 'password') {
        inputElement.type = 'text'
        inputElementicon.className = 'ti ti-eye';
        return;
    }
    if (inputElement.type == 'text') {
        inputElement.type = 'password'
        inputElementicon.className = 'ti ti-eye-off';
        return;
    }
};

function PBC2() {
    var inputElement = document.getElementById('UserPasswordRep');
    var inputElementicon = document.getElementById('UserPasswordIcon2');
    if (inputElement.type == 'password') {
        inputElement.type = 'text'
        inputElementicon.className = 'ti ti-eye';
        return;
    }
    if (inputElement.type == 'text') {
        inputElement.type = 'password'
        inputElementicon.className = 'ti ti-eye-off';
        return;
    }
};

function UserValidate() {
    const Form = document.getElementById("FormAuth");
    const UserName = document.getElementById('UserName');
    const UserSurname = document.getElementById('UserSurname');
    const UserEmail = document.getElementById('UserEmail');
    const UserPhoneNumber = document.getElementById('UserPhoneNumber');
    const UserPassword = document.getElementById('UserPassword');
    const UserPasswordRep = document.getElementById('UserPasswordRep');
    if (UserName.value == null) {
        window.Swal.fire({
            title: 'Kullanıcı Adını Boş Geçemezsiniz',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    } else if (UserName.value.length <= 2 || UserName.value.length >= 20) {
        window.Swal.fire({
            title: 'Kullanıcı Adı 2 Karakterden Kısa 20 Karakterden Uzun Olamaz',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    }
    if (UserSurname.value == null) {
        debugger
        window.Swal.fire({
            title: 'Kullanıcı Soyadını Boş Geçemezsiniz',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    } else if (UserSurname.value.length <= 2 || UserSurname.value.length >= 20) {
        window.Swal.fire({
            title: 'Kullanıcı Soyadı 2 Karakterden Kısa 20 Karakterden Uzun Olamaz',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    }
    if (UserEmail.value == null || UserEmail.value == "") {
        window.Swal.fire({
            title: 'E-Posta Adresi Boş Geçilemez',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    } else if (!UserEmail.value.includes("@") || !UserEmail.value.includes(".com")) {
        window.Swal.fire({
            title: 'Lütfen Geçerli Bir E-Posta Adresi Giriniz',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    }
    if (UserPhoneNumber.value == null || UserPhoneNumber.value == "") {
        window.Swal.fire({
            title: 'Lütfen Bir Telefon Numarası Giriniz',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    } else if (UserPhoneNumber.value.length < 13 || UserPhoneNumber.value.length > 17) {
        window.Swal.fire({
            title: 'Lütfen Geçerli Bir Telefon Numarası Giriniz',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    }
    if (UserPassword.value.length < 8 || UserPassword.value.length > 24) {
        window.Swal.fire({
            title: 'Şifre 8 Karakterden Uzun 24 Karakterden Kısa Olmalı',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    }
    if (UserPasswordRep.value != UserPassword.value) {
        window.Swal.fire({
            title: 'Girilen Şifreler Uyuşmuyor',
            icon: 'info',
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
                dropdownParent: $this.parent()
            });
        });
        select2.val(Perms).trigger('change');
    }
});