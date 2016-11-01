interface IStore {
    chainName: string;
    chainId: number;
    storeId: number;
    name: string;
    address: string;
    city: string;
}

class StoreSelectionListCtrl {
    chains: IChain[];
    allStores: IStore[];
    availableStores: IStore[];
    storeSelectionList : IStoreSelectionItem[];

    constructor(storesService: IStoreService) {
        this.storeSelectionList = [{ store: null, selection: null }, { store: null, selection: null }];

        storesService.getStores()
        .then(data => {
            this.allStores = data;
            })
        .then(() => this.updateAvailableStores());
    }

    onStoreSelected(storeSelectionItem: IStoreSelectionItem) {
        if (!(storeSelectionItem.store === storeSelectionItem.selection)) {
            this.availableStores.push(storeSelectionItem.store);
            storeSelectionItem.store = storeSelectionItem.selection;
        }
        const storeIndex = this.availableStores.indexOf(storeSelectionItem.selection);
        this.availableStores.splice(storeIndex, 1);
    }
    onChainSelected(storeSelectionItem: IStoreSelectionItem) {

    }

    updateAvailableStores() {
        this.availableStores = [];
        for (let i = 0; i < this.allStores.length; i++) {
            this.availableStores.push(this.allStores[i]);
            for (let j = 0; j < this.storeSelectionList.length; j++) {
                if (this.allStores[i] === this.storeSelectionList[j].selection) {
                    const storeIndex = this.availableStores.indexOf(this.allStores[i]);
                    this.availableStores.splice(storeIndex, 1);
                }
            }
        }
    }

    onStoreRemoveClicked(storeSelectionItem: IStoreSelectionItem) {
        if (storeSelectionItem.selection) {
            this.availableStores.push(storeSelectionItem.selection);
        }
        const storeSelectionItemIndex = this.storeSelectionList.indexOf(storeSelectionItem);
        this.storeSelectionList.splice(storeSelectionItemIndex, 1);
    }
    onAddStoreClicked() {
        this.storeSelectionList.push({ store: null, selection: null });
    }
    isAddButtonDisabled(): boolean {
        const numberOfStores = this.allStores ? this.allStores.length : 0;
        return this.storeSelectionList.length >= numberOfStores;
    }
}

app.component("edStoreSelectionList",
{
    templateUrl: "src/components/ed-app/ed-stores-select/ed-store-selection-list/ed-store-selection-list.component.html",
    bindings: {
        chains: "<"
    },
    controller: StoreSelectionListCtrl
});