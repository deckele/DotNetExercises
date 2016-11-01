interface IItemService {
    getItems(): ng.IPromise<IItem[]>;
}

class ItemsService {
    constructor(private $http: ng.IHttpService) {
    }

    getItems(): angular.IPromise<IItem[]> {
        return this.$http.get("api/items/getItems")
            .then(data => {
                return data.data;
            },
            (error) => {
                console.log(error);
            });
    }
}

app.service("itemsService", ItemsService);