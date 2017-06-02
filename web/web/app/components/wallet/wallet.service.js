(function(){

    function walletService($http) {
        var self = {};

        self.getWallet = function() {
            console.log("item loading...");
            return $http.get(root + "wallet/items");

            //var items  = [];
            //for (var i = 0; i < 10; i++) {
            //    var sign = i % 2 === 0 ? 1 : -1;
            //    items.push({
            //        id: i,
            //        money: i * Math.random() * 100000 * sign,
            //        time: new Date(),
            //        note: "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Eligendi quam deleniti, quos, tempore laboriosam atque dolores",
            //        done: false,
            //        checked: false,
            //        active: true
            //    });
            //}

            //return items; 
        };

        self.addItem = function(item) {
            // $http.post(root + "add-item", angular.toJson(item));

            console.log("item adding...");
            return $http.post(root + "wallet/add", angular.toJson(item));
        };

        return self;
    };

    self.markDone = function(doneItems) {
        // $http.post(root + "done", angular.toJson(doneItems));
    };

    angular.module("app")
        .factory("walletService", ["$http", walletService]);
})();