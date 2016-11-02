var ProductsSelectCtrl = (function () {
    function ProductsSelectCtrl() {
        this.selectedProducts = [];
    }
    ProductsSelectCtrl.prototype.addProductClicked = function () {
        if (this.onAddProductClicked) {
            this.onAddProductClicked();
        }
    };
    ProductsSelectCtrl.prototype.removeProductClicked = function (product) {
        if (this.onRemoveProductClicked) {
            this.onRemoveProductClicked(product);
        }
    };
    return ProductsSelectCtrl;
}());
app.component("edProductsSelect", {
    templateUrl: "src/components/ed-app/ed-products-select/ed-products-select.component.html",
    bindings: {
        products: "=",
        selectedProducts: "="
    },
    controller: ProductsSelectCtrl
});
//# sourceMappingURL=ed-products-select.component.js.map