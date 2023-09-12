const phoneMaskList = document.querySelectorAll('.phone-mask');

if (phoneMaskList) {
    phoneMaskList.forEach(function (phoneMask) {
        new Cleave(phoneMask, {
            phone: true,
            phoneRegionCode: 'TR'
        });
    });
}

$(document).ready(function () {
    $("#ApplicationProvinceID").change(function () {
        var selectedId = $(this).val();
        if (selectedId == 0) {
            $("#ApplicationDistrictID").empty();

            $("#ApplicationDistrictID").append($('<option></option>').val("0").text("-Seçiniz-"));
        }
        $.ajax({
            url: '/TR/GetDistrictSelectList',
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
    const Dates = document.querySelector('#ApplicationBornDate');
    if (Dates) {
        Dates.flatpickr({
            dateFormat: 'd-m-Y',
            locale: {
                firstDayOfWeek: 0, // Pazartesi başlangıç
                weekdays: {
                    shorthand: ["Pzt", "Sal", "Çar", "Per", "Cum", "Cmt", "Paz"],
                    longhand: [
                        "Pazartesi",
                        "Salı",
                        "Çarşamba",
                        "Perşembe",
                        "Cuma",
                        "Cumartesi",
                        "Pazar"
                    ]
                },
                months: {
                    shorthand: [
                        "Oca",
                        "Şub",
                        "Mar",
                        "Nis",
                        "May",
                        "Haz",
                        "Tem",
                        "Ağu",
                        "Eyl",
                        "Eki",
                        "Kas",
                        "Ara"
                    ],
                    longhand: [
                        "Ocak",
                        "Şubat",
                        "Mart",
                        "Nisan",
                        "Mayıs",
                        "Haziran",
                        "Temmuz",
                        "Ağustos",
                        "Eylül",
                        "Ekim",
                        "Kasım",
                        "Aralık"
                    ]
                }
            }
        });
    }

})();

function Validate() {
    const Form = document.getElementById("form");
    const Name = document.getElementById('ApplicationName');
    const Surname = document.getElementById('ApplicationSurname');
    const kimlikNo = document.getElementById("ApplicationIdentityNumber");
    const Email = document.getElementById('ApplicationEmail');
    const Gender = document.getElementById('ApplicationGenderID');
    const FatherName = document.getElementById('ApplicationFatherName');
    const MotherName = document.getElementById('ApplicationMotherName');
    const BornPlace = document.getElementById('ApplicationBornPlace');
    const BornDate = document.getElementById('ApplicationBornDate');
    const Education = document.getElementById('ApplicationEducationID');
    const Organisation = document.getElementById('ApplicationOrganisationID');
    const WorkPlace = document.getElementById('ApplicationWorkPlaceName');
    const PhoneNumber = document.getElementById('ApplicationPhoneNumber');
    const Province = document.getElementById('ApplicationProvinceID');
    const District = document.getElementById('ApplicationDistrictID');
    const Staff = document.getElementById('ApplicationStaffID');
    const BloodType = document.getElementById('ApplicationBloodTypeID');
    if (Name.value == null || Name.value == "") {
        window.Swal.fire({
            title: 'Ad Boş Geçilemez',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    }
    if (Surname.value == null || Surname.value == "") {
        window.Swal.fire({
            title: 'Soyad Boş Geçilemez',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    }
    if (Email.value == null || Email.value == "") {
        window.Swal.fire({
            title: 'EPosta Boş Geçilemez',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    }
    if (Gender.value == null || Gender.value == "") {
        window.Swal.fire({
            title: 'Cinsiyet Boş Geçilemez',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    }
    if (FatherName.value == null || FatherName.value == "") {
        window.Swal.fire({
            title: 'Baba Adı Boş Geçilemez',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    }
    if (MotherName.value == null || MotherName.value == "") {
        window.Swal.fire({
            title: 'Anne Adı Boş Geçilemez',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    }
    if (BornPlace.value == null || BornPlace.value == "") {
        window.Swal.fire({
            title: 'Doğum Yeri Boş Geçilemez',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    }
    if (BornDate.value == null || BornDate.value == "") {
        window.Swal.fire({
            title: 'Doğum Tarihi Boş Geçilemez',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    }
    if (Education.value == null || Education.value == "") {
        window.Swal.fire({
            title: 'Eğitim Seviyesi Boş Geçilemez',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    }
    if (Organisation.value == null || Organisation.value == "") {
        window.Swal.fire({
            title: 'Kurum Boş Geçilemez',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    }
    if (WorkPlace.value == null || WorkPlace.value == "") {
        window.Swal.fire({
            title: 'İş Yeri Boş Geçilemez',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    }
    if (PhoneNumber.value == null || PhoneNumber.value == "") {
        window.Swal.fire({
            title: 'Telefon Numarası Boş Geçilemez',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    }
    if (Province.value == null || Province.value == "") {
        window.Swal.fire({
            title: 'İl Boş Geçilemez',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    }
    if (District.value == null || District.value == "") {
        window.Swal.fire({
            title: 'İlçe Boş Geçilemez',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    }
    if (Staff.value == null || Staff.value == "") {
        window.Swal.fire({
            title: 'Kadro Boş Geçilemez',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    }
    if (BloodType.value == null || BloodType.value == "") {
        window.Swal.fire({
            title: 'Kan Grubu Boş Geçilemez',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    }

    if (kimlikNo.value.length !== 11 || isNaN(kimlikNo.value)) {
        window.Swal.fire({
            title: 'Geçersiz Kimlik Numarası',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    }

    var toplam = 0;
    for (var i = 0; i < 10; i++) {
        toplam += parseInt(kimlikNo.value.charAt(i));
    }
    var kontrolRakam = toplam % 10;

    if (kontrolRakam === parseInt(kimlikNo.value.charAt(10))) {
    } else {
        window.Swal.fire({
            title: 'Geçersiz Kimlik Numarası',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    }
    Form.submit();
};





