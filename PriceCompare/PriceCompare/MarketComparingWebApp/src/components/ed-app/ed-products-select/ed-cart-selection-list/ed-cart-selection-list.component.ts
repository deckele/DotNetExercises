﻿class CartSelectionListCtrl {
    onProductChanged: Function;
}

app.component("edCartSelectionList",
    {
        templateUrl: "src/components/ed-app/ed-products-select/ed-cart-selection-list/ed-cart-selection-list.component.html",
        bindings: {
            selectedProducts: "=",
            onProductChanged: "&"
        },
        controller: CartSelectionListCtrl
    });