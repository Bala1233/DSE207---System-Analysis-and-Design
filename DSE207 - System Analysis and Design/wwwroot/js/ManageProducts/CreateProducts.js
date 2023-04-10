function WritingName(NewValue) {
    document.getElementById("ShowName").innerHTML = NewValue;
    CheckValue()
}
function WritingTitle(NewValue) {
    document.getElementById("ShowTitle").innerHTML = NewValue;
    CheckValue()
}
function WritingDescription(NewValue) {
    document.getElementById("ShowDescription").innerHTML = NewValue;
    CheckValue()
}
function WritingOriPrice(NewValue) {
    document.getElementById("ShowOriPrice").innerHTML = "$ " + NewValue;
    CheckValue()
}
function WritingDisPrice(NewValue) {
    document.getElementById("DisPriceError").innerHTML = "";
    var OriginalPrice = document.getElementById("oriPrice").value
    if (parseInt(NewValue) > parseInt(OriginalPrice)) {
        NewValue = OriginalPrice
        document.getElementById("disPrice").value = NewValue;
        document.getElementById("DisPriceError").innerHTML = "DisPrice cant be large than oriprice"
    }
    document.getElementById("ShowDisPrice").innerHTML = "$ " + NewValue;
    CheckValue()
}
function WritingQty(NewValue) {
    document.getElementById("ShowQty").innerHTML = NewValue + "  Qty";
    CheckValue()
}
function WritingProductImg1(NewValue) {
    document.getElementById("ShowImgUrl").src = NewValue;
    document.getElementById("ShowImgUrl-1").src = NewValue;
    CheckValue()
}
function WritingProductImg2(NewValue) {
    document.getElementById("ShowImgUr2").src = NewValue;
}
function WritingProductImg3(NewValue) {
    document.getElementById("ShowImgUr3").src = NewValue;
}
function WritingProductDetails2(NewValue) {
    document.getElementById("ShowImgDetUr2").src = NewValue;
}
function WritingProductDetails3(NewValue) {
    document.getElementById("ShowImgDetUr3").src = NewValue;
}

function ErrorImg(img) {
    img.src = "https://t3.ftcdn.net/jpg/04/34/72/82/360_F_434728286_OWQQvAFoXZLdGHlObozsolNeuSxhpr84.jpg"
}


$(document).ready(function () {

    $(".smallPic").on({

        mouseenter: function () {

            $(".OnShowPic").attr("src", ($(this).attr('src')));
        }
    });
});

function BackToList() {
    location.href = "/ManageProducts/ProductList"
}

function CheckValue() {

    var inputName = document.getElementById("ProductName").value
    var inputTitle = document.getElementById("Title").value
    var img = document.getElementsByClassName("smallPic").length
    var inputOriPice = document.getElementById("oriPrice").value
    var inputDisPrice = document.getElementById("disPrice").value
    var inputQty = document.getElementById("qty").value
    var des = editor1.getText()
    var img1 = $("input[name='ProductImg1']").val()

    if (typeof img1 === "undefined") {

        document.getElementById("BtnDis").disabled = true;
        return;
    }
    else if (inputName != "" && inputTitle != "" && inputOriPice != "" && inputDisPrice != "" && inputQty != "" && img > 0 && des.replaceAll(" ", "") != "") {

        document.getElementById("BtnDis").disabled = false;
        return;
    }
    else {

        document.getElementById("BtnDis").disabled = true;
    }
}


$(function () {
    $("#clickbtn").click(function () {
        var x = $("#default_rte-edit-view").html()

    })
    $("#PreviewBtn").click(function () {
        if ($("#Right_Box").css("display") == "none") {
            $("#Left_Box").fadeOut(200, function () {
                $("#Right_Box").fadeIn(200)
            })

        } else {
            $("#Right_Box").fadeOut(200, function () {
                $("#Left_Box").fadeIn(200)
            })

        }
    })


    function getBase64(file) {
        var reader = new FileReader();
        reader.readAsDataURL(file);
        reader.onload = function () {

            $(".OnShowPic").attr("src", reader.result);
            $("#smallpivContainer").append(`
                                                 <div style="padding:5px;"class="col-3 pivBoc">
                                                 <img class="smallPic" onerror="ErrorImg(this)"  src="${reader.result}" />
                                                 </div>
                                                      `)

            if ($(".pivBoc").length <= 2) {
                $("#smallpivContainer").append(`
                                                <input style="display:none" value="${reader.result}" id="ProductImg${$(".pivBoc").length}"name = "ProductImg${$(".pivBoc").length}"/>
                                      `)
            }
            else {
                $("#smallpivContainer").append(`
                                                <input style="display:none" value="${reader.result}" name = "DetailsImg1" />
                                          `)
            }
            CheckValue()



            if ($(".pivBoc").length == 3) {
                $("#uploadImage").prev().hide(200)
            }

            $(".pivBoc").click(function () {
                CheckValue()
                var name = $(this).next().attr("name")

                $(this).remove()
                if ($(".pivBoc").length < 3) {
                    $("#uploadImage").prev().show(200)

                }
                $(`input[name='${name}']`).remove()
            })
        }; reader.onerror = function (error) {
            alert('Invalid file type');
        };
    }
    var x;
    var image;
    $("#uploadImage").change(function (event) {
        x = getBase64(event.target.files[0])

    })

    editor1.attachEvent("change", function () {
        $("#InputDes").val(editor1.getHTMLCode())
        $("#ShowDescription").html(editor1.getHTMLCode())

        CheckValue()
    })


})


