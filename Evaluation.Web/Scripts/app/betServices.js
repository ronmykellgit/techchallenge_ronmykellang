var betServices = angular.module('betServices', ['ngResource']);

betServices
    .factory('betService', ['$resource',
        function ($resource) {
            var service = {};

            // makes a restful get to web api to get bets 
            service.getBets = function (pageInfo) {
                return $resource(
                    '/api/bet/customerBets',
                    {
                        sortBy: pageInfo.sortBy,
                        isAscending: pageInfo.isSortAscending,
                    },
                ).get()
            }
            return service;
    }]);
