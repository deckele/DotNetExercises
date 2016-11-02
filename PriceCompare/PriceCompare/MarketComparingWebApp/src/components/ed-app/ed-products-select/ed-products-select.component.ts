class ProductsSelectCtrl {
    selectedProducts: IProduct[];
    constructor() {
        this.selectedProducts = [];
    }
}

app.component("edProductsSelect",
    {
        templateUrl: "src/components/ed-app/ed-products-select/ed-products-select.component.html",
        bindings: {
            products: "=",
            selectedProducts: "=",
            onProductChanged: "&"
        },
        controller: ProductsSelectCtrl
    });