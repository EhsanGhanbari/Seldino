$(".nav.nav-tabs div[role='presentation']").click(function () {
    $(".nav.nav-tabs div[role='presentation']").each(function() {
        $(this).removeClass("active");
    });
    $(this).addClass("active");
});