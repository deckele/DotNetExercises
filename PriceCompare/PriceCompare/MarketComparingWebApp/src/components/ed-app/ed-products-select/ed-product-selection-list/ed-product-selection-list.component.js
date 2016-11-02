var ProductSelectionListCtrl = (function () {
    function ProductSelectionListCtrl() {
        this.searchText = "חיפוש מוצרים...";
    }
    ProductSelectionListCtrl.prototype.addProductClicked = function (product) {
        var productIndex = this.products.indexOf(product);
        this.products.splice(productIndex, 1);
        this.selectedProducts.push(product);
    };
    return ProductSelectionListCtrl;
}());
app.component("edProductSelectionList", {
    templateUrl: "src/components/ed-app/ed-products-select/ed-product-selection-list/ed-product-selection-list.component.html",
    bindings: {
        products: "=",
        selectedProducts: "="
    },
    controller: ProductSelectionListCtrl
});
//(function (angular) {
//    var module = angular.module('demo', []);
//    module.controller('DemoCtrl', function ($scope) {
//        $scope.content = 'foobar';
//    });
//    module.directive('selectOnClick', ['$window', function ($window) {
//        // Linker function
//        return function (scope, element, attrs) {
//            element.bind('click', function () {
//                if (!$window.getSelection().toString()) {
//                    this.setSelectionRange(0, this.value.length)
//                }
//            });
//        };
//    }]);
//} (angular)); 
//app.directive('clickOutside', function ($document) {
//    return {
//        restrict: 'A',
//        scope: {
//            clickOutside: '&'
//        },
//        link: function (scope, el, attr) {
//            $document.on('click', function (e) {
//                if (el !== e.target && !el[0].contains(e.target)) {
//                    scope.$apply(function () {
//                        scope.$eval(scope.clickOutside);
//                    });
//                }
//            });
//        }
//    }
//}); 
//# sourceMappingURL=ed-product-selection-list.component.js.map