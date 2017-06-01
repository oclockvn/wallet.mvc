(function () {

    function walletController() {
        var self = this;

        self.$onInit = function () {
            self.items = [];
            self.checkedItems = [];
            self.settings = {
                showDone: true
            };

            for (var i = 0; i < 10; i++) {
                var sign = i % 2 === 0 ? 1 : -1;
                self.items.push({
                    id: i,
                    money: i * Math.random() * 100000 * sign,
                    date: new Date(),
                    note: "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Eligendi quam deleniti, quos, tempore laboriosam atque dolores",
                    done: false,
                    checked: false,
                    active: true
                });
            }
        };

        self.toggleItem = function() {            
            self.checkedItems = _.filter(self.items, function(i) {
                return i.checked;
            })
        };

        self.toggleAll = function(checked) {
            _.each(self.items, function(item) {
                item.checked = checked;
            });

            if (!checked) {
                self.checkedItems.length = 0;
            }
        };

        self.markDone = function() {
            _.each(self.checkedItems, function(item) {
                item.done = true;
                item.checked = false;
            });

            self.checkedItems.length = 0;
            self.toggleShowDone();
        };

        self.removeItems = function() {
            _.each(self.checkedItems, function(checkedItem) {
                var index = _.findIndex(self.items, function(i) {
                    return i.id === checkedItem.id;
                });

                if (index >= 0) {
                    self.items.splice(index, 1);
                }
            });

            self.checkedItems.length = 0;
        };

        self.toggleShowDone = function() {            
            var state = self.settings.showDone;            
            var doneItems = _.filter(self.items, function(i) {
                return i.done;
            });

            if (doneItems.length > 0) {
                _.each(doneItems, function(item) {
                    item.active = state;
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