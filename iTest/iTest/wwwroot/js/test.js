(function() {
    $('#add-question').click(function() {
        console.log('test');
        $.get('@Url.Action("CreateQuestion", "ManageTest")',
            {},
            function(response) {
                $("#questions-body").append(response);
            });
    });

    $('#add-answer').click(function() {
        console.log('test answer');
        $.get('@Url.Action("CreateAnswer", "ManageTest")',
            {},
            function(response) {
                $("#questions-body").html(response);
            });
    });
});