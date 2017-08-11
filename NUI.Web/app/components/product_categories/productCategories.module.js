﻿/// <reference path="E:\LẬP TRÌNH\2017\TeduShop\NUI\TeduShopCodeFirst2017\NUI.Web\Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('nuishop.product_categories', ['nuishop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('product_categories', {
            url: "/product_categories",
            templateUrl: "app/components/product_categories/productCategoryListView.html",
            controller: "productCategoryListController"
        });
    }
})();