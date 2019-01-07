$("[data-dropdown]").click(function() {
    $(this).find("[data-dropdown-menu]").toggleClass("open");
});

$("[data-dropdown-menu]").mouseleave(function () {
    $(this).removeClass("open");
});