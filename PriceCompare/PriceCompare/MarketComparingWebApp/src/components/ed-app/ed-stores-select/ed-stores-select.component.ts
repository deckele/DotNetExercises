class StoresSelectCtrl {

}

app.component("edStoresSelect",
    {
        templateUrl: "src/components/ed-app/ed-stores-select/ed-stores-select.component.html",
        bindings: {
            chains: "<"
        },
        controller: StoresSelectCtrl
    });