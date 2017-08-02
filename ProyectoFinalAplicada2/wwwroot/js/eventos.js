var app = angular.module("App", []);

app.controller("EventosController", function ($scope, $http, $window) {

    $scope.eventos = [];
    $scope.master = true;

    var getEventos = function () {

        $http.get("/api/Eventos/").then(

            function (response) {

                $scope.eventos = response.data;
                

            }, function (response) {

                console.log(response.error);

            });
    };


    $scope.eventoClicked = function (cliente) {

        alert("Hola");
        $window.location.href = '/eventos/details/' + cliente.id;
    };



    getEventos();


});
