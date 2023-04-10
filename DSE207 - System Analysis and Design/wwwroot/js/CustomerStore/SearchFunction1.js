
function searchToggle(obj, evt) {
    var container = $(obj).closest('.search-wrapper');
    if (!container.hasClass('active')) {
        container.addClass('active');
        evt.preventDefault();
    }
    else if (container.hasClass('active') && $(obj).closest('.input-holder').length == 0) {
        container.removeClass('active');
        // clear input
        container.find('.search-input').val('');
    }
}

$(function () {

    //$("#searchBar").keypress(function (event) {
    //    //Detect Enter Key
    //    var keycode = (event.keyCode ? event.keyCode : event.which);
    //    // 'Enter' == keycode = 13
    //    if (keycode == '13') {

    //        var searchName = $("#searchBar").val();
    //        location.href = "/CustomerStore/AzurLanePage?Search=" + searchName

    //    }
    //})
    //$("#SearchIcon").click(function (event) {

    //    var searchName = $("#searchBar").val();
    //    location.href = "/CustomerStore/ForFilterAzurLanePage?Search=" + searchName

    //})
})

