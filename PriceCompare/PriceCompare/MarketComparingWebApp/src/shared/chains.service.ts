interface IChain {
    
}

interface IChainService {
    getChains(): ng.IPromise<IChain[]>;
}

class ChainsService {
    public chains: IChain[];

    constructor(private $http: ng.IHttpService, private $q: ng.IQService) {

    }

    getChains(): angular.IPromise<IChain[]> {
        var defer = this.$q.defer<IChain[]>();

        if (this.chains) {
            defer.resolve(this.chains);
        }
        else {
            this.$http.get("api/chains/getChains")
                .then(data => {
                    this.chains = data.data as IChain[];
                    defer.resolve(this.chains);
                },
                (error) => {
                    defer.reject(error);
                });
        }


        return defer.promise;
    }
}

app.service("chainsService", ChainsService);