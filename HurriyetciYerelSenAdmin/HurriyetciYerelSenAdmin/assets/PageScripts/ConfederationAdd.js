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