angular.module('yapp')
    .controller('AddProductController', function ($scope, $state, $http) {
        var domainUrl = 'http://localhost:21506/';
        $scope.$state = $state;
        $scope.viewModel = {
            productDetails: {
                shortdescription: '',
                longdescription: '',
                price: '',
                inventory: ''
            }
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
    });