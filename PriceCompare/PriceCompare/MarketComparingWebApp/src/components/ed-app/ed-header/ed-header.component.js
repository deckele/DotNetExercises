var HeaderCtrl = (function () {
    function HeaderCtrl($location) {
        this.$location = $location;
        this.numberOfItems = "0";
    }
    return HeaderCtrl;
}());
app.component("edHeader", {
    templateUrl: "src/components/ed-app/ed-header/ed-header.component.html",
    bindings: {
        numberOfItems: "<"
    },
    controller: HeaderCtrl
});
