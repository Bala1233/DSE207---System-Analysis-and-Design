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


    $("#activeSelectedProduct").click(function () {
        //Open an array to store ProductId has selected
        var ProductIdArray = [];         //Foreach every selectBox has checked
        $.each($(".selectBox:checked"), function () {
            //Push into array
            ProductIdArray.push($(this).val())
            var ProductRow = $(this).parents("tr")
            ProductRow.find("button.statusBtn").text("Active").addClass("EnabledBtn1").removeClass("DisableBtn1")  
            // CSS

        })
        console.log(ProductIdArray)
        //End         })
        //Calling AJAX to effect the change, Pass the Array ProductId
        //Controller --
        //  Foreach(var product in ProductIdArray){
        //        db.ProductTable.FirstOrDefault(e=>e.ProductId==product)!.Active =true;
        //        }
        // db.saveChange();
        // return Json("");        
        $.post("/AdminFunction/MultiActiveSellerProduct", { ProductIdArray: ProductIdArray });


    })
    $("#disabledSelectedProduct").click(function () {
        //Open an array to store ProductId has selected
        var ProductIdArray = [];         //Foreach every selectBox has checked        
        $.each($(".selectBox:checked"), function () {
            //Push into array
            ProductIdArray.push($(this).val())
            var ProductRow = $(this).parents("tr")
            ProductRow.find("button.statusBtn").text("Disabled").addClass("DisableBtn1").removeClass("EnabledBtn1")  
            // CSS
            /*        var ProductRow = $("#OrderList").children("tr")*/

        })

        console.log(ProductIdArray)
        //Calling AJAX to effect the change, Pass the Array ProductId
        //Controller --
        //  Foreach(var product in ProductIdArray){
        //        db.ProductTable.FirstOrDefault(e=>e.ProductId==product)!.Active =false;
        //        }
        // db.saveChange();
        // return Json("");
        $.post("/AdminFunction/MultiDisabledSellerProduct", { ProductIdArray: ProductIdArray });
    })

    $("#deleteSelectedProduct").click(function () {
        var ProductIdArray = [];
        $.each($(".selectBox:checked"), function () {
            ProductIdArray.push($(this).val())

        })
        console.log(ProductIdArray)
        $.post("/AdminFunction/MultiDeleteProduct", { ProductIdArray: ProductIdArray });
    })
})

