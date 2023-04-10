$(function () {

    //Giving Cart Icon id == "open-panel" declare to openPanelButton
    //Giving the close icon id =="close-panel" declare to closePanelButton
    var openPanelButton = $("#open-panel,.cartCountBg");
    var closePanelButton = $("#close-panel");
    var cartPanel = $(".cart-panel");

    openPanelButton.click(function () {
        $(" .cartShadow").fadeIn(300)
        cartPanel.addClass("open");
        openPanelButton.addClass("hide")
    })
    closePanelButton.click(function () {
        $(" .cartShadow").fadeOut(200)
        cartPanel.removeClass("open");
        openPanelButton.removeClass("hide");
    })

    $.ajax({
        type: "GET",
        url: "/CustomerStoreFunction/SmallCartList",
        success: function (data) {
            console.log(data)
            $.each(data, function (count, pair) {
                //console.log(pair)

                $("#SmallCartList").append(`
                     <div class="product side_ProductName">
        <!-- Product Image -->

        <img width="80" src="${pair.product.productImg1}" alt="${pair.product.productImg1}">
        <div style="padding:8px">
            <!-- Product Name -->
            <span class="side_cart_productName">
                ${pair.product.productName}
                <br />
                <!-- Product Price -->
                <strong style="font-size:18px;">Total Price:  $ ${pair.product.disPrice}</strong>
            </span>
            <br />
            <span class="side_cart_productName">
                <!-- Product Quantity -->
                Quantity :
            </span>
            <!-- Minus button -->

            <i data-CartId="${pair.cart.cartId}" style="margin-left:5px;" class="qtyBtn fa fa-minus"></i>
            <!-- this cart row quantity -->
            <input id="DiaplayValue" readonly style="font-size:18px;margin:10px;background-color:transparent;width:50px;color:white"
                   class="fontContent CartListQty-${pair.cart.cartId}" value="${pair.cart.qty}" />
            
            <!-- Plus button -->
            <i data-CartId="${pair.cart.cartId}" class=" qtyBtn fa fa-plus"></i>

            <br />
            <span id="cart_Row_Error_Msg-${pair.cart.customerId}" style="color:rgba(0, 133, 170, 1)"></span>
        </div>
        <div class="confirmation" style="padding:8px; display:none;text-align:center;">
            <span style="color:rgba(0, 133, 170, 1);font-size:18px;">Do you want to remove</span>
            <br>
            <h5 style="color:white">
                ${pair.product.productName}
            </h5>
            <div style="width:100%;justify-content:space-evenly;display:flex">
                <button data-cartId="${pair.cart.cartId}" value="y" style="color:white" class="btn btn-black btn_Confirmation fontAorus">Yes</button>
                <button value="n" style="color:white" class="btn btn-black btn_Confirmation fontAorus">No</button>

            </div>

        </div>
        <!-- trash icon/delete icon-->
        <i data-CartId="" class="side_cart_row_delete fa fa-trash side-cart-trash-icon"></i>
    </div>
    <!-- end of each product row -->
                                `)
            })

            //When Click the minus button
            $(".fa-minus").click(function () {
                //Get Cart Row Id
            
                var cart_row_Id = $(this).attr("data-CartId");
                if ($(".CartListQty-" + cart_row_Id).val() == 1) {
                    return;
                }
                //Ajax
                $.ajax({
                    type: "POST",
                    url: "/CustomerStoreFunction/MinusQtyFunction",
                    data: { CartId: cart_row_Id },
                    success: function (data) {
                        $(".CartListQty-" + cart_row_Id).val(data)

                    }
                })

            })
            //When Click the plus button
            $(".fa-plus").click(function () {
                //Get Cart Row Id
                var cart_row_Id = $(this).attr("data-CartId");

                //Ajax
                $.ajax({
                    type: "POST",
                    url: "/CustomerStoreFunction/AddQtyFunction",
                    data: { CartId: cart_row_Id },
                    success: function (data) {
                        $(".CartListQty-" + cart_row_Id).val(data)

                    }
                })
            })
            //When click the trash icon
            $(".side_cart_row_delete").click(function () {
                //this icon last two element == Product content fadeOut
                $(this).prev().prev().fadeOut(400, function () {
                    //fadeOut complete, 
                    //delete confirmation fadeIn
                    $(this).next().fadeIn(400)
                    //after fadeIn declare a function for btn Confirmation
                    $(".btn_Confirmation").click(function () {
                        var thisValue = $(this).val();

                        //if Yes, remove
                        if (thisValue == "y") {
                            var cartid = $(this).attr("data-CartId")

                            //here is display remove
                            $(this).parents(".side_ProductName").fadeOut(400, function () {
                                //here for Ajax delete from cart
                                //$(this).remove();
                                $.ajax({
                                    type: "GET",
                                    url: `/CustomerStoreFunction/CartRemoveAjax`,
                                    data: { CartId: cartid },
                                    success: function (data) {
                                        if (data == "Remove") {

                                            $(`#DiaplayValue${cartid}`).parent().parent().remove();
                                        }
                                    }
                                })
                            });
                        } else {
                            //confirmation fadeOut
                            $(this).parents(".confirmation").fadeOut(400, function () {
                                //fadeOut complete,
                                //Product content fadeIn
                                $(this).prev().fadeIn(400);
                            })
                        }
                    })
                })
            })

        }
    })

})

