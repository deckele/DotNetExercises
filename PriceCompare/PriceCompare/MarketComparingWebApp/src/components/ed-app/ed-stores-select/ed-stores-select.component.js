var StoresSelectCtrl = (function () {
    function StoresSelectCtrl() {
    }
    StoresSelectCtrl.prototype.onStoreSelected = function () {
        if (this.onStoreSelect) {
            this.onStoreSelect();
        }
    };
    return StoresSelectCtrl;
}());
app.component("edStoresSelect", {
    templateUrl: "src/components/ed-app/ed-stores-select/ed-stores-select.component.html",
    bindings: {
        chains: "<",
        storeSelectionList: "=",
        onStoreSelect: "&"
    },
    controller: StoresSelectCtrl
});
