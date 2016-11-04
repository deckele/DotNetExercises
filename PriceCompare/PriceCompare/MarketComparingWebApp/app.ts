const app = angular.module("app", ['ui.bootstrap', 'angular.filter', 'ngRoute']);

app.config(["$routeProvider", ($routeProvider: ng.route.IRouteProvider) => {
        $routeProvider.when("/home",
        {
            templateUrl: "src/components/ed-app/ed-home/ed-home.component.html"
        });
        $routeProvider.when("/compare",
        {
            templateUrl: "src/components/ed-app/ed-compare/ed-compare.component.html"
        });
        $routeProvider.otherwise("/home");
    }
]);