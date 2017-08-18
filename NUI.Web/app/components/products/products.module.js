/// <reference path="E:\LẬP TRÌNH\2017\TeduShop\NUI\TeduShopCodeFirst2017\NUI.Web\Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('nuishop.products', ['nuishop.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('products', {
                url: "/products",
                parent: 'base',
                templateUrl: "/app/components/products/productListView.html",
                controller: "productListController"
            }).state('product_add', {
                url: "/product_add",
                parent: 'base',
                templateUrl: "/app/components/products/productAddView.html",
                controller: "productAddController"
            }).state('product_edit', {
                url: "/product_edit/:id",
                parent: 'base',
                templateUrl: "/app/components/products/productEditView.html",
                controller: "productEditController"
            });
    }
})();