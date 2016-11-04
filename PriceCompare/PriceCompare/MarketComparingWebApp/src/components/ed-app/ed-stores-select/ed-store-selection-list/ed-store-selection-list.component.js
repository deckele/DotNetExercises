var StoreSelectionListCtrl = (function () {
    function StoreSelectionListCtrl(storesService) {
        var _this = this;
        storesService.getStores()
            .then(function (data) {
            _this.allStores = data;
        });
    }
    StoreSelectionListCtrl.prototype.onStoreRemoveClicked = function (storeSelectionItem) {
        var storeSelectionItemIndex = this.storeSelectionList.indexOf(storeSelectionItem);
        this.storeSelectionList.splice(storeSelectionItemIndex, 1);
    };
    StoreSelectionListCtrl.prototype.onAddStoreClicked = function () {
        this.storeSelectionList.push({ selectedStore: null, selectedChain: null });
    };
    StoreSelectionListCtrl.prototype.isAddButtonDisabled = function () {
        if (!this.storeSelectionList) {
            return true;
        }
        var numberOfStores = this.allStores ? this.allStores.length : 0;
        return this.storeSelectionList.length >= numberOfStores;
    };
    StoreSelectionListCtrl.prototype.onStoreSelected = function () {
        if (this.onStoreSelect) {
            this.onStoreSelect();
        }
    };
    return StoreSelectionListCtrl;
}());
app.component("edStoreSelectionList", {
    templateUrl: "src/components/ed-app/ed-stores-select/ed-store-selection-list/ed-store-selection-list.component.html",
    bindings: {
        chains: "<",
        storeSelectionList: "=",
        onStoreSelect: "&"
    },
    controller: StoreSelectionListCtrl
});
//# sourceMappingURL=ed-store-selection-list.component.js.map