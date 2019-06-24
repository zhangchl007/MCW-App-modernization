 var  modules = modules || [];
(function () {
    'use strict';
    var rootPath = contoso.policyconnect.vars.rootPath;

    angular.module('policyConnect')
        .controller('People', ['$scope', '$http', function ($scope, $http) {
            $http.defaults.useXDomain = true;
            delete $http.defaults.headers.common['X-Requested-With'];

            $http.get(rootPath + '/api/people/')
                .then(function (response) { $scope.data = response.data; });
        }])
        .controller('Person', ['$scope', '$http', '$routeParams', function ($scope, $http, $routeParams) {
            $http.defaults.useXDomain = true;
            delete $http.defaults.headers.common['X-Requested-With'];

            $http.get(rootPath + '/api/people/' + $routeParams.id)
                .then(function (response) { $scope.data = response.data; });
        }]);
})();