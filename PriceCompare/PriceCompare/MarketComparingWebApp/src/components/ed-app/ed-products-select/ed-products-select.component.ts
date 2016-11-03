class ProductsSelectCtrl {
    products: IProduct[];
    selectedProducts: IProduct[];
    onAddProductClicked: Function;
    onRemoveProductClicked: Function;
    onProductChange: Function;
    constructor() {
        this.selectedProducts = [];
    }
    productChanged() {
        if (this.onProductChange) {
            this.onProductChange();
        }
    }
}

app.component("edProductsSelect",
    {
        templateUrl: "src/components/ed-app/ed-products-select/ed-products-select.component.html",
        bindings: {
            products: "=",
            selectedProducts: "=",
            onProductChange: "&"
        },
        controller: ProductsSelectCtrl
    });