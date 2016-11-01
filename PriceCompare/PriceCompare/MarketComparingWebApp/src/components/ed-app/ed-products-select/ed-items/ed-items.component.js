var ItemsCtrl = (function () {
    function ItemsCtrl(itemsService) {
        var _this = this;
        itemsService.getItems()
            .then(function (data) {
            _this.products = data;
        });
    }
    return ItemsCtrl;
}());
app.component("edItems", {
    templateUrl: "src/components/ed-app/ed-products-select/ed-items/ed-items.component.html",
    bindings: {
        onProductSelected: "&"
    },
    controller: ItemsCtrl
});
//# sourceMappingURL=ed-items.component.js.map