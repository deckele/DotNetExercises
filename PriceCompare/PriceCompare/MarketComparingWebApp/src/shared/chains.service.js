var ChainsService = (function () {
    function ChainsService($http, $q) {
        this.$http = $http;
        this.$q = $q;
    }
    ChainsService.prototype.getChains = function () {
        var _this = this;
        var defer = this.$q.defer();
        if (this.chains) {
            defer.resolve(this.chains);
        }
        else {
            this.$http.get("api/chains/getChains")
                .then(function (data) {
                _this.chains = data.data;
                defer.resolve(_this.chains);
            }, function (error) {
                defer.reject(error);
            });
        }
        return defer.promise;
    };
    return ChainsService;
}());
app.service("chainsService", ChainsService);
