﻿var multiDBApp = angular.module('multiDBApp', []);

multiDBApp.controller('multiController', function ($scope,$http) {

    
    $scope.todas = [];
    
    $scope.addColumn = function () {
        $scope.todas.push({ name: $scope.Cname, type: $scope.Ctype, length: $scope.Clength });
  
    };

  
    $scope.createTable = function ()     {

        
       
    
        var json = JSON.stringify($scope.todas);

        $http.post('../App/HttpCreateTable?cID=' + $scope.cID + '&name=' + $scope.name + '&columns=' + json,
            { data: {} })
        .success(function (data, status, headers, config) {
            alert("Listo! Parece que todo salió bien");
        })
        .error(function (data, status, headers, config) {
            alert("Ups! Hubo un error en la solicitud REST");
            
        });
       
    }
    $scope.includeDB = function ()      {

        shuffle_b(false);

        $http.post('../App/HttpIncludeDB?db_type=' + $scope.db_type + '&username=' + $scope.username
            + '&pass=' + $scope.pass + '&server=' + $scope.server + '&protocol=' + $scope.protocol
            + '&port=' + $scope.port + '&alias=' + $scope.alias,
            { data: {} })
        .success(function (data, status, headers, config) {
         
            shuffle_b(true);
            alert(data);
            
           
        })
        .error(function (data, status, headers, config) {
            shuffle_b(true);
            alert("Ups! Hubo un error en la solicitud REST");

        });

        

       
    }
    $scope.createDB = function () {

        $http.post('../App/HttpCreateDB?cID=' + $scope.cID + '&db_name=' + $scope.db_name,
            { data: {} })
        .success(function (data, status, headers, config) {

            alert("Listo! Parece que todo salió bien");
        })
        .error(function (data, status, headers, config) {
            alert("Ups! Hubo un error en la solicitud REST");

        });
    }
    $scope.deleteTable = function () {

        var json = JSON.stringify($scope.todas);

        $http.post('../App/HttpDeleteTable?cID=' + $scope.cID + '&table_name=' + $scope.name ,
            { data: {} })
        .success(function (data, status, headers, config) {
            alert("Listo! Parece que todo salió bien");
        })
        .error(function (data, status, headers, config) {
            alert("Ups! Hubo un error en la solicitud REST");

        });

    }
      
}).config(function ($httpProvider) {
    $httpProvider.defaults.headers.post = {};
    $httpProvider.defaults.headers.post["Content-Type"] = "application/json; charset=utf-8";
});

