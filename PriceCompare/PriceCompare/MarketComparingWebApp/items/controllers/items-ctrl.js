var ItemsCtrl = (function () {
    function ItemsCtrl(itemsService) {
        var _this = this;
        itemsService.getItems()
            .then(function (data) {
            _this.itemsFromDb = data;
        });
    }
    return ItemsCtrl;
}());
app.controller("itemsCtrl", ItemsCtrl);
//# sourceMappingURL=items-ctrl.js.map