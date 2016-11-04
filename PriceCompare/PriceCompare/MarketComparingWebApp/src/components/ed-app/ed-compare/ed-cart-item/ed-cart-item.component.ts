class CartItemCtrl {

    constructor() {
    }

}

app.component("edCartItem",
    {
        templateUrl: "src/components/ed-app/ed-compare/ed-cart-item/ed-cart-item.component.html",
        bindings: {
            cart: "<",
            carts: "<"
        },
        controller: MainCtrl
    });