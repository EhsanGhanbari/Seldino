$(".carousel .carousel-inner .item:first-child").addClass("active");
$(".carousel .carousel-controllers .carousel-indicators-item:first-child").addClass("active");

$(".carousel .carousel-inner .item").each(function (index) {
    var num = index + 1;
    $(this).attr("data-index", num);
});

$(".carousel .carousel-controllers .carousel-indicators-item").each(function (index) {
    var num = index + 1;
    $(this).attr("data-slide-to", index);
    $(this).attr("data-index", num);
    $(this).find(".index").html("<span>" + num + "</span>");
});

$(".carousel .carousel-controllers .carousel-indicators-item").click(function () {
    $(".carousel .carousel-controllers .carousel-indicators-item").each(function () {
        $(this).removeClass("active");
    });
    $(this).addClass("active");
});




