var ItemsCtrl = (function () {
    function ItemsCtrl(itemsService) {
        var _this = this;
        itemsService.getItems()
            .then(function (collection) {
            _this.items = collection;
        });
    }
    return ItemsCtrl;
}());
app.controller("itemsCtrl", ItemsCtrl);
//# sourceMappingURL=items-ctrl.js.map