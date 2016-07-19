'use strict';

var gamesApp = angular.module('gamesApp', ['ngResource'])
    // Inject pre-created resources, not $resource directly
    .factory('gamesListResource', function ($resource) {
        return $resource('api/Game/GetAll');
    })

    // Actual controller
    .controller("GamesListController", function (gamesListResource) {
        var gamesList = this;

        console.log("Constructor started (list resource = " + gamesListResource + ") ...");
        // Make sure you're querying api/Game/GetAll
        gamesListResource.query().$promise.then(function (results) {
            gamesList.games = results;
            console.log("Got some games: " + JSON.stringify(results));
        })
        console.log("... done!");
    });