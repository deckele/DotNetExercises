var StoreSelectionItemCtrl = (function () {
    function StoreSelectionItemCtrl() {
    }
    StoreSelectionItemCtrl.prototype.onRemoveClicked = function () {
        if (this.onRemove) {
            this.onRemove();
        }
    };
    StoreSelectionItemCtrl.prototype.onStoreSelected = function () {
        if (this.onStoreSelect) {
            this.onStoreSelect();
        }
    };
    return StoreSelectionItemCtrl;
}());
app.component("edStoreSelectionItem", {
    templateUrl: "src/components/ed-app/ed-stores-select/ed-store-selection-list/ed-store-selection-item/ed-store-selection-item.component.html",
    bindings: {
        chains: "<",
        storeSelectionItem: "=",
        index: "<",
        onRemove: "&",
        onStoreSelect: "&"
    },
    controller: StoreSelectionItemCtrl
});
//# sourceMappingURL=ed-store-selection-item.component.js.map