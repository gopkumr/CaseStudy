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
          itemsInCart:0
      };

      this.initialize = function () {
          this.getProducts();
      };

      this.getProducts = function () {
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
                  $scope.loading = false;
              }).
              error(function () {
                  alert('Error occured');
                  $scope.loading = false;
              });
      };
      
      this.initialize();
  });
