$(function () {
    $("#SortTags").change(function () {
        var value = $(this).val()
        //alert(value)

        $.ajax({
            type: "POST",
            url: "/CustomerStore/DescriptionPage",
            data: value,
            //beforeSend: function () {
            //    $("#ItemForSearch").html("<span>Searching . . .</span>")
            //},
            success: function (data) {
                alert(data)
                $("#ItemForSearch").load(data)
            }
        })
    })

    $(".product-card").click(function () {
        var value = $(this).val()

        alert(value)
    })

})