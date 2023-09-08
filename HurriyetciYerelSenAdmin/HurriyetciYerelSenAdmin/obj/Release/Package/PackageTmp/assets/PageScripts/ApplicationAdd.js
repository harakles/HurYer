/**
 * Form Layout Vertical
 */
'use strict';


function UserValidate() {
    const Form = document.getElementById("FormAuth");
    const kimlikNo = document.getElementById("ApplicationIdentityNumber").value;
    if (kimlikNo.length !== 11 || isNaN(kimlikNo)) {
        window.Swal.fire({
            title: 'Geçersiz Kimlik Numarasý',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    }

    var toplam = 0;
    for (var i = 0; i < 10; i++) {
        toplam += parseInt(kimlikNo.charAt(i));
    }
    var kontrolRakam = toplam % 10;

    if (kontrolRakam === parseInt(kimlikNo.charAt(10))) {
        //Kimlik Numarasý Doðru
    } else {
        window.Swal.fire({
            title: 'Geçersiz Kimlik Numarasý',
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

$(document).ready(function () {
    $("#ApplicationProvinceID").change(function () {
        var selectedId = $(this).val();
        if (selectedId == 0) {
            $("#ApplicationDistrictID").empty();

            $("#ApplicationDistrictID").append($('<option></option>').val("0").text("-Seçiniz-"));
        }
        $.ajax({
            url: '/Application/GetDistrictSelectList',
            type: 'GET',
            data: { Id: selectedId },
            success: function (data) {
                $("#ApplicationDistrictID").empty();

                $("#ApplicationDistrictID").append($('<option></option>').val("0").text("-Seçiniz-"));

                $.each(data, function (index, item) {
                    $("#ApplicationDistrictID").append($('<option></option>').val(item.Value).text(item.Text));
                });
            }
        });
    });
});

(function () {
    const Date = document.querySelector('#ApplicationBornDate');
    if (Date) {
        Date.flatpickr({
            dateFormat: 'd-m-Y'
        });
    }

})();