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
          searchResults: []
      };

      this.initialize = function () {
          this.getProducts();
      };

      this.getProducts = function () {
          $scope.loading = true;
          $http.get(domainUrl + 'api/products/test').
              success(function(data) {
                  $scope.viewModel.searchResults = data;
                  $scope.loading = false;
              }).
              error(function() {
                  alert('Error occured');
                  $scope.loading = false;
              });
      };

      this.initialize();
  });
