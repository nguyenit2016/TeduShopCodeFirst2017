/// <reference path="E:\LẬP TRÌNH\2017\TeduShop\NUI\TeduShopCodeFirst2017\NUI.Web\Assets/admin/libs/angular/angular.js" />

(function (app) {
    app.service('apiService', apiService);

    apiService.$inject = ['$http'];

    function apiService($http) {
        return {
            get: get
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