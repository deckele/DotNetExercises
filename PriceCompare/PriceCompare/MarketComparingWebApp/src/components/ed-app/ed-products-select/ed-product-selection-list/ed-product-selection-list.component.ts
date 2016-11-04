class ProductSelectionListCtrl {
    products: IProduct[];
    selectedProducts: IProduct[];
    searchText: string;
    onAddProductClicked: Function;
    onProductChange: Function;
    constructor(private $location) {
        this.searchText = "חיפוש מוצרים...";
    }
    addProductClicked(product: IProduct) {
        const productIndex = this.products.indexOf(product);
        this.products.splice(productIndex, 1);
        this.selectedProducts.push(product);
        this.onProductChange();
    }
    compareButtonClicked() {
        if (this.selectedProducts.length > 0) {
            this.$location.path("/compare");
        }
    }
}

app.component("edProductSelectionList",
    {
        templateUrl: "src/components/ed-app/ed-products-select/ed-product-selection-list/ed-product-selection-list.component.html",
        bindings: {
            products: "=",
            selectedProducts: "=",
            onProductChange: "&"
        },
        controller: ProductSelectionListCtrl
    });