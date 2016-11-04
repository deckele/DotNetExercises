var ProductSelectionListCtrl = (function () {
    function ProductSelectionListCtrl($location) {
        this.$location = $location;
        this.searchText = "חיפוש מוצרים...";
    }
    ProductSelectionListCtrl.prototype.addProductClicked = function (product) {
        var productIndex = this.products.indexOf(product);
        this.products.splice(productIndex, 1);
        this.selectedProducts.push(product);
        this.onProductChange();
    };
    ProductSelectionListCtrl.prototype.compareButtonClicked = function () {
        if (this.selectedProducts.length > 0) {
            this.$location.path("/compare");
        }
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
