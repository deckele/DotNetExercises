class MainCtrl {
    chains: IChain[];
    storeSelectionList: IStoreSelectionItem[];
    products: IProduct[];
    selectedProducts: IProduct[];
    carts: ICart[];

    constructor(private chainsService: IChainService) {
        this.chainsService.getChains()
            .then(data => {
                this.chains = data;
            })
            .then(() => {
                this.storeSelectionList = [{ selectedStore: null, selectedChain: null }, { selectedStore: null, selectedChain: null }];
            });
    }

    calculateProductsCorrelation() {
        this.products = [];
        let correlationList: IProductCorrelation[] = [];
        let undefinedSelectedStores = 0;
        let pricesInStore: IPrice[];
        let foundProduct: Boolean;

        //mapping which store-selection-items are defined, and how many are undefined.
        for (let i = 0; i < this.storeSelectionList.length; i++) {
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
            for (let i = 0; i < this.storeSelectionList.length; i++) {
                if (this.storeSelectionList[i].selectedStore) {
                    pricesInStore = this.storeSelectionList[i].selectedStore.prices;
                    for (let p = 0; p < pricesInStore.length; p++) {
                        this.products.push(pricesInStore[p].product);
                    }
                }
            }
            //no need to proceed in function.
            return;
        }
        for (let i = 0; i < this.storeSelectionList.length; i++) {
            if (this.storeSelectionList[i].selectedStore) {
                pricesInStore = this.storeSelectionList[i].selectedStore.prices;
                for (let p = 0; p < pricesInStore.length; p++) {
                    correlationList.push({ price: pricesInStore[p], counter: 0});
                }
                break;
            }
        }

        for (let i = 0; i < this.storeSelectionList.length; i++) {
            if (!this.storeSelectionList[i].selectedStore) {
                continue;
            }
            pricesInStore = this.storeSelectionList[i].selectedStore.prices;
            for (let p = 0; p < pricesInStore.length; p++) {
                foundProduct = false;
                for (let c = 0; c < correlationList.length; c++) {
                    if (pricesInStore[p].product.id === correlationList[c].price.product.id) {
                        correlationList[c].counter++;
                        if (correlationList[c].counter === (this.storeSelectionList.length - undefinedSelectedStores)) {
                            this.products.push(pricesInStore[p].product);
                        }
                    }
                }
            }
        }
    }

    calculateCarts() {
        this.carts = [];
        for (let s = 0; s < this.storeSelectionList.length; s++) {
            if (!this.storeSelectionList[s].selectedStore) {
                continue;
            }
            const chain = this.storeSelectionList[s].selectedChain;
            const store = this.storeSelectionList[s].selectedStore;
            const storeCartPrices: IPrice[] = [];
            let totalPrice = 0;
            for (let p = 0; p < this.selectedProducts.length; p++) {
                const selectedProduct = this.selectedProducts[p];
                for (let i = 0; i < store.prices.length; i++) {
                    const price = store.prices[i];
                    if (price.product === selectedProduct) {
                        storeCartPrices.push(price);
                        totalPrice += (price.productPrice*price.product.selectedQuantity);
                    }
                }
            }
            this.carts.push({ chain: chain, store: store, prices: storeCartPrices, totalPrice: totalPrice});
        }
    }

    onStoreSelected() {
        if (this.calculateProductsCorrelation) {
            this.calculateProductsCorrelation();
        }
    }

    productChanged() {
        if (this.calculateCarts) {
            this.calculateCarts();
        }
    }
}

app.component("edApp",
    {
        templateUrl: "src/components/ed-app/ed-app.component.html",
        controller: MainCtrl
    });