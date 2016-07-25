'use strict';

var gamesApp = angular.module('gamesApp', ['ngResource'])
    .controller("GamesListController", function ($resource) {
        var gamesList = this;

        $resource('api/Game/GetAll', {}).query().$promise.then(function (results) {
            gamesList.games = results;
        })
    });