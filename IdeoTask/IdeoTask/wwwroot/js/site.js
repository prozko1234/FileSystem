var createUrl = '/Home/Create?';
var deleteUrl = '/Home/Delete?';
var editUrl = '/Home/Edit?';
var indexUrl = '/Home/Index?';
var replaceUrl = '/Home/Replace';
var sortType;

$(function() {
    //Calling create partial view
    $(".createAnchor").click(function () {
        var $buttonClicked = $(this);
        if ($('#nameInput').text === '') {
            $('.nameHelp').style('visibility', 'inherit');
        }
        var id = $buttonClicked.attr('data-id');
        var options = { "backdrop": "static", keyboard: true };
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
        if ($('#nameEditInput').text === '') {
            $('.nameEdirHelp').style('display', 'block');
        }
        var id = $buttonClicked.attr('data-id');
        var options = { "backdrop": "static", keyboard: true };
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
            sortType = $buttonClicked.attr('value');
            window.location = '/Home/Index?sort=' + sortType;
    });
    //Drag and drop
    //Works but have a problem, when dropping dragged item more left,
    //it drops in root branch, not selected

    $('.treeElementChild').click(function () {
    }).draggable({
        stack:'.treeElement',
        zIndex: 100,
        containment: '.treeElement',
        snap: '.treeElement',
        appendTo: '.treeElement'
    });
    var targetId;
    $('.treeElement').droppable({
        drop: function (event, ui) {
            var ids = new Array();
            var id = ui.helper.attr('data-id'); 
            ids.push($(event.target).attr('data-id'));
            targetId = $(event.target).attr('data-id');
            if (ids.length === 1)
                targetId = ids[0];
            else if (ids.length === 3)
                targetId = ids[1];
            for (var i = 0; i < ids.length; i++) {
                console.log('dragable: ' + id + ' target: ' + ids[i]);
            }
            if (id !== targetId) {
                $.ajax({
                    type: "POST",
                    url: replaceUrl,
                    cache: false,
                    data: {
                        idTarget: targetId,
                        idMoved: id
                    },
                    error: function () {
                        alert("Dynamic content load failed.");
                    }
                }).done(function (result) {
                    window.location = '/Home/Index?sort=' + sortType;
                });
            }
        }
    });

    // Showing and hiding tree branches
    $('.treeElementIcon').click(function() {
        $(this).toggleClass('down');
        var $treeElement = $(this).parent('.treeElementChild');
        var $treeElementParent = $treeElement.parent('.treeElement');
        $treeElementParent.children('.treeElement').toggle();
    });
});