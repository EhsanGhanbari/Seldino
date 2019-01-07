$("[data-add-to-card]").click(function () {
    var $btn = $(this).button("loading");
    var productId = $(this).data("product-id");

    ///*go to command*/
    var command = {
        ProductIds: [productId],
        Quantity: 1
    }

    $.post("/Basket/AddItem", command).done(function (response) {
        if (response.Success) {
            $btn.button("reset");
            toastr.success(response.Message);
            updateBasket();
        } else {
            toastr.error(response.Message);
        }
    }).error(function () {
        toastr.error("مشکل در ارتباط با سرور، مجدداً تلاش نمایید");
    });
});

$("[data-remove-id]").click(function () {
    var id = $(this).data("remove-id");
    var command = {
        ProductIds: [id]
    }

    $.post("/Basket/RemoveItem", command).done(function (response) {
        if (response.Success) {
            window.location.reload();
            toastr.success(response.Message);
        } else {
            toastr.error(response.Message);
        }
    });
})