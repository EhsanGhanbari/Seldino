$("[data-side-nav]").click(function() {
    var side = $(this).data("side-nav");
    $(".side-nav[data-side='" + side + "']").addClass("open");
    $(".side-nav[data-side='" + side + "']").after("<div class=\"backdrop\"></div>");

    $(".backdrop").click(function () {
        $(".side-nav[data-side='" + side + "']").removeClass("open");
        $(this).remove();
    });
});

