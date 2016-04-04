angular.module("bikeServices", ["ngResource"])
    .factory('Bike', ["$resource", function (resource) {
        return resource("/api/bike/:id");
    }])
    .factory('Model', ["$resource", function (resource) {
        return resource("/api/lookup").get();
    }]);