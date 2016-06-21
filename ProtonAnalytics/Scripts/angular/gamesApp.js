'use strict';

var gamesApp = angular.module('gamesApp', ['ngResource'])
    .controller("GamesListController", function($resource) {
        var gamesList = this;

        // $resource('data/events/:id', { id: '@id' }).get({ id: 1 });

        gamesList.games = [
            { "name": "first game" },
            { "name": "second game" }
        ];
    });