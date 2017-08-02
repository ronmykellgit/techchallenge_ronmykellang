var betControllers = angular.module('betControllers', []);

betControllers.controller('betController',
    ['$scope', '$http', 'betService',
        function ($scope, $http, betService) {

            // pagination related properties
            $scope.pageInfo = new function() {
                this.totalItems = 0;
                this.sortBy = 'customerName';
                this.isSortAscending = 'true';
            }

            $scope.table = $('#customer-bet');
            
            // event when change sorting of table
            $scope.sort = function (sortBy) {
                $scope.table.block({ message: 'loading' });
                if (sortBy === $scope.pageInfo.sortBy) {
                    $scope.pageInfo.isSortAscending = !$scope.pageInfo.isSortAscending;
                } else {
                    $scope.pageInfo.sortBy = sortBy;
                    $scope.pageInfo.isSortAscending = 'true';
                }
                loadBets();
            };

            // calls betService to get bets
            function loadBets() {
                $scope.users = null;
                betService
                    .getBets($scope.pageInfo)
                    .$promise.then(function (result) {
                        $scope.bets = result.data;
                        $scope.pageInfo.totalItems = result.totalCount;
                        $scope.table.unblock();
                    });
            }

            // initial table load
            loadBets();
        }]
);
