$(function () {

    $(".statusBtn").click(function () {
        var btn = $(this);
        var productsId = $(this).attr("data-productId");
        $.ajax({
            type: "Get",
            url: "/AdminFunction/Admin_Status_True?ProductId=" + productsId,
            success: function (data) {
                btn.toggleClass("EnabledBtn1").toggleClass("DisableBtn1")
                var statusValue = data == true ? "Enable" : "Disable";
                btn.text(statusValue)
            }
        })
    })
})
