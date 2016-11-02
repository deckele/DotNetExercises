var CartSelectionListCtrl = (function () {
    function CartSelectionListCtrl() {
    }
    CartSelectionListCtrl.prototype.removeProductClicked = function (product) {
        var productIndex = this.selectedProducts.indexOf(product);
        this.selectedProducts.splice(productIndex, 1);
        this.products.push(product);
    };
    return CartSelectionListCtrl;
}());
app.component("edCartSelectionList", {
    templateUrl: "src/components/ed-app/ed-products-select/ed-cart-selection-list/ed-cart-selection-list.component.html",
    bindings: {
        products: "=",
        selectedProducts: "=",
        onRemoveProductClicked: "&"
    },
    controller: CartSelectionListCtrl
});
//# sourceMappingURL=ed-cart-selection-list.component.js.map