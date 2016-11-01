class ItemsCtrl {
    products: IItem[];
    constructor(itemsService: IItemService) {
        itemsService.getItems()
        .then(data => {
            this.products = data;
        });
    }
}

app.component("edItems",
{
    templateUrl: "src/components/ed-app/ed-products-select/ed-items/ed-items.component.html",
    bindings: {
        onProductSelected:"&"
    },
    controller: ItemsCtrl
});