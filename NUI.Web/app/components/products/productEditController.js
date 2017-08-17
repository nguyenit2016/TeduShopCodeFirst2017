(function (app) {
    app.controller('productEditController', productEditController);

    productEditController.$inject = ['$scope', 'apiService', 'notificationService', '$state', '$stateParams', 'commonService'];

    function productEditController($scope, apiService, notificationService, $state, $stateParams, commonService) {
        $scope.product = {
            UpdatedDate: new Date()
        }
        $scope.moreImages = [];

        $scope.UpdateProduct = UpdateProduct;
        $scope.GetSeoTitle = GetSeoTitle;
        $scope.ckeditorOptions = {
            language: 'vi',
            height: '200px'
        }
        $scope.ChooseImage = ChooseImage;
        $scope.ChooseMoreImage = ChooseMoreImage;

        function ChooseMoreImage() {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.moreImages.push(fileUrl);
                })
            }
            finder.popup();
        }

        function LoadProductDetail() {
            apiService.get('api/product/getbyid/' + $stateParams.id, null, function (result) {
                $scope.product = result.data;
                $scope.moreImages = JSON.parse($scope.product.MoreImages);
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function ChooseImage() {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.product.Images = fileUrl;
                })
            }
            finder.popup();
        }

        function GetSeoTitle() {
            $scope.product.Alias = commonService.getSeoTitle($scope.product.Name);
        }

        function UpdateProduct() {
            $scope.product.MoreImages = JSON.stringify($scope.moreImages);
            apiService.put('api/product/update', $scope.product, function (result) {
                notificationService.displaySuccess(result.data.Name + ' đã được cập nhật.');
                $state.go('products');
            }, function () {
                notificationService.displayError('Cập nhật chưa thành công.');
            });
        }

        function loadProductCategory() {
            apiService.get('api/productcategory/getallparents', null, function (result) {
                $scope.productCategories = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }


        loadProductCategory();
        LoadProductDetail();
    }
})(angular.module('nuishop.products'));