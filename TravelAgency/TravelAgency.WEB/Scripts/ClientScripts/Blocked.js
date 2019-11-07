$(document).ready(function () {
    redirect();
});
function redirectToAction() {
    window.location.href = '/Home/Index';
}
function redirect() {
setTimeout(redirectToAction, 7000);
}
