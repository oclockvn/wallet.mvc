(function () {

    function walletController($scope, $timeout, walletService) {
        var self = this;

        self.$onInit = function () {
            self.items = [];
            self.checkedItems = [];
            self.settings = {
                showDone: true,
                showLoading: true
            };
            self.totalMoney = 0;

            // for (var i = 0; i < 10; i++) {
            //     var sign = i % 2 === 0 ? 1 : -1;
            //     self.items.push({
            //         id: i,
            //         money: i * Math.random() * 100000 * sign,
            //         time: new Date(),
            //         note: "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Eligendi quam deleniti, quos, tempore laboriosam atque dolores",
            //         done: false,
            //         checked: false,
            //         active: true
            //     });
            // } 
            self.items = walletService.getWallet();

            calculateMoney();     
            $timeout(function(){
                self.settings.showLoading = false;
            }, 1000);
        };

        self.addFieldOnKeyup = function($event) {
            var text = self.addField || '';
            if (text !== '' && $event.keyCode === 13) {

                if (/^(.{1,255})([+-]\d{1,12})$/g.test(text) === false) {
                    return;
                }

                // self.loading = true;

                var matches = /^(.{1,255})([+-]\d{1,12})$/g.exec(text);
                var note = matches[1].trim();
                var money = Number(matches[2]);

                // if (note[0] === window.app.start_search) {
                //     note = note.substr(1, note.length);
                // }

                self.settings.showLoading = true;

                var item = {
                    checked: false,
                    time: new Date().getTime(),
                    note: note,
                    money: money,
                    done: false,
                    active: true
                };

                walletService.addItem(item); // .then(success, fail);
                self.items.unshift(item);

                self.addField = '';

                hideLoading();
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

            calculateMoney();
        };

        self.unDone = function(item) {
            item.done = false;
            calculateMoney();
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

        function calculateMoney() {
            var doneItems = _.filter(self.items, function(item) {
                return item.done;
            });

            if (doneItems.length === 0) {
                self.totalMoney = 0;
                return;
            }

            self.totalMoney = _.reduce(doneItems, function(total, item) {
                return total + item.money;
            }, 0);
        }

        function hideLoading() {
            $timeout(function(){
                self.settings.showLoading = false;
            }, 1000);
        }
    }

    angular.module("app")
        .component("wallet", {
            templateUrl: "app/components/wallet/wallet.template.html",
            controller: ["$scope", "$timeout", "walletService", walletController]
        });
})();