(function() {

    function itemController() {
        var self = this;
    }

    angular.module("app")
        .component("item", {
            templateUrl: "app/components/item/item.template.html",
            controller: [itemController],
            parent: "^^wallet",
            bindings: {
                data: "<"
            }
        });
})();