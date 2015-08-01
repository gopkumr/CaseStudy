angular.module('yapp')
    .controller('AddProductController', function ($scope, $state, $http) {
        var domainUrl = 'http://localhost:21506/';
        $scope.$state = $state;
        $scope.viewModel = {
            products:[],
            productDetails: {
                productId:'',
                shortdescription: '',
                longdescription: '',
                price: '',
                inventory: ''
            },
            itemSelected: false,
            selectedItemName:'Select existing item'
        };

        $scope.save = function() {
            var req = {
                method: 'POST',
                url: domainUrl+'api/products',
                headers: {
                    'Content-Type': 'application/json'
                },
                data: $scope.viewModel.productDetails
            };

            $http(req).success(function() { alert('success'); }).error(function(data) {
                alert(data);
            });
        };
        
        $scope.update = function () {
            var req = {
                method: 'PATCH',
                url: domainUrl + 'api/products',
                headers: {
                    'Content-Type': 'application/json'
                },
                data: $scope.viewModel.productDetails
            };

            $http(req).success(function () { alert('success'); }).error(function (data) {
                alert(data);
            });
        };

        $scope.selectProduct = function (product) {
            $scope.viewModel.productDetails.shortdescription = product.ShortDescription;
            $scope.viewModel.productDetails.longdescription = product.LongDescription;
            $scope.viewModel.productDetails.inventory = product.Inventory;
            $scope.viewModel.productDetails.price = product.Price;
            $scope.viewModel.productDetails.productId = product.ProductId;
            $scope.viewModel.itemSelected = true;
            $scope.viewModel.selectedItemName = product.ShortDescription;
        };

        this.initialize = function() {
            $http.get(domainUrl + 'api/products/0').
             success(function (data) {
                 $scope.viewModel.products = data;
                 $scope.loading = false;
             }).
             error(function () {
                 alert('Error occured');
                 $scope.loading = false;
             });
        };

        this.initialize();
    });