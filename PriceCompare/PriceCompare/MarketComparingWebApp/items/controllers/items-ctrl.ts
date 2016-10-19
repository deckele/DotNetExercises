class ItemsCtrl {
    itemsFromDb: IItem[];
    allItems: IItem[];
    selectedItems: IItem[];


    constructor(itemsService : IItemService) {
        itemsService.getItems()
            .then(data => {
                this.itemsFromDb = data;
            });
    }
}

app.controller("itemsCtrl", ItemsCtrl);