interface IStoreSelectionItem {
    selectedStore: IStore;
    selectedChain: IStore;
}

interface IChain {
    name: string;
    chainId: number;
    stores: IStore[];
}

interface IChainService {
    getChains(): ng.IPromise<IChain[]>;
}

interface IStore {
    storeId: number;
    name: string;
    address: string;
    city: string;
    prices: IPrice[];
}

interface IStoreService {
    getStores(): ng.IPromise<IStore[]>;
}

interface IPrice {
    productPrice: number; 
    product: IProduct;
}

interface IProduct {
    name: string;
    id: number;
    unitsQuantity: number;
    units: string;
    selectedQuantity: number;
}

interface IProductService {
    getItems(): ng.IPromise<IProduct[]>;
}

interface IProductCorrelation {
    price: IPrice;
    counter: number;
}