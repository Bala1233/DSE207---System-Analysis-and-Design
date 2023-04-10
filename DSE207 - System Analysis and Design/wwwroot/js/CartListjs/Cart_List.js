$(function () {

    $("#GotoStorePage").click(function () {
        location.href = "/CustomerStore/MerchandisePage"

    })

    $("#LinktoPeyment").click(function () {
        var ItemCount = $(".Item_Cart_Count").text().split(" ")[0]
        if (parseInt(ItemCount) == 0) {
            return;
        } else {
            var Payment = parseFloat(document.getElementById("GrandTotal").innerHTML)
            var Subtotal = document.getElementById("SubTotal").innerHTML
            Subtotal = Subtotal.slice(1)
            location.href = "/Payment/PaymentCheckoutPage?GrandTotal=" + Payment + "&SumToal=" + Subtotal
        }
    })


    var TotalPrice = 0;


    //准备用J-Query
    function GetTotal() {
        $.ajax({
            type: "GET",
            url: "/CartListFunction/TotalPrice",
            success: function (data) {

                $("#SubTotal").html("$" + data)

                $("#GrandTotal").html(parseFloat(data) + parseFloat($("#DeliveryOpt").val()))
            }
        })
    }
    GetTotal()
    //click的function
    $('.Plus').click(function () {
        var cartid = $(this).val()
        $.ajax({
            //传去后台
            type: "POST",
            //传去后台的哪里
            url: "/CustomerStoreFunction/AddQtyFunction",
            //传的资料
            data: { CartId: $(this).val() },
            success: function (data) {

                $("#Display-" + cartid).val(data)

                $("#Display-" + cartid).prev().attr('disabled', false)
                GetTotal()

            }
        })
    })
    $('.Minus').click(function () {

        var cartid = $(this).val();

        $.ajax({
            type: "POST",
            url: "/CustomerStoreFunction/MinusQtyFunction",
            data: { CartId: $(this).val() },
            success: function (data) {

                $("#Display-" + cartid).val(data)
                if (data == 1) {
                    $("#Display-" + cartid).prev().attr('disabled', true)
                }
                GetTotal()
            }
        })

    })
    $(".qtyinput").change(function () {
        var id = $(this).attr("id")
        var cartid = id.split("Display-")[1]
        var qty = $(this).val()
        $.ajax({
            type: "POST",
            url: "/CartListFunction/CheckQty",
            data: { Qty: qty, CartId: cartid },
            success: function (data) {
                if (data.split('/')[0] == "Stock Invalid") {
                    $("#Display-" + cartid).val(data.split('/')[1])
                    $("#Display-" + cartid).prev().attr('disabled', false)
                }
                if (data == "Invalid Number") {
                    $("#Display-" + cartid).val(1)
                    $("#Display-" + cartid).prev().attr('disabled', true)
                }
                // alert(data.split('/')[1])
                //$(".qtyinput").val(data)
                GetTotal()
            }
        })
    })
    $("#DeliveryOpt").change(function () {

        GetTotal()
    })
    $(".transhicon").click(function () {
        var cartid = $(this).attr("data-cartId")
        $(this).parent().next().fadeIn()
        //$(this).fadeOut()

        $(".btn_Confirmation").click(function () {
            var thisValue = $(this).val();

            //if Yes, remove
            if (thisValue == "y") {
                var cartid = $(this).attr("data-cartId")
                //here is display remove

                //here for Ajax delete from cart
                //$(this).remove();
                $.ajax({
                    type: "GET",
                    url: `/CustomerStoreFunction/CartRemoveAjax`,
                    data: { CartId: cartid },
                    success: function (data) {
                        if (data == "Remove") {
                            $(`#Display-${cartid}`).parent().parent().remove();

                        }
                        GetTotal()
                        $.ajax({
                            type: "GET",
                            url: "/CartListFunction/Cehcking_CartList_Items",
                            success: function (data) {
                                $(".Item_Cart_Count").html(data + " Item")
                                if (data == 0) {

                                    $(".CheckOutBtn").css("display", "none")
                                    $("#No_Items_Img").html("")
                                    $("#No_Items_Img").append(`
                    <img src="https://www.dlinkmea.com/images/no-product.png" /> `)
                                }
                            }
                        })
                    }
                })

            } else {
                //confirmation fadeOut
                $(this).parents(".confirmation").fadeOut(400, function () {
                    //fadeOut complete,
                    //Product content fadeIn

                })
            }
        })




    })

})