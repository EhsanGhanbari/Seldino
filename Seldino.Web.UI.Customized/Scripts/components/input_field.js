$(".input-field input").each(function () {
    var hasValue = $(this).val();
    if (hasValue !== "") {
        $(this).closest(".input-field").addClass("active");
    }
});

$(".input-field input").focus(function () {
    $(this).closest(".input-field").addClass("active");
}).blur(function () {
    var hasValue = $(this).val();
    if (hasValue !== "") {
        $(this).closest(".input-field").addClass("active");
    } else {
        $(this).closest(".input-field").removeClass("active");
    }
});