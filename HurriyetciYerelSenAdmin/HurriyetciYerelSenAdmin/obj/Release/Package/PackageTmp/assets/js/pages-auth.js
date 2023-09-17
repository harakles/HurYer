
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