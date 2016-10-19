interface IItem {
    itemId: number;
    name: string;
}

class ItemsCtrl {
    items: IItem[];

    constructor(itemsService : IItemService) {
        itemsService.getItems()
            .then(collection => {
                this.items = collection;
            });
    }
}

app.controller("itemsCtrl", ItemsCtrl);