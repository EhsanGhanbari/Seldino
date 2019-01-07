function carousel3d() {
    $(".carousel3d").each(function () {
        if ($(this).hasClass("disabled")) {
            return;
        }
        var liLength = $(this).find("li").length;

        if (liLength > 3) {
            for (var i = 0; i < liLength; i++) {
                if (i > 2) {
                    $(this).find("li:nth-child(" + i + ")").remove();
                }
            }
        }

        if (liLength === 0) {
            $(this).addClass("empty");
        }

        if (liLength === 1) {
            $(this).find("li:nth-child(1)").addClass("item2");
        } else {
            $(this).find("li:nth-child(1)").addClass("item1");
            $(this).find("li:nth-child(2)").addClass("item2");
            $(this).find("li:nth-child(3)").addClass("item3");
        }

    });

    //$(".carousel3d li").each(function() {
    //    var img = $(this).find("img").attr("src");
    //    console.log(img)
    //})

    $(".carousel3d li").click(function () {
        if ($(this).closest(".carousel3d").hasClass("disabled")) {
            return;
        }else{
            var items = $(this).parent().data("items");

            var self = $(this);
            var selfClass = self.attr("class");
            var effectedRight = self.data("effectedRight");
            var effectedLeft = self.data("effectedLeft");
            if (items === 3) {
                switch (selfClass) {
                    case "item1":
                        if (effectedLeft) {
                            $(this).parent().find("li:nth-child(1)").removeClass().addClass("item1");
                            $(this).parent().find("li:nth-child(2)").removeClass().addClass("item2");
                            $(this).parent().find("li:nth-child(3)").removeClass().addClass("item3");
                        } else {
                            self.removeClass().addClass("item2");
                            $(this).parent().find("li:nth-child(2)").removeClass().addClass("item3").data("effectedRight", true).data("effectedLeft", false);
                            $(this).parent().find("li:nth-child(3)").removeClass().addClass("outRight");
                        }
                        break;
                    case "item3":
                        if (effectedRight) {
                            $(this).parent().find("li:nth-child(1)").removeClass().addClass("item1");
                            $(this).parent().find("li:nth-child(2)").removeClass().addClass("item2");
                            $(this).parent().find("li:nth-child(3)").removeClass().addClass("item3");
                        } else {
                            self.removeClass().addClass("item2");
                            $(this).parent().find("li:nth-child(2)").removeClass().addClass("item1").data("effectedRight", false).data("effectedLeft", true);
                            $(this).parent().find("li:nth-child(1)").removeClass().addClass("outLeft");
                        }
                        break;
                }
            }
        }
    });
}