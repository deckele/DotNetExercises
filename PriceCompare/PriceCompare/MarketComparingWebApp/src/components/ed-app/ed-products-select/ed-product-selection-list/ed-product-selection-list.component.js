var ProductSelectionListCtrl = (function () {
    function ProductSelectionListCtrl() {
        this.searchText = "חיפוש מוצרים...";
    }
    ProductSelectionListCtrl.prototype.addProductClicked = function (product) {
        var productIndex = this.products.indexOf(product);
        this.products.splice(productIndex, 1);
        this.selectedProducts.push(product);
        this.onProductChange();
    };
    return ProductSelectionListCtrl;
}());
app.component("edProductSelectionList", {
    templateUrl: "src/components/ed-app/ed-products-select/ed-product-selection-list/ed-product-selection-list.component.html",
    bindings: {
        products: "=",
        selectedProducts: "=",
        onProductChange: "&"
    },
    controller: ProductSelectionListCtrl
});
//# sourceMappingURL=ed-product-selection-list.component.js.map