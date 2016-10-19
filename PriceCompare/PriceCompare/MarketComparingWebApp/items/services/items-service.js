var ItemsService = (function () {
    function ItemsService($http) {
        this.$http = $http;
    }
    ItemsService.prototype.getItems = function () {
        return this.$http.get("api/items/getItems")
            .then(function (data) {
            return data.data;
        }, function (error) {
            console.log(error);
        });
    };
    return ItemsService;
}());
app.service('itemsService', ItemsService);
//# sourceMappingURL=items-service.js.map