 $(function () {
     var filterId = $("#SortBy").val()

     $.ajax({
         type: "GET",
         url: "/CustomerStoreFunction/GetAzurLaneProductList?filter=" + filterId,
         success: function (data) {

             $.each(data, function (count, pair) {
                 console.log(pair)
                 var name = pair.productName.length > 30 ? pair.productName.substring(0, 30) + "..." : pair.productName

                 $("#ItemList").append(`
                                   <div class="item-box grid__item small--one-half medium-up--one-fifth">
                            <!-- /snippets/product-card.liquid -->

                            <a href="/CustomerStore/MerchandiseDetailsPage?id=${pair.id}" class="product-card advanced-preorder__Iterated">

                                <div class="product-card__image-container">
                                    <div class="product-card__image-wrapper">
                                        <div class="product-card__image js" style="max-width: 168.90625px;" data-image-id="30599860748401" data-image-with-placeholder-wrapper="">
                                            <div style="padding-top:139.1304347826087%;">
                                                               <img class="lazyautosizes lazyloaded" src="${pair.productImg1}" alt="${pair.productName}" class="product-card__image">

                                              
                                            </div>
                                            <div class="placeholder-background placeholder-background--animation placeholder-background--hide" data-image-placeholder=""></div>
                                        </div>
                                        <noscript>

                                         <img src="${pair.productImg1}" alt="${pair.productImg1}" class="product-card__image">

                                        </noscript>
                                    </div>
                                </div>
                                <div class="product-card__info">

                                            <div class="product-card__name">${name}</div>

                                    <div class="product-card__price">

                                            $ ${pair.disPrice}

                                    </div>

                                </div>

                                <div class="product-card__overlay">

                                    <span class="btn product-card__overlay-btn ">View</span>
                                </div>
                            </a>

                        </div>

                    `)


             })
         }
     })
     $("#SortBy").change(function () {
         $("#ItemList").html("")
       filterId = $("#SortBy").val()

         $.ajax({
             type: "GET",
             url: "/CustomerStoreFunction/GetAzurLaneProductList?filter=" + filterId,
             success: function (data) {

                 $.each(data, function (count, pair) {
                     console.log(pair)
                     var name = pair.productName.length > 30 ? pair.productName.substring(0, 30) + "..." : pair.productName

                     $("#ItemList").append(`
                                   <div class="item-box grid__item small--one-half medium-up--one-fifth">
                            <!-- /snippets/product-card.liquid -->

                            <a href="/CustomerStore/MerchandiseDetailsPage?id=${pair.id}" class="product-card advanced-preorder__Iterated">

                                <div class="product-card__image-container">
                                    <div class="product-card__image-wrapper">
                                        <div class="product-card__image js" style="max-width: 168.90625px;" data-image-id="30599860748401" data-image-with-placeholder-wrapper="">
                                            <div style="padding-top:139.1304347826087%;">
                                                               <img class="lazyautosizes lazyloaded" src="${pair.productImg1}" alt="${pair.productName}" class="product-card__image">

                                              
                                            </div>
                                            <div class="placeholder-background placeholder-background--animation placeholder-background--hide" data-image-placeholder=""></div>
                                        </div>
                                        <noscript>

                                         <img src="${pair.productImg1}" alt="${pair.productImg1}" class="product-card__image">

                                        </noscript>
                                    </div>
                                </div>
                                <div class="product-card__info">

                                            <div class="product-card__name">${name}</div>

                                    <div class="product-card__price">

                                            $ ${pair.disPrice}

                                    </div>

                                </div>

                                <div class="product-card__overlay">

                                    <span class="btn product-card__overlay-btn ">View</span>
                                </div>
                            </a>

                        </div>

                    `)


                 })
             }
         })
     })

    })