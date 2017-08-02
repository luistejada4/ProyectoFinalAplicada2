var app = angular.module("App", []);

app.controller("EventosController", function ($scope, $http) {

    $scope.eventos = [];



    var getEventos = function () {

        $http.get("/api/Eventos/ ").then(

            function (response) {

               alert(response.data[0].descripcion);

            }, function (response) {

                console.log(response.error);

            });
    };



    getEventos();
    alert($scope.eventos.length);


});
