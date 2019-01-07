$(function () {
    $('a[href="#search"]').on("click", function (event) {
        event.preventDefault();
        $("#search").addClass("open");
        $('#search > div.form-holder > input[type="search"]').focus();
    });

    $("#search button.close").click(function() {
        $(this).closest("#search").removeClass("open");
    });
});