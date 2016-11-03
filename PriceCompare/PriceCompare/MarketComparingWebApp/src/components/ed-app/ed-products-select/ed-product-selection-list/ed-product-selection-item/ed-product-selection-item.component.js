var ProductSelectionItemCtrl = (function () {
    function ProductSelectionItemCtrl() {
    }
    ProductSelectionItemCtrl.prototype.productButtonClicked = function () {
        if (this.onProductChanged) {
            this.onProductChanged();
        }
    };
    ProductSelectionItemCtrl.prototype.productQuantityChanged = function () {
        if (this.onProductQuantityChanged) {
            this.onProductQuantityChanged();
        }
    };
    return ProductSelectionItemCtrl;
}());
app.component("edProductSelectionItem", {
    templateUrl: "src/components/ed-app/ed-products-select/ed-product-selection-list/ed-product-selection-item/ed-product-selection-item.component.html",
    bindings: {
        product: "=",
        isAddButton: "<",
        onProductChanged: "&",
        onProductQuantityChanged: "&"
    },
    controller: ProductSelectionItemCtrl
});
//# sourceMappingURL=ed-product-selection-item.component.js.map