document.addEventListener('DOMContentLoaded', function (e) {
    (function () {
        // Update/reset user image of account page
        let SystemLogoInput = document.getElementById('LogouploadedAvatar');
        const LogofileInput = document.querySelector('.Logoaccount-file-input'),
            LogoresetFileInput = document.querySelector('.Logoaccount-image-reset');
        let SystemIconInput = document.getElementById('IconuploadedAvatar');
        const IconfileInput = document.querySelector('.Iconaccount-file-input'),
            IconresetFileInput = document.querySelector('.Iconaccount-image-reset');

        if (SystemLogoInput) {
            const resetImage = SystemLogoInput.src;
            LogofileInput.onchange = () => {
                if (LogofileInput.files[0]) {
                    SystemLogoInput.src = window.URL.createObjectURL(LogofileInput.files[0]);
                }
            };
            LogoresetFileInput.onclick = () => {
                LogofileInput.value = '';
                SystemLogoInput.src = resetImage;
            };
        }

        if (SystemIconInput) {
            const resetImage = SystemIconInput.src;
            IconfileInput.onchange = () => {
                if (IconfileInput.files[0]) {
                    SystemIconInput.src = window.URL.createObjectURL(IconfileInput.files[0]);
                }
            };
            IconresetFileInput.onclick = () => {
                IconfileInput.value = '';
                SystemIconInput.src = resetImage;
            };
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

    })();
});

function SystemValidate() {
    const Form = document.getElementById("FormAuth");
    const SystemName = document.getElementById("SystemName");
    const SysteTelephone = document.getElementById("SystemTelephone");
    const FacebookLink = document.getElementById("FacebookLink");
    const InstagramLink = document.getElementById("InstagramLink");
    const WhatsAppApi = document.getElementById("WhatsAppApi");
    const YoutubeLink = document.getElementById("YoutubeLink");
    const SystemEmail = document.getElementById("SystemEmail");
    const SystemMapsLink = document.getElementById("SystemMapsLink");
    if (SystemName.value == null) {
        window.Swal.fire({
            title: 'Sistem Adını Boş Geçemezsiniz',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    } else if (SystemName.value.length <= 2 || SystemName.value.length >= 40) {
        window.Swal.fire({
            title: 'Sistem Adı 2 Karakterden Kısa 40 Karakterden Uzun Olamaz',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    }
    if (SysteTelephone.value == null) {
        window.Swal.fire({
            title: 'Telefon Numarasını Boş Geçemezsiniz',
            icon: 'error',
            showCancelButton: true,
            showConfirmButton: false,
            cancelButtonText: 'Tamam',
        });
        return;
    }
    
    Form.submit();
}