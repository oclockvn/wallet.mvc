(function(){

    function walletService($http) {
        var self;

        return self;
    }

    angular.module("app")
        .factory("walletService", ["$http", walletService]);
})();