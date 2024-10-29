$(function () { 
    //delete
    $('.js-delete').on('click', function () {
        var btn = $(this);
        var message = confirm("are you sure to delete");
        if (message) {
            $.ajax({
                method: 'Delete',
                url: '/ProjectOperations/Delete/' + btn.data('id'),
                success: function () {
                    btn.parents('.col-12').fadeOut();
                    toastr.success("success deleted");
                },
                error: function () {
                    toastr.error("this element has a action")
                }

            });
        }
    });

});
