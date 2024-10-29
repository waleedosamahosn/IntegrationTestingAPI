$(function () {

const { Button } = require("../lib/bootstrap/dist/js/bootstrap.bundle");

    //delete
    $('.js-deleteparameter').on('click', function () {
        var btn = $(this);
        var message = confirm("are you sure to delete");
        if (message) {
            $.ajax({
                method: 'Delete',
                url: '/ProjectActionParametersQuery/Delete/' + btn.data('id'),
                success: function () {
                    btn.parents('.col-11').fadeOut();
                    toastr.success("success deleted");
                },
                error: function () {
                    toastr.error("this element has a action")
                }

            });
        }
    });

})



//$(function() {
//    var PlaceHolderElement = $('#PlaceHolderHere');
//    $('button[data-toggle="ajax-modal"]').click(function (event) {

//        var url = $(this).data('url');
//        $.get(url).done(function (data) {
//            PlaceHolderElement.html(data);
//            PlaceHolderElement.find('.modal').modal('show');
//        })
//    })

//})