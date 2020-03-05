var createUrl = '/Home/Create?';
var deleteUrl = '/Home/Delete?';
var editUrl = '/Home/Edit?';
var indexUrl = '/Home/Index?';

$(function() {
    //Calling create partial view
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
            error: function () {
                alert("Dynamic content load failed.");
            }
        }).done(function (result) {
            $('#funcBlock').html(result);
        });
    });
    //Calling edit partial view
    $(".editAnchor").click(function() {
        var $buttonClicked = $(this);
        var id = $buttonClicked.attr('data-id');
        var options = { "backdrop": "static", keyboard: true };
        console.log("Id = " + id);
        $.ajax({
            type: "GET",
            url: editUrl+id,
            cache: false,
            data: {Id : id},
            error: function () {
                alert("Dynamic content load failed.");
            }
        }).done(function (result) {
            $('#funcBlock').html(result);
        });
    });
    //Calling delete modal window
        $(".deleteAnchor").click(function() {
            var $buttonClicked = $(this);
            var id = $buttonClicked.attr('data-id');
            var options = { "backdrop": "static", keyboard: true };
            console.log("Id = " + id);
            $.ajax({
                type: "GET",
                url: deleteUrl+id,
                cache: false,
                data: {Id : id},
                error: function () {
                    alert("Dynamic content load failed.");
                }
            }).done(function (result) {
                $('#funcBlock').html(result);
            });
        });
    //Calling Index view with sorting 
  
    $('.sortBtn').click(function () {
            var $buttonClicked = $(this);
            var sortType = $buttonClicked.attr('value');
            window.location = '/Home/Index?sort=' + sortType;
    });
    // Showing and hiding tree branches
    $('.treeElementIcon').click(function() {
        $(this).toggleClass('down')
        var $treeElement = $(this).parent('.treeElementChild');
        var $treeElementParent = $treeElement.parent('.treeElement');
        $treeElementParent.children('.treeElement').toggle();
    });
});