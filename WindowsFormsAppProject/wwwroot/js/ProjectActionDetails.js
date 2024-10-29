$(function () {

    //delete
    $('.js-deleteaction').on('click', function () {
        var btn = $(this);
        var message = confirm("are you sure to delete");
        if (message) {
            $.ajax({
                method: 'Delete',
                url: '/ProjectActionOperationWeb/Delete/' + btn.data('id'),
                success: function () {
                    btn.parents('.col-10').fadeOut();
                    toastr.success("success deleted");
                },
                error: function () {
                    toastr.error("this element has a action")
                }

            });
        }
    });

})
