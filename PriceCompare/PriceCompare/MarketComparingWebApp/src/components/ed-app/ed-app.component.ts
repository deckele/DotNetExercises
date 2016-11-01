class MainCtrl {
    chains: IChain[];
    constructor(private chainsService: IChainService) {
        this.chainsService.getChains()
        .then(data => {
                this.chains = data;
            });
    }
}

app.component("edApp",
    {
        templateUrl: "src/components/ed-app/ed-app.component.html",
        bindings: {
        },
        controller: MainCtrl
    });