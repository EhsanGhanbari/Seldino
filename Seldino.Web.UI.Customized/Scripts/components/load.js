$(document).ready(function () {
    carousel3d();

    addCaptchaTo("#ContactForm");

    ajaxCaller();

    productsSettings();

    $("[data-is-price]").each(function () {
        $(this).digits();
    });

    gallery(".product-image-gallery .image-selected", ".product-image-gallery .items .item");

    gallery("#images .content", "#images .items .item");

    $(".product-container .buy").each(function () {
        $(this).attr("data-loading-text", "<i class=\"fa fa-spinner fa-spin\"><i>");
    });

    $("button[data-login]").click(function () {
        var form = $(this).closest(".login-form");
        var params = {
            Email: form.find("input[name='Email']").val(),
            Password: form.find("input[name='Password']").val(),
            RememberMe: form.find("input[name='RememberMe']").is(":checked"),
            ReturnUrl: form.find("input[name='ReturnUrl']").val()
        }
        $.post("/Account/SignIn", params).done(function (response) {
            if (!response.Failed) {
                if (params.ReturnUrl !== "") {
                    window.location.href = params.ReturnUrl;
                } else {
                    window.location.href = "/";
                }
            } else {
                toastr.error(response.Message);
                return false;
            }
        });
    });

    $("button.register").click(function () {
        var form = $(this).closest(".register-form");

        var command = {
            Email: form.find("input[name='Email']").val(),
            Password: form.find("input[name='Password']").val(),
            ConfirmPassword: form.find("input[name='ConfirmPassword']").val()
        }

        if (!isEmail(command.Email)) {
            toastr.error("ایمیل وارد شده صحیح نمیباشد");
        } else if (command.Password !== command.ConfirmPassword) {
            toastr.error("رمز عبور تکرار شده صحیح نمیباشد.");
        } else if (command.Password.length < 6) {
            toastr.error("رمز عبور نباید کوچک تر از 6 کاراکتر باشد.");
        }
        else {
            $.post("/Account/Register", command).done(function () {
                toastr.success("حساب کاربری شما با موفقیت ثبت گردید.");
                toastr.info("در حال ورود به فروشگاه هستید!");
                setTimeout(function() {
                    window.location.href = "/";
                }, 1000);
            });
        }
    });

    $(".rating i").each(function (i) {
        var index = i + 1;
        $(this).mouseenter(function () {
            switch (index) {
                case 1:
                    $(".rating i:nth-child(" + index + ")").removeClass("fa-star-o").addClass("fa-star fadeIn");
                    break;
                case 2:
                    $(".rating i:nth-child(1)").removeClass("fa-star-o").addClass("fa-star fadeIn");
                    $(".rating i:nth-child(" + index + ")").removeClass("fa-star-o").addClass("fa-star fadeIn");
                    break;
                case 3:
                    $(".rating i:nth-child(1)").removeClass("fa-star-o").addClass("fa-star fadeIn");
                    $(".rating i:nth-child(2)").removeClass("fa-star-o").addClass("fa-star fadeIn");
                    $(".rating i:nth-child(" + index + ")").removeClass("fa-star-o").addClass("fa-star fadeIn");
                    break;
                case 4:
                    $(".rating i:nth-child(1)").removeClass("fa-star-o").addClass("fa-star fadeIn");
                    $(".rating i:nth-child(2)").removeClass("fa-star-o").addClass("fa-star fadeIn");
                    $(".rating i:nth-child(3)").removeClass("fa-star-o").addClass("fa-star fadeIn");
                    $(".rating i:nth-child(" + index + ")").removeClass("fa-star-o").addClass("fa-star fadeIn");
                    break;
                case 5:
                    $(".rating i:nth-child(1)").removeClass("fa-star-o").addClass("fa-star fadeIn");
                    $(".rating i:nth-child(2)").removeClass("fa-star-o").addClass("fa-star fadeIn");
                    $(".rating i:nth-child(3)").removeClass("fa-star-o").addClass("fa-star fadeIn");
                    $(".rating i:nth-child(4)").removeClass("fa-star-o").addClass("fa-star fadeIn");
                    $(".rating i:nth-child(" + index + ")").removeClass("fa-star-o").addClass("fa-star fadeIn");
                    break;
            }
        }).mouseleave(function () {
            $(".rating i:nth-child(1)").removeClass("fa-star fadeIn").addClass("fa-star-o");
            $(".rating i:nth-child(2)").removeClass("fa-star fadeIn").addClass("fa-star-o");
            $(".rating i:nth-child(3)").removeClass("fa-star fadeIn").addClass("fa-star-o");
            $(".rating i:nth-child(4)").removeClass("fa-star fadeIn").addClass("fa-star-o");
            $(".rating i:nth-child(5)").removeClass("fa-star fadeIn").addClass("fa-star-o");
        });
    });

    $("*[data-rate]").click(function () {
        var score = $(this).data("rate");
        var id = $(this).data("id");
        var command = {
            ProductId: id,
            Score: score
        }
        $.post("/Product/RateProduct", command).done(function (response) {
            if (response.Success) {
                toastr.success(response.Message);
            } else {
                toastr.error(response.Message);
            }
        });
    });

    $("[data-content-more]").click(function() {
        var parent = $(this).closest(".content");
        parent.addClass("more");
    });

    $("[data-content-less]").click(function () {
        var parent = $(this).closest(".content");
        parent.removeClass("more");
    });
});