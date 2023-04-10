$(function () {
    //Multi Select Setup
    // 1. give first th a input(checkbox) id = SelectAll
    // 2. give all the product row a input(checkbox) at first, class = selectBox,
    //    and give the productId as value to input(checkbox)
    // 3. open three button for Active, Disabled, Delete function             //Target All Select Box             $(".selectBox").click(function () {
    //Active Multi Select
    //Counting

    $(".selectBox").click(function () {
        //Active Multi Select
        //Counting
        var selectedCount = $(".selectBox:checked")
        if (selectedCount.length == 0) {
            $("#SelectAll").prop("checked", false)
            //If Dont Have, hidden the button
            $(".multiBtnContainer").fadeOut(300)
        }
        else if (selectedCount.length == $(".selectBox").length) {
            $(".multiBtnContainer").fadeIn(300)
            //If All has checked
            $("#SelectAll").prop("checked", true)
        }
        else {
            //If have any checked, show the button
            $(".multiBtnContainer").fadeIn(300)
        }
    })
    $("#SelectAll").click(function () {
        //Get SelectAll 'checked' value
        var value = $(this).prop("checked");

        if (value == false) {
            $(".multiBtnContainer").fadeOut(300)
        } else {
            $(".multiBtnContainer").fadeIn(300)
        }
        //Set To Every selectBox
        $.each($(".selectBox"), function () {
            $(this).prop("checked", value)
        })
    })


  

    $("#deleteSelectedProduct").click(function () {
        var ProductIdArray = [];
        $.each($(".selectBox:checked"), function () {
            ProductIdArray.push($(this).val())
            $(this).parents("tr").remove()
        })
        console.log(ProductIdArray)
        $.post("/ManageProducts/MultiDeleteProduct", { ProductIdArray: ProductIdArray });
    })
})


