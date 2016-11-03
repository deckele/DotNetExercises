class ProductSelectionItemCtrl {
    product: IProduct;
    onProductChanged: Function;
    onProductQuantityChanged: Function;
    productButtonClicked() {
        if (this.onProductChanged) {
            this.onProductChanged();
        }
    }
    productQuantityChanged() {
        if (this.onProductQuantityChanged) {
            this.onProductQuantityChanged();
        }
    }
}

app.component("edProductSelectionItem",
    {
        templateUrl: "src/components/ed-app/ed-products-select/ed-product-selection-list/ed-product-selection-item/ed-product-selection-item.component.html",
        bindings: {
            product: "=",
            isAddButton: "<",
            onProductChanged: "&",
            onProductQuantityChanged: "&"
        },
        controller: ProductSelectionItemCtrl
    });