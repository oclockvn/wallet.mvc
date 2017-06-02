(function() {

    function itemController(scope) {
        var self = this;

        // self.UnDone = function() {
        //     self.data.done = false;
        // };
    }

    angular.module("app")
        .component("item", {
            templateUrl: "app/components/item/item.template.html",
            controller: ['$scope', itemController],
            parent: "^^wallet",
            bindings: {
                data: "<",
                toggleItem: "&",
                unDone: "&"
            }
        });
})();