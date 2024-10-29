
$(function () {
    //add and edit
    var PlaceHolderElement = $("#PlaceHolderHere");

    $('button[data-toggle="ajax-modal"]').on("click", function (eveent) {

        var url = $(this).data('url');

        var decodedurl = decodeURIComponent(url);

        $.get(decodedurl).done(function (data) {

            PlaceHolderElement.html(data);
            PlaceHolderElement.find('.modal').modal('show');

        });

    });

    PlaceHolderElement.on('click', '[data-save="modal"]', function (event) {

        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr('action');
        var sendData = form.serialize();

        $.post(actionUrl, sendData).done(function (data) {
            PlaceHolderElement.find('.modal').modal('hide');
        });

    });

})
