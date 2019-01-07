function gallery(content, items) {
    var defaultImage = $(content);
    var selectFirstImage = $(items + ":first-child").html();
    defaultImage.html(selectFirstImage);
    $(items).click(function () {
        var isImage = $(this).data("slider");
        var imageSelected = $(this).html();
        if (isImage) {
            defaultImage.html(imageSelected);
        }
    });
}

function isEmail(email) {
    var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email);
}

function inputNumberPlus() {
    var self = ".input-number .plus";

    $(self).click(function () {
        var inCart = $(self).parent().data("in-cart");
        var number = $(self).parent().find("input").val();
        if (inCart) {
            var price = $(self).closest("tr").find(".price").text();
            $(self).parent().find("input").val(parseInt(number) + 1);
            var newPrice = (parseInt(number) + 1) * parseInt(removeDigits(price));
            $(self).closest("tr").find(".row-sum").text(setDigits(newPrice));
            cartSum();
        } else {
            $(self).parent().find("input").val(parseInt(number) + 1);
        }
    });
}

function inputNumberMinus() {
    var self = ".input-number .minus";

    $(self).click(function () {
        var inCart = $(self).parent().data("in-cart");
        var number = $(self).parent().find("input").val();

        if (inCart) {
            var price = $(self).closest("tr").find(".price").text();
            if (parseInt(number) < 1) {
                $(self).closest("tr").find(".row-sum").text(0);
                $(self).closest("tr").fadeOut(500);
                cartSum();
                return false;
            } else {
                $(self).parent().find("input").val(parseInt(number) - 1);
                var newPrice = (parseInt(number) - 1) * parseInt(removeDigits(price));
                $(self).closest("tr").find(".row-sum").text(setDigits(newPrice));
                cartSum();
            }
        } else {
            if (parseInt(number) < 1) {
                return false;
            } else {
                $(self).parent().find("input").val(parseInt(number) - 1);
            }
        }
    });
}

function inputNumberChange() {
    var self = ".input-number input";

    $(self).bind("mousewheel", function (e) {
        var number = $(self).val();
        var price = $(self).closest("tr").find(".price").text();

        if (e.originalEvent.wheelDelta / 120 > 0) {
            var plus = (parseInt(number) + 1) * parseInt(removeDigits(price));
            $(self).closest("tr").find(".row-sum").text(setDigits(plus));
            cartSum();
        }
        else {
            var minus = (parseInt(number) - 1) * parseInt(removeDigits(price));
            $(self).closest("tr").find(".row-sum").text(setDigits(minus));
            cartSum();

            if (parseInt(number) <= 1) {
                $(self).closest("tr").find(".row-sum").text(0);
                $(self).closest("tr").fadeOut(500);
                cartSum();
                return false;
            }
        }
    });

    $(self).change(function () {
        var number = $(self).val();
        var price = $(self).closest("tr").find(".price").text();
        console.log(number);
        if (parseInt(number) < 1) {
            $(self).closest("tr").find(".row-sum").text(0);
            $(self).closest("tr").fadeOut(500);
            cartSum();
            return false;
        } else {
            var newPrice = parseInt(number) * parseInt(removeDigits(price));
            $(self).closest("tr").find(".row-sum").text(setDigits(newPrice));
            cartSum();
        }
    });
}

function setDigits(amount) {
    var toString = amount.toString();
    return toString.replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,");
}

function removeDigits(amount) {
    return amount.replace(/[^0-9\.]+/g, "");
}

function cartSum() {
    var sum = 0;
    $("#showProducts table td.row-sum").each(function () {
        var value = removeDigits($(this).text());
        sum += parseInt(value);
    });
    $(".sum").text(setDigits(sum));
}

function addCaptchaTo(form) {
    var captchaActivator = $(form).data("captcha");
    var template = "<div class=\"captcha-circle animated\"></div><div class=\"captcha-text\">من ربات نیستم</div>";

    $(form).find("*[type='submit']").hide();

    if (captchaActivator) {
        $(form).find(".captcha").append(template);

        $(".captcha").click(function () {
            $(this).find(".captcha-circle").addClass("active");
            $(this).find(".captcha-circle").one("webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend", function () {
                $(".captcha").fadeOut();
                $(form).find("*[type='submit']").fadeIn();
            });
        });
    }
}

function product(id) {
    var specialOffer = $("#" + id).data("specialoffer");
    var notExist = $("#" + id).data("notexist");

    specialOffer === "False" ? specialOffer = false : specialOffer = true;
    notExist === "False" ? notExist = false : notExist = true;

    if (specialOffer) {
        $("#" + id).find(".corner-ribbon").addClass("special-offer");
    }

    if (notExist) {
        $("#" + id).find(".clock").hide();
        $("#" + id).find(".carousel3d").addClass("disabled");
        $("#" + id).addClass("disabled");
        $("#" + id).find(".corner-ribbon").addClass("not-exist");
    }
}

function productsSettings() {
    $(".product-container").each(function () {
        var id = $(this).attr("id");
        product(id);
    });
}

function startCountDown(id, date) {
    var currentDate = new Date();

    var dateToEnd = date;

    var targetDate = new Date(dateToEnd);

    var diff = targetDate.getTime() / 1000 - currentDate.getTime() / 1000;

    if (diff < 0) {
        return;
    }
    $("#" + id + " .clock").FlipClock(diff, {
        clockFace: "HourlyCounter",
        countdown: true,
        callbacks: {
            stop: function () {
                $("#" + id + " .buy").hide();
                $("#" + id + " .information").show();
                $("#" + id + " .clock").fadeOut();
            }
        }
    });
}

function productExist(inArr, id, exists) {
    for (i = 0; i < inArr.length; i++) {
        if (inArr[i].id == id) {
            return (exists === true) ? true : inArr[i];
        }
    }
}

function deleteProduct(inArr, id, exists) {
    for (i = 0; i < inArr.length; i++) {
        if (inArr[i].id == id) {
            if (exists === true) {
                inArr.splice(i, 1);
            }
        }
    }
}

function modifyCartCount(up, value) {
    var number = parseInt($("#CartCount").html());
    if (up) {
        $("#CartCount").html(number + value);
    } else {
        $("#CartCount").html(number - value);
    }
}

function cartCounting(value) {
    var ssm = $("#CartCount").data("server-side-mode");
    if (ssm === undefined) {
        $("#CartCount").html(value);
    }
}

function addToCartFromDetails() {
    $(".buyIt").click(function () {
        var userId = $("input#userInfo").val();
        var productId = $(this).data("product");
        var productImage = $(this).data("image");
        var productName = $(this).data("name");
        var productPrice = $(this).data("price");
        var productDesc = $(this).data("desc");
        var number = $("#product_number").val();

        var addProductToBasket = {
            id: productId,
            name: productName,
            price: productPrice,
            desc: productDesc,
            image: productImage
        }

        var exist = productExist(basket, productId, true);

        if (exist !== true) {
            var $btn = $(".buy").button("loading");
            basket.push(addProductToBasket);
            localStorage.setItem("basket", JSON.stringify(basket));

            $(".basketHasItems").show();

            $(".basketIsEmpty").hide();

            var table = $(".basketHasItems .scroller table.table");
            var sum = parseInt(removeDigits(productPrice)) * parseInt(number);
            var template = "<tr id=\"" + productId + "\">" +
            "<td class=\"col-lg-1\">" +
            "<img src=\"" + productImage + "\" alt=\"" + productName + "\">" +
            "</td>" +
            "<td class=\"col-lg-4\">" +
            "<b>" + productName + "</b>" +
            "</td>" +
            "<td class=\"col-lg-2 price amount\">" + productPrice + "</td>" +
            "<td class=\"col-lg-2 number\">" + number + "</td>" +
            "<td class=\"col-lg-2 row-sum amount\">" + setDigits(sum) + "</td>" +
            "<td class=\"col-lg-1\">" +
            "<a href=\"#delete\" data-id=\"" + productId + "\">حذف</a>" +
            "</td>" +
            "</tr>";

            table.append(template);
            cartCounting(basket.length);
            cartSum();

            var command = {
                ProductIds: [productId],
                UserId: userId !== " " ? userId : "00000000-0000-0000-0000-000000000000",
                Quantity: number,
                isGuest: userId !== " " ? false : true
            }

            $.post("/Basket/AddItem", command).done(function (response) {
                if (response.Success) {
                    toastr.success(response.Message);
                } else {
                    toastr.error(response.Message);
                }
                $btn.button("reset");
            }).error(function () {
                toastr.error("مشکل در ارتباط با سرور، مجدداً تلاش نمایید");
                $btn.button("reset");
            });

            $("a[href='#delete']").click(function () {
                var id = $(this).data("id");
                table.find("#" + id).remove();
                deleteProduct(basket, id, true);
                cartCounting(basket.length);
                localStorage.setItem("basket", JSON.stringify(basket));
                cartSum();
                if (hasItem.length === 0) {
                    $(".basketHasItems").hide();
                    $(".basketIsEmpty").show();
                    localStorage.removeItem("basket");
                }
            });
        } else {
            toastr.info("محصول مورد نظر در سبد خرید شما موجود میباشد");
        }
    });
}

function updateBasket() {
    $.get("/Basket/ShowBasket", { PageIndex: 1, PageSize: 100 }).done(function (data) {
        $("#card").html(data);
        deleteFromCart();
        $("[data-is-price]").each(function () {
            $(this).digits();
        });
    });
}

function addToCart() {
    $(".buy").click(function () {
        var $btn = $(".buy").button("loading");
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
}

function deleteFromCart() {
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
}

function searchEffect() {
    $("#search_block_top").each(function () {
        $(".open-search").click(function () {
            $(".over-layer,.block-form,.close-overlay").addClass("active");
        });
    });
    $(".close-overlay").click(function () {
        $(".over-layer,.block-form,.close-overlay").removeClass("active");
    });
}

function customDropDown() {
    $("li.dropdown").click(function () {
        var menu = $(this).find(".dropdown-menu-full");

        menu.fadeIn(function () {
            menu.addClass("active");
        });

        menu.mouseleave(function () {
            menu.fadeOut();
            menu.removeClass("active");
        });
    });
}

function carouselSettings() {
    var length = $(".carousel-indicators div.carousel-indicators-item").length;

    if (length === 0) {
        $("#carousel-thum").hide();
    }

    $(".carousel-inner .item:first-child").addClass("active");
    $(".carousel-indicators div.carousel-indicators-item:first-child").addClass("active");

    $(".carousel-indicators div.carousel-indicators-item").each(function (index) {
        $(this).attr("data-slide-to", index);
        $(this).find(".number").text(index + 1);
    });
}

function sideNavBarSettings() {
    $(".button-collapse").sideNav({
        menuWidth: 400,
        edge: "right",
        closeOnClick: true
    });
}

$.fn.digits = function () {
    return this.each(function () {
        $(this).text($(this).text().replace(/(\d)(?=(\d\d\d)+(?!\d))/g, "$1,"));
    });
}

function forgotPassword() {
    $("form[name='ForgotPassword'] button").click(function () {
        var form = $(this).closest("form");
        var email = form.find("input#Email").val();
        var url = form.data("url");
        var messages = form.find(".alert");
        var command = {
            Email: email
        }

        $.post(url, command).success(function (response) {
            if (response.Success) {
                messages.addClass("alert-success").html(response.Message);
            } else {
                messages.addClass("alert-danger").html(response.Message);
            }
        });

    });
}

function ajaxCaller() {
    $("[data-ajax-default]").each(function () {
        var action = $(this).data("ajax-call");
        var id = $(this).data("ajax-id");
        var body = $(this).data("ajax-to");
        $.get(action).done(function (data) {
            $("[data-ajax-body='" + body + "']").find("[data-ajax-bind='" + id + "']").html(data);
            $(".product-container .buy").each(function () {
                $(this).attr("data-loading-text", "<i class=\"fa fa-spinner fa-spin\"><i>");
            });
            carousel3d();
            addToCart();
            $("[data-is-price]").each(function () {
                $(this).digits();
            });
        });
    });

    $("[data-ajax-call]").click(function () {
        var action = $(this).data("ajax-call");
        var id = $(this).data("ajax-id");
        var body = $(this).data("ajax-to");
        $.get(action).done(function (data) {
            $("[data-ajax-body='" + body + "']").find("[data-ajax-bind='" + id + "']").html(data);
            $(".product-container .buy").each(function () {
                $(this).attr("data-loading-text", "<i class=\"fa fa-spinner fa-spin\"><i>");
            });
            carousel3d();
            addToCart();
            $("[data-is-price]").each(function () {
                $(this).digits();
            });
        });
    });
}

