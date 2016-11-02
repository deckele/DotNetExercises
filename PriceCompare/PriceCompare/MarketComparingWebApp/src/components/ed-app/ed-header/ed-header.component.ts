class HeaderCtrl {
    numberOfItems: string;
    constructor() {
        this.numberOfItems = "0";
    }
}

app.component("edHeader",
{
    templateUrl: "src/components/ed-app/ed-header/ed-header.component.html",
    bindings: {
        numberOfItems: "<"
    },
    controller: HeaderCtrl
})