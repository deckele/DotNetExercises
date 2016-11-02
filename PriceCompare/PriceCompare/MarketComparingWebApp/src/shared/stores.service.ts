class StoresService {
    constructor(private $http: ng.IHttpService) {
    }

    getStores(): angular.IPromise<IStore[]> {
        return this.$http.get("api/stores/getStores")
            .then(data => {
                return data.data;
            },
            (error) => {
                console.log(error);
            });
    }
}

app.service("storesService", StoresService);