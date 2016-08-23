jQuery(document).ready(function () {
    var offset = 100;
    var duration = 10;
    jQuery(window).scroll(function () {
        if (jQuery(this).scrollTop() > offset) {
            jQuery('.back-to-top').fadeIn(duration);
        }
        else {
            jQuery('.back-to-top').fadeOut(duration);
        }
    });
    jQuery('.back-to-top').click(function (event) {
        event.preventDefault();
        jQuery('html, body').animate({ scrollTop: 0 }, duration);
        return false;
    })
});


$(document).ready(function () {
    $(window).scroll(function () {
        console.log($(window).scrollTop())
        if ($(window).scrollTop() > 20) {
            $('#nav_bar').addClass('navbar-fixed');
        }
        if ($(window).scrollTop() < 21) {
            $('#nav_bar').removeClass('navbar-fixed');
        }
    });
});

$(document).ready(function () {
    // Show hide popover
    $(".dropdown").click(function () {
        $(this).siblings().find('.dropdown-menu').slideUp(-300);
        $(this).find(".dropdown-menu").slideToggle(-300);
    });
});
$(document).on("click", function (event) {
    var $trigger = $(".dropdown");
    if ($trigger !== event.target && !$trigger.has(event.target).length) {
        $(".dropdown-menu").slideUp(-300);
    }
});

$(document).ready(function () {
    $('.Show').click(function () {
        $('#target').show(500);
        $('.Show').hide(0);

    });
});
$(document).ready(function () {
    $('.toggle').click(function () {
        $('#target').slidetoggle(-300);
        $('#target').slideUp(-300);

    });
});

$(document).ready(function () {
    var randomstring = Math.random().toString(36).slice(-8);

});

function randomPassword() {
    var result = '';
    var possible='0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ';
    for (var i = length; i<5; i++) {
        result += possible.charAt[Math.floor(Math.random() * possible.length)];
        return result;
    }
    document.getElementsByClassName(getpwd).innerHTML = randomPassword();
}

    


