angular.module('infyapp')
  .controller('DashboardCtrl', function($scope, $state, $http) {
      var domainUrl = 'http://localhost:21506/';
      $scope.$state = $state;
      $scope.viewModel = {
          searchResults: [],
          cartId: '',
          itemsInCart: 0,
          cart: {},
          selectedItem: {},
          searchText: '',
          loading: false,
          
          isSuccess: false,
          isError: false,
          successMessage: '',
          errorMessage: ''
      };

      this.initialize = function () {
          $scope.getProducts();
          $scope.viewModel.isSuccess = false;
          $scope.viewModel.isError = false;
      };

      $scope.getProducts = function () {
          $scope.viewModel.loading = true;
          $http.get(domainUrl + 'api/products/10').
              success(function(data) {
                  $scope.viewModel.searchResults = data;
                  $scope.viewModel.loading = false;
              }).
              error(function() {
                  $scope.showError('Error loading products');
                  $scope.viewModel.loading = false;
              });
      };

      $scope.AddItemToCart = function (productId) {
          
          if ($scope.viewModel.cartId == '') {
              $scope.viewModel.loading = true;
              $http.get(domainUrl + 'api/orders').
                  success(function(data) {
                      $scope.viewModel.loading = false;
                      $scope.viewModel.cartId = data;
                      $scope.AddItem(productId);
                  }).
                  error(function() {
                      $scope.showError('Error creating a cart');
                      $scope.viewModel.loading = false;
                  });
          } else {
              $scope.AddItem(productId);
          }
      };

      $scope.AddItem = function (productId) {
          $scope.viewModel.loading = true;
          $http.patch(domainUrl + 'api/orders/' + $scope.viewModel.cartId + '?productId=' + productId + '&quantity=1').
              success(function (data) {
                  $scope.viewModel.itemsInCart = data.Items.length;
                  $scope.viewModel.cart = data;
                  $scope.viewModel.loading = false;
                  $scope.showSuccess('Item added to cart successfully');
              }).
              error(function (data) {
                  $scope.viewModel.loading = false;
                  $scope.showError(data.ExceptionMessage);
              });
      };
      
      $scope.SelectItem = function (product) {
          $scope.viewModel.selectedItem = product;
      };
      
      $scope.SearchItem = function () {
          if ($scope.viewModel.searchText == '') {
              this.getProducts();
          } else {
              $scope.viewModel.loading = true;
              $http.get(domainUrl + 'api/products/' + $scope.viewModel.searchText).
              success(function (data) {
                  $scope.viewModel.searchResults = data;
                  $scope.viewModel.loading = false;
              }).
              error(function () {
                  $scope.showError('Error searching the products');
                  $scope.viewModel.loading = false;
              });
          }
      };

      $scope.CheckOut = function () {
          $scope.viewModel.loading = true;
          $http.post(domainUrl + 'api/orders/' + $scope.viewModel.cartId).
              success(function () {
                  $scope.showSuccess('Congratulations! You have successfully purchased the item.');
                  $scope.viewModel.cart = {};
                  $scope.viewModel.itemsInCart = 0;
                  $scope.viewModel.loading = false;
              }).
              error(function () {
                  $scope.showError('Error while sumitting order');
                  $scope.viewModel.loading = false;
              });
      };

      $scope.showSuccess = function(message) {
          $scope.viewModel.isSuccess = true;
          $scope.viewModel.isError = false;
          $scope.viewModel.successMessage = message;
          $scope.viewModel.errorMessage = '';

          window.setTimeout(function () {
              $scope.viewModel.isSuccess = false;
              $scope.viewModel.isError = false;
              $scope.$apply();
          }, 1500);
      };
      
      $scope.showError = function (message) {
          $scope.viewModel.isSuccess = false;
          $scope.viewModel.isError = true;
          $scope.viewModel.successMessage = '';
          $scope.viewModel.errorMessage = message;
          window.setTimeout(function () {
              $scope.viewModel.isSuccess = false;
              $scope.viewModel.isError = false;
          }, 2000);
      };
      

      this.initialize();
  });
