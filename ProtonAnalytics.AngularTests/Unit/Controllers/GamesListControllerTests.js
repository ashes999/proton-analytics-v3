// For reference: https://github.com/mmanela/chutzpah/blob/master/Samples/Angular/TemplateDirective/chutzpah.json

describe("Hello World test suite", function() {
    describe("Math tests", function() {
        it('2^3 = 8', function() {
            expect(Math.pow(2, 3)).toEqual(8);
        });
    });
});

describe('GamesListController', function() {
    
    var $httpBackend, $controller, $resource;

    beforeEach(module('gamesApp'));
    
    // The injector unwraps the underscores (_) from around the parameter names when matching
    beforeEach(inject(function ($injector, _$controller_, _$resource_) {
        $httpBackend = $injector.get('$httpBackend');
        $resource = _$resource_;
        $controller = _$controller_;
        return null;
    }));

    describe('gamesApp unit tests', function() {
        it('gets all games from gamesListResource', function () {

            var expectedGame = {
                Id: "B2B0DBFB-DF48-4D94-A360-47A1415E8618",
                Name: "Super Mario Brozers",
                OwnerId: "another-fake-guid-here"
            };

            $httpBackend.expectGET("api/Game/GetAll").respond([expectedGame]);

            $controller('GamesListController', {
                $resource: $resource
            });

            $httpBackend.flush();
            
            var actualGames = $controller.games;
            expect(actualGames.length).toEqual(1);
            expect(actualGames[0]).toEqual([mockGame]);
        });
    });
});