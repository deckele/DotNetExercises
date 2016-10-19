interface IItem {
    itemId: number;
    name: string;
}

class ItemsCtrl {
    items: IItem[];

    constructor(itemsService : IItemService) {
        itemsService.getItems()
            .then(data => {
                this.items = data;
            });
    }
}

app.controller("itemsCtrl", ItemsCtrl);