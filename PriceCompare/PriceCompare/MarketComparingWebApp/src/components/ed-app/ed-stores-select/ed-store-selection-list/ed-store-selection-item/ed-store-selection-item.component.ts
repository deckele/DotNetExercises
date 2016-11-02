class StoreSelectionItemCtrl {
    selection: IStore;
    storeSelectionItem: IStoreSelectionItem;
    index: number;
    onRemove: Function;
    onStoreSelect: Function;

    onRemoveClicked() {
        if (this.onRemove) {
            this.onRemove();
        }
    }

    onStoreSelected() {
        if (this.onStoreSelect) {
            this.onStoreSelect();
        }
    }
}

app.component("edStoreSelectionItem",
    {
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