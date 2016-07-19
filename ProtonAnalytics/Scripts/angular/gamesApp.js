'use strict';

var gamesApp = angular.module('gamesApp', ['ngResource'])
    .controller("GamesListController", function ($resource) {
        var gamesList = this;

        $resource('api/Game/GetAll', {}).query().$promise.then(function (results) {
            console.log("GOT YER RESOURCEZ: " + results.length);
            gamesList.games = results;
        })
    });