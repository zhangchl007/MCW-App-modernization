'use strict';
angular.module('policyConnect', ['ngRoute'])
.config(['$routeProvider', '$httpProvider', function ($routeProvider, $httpProvider) {

    $routeProvider.when('/PolicyHolder', {
                title: 'PolicyHolder - List',
                templateUrl: '/Static/PolicyHolder_List.html',
                controller: 'PolicyHolder_list',
                requireADLogin: true
            })
            .when('/PolicyHolder/Create', {
                title: 'PolicyHolder - Create',
                templateUrl: '/Static/PolicyHolder_Edit.html',
                controller: 'PolicyHolder_create',
                requireADLogin: true
            })
            .when('/PolicyHolder/Edit/:id', {
                title: 'PolicyHolder - Edit',
                templateUrl: '/Static/PolicyHolder_Edit.html',
                controller: 'PolicyHolder_edit',
                requireADLogin: true
            })
            .when('/PolicyHolder/Delete/:id', {
                title: 'PolicyHolder - Delete',
                templateUrl: '/Static/PolicyHolder_Delete.html',
                controller: 'PolicyHolder_delete',
                requireADLogin: true
            })
            .when('/PolicyHolder/:id', {
                title: 'PolicyHolder - Details',
                templateUrl: '/Static/PolicyHolder_Details.html',
                controller: 'PolicyHolder_details',
                requireADLogin: true
            })
            .when('/Policy', {
                title: 'Policy - List',
                templateUrl: '/Static/Policy_List.html',
                controller: 'Policy_list',
                requireADLogin: true
            })
            .when('/Policy/Create', {
                title: 'Policy - Create',
                templateUrl: '/Static/Policy_Edit.html',
                controller: 'Policy_create',
                requireADLogin: true
            })
            .when('/Policy/Edit/:id', {
                title: 'Policy - Edit',
                templateUrl: '/Static/Policy_Edit.html',
                controller: 'Policy_edit',
                requireADLogin: true
            })
            .when('/Policy/Delete/:id', {
                title: 'Policy - Delete',
                templateUrl: '/Static/Policy_Delete.html',
                controller: 'Policy_delete',
                requireADLogin: true
            })
            .when('/Policy/:id', {
                title: 'Policy - Details',
                templateUrl: '/Static/Policy_Details.html',
                controller: 'Policy_details',
                requireADLogin: true
            })
            .when('/Person', {
                title: 'Person - List',
                templateUrl: '/Static/Person_List.html',
                controller: 'Person_list',
                requireADLogin: true
            })
            .when('/Person/Create', {
                title: 'Person - Create',
                templateUrl: '/Static/Person_Edit.html',
                controller: 'Person_create',
                requireADLogin: true
            })
            .when('/Person/Edit/:id', {
                title: 'Person - Edit',
                templateUrl: '/Static/Person_Edit.html',
                controller: 'Person_edit',
                requireADLogin: true
            })
            .when('/Person/Delete/:id', {
                title: 'Person - Delete',
                templateUrl: '/Static/Person_Delete.html',
                controller: 'Person_delete',
                requireADLogin: true
            })
            .when('/Person/:id', {
                title: 'Person - Details',
                templateUrl: '/Static/Person_Details.html',
                controller: 'Person_details',
                requireADLogin: true
            })
            .when('/Dependent', {
                title: 'Dependent - List',
                templateUrl: '/Static/Dependent_List.html',
                controller: 'Dependent_list',
                requireADLogin: true
            })
            .when('/Dependent/Create', {
                title: 'Dependent - Create',
                templateUrl: '/Static/Dependent_Edit.html',
                controller: 'Dependent_create',
                requireADLogin: true
            })
            .when('/Dependent/Edit/:id', {
                title: 'Dependent - Edit',
                templateUrl: '/Static/Dependent_Edit.html',
                controller: 'Dependent_edit',
                requireADLogin: true
            })
            .when('/Dependent/Delete/:id', {
                title: 'Dependent - Delete',
                templateUrl: '/Static/Dependent_Delete.html',
                controller: 'Dependent_delete',
                requireADLogin: true
            })
            .when('/Dependent/:id', {
                title: 'Dependent - Details',
                templateUrl: '/Static/Dependent_Details.html',
                controller: 'Dependent_details',
                requireADLogin: true
            }).otherwise({ redirectTo: '/Static/PolicyHolder_List.html' });

        var endpoints = {
        // Map the location of a request to an API to a the identifier of the associated resource
        "https://contosoinsapijjbp34uowoybc.azurewebsites.net/": contoso.policyconnect.vars.webApiAppId
    };
}]);
