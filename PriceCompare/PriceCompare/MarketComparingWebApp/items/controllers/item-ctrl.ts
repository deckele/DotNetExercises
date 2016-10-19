interface IItem {
    itemId: number;
    name: string;
}

class ItemCtrl {
    model: IItem;
    constructor() {
    }
}

app.controller("itemCtrl", ItemCtrl);