
var cartNum;var cNum;
        //$(".addToCart").click(function () 
       function addToCart(bagID)
       {

           $.ajax({
                contentType: 'application/json; charset=utf-8',
                dataType: 'json', 
                type: 'GET',

                url: '/LIZ110/asp_assignment/ShoppingCart/AddToCart',
                data: { 'id': bagID },

                success: function (msg) {

                    

                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {


   
                }
            });
    }


















