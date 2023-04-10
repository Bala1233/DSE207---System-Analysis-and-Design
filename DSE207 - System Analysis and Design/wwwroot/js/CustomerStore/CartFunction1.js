
$(function () {
 
    $drawerRight = $('.cart-drawer-right');
    $cart_list = $('.cart-btn, .close-btn');

    $cart_list.click(function () {
        $(this).toggleClass('active');
        $('.cart-drawer-push').toggleClass('cart-drawer-pushtoleft');
        $drawerRight.toggleClass('cart-drawer-open');
    });

    $(".site-header__cart").click(function () {
        $(".slideCart").show(200)
        $(".shadow").fadeIn(300)
        $(".shadow").click(function () {
            $(".slideCart").hide(200)
            $(".shadow").fadeOut(300)
        })
        $(".Drawer__Close").click(function () {
            $(".slideCart").hide(200)
            $(".shadow").fadeOut(300)
        })
    })
});


