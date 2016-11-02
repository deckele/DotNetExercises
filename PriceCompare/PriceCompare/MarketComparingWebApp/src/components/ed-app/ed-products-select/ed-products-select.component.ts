class ProductsSelectCtrl {
    products: IProduct[];
    selectedProducts: IProduct[];
    onAddProductClicked: Function;
    onRemoveProductClicked: Function;
    constructor() {
        this.selectedProducts = [];
    }
    addProductClicked() {
        if (this.onAddProductClicked) {
            this.onAddProductClicked();
        }
    }
    removeProductClicked(product: IProduct) {
        if (this.onRemoveProductClicked) {
            this.onRemoveProductClicked(product);
        }
    }
}

app.component("edProductsSelect",
    {
        templateUrl: "src/components/ed-app/ed-products-select/ed-products-select.component.html",
        bindings: {
            products: "=",
            selectedProducts: "="
            //onAddProductClicked: "&",
            //onRemoveProductClicked: "&"
        },
        controller: ProductsSelectCtrl
    });