var StoresService = (function () {
    function StoresService($http) {
        this.$http = $http;
    }
    StoresService.prototype.getStores = function () {
        return this.$http.get("api/stores/getStores")
            .then(function (data) {
            return data.data;
        }, function (error) {
            console.log(error);
        });
    };
    return StoresService;
}());
app.service("storesService", StoresService);
//# sourceMappingURL=stores.service.js.map