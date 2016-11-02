class StoreSelectionListCtrl {
    chains: IChain[];
    allStores: IStore[];
    availableStores: IStore[];
    storeSelectionList: IStoreSelectionItem[];
    onStoreSelect: Function;

    constructor(storesService: IStoreService) {
        storesService.getStores()
        .then(data => {
            this.allStores = data;
            });
    }

    onStoreRemoveClicked(storeSelectionItem: IStoreSelectionItem) {
        const storeSelectionItemIndex = this.storeSelectionList.indexOf(storeSelectionItem);
        this.storeSelectionList.splice(storeSelectionItemIndex, 1);
    }
    onAddStoreClicked() {
        this.storeSelectionList.push({ selectedStore: null, selectedChain: null });
    }
    isAddButtonDisabled(): boolean {
        if (!this.storeSelectionList) {
            return true;
        }
        const numberOfStores = this.allStores ? this.allStores.length : 0;
        return this.storeSelectionList.length >= numberOfStores;
    }

    onStoreSelected() {
        if (this.onStoreSelect) {
            this.onStoreSelect();
        }
    }
}

app.component("edStoreSelectionList",
{
    templateUrl: "src/components/ed-app/ed-stores-select/ed-store-selection-list/ed-store-selection-list.component.html",
    bindings: {
        chains: "<",
        storeSelectionList: "=",
        onStoreSelect: "&"
    },
    controller: StoreSelectionListCtrl
});