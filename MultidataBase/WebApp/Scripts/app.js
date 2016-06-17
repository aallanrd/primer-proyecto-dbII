var multiDBApp = angular.module('multiDBApp', []);

multiDBApp.controller('multiController', function ($scope,$http) {

   // 

    $scope.todas = [];
    $scope.valoresI = [];
    $scope.valoresU = [];
    $scope.valoresD = [];
    $scope.Querys = [];
    $scope.CO = [];
 
    $scope.id;
    $scope.myText;
    //var j = $location.search().id;


   

    $scope.addColumn = function () {
        $scope.todas.push({ name: $scope.Cname, type: $scope.Ctype, length: $scope.Clength });
  
    };


    $scope.addValueTable = function () {
        $scope.valoresI.push({ Vcol: $scope.vCol, Vval: $scope.Vval });

    };


    $scope.addValueI = function () {
        $scope.valoresI.push({ Vcol: $scope.Vcol, Vval: $scope.Vval });

    };


    $scope.addValueU = function () {
        $scope.valoresU.push({ Vcol: $scope.Vcol, Vval: $scope.Vval });

    };

    $scope.addValueD = function () {
        $scope.valoresD.push({ Vcol: $scope.Vcol, Vval: $scope.Vval });

    };
  
    $scope.addQuery = function () {
        $scope.Querys.push({ _cName: $scope._cName, _table: $scope._table });

    };

  

    $scope.includeDB = function () {

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

        alert($scope.cID);
        alert($scope.db_name);

        $http.post('../App/HttpCreateDB?cID=' + $scope.cID + '&db_name=' + $scope.db_name,
            { data: {} })
        .success(function (data, status, headers, config) {

            alert(data);
        })
        .error(function (data, status, headers, config) {
            alert("Ups! Hubo un error en la solicitud REST");

        });
    }
    

    $scope.createTable = function () {


        var json = JSON.stringify($scope.todas);

        $http.post('../App/HttpCreateTable?cID=' + $scope.cID + '&name=' + $scope.name + '&columns=' + json,
            { data: {} })
        .success(function (data, status, headers, config) {
            alert(data);
        })
        .error(function (data, status, headers, config) {
            alert(data);
            
        });
       
    }     
    $scope.deleteTable = function () {

        var json = JSON.stringify($scope.todas);

        $http.post('../App/HttpDeleteTable?cID=' + $scope.cID + '&table_name=' + $scope.name ,
            { data: {} })
        .success(function (data, status, headers, config) {
            alert(data);
        })
        .error(function (data, status, headers, config) {
            alert("Ups! Hubo un error en la solicitud REST");

        });

    }
    $scope.insertValuesTable = function () {


        var json = JSON.stringify(this.valoresI);

        $http.post('../App/HttpInsertValueTable?cID=' + $scope.cID + '&table_name=' + $scope.name +
            '&values=' + json,
            { data: {} })
        .success(function (data, status, headers, config) {
            alert(data);
        })
        .error(function (data, status, headers, config) {
            alert(data);

        });
    }
    $scope.updateValuesTable = function () {


            var json = JSON.stringify($scope.valores);

            $http.post('../App/HttpUpdateValuesTable?cID=' + $scope.cID + '&table_name=' + $scope.name +
                '&values=' + json,
                { data: {} })
            .success(function (data, status, headers, config) {
                alert("Listo! Parece que todo salió bien");
            })
            .error(function (data, status, headers, config) {
                alert("Ups! Hubo un error en la solicitud REST");

            });

        };
    $scope.deleteValuesTable = function () {


            var json = JSON.stringify($scope.valores);

            $http.post('../App/HttpDeleteValuesTable?cID=' + $scope.cID + '&table_name=' + $scope.name +
                '&values=' + json,
                { data: {} })
            .success(function (data, status, headers, config) {
                alert("Listo! Parece que todo salió bien");
            })
            .error(function (data, status, headers, config) {
                alert("Ups! Hubo un error en la solicitud REST");

            });
    };
    $scope.queryAll = function () {


            var json = JSON.stringify($scope.Querys);

        $http.post('../App/HttpQuery?cID=' + $scope.cID +
            '&querys=' + json + '&order_by=' + $scope.order_by + '&join_on=' + $scope.join_on,
               
                { data: {} })
            .success(function (data, status, headers, config) {
                alert(data);
            })
            .error(function (data, status, headers, config) {
                alert("Ups! Hubo un error en la solicitud REST");

            });

    };

    $scope.getConnections = function () {

       // $scope.connections = [];
        $http.post('../App/HttpGetConnections',

                { data: {} })
            .success(function (data, status, headers, config) {
               // alert(data);
                $scope.connections =  JSON.parse(data);
            })
            .error(function (data, status, headers, config) {
                alert("Ups! Hubo un error en la solicitud REST");

            });

    };

    $scope.deleteFromServer = function () {

        // $scope.connections = [];
        $http.post('../App/HttpDeleteFromServer?id=' + this.myText,

                { data: {} })
            .success(function (data, status, headers, config) {
                alert(data);
                $scope.connections = JSON.parse(data);
            })
            .error(function (data, status, headers, config) {
                alert(data);
                //alert("Ups! Hubo un error en la solicitud REST");

            });

    };

}).config(function ($httpProvider) {
    $httpProvider.defaults.headers.post = {};
    $httpProvider.defaults.headers.post["Content-Type"] = "application/json; charset=utf-8";
});

