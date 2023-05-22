$(window).on("load", function () {
    if ($(window).width() < 768) {
        if ($(".carousel-gallery").children().length >= 2) {
            $(".carousel-gallery").flickity({
                contain: !0,
                cellAlign: "left",
                pageDots: !1,
                prevNextButtons: !1,
                autoPlay: 2e3,
                pauseAutoPlayOnHover: !1,
                wrapAround: !0,
            });
        }
        else {
            $(".carousel-gallery").flickity({
                contain: !0,
                cellAlign: "center",
                pageDots: !1,
                prevNextButtons: !1,
                pauseAutoPlayOnHover: !1,
                wrapAround: !1,
            });
        }
    }
    else if (($(window).width() > 767) && ($(window).width() < 992)) {
        if ($(".carousel-gallery").children().length >= 3) {
            $(".carousel-gallery").flickity({
                contain: !0,
                cellAlign: "left",
                pageDots: !1,
                prevNextButtons: !1,
                autoPlay: 2e3,
                pauseAutoPlayOnHover: !1,
                wrapAround: !0,
            });
        }
        else {
            $(".carousel-gallery").flickity({
                contain: !0,
                cellAlign: "center",
                pageDots: !1,
                prevNextButtons: !1,
                pauseAutoPlayOnHover: !1,
                wrapAround: !1,
            });
        }
    }
    else if (($(window).width() > 991) && ($(window).width() < 1201)) {
        if ($(".carousel-gallery").children().length >= 4) {
            $(".carousel-gallery").flickity({
                contain: !0,
                cellAlign: "left",
                pageDots: !1,
                prevNextButtons: !1,
                autoPlay: 2e3,
                pauseAutoPlayOnHover: !1,
                wrapAround: !0,
            });
        }
        else {
            $(".carousel-gallery").flickity({
                contain: !0,
                cellAlign: "center",
                pageDots: !1,
                prevNextButtons: !1,
                pauseAutoPlayOnHover: !1,
                wrapAround: !1,
            });
        }
    }
    else if ($(window).width() > 1201) {
        if ($(".carousel-gallery").children().length >= 5) {
            $(".carousel-gallery").flickity({
                contain: !1,
                cellAlign: "left",
                pageDots: !1,
                prevNextButtons: !1,
                autoPlay: 2e3,
                pauseAutoPlayOnHover: !1,
                wrapAround: !0,
            });
        }
        else {
            $(".carousel-gallery").flickity({
                contain: !0,
                cellAlign: "center",
                pageDots: !1,
                prevNextButtons: !1,
                pauseAutoPlayOnHover: !1,
                wrapAround: !1,
            });
        }
    };
    if ($(window).width() < 768) {
        $(".toggle-link").each(function () {
            let e = $(this);
            e.on("click", function () {
                var p = e.parent();
                e.toggleClass("active");
                e.parent().find(".list-toggle").slideToggle();
            })
        })
    };
    if ($(".carousel-category").children().length <= 5) {
        $(".carousel-category").flickity({
            contain: !0,
            cellAlign: "left",
            pageDots: !1,
            prevNextButtons: !1,
        })
    }
    else {
        $(".carousel-category").flickity({
            contain: !0,
            cellAlign: "left",
            pageDots: !0,
        })
    };
    
    $(".content-post").each(function(){
        let e = $(this);
        let iframe = e.find("iframe");
        iframe.parent().addClass("has-iframe");
    })
    $(".content-ellips").each(function () {
        let e = $(this);
        console.log(e.height());
        let parent = e.parent();
        if (e.height() >= 1200) {
          e.addClass("text-over");
          parent.find(".btn-toggle-content").removeClass("hidden");
        } else {
          e.removeClass("text-over");
          parent.find(".btn-toggle-content").addClass("hidden");
        }
      });
})