var StoreSelectionItemCtrl = (function () {
    function StoreSelectionItemCtrl() {
        this.selectedStore = null;
        this.selectedChain = null;
        this.storeSelectionItem = { store: null, selection: null };
    }
    StoreSelectionItemCtrl.prototype.onStoreSelected = function () {
        if (this.onStoreSelect) {
            this.storeSelectionItem.selection = this.selection;
            this.onStoreSelect();
        }
    };
    StoreSelectionItemCtrl.prototype.onChainSelected = function () {
        if (this.onChainSelect) {
            this.onChainSelect();
        }
    };
    StoreSelectionItemCtrl.prototype.onRemoveClicked = function () {
        if (this.onRemove) {
            this.onRemove();
        }
    };
    return StoreSelectionItemCtrl;
}());
app.component("edStoreSelectionItem", {
    templateUrl: "src/components/ed-app/ed-stores-select/ed-store-selection-list/ed-store-selection-item/ed-store-selection-item.component.html",
    bindings: {
        chains: "<",
        //selection: "=",
        storeSelectionItem: "=",
        index: "<",
        //stores: "<",
        //onStoreSelect: "&",
        //onChainSelect: "&",
        onRemove: "&"
    },
    controller: StoreSelectionItemCtrl
});
//# sourceMappingURL=ed-store-selection-item.component.js.map