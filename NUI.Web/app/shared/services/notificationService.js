(function (app) {
    app.factory('notificationService', notificationService);

    function notificationService() {
        toastr.options = {
            "debug": false,
            "positionClass": "toast-bottom-right",
            "onclick": null,
            "fadeIn": "300",
            "fadeOut": "1000",
            "timeOut": "3000",
            "extendedTimeOut": "1000",
        };

        function displaySuccess(message) {
            toastr.success(message);
        }
        function displayWarning(message) {
            toastr.warning(message);
        }
        function displayError(error) {
            if (Array.isArray(error)) {
                error.each(function (err) {
                    toastr.error(err);
                });
            }
            else {
                toastr.error(error);
            }
        }

        return {
            displaySuccess: displaySuccess,
            displayWarning: displayWarning,
            displayError: displayError
        }
    }
})(angular.module('nuishop.common'));