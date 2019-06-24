var modules = modules || [];
var contoso = contoso || {};
(function () {
    'use strict';
    var rootPath = contoso.policyconnect.vars.rootPath;
    // TODO: Need to get where this is set, and update to the Function App, not Functions proxy. Should be the same, but rename...
    var proxyPath = contoso.policyconnect.vars.azureFunctionsProxyUrl;

    angular.module('policyConnect')
        .controller('PolicyHolders',
            [
                '$scope', '$http', function ($scope, $http) {
                    $http.defaults.useXDomain = true;
                    delete $http.defaults.headers.common['X-Requested-With'];
                    $http.get(rootPath + '/api/policyholders/')
                        .then(function (response) {
                            if (response.statusCode === 401) {
                                alert('Authentication failed. You need to sign in first!');
                            }
                            $scope.data = response.data;
                        });
                }
            ])
        .controller('PolicyHolder',
            [
                '$scope', '$http', '$routeParams', function ($scope, $http, $routeParams) {
                    $http.defaults.useXDomain = true;
                    delete $http.defaults.headers.common['X-Requested-With'];
                    $scope.data = {};
                    $http.get(rootPath + '/api/policyholders/' + $routeParams.id)
                        .then(function (response) {
                            $scope.data = response.data;
                            $scope.azureFunctionsProxyUrl = proxyPath.replace("{policyHolder}", $scope.data.person.lName).replace("{policyNumber}", $scope.data.policyNumber);
                        });
                }
            ]);
})();