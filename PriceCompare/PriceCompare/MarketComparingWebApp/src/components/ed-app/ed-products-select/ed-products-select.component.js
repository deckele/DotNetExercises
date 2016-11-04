var ProductsSelectCtrl = (function () {
    function ProductsSelectCtrl() {
        this.selectedProducts = [];
    }
    ProductsSelectCtrl.prototype.productChanged = function () {
        if (this.onProductChange) {
            this.onProductChange();
        }
    };
    return ProductsSelectCtrl;
}());
app.component("edProductsSelect", {
    templateUrl: "src/components/ed-app/ed-products-select/ed-products-select.component.html",
    bindings: {
        products: "=",
        selectedProducts: "=",
        onProductChange: "&"
    },
    controller: ProductsSelectCtrl
});
