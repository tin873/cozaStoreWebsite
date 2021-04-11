var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btnContiniu').on('click', function () {
            console.log("hello")
            window.location.href = "/";
        });

        $("#btnUpdate").on('click', function () {
            var listProduct = $('.txtquantity');
            var cartList = [];
            $.each(listProduct, function (i, item) {
                cartList.push({
                    Quantity: $(item).val(),
                    Product: {
                        productID: $(item).data('id')
                    }
                });
            });
            console.log("hello");
            $.ajax({
                url: '/Cart/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart/Index"
                    }
                }
            });
        });
    }
}
cart.init();

