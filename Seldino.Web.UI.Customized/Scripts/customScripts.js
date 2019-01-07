$(document).ready(function () {
    //carousel3d();

    //addToCart();

    //addToCartFromDetails();

    //forgotPassword();

    //addCaptchaTo("#ContactForm");

    ////cartSum();

    //$(".amount").digits();

    ////inputNumberPlus();

    ////inputNumberMinus();

    //inputNumberChange();

    //searchEffect();

    //$('[data-toggle="tooltip"]').tooltip({ animation: true, delay: { show: 300, hide: 300 } });

    //customDropDown();

    //carouselSettings();

    //gallery(".product-image-gallery .image-selected", ".product-image-gallery .items .item");

    //gallery("#images .content", "#images .items .item");

    //productsSettings();

    //sideNavBarSettings();

    //$("a[href='#delete']").click(function () {
    //    var table = $(".basketHasItems .scroller table.table");
    //    var id = $(this).data("id");
    //    table.find("#" + id).remove();
    //    basket.splice(id, 1);
    //    cartCounting(basket.length);
    //    localStorage.setItem("basket", JSON.stringify(basket));
    //    if (basket.length === 0) {
    //        $(".basketHasItems").hide();
    //        $(".basketIsEmpty").show();
    //        localStorage.removeItem("basket");
    //    } else {
    //        $(".basketHasItems").show();
    //        $(".basketIsEmpty").hide();
    //    }
    //});

    //$(".range-field").each(function () {
    //    var defaultValue = $(this).find("input[type='range']").val();
    //    $(".range-field .bind-range").html("<b>" + defaultValue + "</b>");

    //    $(this).find("input[type='range']").change(function () {
    //        var value = $(this).val();
    //        $(".range-field .bind-range").html("<b>" + value + "</b>");
    //    });
    //});

    //$(".rating i").each(function (i) {
    //    var index = i + 1;
    //    $(this).mouseenter(function () {
    //        switch (index) {
    //            case 1:
    //                $(".rating i:nth-child(" + index + ")").removeClass("fa-star-o").addClass("fa-star fadeIn");
    //                break;
    //            case 2:
    //                $(".rating i:nth-child(1)").removeClass("fa-star-o").addClass("fa-star fadeIn");
    //                $(".rating i:nth-child(" + index + ")").removeClass("fa-star-o").addClass("fa-star fadeIn");
    //                break;
    //            case 3:
    //                $(".rating i:nth-child(1)").removeClass("fa-star-o").addClass("fa-star fadeIn");
    //                $(".rating i:nth-child(2)").removeClass("fa-star-o").addClass("fa-star fadeIn");
    //                $(".rating i:nth-child(" + index + ")").removeClass("fa-star-o").addClass("fa-star fadeIn");
    //                break;
    //            case 4:
    //                $(".rating i:nth-child(1)").removeClass("fa-star-o").addClass("fa-star fadeIn");
    //                $(".rating i:nth-child(2)").removeClass("fa-star-o").addClass("fa-star fadeIn");
    //                $(".rating i:nth-child(3)").removeClass("fa-star-o").addClass("fa-star fadeIn");
    //                $(".rating i:nth-child(" + index + ")").removeClass("fa-star-o").addClass("fa-star fadeIn");
    //                break;
    //            case 5:
    //                $(".rating i:nth-child(1)").removeClass("fa-star-o").addClass("fa-star fadeIn");
    //                $(".rating i:nth-child(2)").removeClass("fa-star-o").addClass("fa-star fadeIn");
    //                $(".rating i:nth-child(3)").removeClass("fa-star-o").addClass("fa-star fadeIn");
    //                $(".rating i:nth-child(4)").removeClass("fa-star-o").addClass("fa-star fadeIn");
    //                $(".rating i:nth-child(" + index + ")").removeClass("fa-star-o").addClass("fa-star fadeIn");
    //                break;
    //        }
    //    }).mouseleave(function () {
    //        $(".rating i:nth-child(1)").removeClass("fa-star fadeIn").addClass("fa-star-o");
    //        $(".rating i:nth-child(2)").removeClass("fa-star fadeIn").addClass("fa-star-o");
    //        $(".rating i:nth-child(3)").removeClass("fa-star fadeIn").addClass("fa-star-o");
    //        $(".rating i:nth-child(4)").removeClass("fa-star fadeIn").addClass("fa-star-o");
    //        $(".rating i:nth-child(5)").removeClass("fa-star fadeIn").addClass("fa-star-o");
    //    });
    //});

    //$("*[data-rate]").click(function () {
    //    var score = $(this).data("rate");
    //    var id = $(this).data("id");
    //    var command = {
    //        ProductId: id,
    //        Score: score
    //    }
    //    $.post("/Product/RateProduct", command).done(function (response) {
    //        if (response.Success) {
    //            toastr.success(response.Message);
    //        } else {
    //            toastr.error(response.Message);
    //        }
    //    });
    //});

    //deleteFromCart();

    //$("[data-submit]").click(function () {
    //    var refer = $(this).data("refer");
    //    var action = $("#" + refer).data("action");
    //    var values = $("#" + refer).data("command").split(",");
    //    var command = {};
    //    $.each(values, function (index, item) {
    //        command[item] = $("#" + refer + " input[name=" + item + "]").val();
    //    });
    //    $.post(action, command).done(function (response) {
    //        if (response.Success) {
    //            toastr.success(response.Message);
    //        } else {
    //            toastr.error(response.Message);
    //        }
    //    });
    //});

    //$("[data-ajax-default]").each(function () {
    //    var action = $(this).data("ajax-call");
    //    var id = $(this).data("ajax-id");
    //    var body = $(this).data("ajax-to");
    //    $.get(action).done(function (data) {
    //        $("[data-ajax-body='" + body + "']").find("[data-ajax-bind='" + id + "']").html(data);
    //        carousel3d();
    //    });
    //});

    //$("[data-ajax-call]").click(function () {
    //    var action = $(this).data("ajax-call");
    //    var id = $(this).data("ajax-id");
    //    var body = $(this).data("ajax-to");
    //    $.get(action).done(function (data) {
    //        $("[data-ajax-body='" + body + "']").find("[data-ajax-bind='" + id + "']").html(data);
    //        carousel3d();
    //    });
    //});

    //$("button.login").click(function () {
    //    var form = $(this).closest(".login-form");
    //    var params = {
    //        Email: form.find("input[name='Email']").val(),
    //        Password: form.find("input[name='Password']").val(),
    //        RememberMe: form.find("input[name='RememberMe']").is(":checked"),
    //        ReturnUrl: form.find("input[name='ReturnUrl']").val()
    //    }
    //    $.post("/Account/SignIn", params).done(function (response) {
    //        if (!response.Failed) {
    //            if (params.ReturnUrl !== "") {
    //                window.location.href = params.ReturnUrl;
    //            } else {
    //                window.location.href = "/";
    //            }
    //        } else {
    //            toastr.error(response.Message);
    //            return false;
    //        }
    //    });
    //});

    //$("button.register").click(function () {
    //    var form = $(this).closest(".register-form");

    //    var command = {
    //        Email: form.find("input[name='Email']").val(),
    //        Password: form.find("input[name='Password']").val(),
    //        ConfirmPassword: form.find("input[name='ConfirmPassword']").val()
    //    }

    //    if (!isEmail(command.Email)) {
    //        toastr.error("ایمیل وارد شده صحیح نمیباشد");
    //    } else if (command.Password !== command.ConfirmPassword) {
    //        toastr.error("رمز عبور تکرار شده صحیح نمیباشد.");
    //    } else if (command.Password.length < 6) {
    //        toastr.error("رمز عبور نباید کوچک تر از 6 کاراکتر باشد.");
    //    }
    //    else {
    //        $.post("/Account/Register", command).done(function (x) {
    //            toastr.success("حساب کاربری شما با موفقیت ثبت گردید.");
    //            toastr.info("در حال ورود به فروشگاه هستید!");
    //            var params = {
    //                Email: command.Email,
    //                Password: command.Password,
    //                RememberMe: false,
    //                ReturnUrl: ""
    //            }
    //            $.post("/Account/SignIn", params).done(function (response) {
    //                if (!response.Failed) {
    //                  window.location.href = "/";
    //                }
    //            });
    //        });
    //    }
    //});
});