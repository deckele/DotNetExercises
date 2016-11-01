interface IItem {
    itemId: number;
    name: string;
    quantity: number;
}

class ItemCtrl {
    model: IItem;
    constructor() {
    }
}

app.component("edItem",
{
    templateUrl: "src/components/ed-app/ed-products-select/ed-items/ed-item/ed-item.component.html",
    bindings: {
        model: "<",
        onRemove: "&"
    },
    controller: ItemCtrl
});