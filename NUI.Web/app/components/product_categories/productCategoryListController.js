﻿(function (app) {
    app.controller('productCategoryListController', productCategoryListController);

    productCategoryListController.$inject = ['$scope', 'apiService', 'notificationService'];

    function productCategoryListController($scope, apiService, notificationService) {
        $scope.productCategories = [];

        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.keyword = '';

        $scope.getProductCategories = getProductCategories;
        $scope.search = search;
        $scope.keyPressed = keyPressed;

        function search() {
            getProductCategories();
        }
        function keyPressed() {
            getProductCategories();
        }

        function getProductCategories(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 2
                }
            }

            apiService.get('/api/productcategory/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có dữ liệu');
                }
                //else {
                //    notificationService.displaySuccess('Đã tìm thấy tổng số ' + result.data.TotalCount + ' bản ghi');
                //}
                $scope.productCategories = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log('Load product category failed.');
            });
        }

        $scope.getProductCategories();
    }
})(angular.module('nuishop.product_categories'));