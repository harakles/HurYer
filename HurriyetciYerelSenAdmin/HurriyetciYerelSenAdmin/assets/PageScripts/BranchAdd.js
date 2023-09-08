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