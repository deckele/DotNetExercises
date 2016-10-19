app.component("item",
{
    templateUrl: "items/templates/item.html",
    bindings: {
        model: "<"
    },
    controller: ItemCtrl
});