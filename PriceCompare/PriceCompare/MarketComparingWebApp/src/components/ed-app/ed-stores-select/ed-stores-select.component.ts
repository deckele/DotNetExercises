class StoresSelectCtrl {
    onStoreSelect: Function;
    onStoreSelected() {
        if (this.onStoreSelect) {
            this.onStoreSelect();
        }
    }
}

app.component("edStoresSelect",
    {
        templateUrl: "src/components/ed-app/ed-stores-select/ed-stores-select.component.html",
        bindings: {
            chains: "<",
            storeSelectionList: "=",
            onStoreSelect: "&"
        },
        controller: StoresSelectCtrl
    });