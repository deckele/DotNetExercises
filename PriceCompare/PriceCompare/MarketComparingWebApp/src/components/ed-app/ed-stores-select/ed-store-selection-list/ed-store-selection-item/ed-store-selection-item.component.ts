interface IStoreSelectionItem {
    store: IStore;
    selection: IStore;
}

class StoreSelectionItemCtrl {
    selectedStore: IStore;
    selectedChain: IStore;
    selection: IStore;
    storeSelectionItem: IStoreSelectionItem;
    index: number;
    onStoreSelect: Function;
    onChainSelect: Function;
    onRemove: Function;
    constructor() {
        this.selectedStore = null;
        this.selectedChain = null;
        this.storeSelectionItem = { store: null, selection: null };
    }

    onStoreSelected() {
        if (this.onStoreSelect) {
            this.storeSelectionItem.selection = this.selection;
            this.onStoreSelect();
        }
    }
    onChainSelected() {
        if (this.onChainSelect) {
            this.onChainSelect();
        }
    }
    onRemoveClicked() {
        if (this.onRemove) {
            this.onRemove();
        }
    }
}

app.component("edStoreSelectionItem",
    {
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