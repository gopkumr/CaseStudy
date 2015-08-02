'use strict';

/**
 * @ngdoc function
 * @name yapp.controller:MainCtrl
 * @description
 * # MainCtrl
 * Controller of yapp
 */
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
          searchText:''
      };

      this.initialize = function () {
          $scope.getProducts();

          angular.element('#productDetailsModal').on('shown.bs.modal', function () {
              
          });
      };

      $scope.getProducts = function () {
          $scope.loading = true;
          $http.get(domainUrl + 'api/products/10').
              success(function(data) {
                  $scope.viewModel.searchResults = data;
                  $scope.loading = false;
              }).
              error(function() {
                  alert('Error occured');
                  $scope.loading = false;
              });
      };

      $scope.AddItemToCart = function(productId) {
          if ($scope.viewModel.cartId == '') {
              $http.get(domainUrl + 'api/orders').
                  success(function(data) {
                      $scope.viewModel.cartId = data;
                      $scope.loading = false;
                      $scope.AddItem(productId);
                  }).
                  error(function() {
                      alert('Error occured');
                      $scope.loading = false;
                  });
          } else {
              $scope.AddItem(productId);
          }
      };

      $scope.AddItem = function (productId) {
          $http.patch(domainUrl + 'api/orders/' + $scope.viewModel.cartId + '?productId=' + productId + '&quantity=1').
              success(function (data) {
                  $scope.viewModel.itemsInCart = data.Items.length;
                  $scope.viewModel.cart = data;
                  $scope.loading = false;
              }).
              error(function () {
                  alert('Error occured');
                  $scope.loading = false;
              });
      };
      
      $scope.SelectItem = function (product) {
          $scope.viewModel.selectedItem = product;
      };
      
      $scope.SearchItem = function () {
          if ($scope.viewModel.searchText == '') {
              this.getProducts();
          } else {
              $http.get(domainUrl + 'api/products/' + $scope.viewModel.searchText).
              success(function (data) {
                  $scope.viewModel.searchResults = data;
                  $scope.loading = false;
              }).
              error(function () {
                  alert('Error occured');
                  $scope.loading = false;
              });
          }
      };

      $scope.CheckOut = function () {
          $http.post(domainUrl + 'api/orders/' + $scope.viewModel.cartId).
              success(function () {
                  alert('success');
              }).
              error(function () {
                  alert('Error occured');
                  $scope.loading = false;
              });
      };
      
      

      this.initialize();
  });
