var StoreSelectionListCtrl = (function () {
    function StoreSelectionListCtrl(storesService) {
        var _this = this;
        this.storeSelectionList = [{ store: null, selection: null }, { store: null, selection: null }];
        storesService.getStores()
            .then(function (data) {
            _this.allStores = data;
        })
            .then(function () { return _this.updateAvailableStores(); });
    }
    StoreSelectionListCtrl.prototype.onStoreSelected = function (storeSelectionItem) {
        if (!(storeSelectionItem.store === storeSelectionItem.selection)) {
            this.availableStores.push(storeSelectionItem.store);
            storeSelectionItem.store = storeSelectionItem.selection;
        }
        var storeIndex = this.availableStores.indexOf(storeSelectionItem.selection);
        this.availableStores.splice(storeIndex, 1);
    };
    StoreSelectionListCtrl.prototype.onChainSelected = function (storeSelectionItem) {
    };
    StoreSelectionListCtrl.prototype.updateAvailableStores = function () {
        this.availableStores = [];
        for (var i = 0; i < this.allStores.length; i++) {
            this.availableStores.push(this.allStores[i]);
            for (var j = 0; j < this.storeSelectionList.length; j++) {
                if (this.allStores[i] === this.storeSelectionList[j].selection) {
                    var storeIndex = this.availableStores.indexOf(this.allStores[i]);
                    this.availableStores.splice(storeIndex, 1);
                }
            }
        }
    };
    StoreSelectionListCtrl.prototype.onStoreRemoveClicked = function (storeSelectionItem) {
        if (storeSelectionItem.selection) {
            this.availableStores.push(storeSelectionItem.selection);
        }
        var storeSelectionItemIndex = this.storeSelectionList.indexOf(storeSelectionItem);
        this.storeSelectionList.splice(storeSelectionItemIndex, 1);
    };
    StoreSelectionListCtrl.prototype.onAddStoreClicked = function () {
        this.storeSelectionList.push({ store: null, selection: null });
    };
    StoreSelectionListCtrl.prototype.isAddButtonDisabled = function () {
        var numberOfStores = this.allStores ? this.allStores.length : 0;
        return this.storeSelectionList.length >= numberOfStores;
    };
    return StoreSelectionListCtrl;
}());
app.component("edStoreSelectionList", {
    templateUrl: "src/components/ed-app/ed-stores-select/ed-store-selection-list/ed-store-selection-list.component.html",
    bindings: {
        chains: "<"
    },
    controller: StoreSelectionListCtrl
});
//# sourceMappingURL=ed-store-selection-list.component.js.map