function UserValidate() {
    const Form = document.getElementById("FormAuth");
    const UserClassName = document.getElementById('UserClassName');
    if (UserClassName.value == null) {
        window.Swal.fire({
            title: 'Rol Adını Boş Geçemezsiniz',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    } else if (UserClassName.value.length <= 2 || UserClassName.value.length >= 20) {
        window.Swal.fire({
            title: 'Rol Adı 2 Karakterden Kısa 20 Karakterden Uzun Olamaz',
            icon: 'info',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    }
    Form.submit();
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

    // Select2
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