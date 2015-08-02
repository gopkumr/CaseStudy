angular.module('yapp')
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
          loading:false
      };

      this.initialize = function () {
          $scope.getProducts();

          angular.element('#productDetailsModal').on('shown.bs.modal', function () {
              
          });
      };

      $scope.getProducts = function () {
          $scope.viewModel.loading = true;
          $http.get(domainUrl + 'api/products/10').
              success(function(data) {
                  $scope.viewModel.searchResults = data;
                  $scope.viewModel.loading = false;
              }).
              error(function() {
                  alert('Error occured');
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
                      alert('Error occured');
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
              }).
              error(function () {
                  alert('Error occured');
                  $scope.viewModel.loading = false;
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
                  alert('Error occured');
                  $scope.viewModel.loading = false;
              });
          }
      };

      $scope.CheckOut = function () {
          $scope.viewModel.loading = true;
          $http.post(domainUrl + 'api/orders/' + $scope.viewModel.cartId).
              success(function () {
                  alert('success');
                  $scope.viewModel.cart = {};
                  $scope.viewModel.itemsInCart = 0;
                  $scope.viewModel.loading = false;
              }).
              error(function () {
                  alert('Error occured');
                  $scope.viewModel.loading = false;
              });
      };
      
      

      this.initialize();
  });
