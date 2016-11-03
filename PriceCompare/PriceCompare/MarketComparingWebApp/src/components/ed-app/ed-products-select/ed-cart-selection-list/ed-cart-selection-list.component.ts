class CartSelectionListCtrl {
    products: IProduct[];
    selectedProducts: IProduct[];
    onProductChange: Function;

    removeProductClicked(product: IProduct) {
        const productIndex = this.selectedProducts.indexOf(product);
        this.selectedProducts.splice(productIndex, 1);
        this.products.push(product);
        this.onProductChange();
    }
    productQuantityChanged() {
        if (this.onProductChange) {
            this.onProductChange();
        }
    }
}

app.component("edCartSelectionList",
    {
        templateUrl: "src/components/ed-app/ed-products-select/ed-cart-selection-list/ed-cart-selection-list.component.html",
        bindings: {
            products: "=",
            selectedProducts: "=",
            onProductChange: "&"
        },
        controller: CartSelectionListCtrl
    });