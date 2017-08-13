/// <reference path="E:\LẬP TRÌNH\2017\TeduShop\NUI\TeduShopCodeFirst2017\NUI.Web\Assets/admin/libs/angular/angular.js" />

(function (app) {
    app.service('apiService', apiService);

    apiService.$inject = ['$http', 'notificationService'];

    function apiService($http, notificationService) {
        return {
            get: get,
            post: post
        }
        function post(url, data, successed, failed) {
            $http.post(url, data).then(function (result) {
                successed(result);
            }, function (error) {
                console.log(error.status);
                if (error.status === 401) {
                    notificationService.displayError('Yêu cầu đăng nhập');
                }
                else if (failed != null) {
                    failed(error);
                }
            });
        }
        function get(url, params, successed, failed) {
            $http.get(url, params).then(function (result) {
                successed(result);
            }, function (error) {
                failed(error);
            });
        }
    }
})(angular.module('nuishop.common'));