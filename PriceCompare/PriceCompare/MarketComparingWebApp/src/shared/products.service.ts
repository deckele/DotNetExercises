class ProductsService {
    constructor(private $http: ng.IHttpService) {
    }

    getItems(): angular.IPromise<IProduct[]> {
        return this.$http.get("api/items/getItems")
            .then(data => {
                return data.data;
            },
            (error) => {
                console.log(error);
            });
    }
}

app.service("itemsService", ProductsService);