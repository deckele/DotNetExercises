var MainCtrl = (function () {
    function MainCtrl(chainsService) {
        var _this = this;
        this.chainsService = chainsService;
        this.chainsService.getChains()
            .then(function (data) {
            _this.chains = data;
        });
    }
    return MainCtrl;
}());
app.component("edApp", {
    templateUrl: "src/components/ed-app/ed-app.component.html",
    bindings: {},
    controller: MainCtrl
});
//# sourceMappingURL=ed-app.component.js.map