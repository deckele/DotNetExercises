app.component("items",
{
    templateUrl: "items/templates/items.html",
    bindings: {
        allItems: "=",
        selectedItems: "="
    },
    controller: ItemsCtrl
});