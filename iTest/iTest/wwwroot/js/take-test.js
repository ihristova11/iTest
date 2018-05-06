$(function () {
    $("#submit").on("click", function (e) {
        e.preventDefault();
        var url = this.action;
        var data = $(this).serialize();
        if ($("#test-form").valid()) {
            var data = {};
            data.Name = $("#test-name").val();
            data.CategoryName = $("#category-name").val();
            data.StartedOn = Date.now();
            data.SubmittedOn = Date.now();
            data.ExecutionTime = $("#ExecutionTime").val();
            data.ResultStatus = $("#ResultStatus").val();

            data.Questions = [];

            let questions = $('.currQuestion');

            for (var i = 0; i < questions.length; i++) {

                let question = questions[i];
                question.Answers = [];


                let answerIsChecked = $(questions[i]).children('.panel-body').children('.answerContainer').children('.has-feedback').children(':radio:checked').val();

                if (answerIsChecked === "True") {
                    question.Answers.push($(questions[i]).children('.panel-body').children('.answerContainer').children('.has-feedback').children(':radio:checked'));
                }

                data.Questions.push(question)
            }

            $.ajax({
                url: "/users/dashboard/details",
                type: "POST",
                contentType: "application/json", //charset=utf-8
                data: JSON.stringify(data),
                success: (response) => {
                    window.location.href = response;
                },
                error: (err) => {
                    console.log(err);
                }
            })
        }
    });
});