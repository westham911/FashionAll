$(document).ready(function () {


    $('.add_to_cart').click(function () {

        var productCard = $(this).parent().parent();
        var position = productCard.offset();

        
        
        $(".container").append('<div class="floating-cart"></div>');
        var cart = $('div.floating-cart');

        

        productCard.clone().appendTo(cart);
        $(cart).css({ 'top': position.top + 'px', "left": position.left + 'px' }).fadeIn("slow").addClass('moveToCart');

    });
});