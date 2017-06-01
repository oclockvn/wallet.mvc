(function () {

    function walletController() {
        var self = this;

        self.$onInit = function () {
            self.items = [];
            for (var i = 0; i < 10; i++) {
                var sign = i % 2 === 0 ? 1 : -1;
                self.items.push({
                    id: i,
                    money: i * Math.random() * 100000 * sign,
                    date: new Date(),
                    note: "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Eligendi quam deleniti, quos, tempore laboriosam atque dolores",
                    done: false        
                });
            }
        };
    }
    angular.module("app")
        .component("wallet", {
            templateUrl: "app/components/wallet/wallet.template.html",
            controller: [walletController]
        });
})();