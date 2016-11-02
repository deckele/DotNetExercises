var ProductSelectionItemCtrl = (function () {
    function ProductSelectionItemCtrl() {
    }
    ProductSelectionItemCtrl.prototype.productButtonClicked = function () {
        if (this.onProductChanged) {
            this.onProductChanged();
        }
    };
    return ProductSelectionItemCtrl;
}());
app.component("edProductSelectionItem", {
    templateUrl: "src/components/ed-app/ed-products-select/ed-product-selection-list/ed-product-selection-item/ed-product-selection-item.component.html",
    bindings: {
        product: "=",
        isAddButton: "<",
        onProductChanged: "&"
    },
    controller: ProductSelectionItemCtrl
});
//# sourceMappingURL=ed-product-selection-item.component.js.map