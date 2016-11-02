var MainCtrl = (function () {
    function MainCtrl(chainsService) {
        var _this = this;
        this.chainsService = chainsService;
        this.chainsService.getChains()
            .then(function (data) {
            _this.chains = data;
        })
            .then(function () {
            _this.storeSelectionList = [{ selectedStore: null, selectedChain: null }, { selectedStore: null, selectedChain: null }];
        });
    }
    MainCtrl.prototype.calculateProductsCorrelation = function () {
        this.products = [];
        var correlationList = [];
        var undefinedSelectedStores = 0;
        var pricesInStore;
        var foundProduct;
        //mapping which store-selection-items are defined, and how many are undefined.
        for (var i = 0; i < this.storeSelectionList.length; i++) {
            if (!this.storeSelectionList[i].selectedStore) {
                undefinedSelectedStores++;
            }
        }
        //no stores selected
        if (undefinedSelectedStores === this.storeSelectionList.length) {
            return;
        }
        //in case there is only one defined store-selection-item.
        if ((this.storeSelectionList.length - undefinedSelectedStores) === 1) {
            for (var i = 0; i < this.storeSelectionList.length; i++) {
                if (this.storeSelectionList[i].selectedStore) {
                    pricesInStore = this.storeSelectionList[i].selectedStore.prices;
                    for (var p = 0; p < pricesInStore.length; p++) {
                        this.products.push(pricesInStore[p].product);
                    }
                }
            }
            //no need to proceed in function.
            return;
        }
        for (var i = 0; i < this.storeSelectionList.length; i++) {
            if (this.storeSelectionList[i].selectedStore) {
                pricesInStore = this.storeSelectionList[i].selectedStore.prices;
                for (var p = 0; p < pricesInStore.length; p++) {
                    correlationList.push({ price: pricesInStore[p], counter: 0 });
                }
                break;
            }
        }
        for (var i = 0; i < this.storeSelectionList.length; i++) {
            if (!this.storeSelectionList[i].selectedStore) {
                continue;
            }
            pricesInStore = this.storeSelectionList[i].selectedStore.prices;
            for (var p = 0; p < pricesInStore.length; p++) {
                foundProduct = false;
                for (var c = 0; c < correlationList.length; c++) {
                    if (pricesInStore[p].product.id === correlationList[c].price.product.id) {
                        correlationList[c].counter++;
                        if (correlationList[c].counter === (this.storeSelectionList.length - undefinedSelectedStores)) {
                            this.products.push(pricesInStore[p].product);
                        }
                    }
                }
            }
        }
    };
    MainCtrl.prototype.onStoreSelected = function () {
        if (this.calculateProductsCorrelation()) {
            this.calculateProductsCorrelation();
        }
    };
    return MainCtrl;
}());
app.component("edApp", {
    templateUrl: "src/components/ed-app/ed-app.component.html",
    controller: MainCtrl
});
//# sourceMappingURL=ed-app.component.js.map