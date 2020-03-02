var createUrl = '/Home/Create?';
var deleteUrl;
var editUrl;

$(function () {
    $(".createAnchor").click(function () {
        var $buttonClicked = $(this);
        var id = $buttonClicked.attr('data-id');
        var options = { "backdrop": "static", keyboard: true };
        console.log("Id = " + id);
        $.ajax({
            type: "GET",
            url: createUrl+id,
            cache: false,
            data: {Id : id},
            //data: { Id: fatherId },
            error: function () {
                alert("Dynamic content load failed.");
            }
        }).done(function (result) {
            $('#funcBlock').html(result);
        });
    });
});