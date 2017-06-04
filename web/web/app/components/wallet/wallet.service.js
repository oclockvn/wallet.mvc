(function(){

    function walletService($http) {
        var self = {};

        self.getWallet = function() {
            console.log("item loading...");
            return $http.get(root + "wallet/info");
        };

        self.addItem = function(item) {            
            console.log("item adding...", item);
            return $http.post(root + "wallet/item/add", angular.toJson(item));
        };

        self.removeItem = function (itemId) {
            console.log("delete item", itemId);
            return $http.post(root + "wallet/item/remove", { itemId: itemId });
        }

        self.doneItem = function (itemIds) {
            console.log("done item", itemIds);
            return $http.post(root + "wallet/item/done", { itemIds: itemIds });
        }

        self.undoneItem = function (itemId) {
            console.log("undone item", itemId);
            return $http.post(root + "wallet/item/undone", { itemId: itemId });
        }

        return self;
    };

    angular.module("app")
        .factory("walletService", ["$http", walletService]);
})();