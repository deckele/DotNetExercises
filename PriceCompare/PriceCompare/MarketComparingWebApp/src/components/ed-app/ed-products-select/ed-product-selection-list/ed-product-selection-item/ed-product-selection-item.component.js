var ProductSelectionItemCtrl = (function () {
    function ProductSelectionItemCtrl() {
        this.selectedQuantity = 1;
    }
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
