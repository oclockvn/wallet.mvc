(function(){

    function walletService($http) {
        var self = {};

        self.getWallet = function() {
            console.log("item loading...");
            return $http.get(root + "wallet/info");
        };

        self.addItem = function(item) {
            // $http.post(root + "add-item", angular.toJson(item));

            console.log("item adding...");
            return $http.post(root + "wallet/item/add", angular.toJson(item));
        };

        self.markDone = function (doneItems) {
            // $http.post(root + "done", angular.toJson(doneItems));
        };

        self.removeItem = function (itemId) {
            return $http.post(root + "wallet/item/remove", { itemId: itemId });
        }

        return self;
    };

    angular.module("app")
        .factory("walletService", ["$http", walletService]);
})();