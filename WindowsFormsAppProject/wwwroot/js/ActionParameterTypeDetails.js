$(function () {

    //delete
    $('.js-deleteactiontype').on('click', function () {
        var btn = $(this);
        var message = confirm("are you sure to delete");
        if (message) {
            $.ajax({
                method: 'Delete',
                url: '/ActionParameterTypes/Delete/' + btn.data('id'),
                success: function () {
                    btn.parents('.col-14').fadeOut();
                    toastr.success("success deleted");
                },
                error: function () {
                    toastr.error("this element has a action")
                }

            });
        }
    });

})
