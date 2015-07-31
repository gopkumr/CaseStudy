'use strict';

/**
 * @ngdoc overview
 * @name yapp
 * @description
 * # yapp
 *
 * Main module of the application.
 */
angular.module('yapp', ['ui.router','ngAnimate'])
  .config(function($stateProvider, $urlRouterProvider) {

      $urlRouterProvider.when('/home', '/dashboard/overview');
      $urlRouterProvider.when('/home/index', '/dashboard/overview');
      $urlRouterProvider.when('', '/dashboard/overview');
    
      $stateProvider
          .state('base', {
              abstract: true,
              url: '',
              templateUrl: '/app/views/base.html'
          })
          .state('login', {
              url: '/login',
              parent: 'base',
              templateUrl: '/app/views/login.html',
              controller: 'LoginCtrl'
          })
          .state('dashboard', {
              url: '/dashboard',
              parent: 'base',
              templateUrl: '/app/views/dashboard.html',
              controller: 'DashboardCtrl'
          })
          .state('overview', {
              url: '/overview',
              parent: 'dashboard',
              templateUrl: '/app/views/dashboard/overview.html'
          })
          .state('storelocator', {
              url: '/storelocator',
              parent: 'dashboard',
              templateUrl: '/app/views/dashboard/storelocator.html'
          });

  });
