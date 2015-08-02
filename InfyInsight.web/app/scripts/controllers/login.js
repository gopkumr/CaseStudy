angular.module('infyapp')
  .controller('LoginCtrl', function($scope, $location) {

      $scope.submit = function() {

          $location.path('/dashboard/overview');

          return false;
      };

  });
