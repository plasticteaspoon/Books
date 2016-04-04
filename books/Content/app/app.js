// app.js
var bikesApp = angular.module('bikesApp', ['ui.router', "bikeServices"]);

bikesApp.config(function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise('/home');

    $stateProvider

        // HOME STATES AND NESTED VIEWS ========================================
        .state('home', {
            url: '/home',
            templateUrl: '/content/app/html/home.html'
        })

        // nested list with custom controller
        .state('home.list', {
            url: '/list',
            templateUrl: '/content/app/html/home-list.html',
            controller: function ($scope) {
                $scope.dogs = ['Bernese', 'Husky', 'Goldendoodle'];
            }
        })

        // nested list with just some random string data
        .state('home.paragraph', {
            url: '/paragraph',
            template: 'I could sure use a drink right now.'
        })

        // RIDER PAGE =================================

        .state('riderList', {
            url: '/riderList',
            templateUrl: '/content/app/html/rider-list.html',
            controller: 'riderListController'
        })

        // BIKE PAGE =================================

        .state('bikeList', {
            url: '/bikeList',
            templateUrl: '/content/app/html/bike-list.html',
            controller: 'bikeListController'
        })

        .state('bikeEdit', {
            url: '/bike/:id/Edit',
            templateUrl: '/content/app/html/bike-edit.html',
            controller: 'bikeEditController'
        });
});

bikesApp.controller('bikeListController', ["$scope", "Model", function (scope, model) {
    scope.model = model;
}]);

bikesApp.controller('riderListController', ["$scope", "Model", function (scope, model) {
    scope.model = model;
}]);

bikesApp.controller('bikeEditController', ["$scope", "$state", "$stateParams", "Bike", function (scope, state, stateParams, Bike) {
    scope.bike = Bike.get({id: stateParams.id});
    scope.saveForm = function () {
        scope.bike.$update(function () {
            state.go("bikeList");
        });
    };
}]);