var ItemCtrl = (function () {
    function ItemCtrl() {
    }
    return ItemCtrl;
}());
app.component("edItem", {
    templateUrl: "src/components/ed-app/ed-products-select/ed-items/ed-item/ed-item.component.html",
    bindings: {
        model: "<",
        onRemove: "&"
    },
    controller: ItemCtrl
});
//# sourceMappingURL=ed-item.component.js.map