var ProductsService = (function () {
    function ProductsService($http) {
        this.$http = $http;
    }
    ProductsService.prototype.getItems = function () {
        return this.$http.get("api/items/getItems")
            .then(function (data) {
            return data.data;
        }, function (error) {
            console.log(error);
        });
    };
    return ProductsService;
}());
app.service("itemsService", ProductsService);
