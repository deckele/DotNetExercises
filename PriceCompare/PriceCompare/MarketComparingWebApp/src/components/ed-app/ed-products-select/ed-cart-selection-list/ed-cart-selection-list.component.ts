class CartSelectionListCtrl {
    products: IProduct[];
    selectedProducts: IProduct[];
    onRemoveProductClicked: Function;

    removeProductClicked(product: IProduct) {
        const productIndex = this.selectedProducts.indexOf(product);
        this.selectedProducts.splice(productIndex, 1);
        this.products.push(product);
    }
}

app.component("edCartSelectionList",
    {
        templateUrl: "src/components/ed-app/ed-products-select/ed-cart-selection-list/ed-cart-selection-list.component.html",
        bindings: {
            products: "=",
            selectedProducts: "=",
            onRemoveProductClicked: "&"
        },
        controller: CartSelectionListCtrl
    });