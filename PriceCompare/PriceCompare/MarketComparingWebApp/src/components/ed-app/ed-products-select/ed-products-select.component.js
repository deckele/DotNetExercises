var ProductsSelectCtrl = (function () {
    function ProductsSelectCtrl() {
        this.selectedProducts = [];
    }
    return ProductsSelectCtrl;
}());
app.component("edProductsSelect", {
    templateUrl: "src/components/ed-app/ed-products-select/ed-products-select.component.html",
    bindings: {
        products: "=",
        selectedProducts: "=",
        onProductChanged: "&"
    },
    controller: ProductsSelectCtrl
});
