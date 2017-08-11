/// <reference path="E:\LẬP TRÌNH\2017\TeduShop\NUI\TeduShopCodeFirst2017\NUI.Web\Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('nuishop', [
        'nuishop.product_categories',
        'nuishop.products',
        'nuishop.common'
    ]).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('home', {
            url: "/admin",
            templateUrl: "app/components/home/homeView.html",
            controller: "homeController"
        });
        $urlRouterProvider.otherwise('/admin');
    }
})();