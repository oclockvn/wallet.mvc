(function () {

    function walletController() {
        var self = this;

        self.$onInit = function () {
            self.items = [1,2,3,4,5,6,7,8];
        };
    }
    angular.module("app")
        .component("wallet", {
            templateUrl: "app/components/wallet/wallet.template.html",
            controller: [walletController]
        });
})();