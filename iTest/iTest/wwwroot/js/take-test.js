$(function () {
    $("#confirm-btn").on("click",
        () => {
            if ($("#test-form").valid()) {
                var data = {};
                data.Questions = [];

                let questions = $('.currQuestion');

                for (var i = 0; i < questions.length; i++) {

                    let question = questions[i];
                    question.Answers = [];

                    //let answers = $(questions[i]).children('.panel-body').children('.answerContainer').children('.has-feedback').children(':radio');

                    //for (var j = 0; j < answers.length; j++) {

                        let answerIsChecked = $(questions[i]).children('.panel-body').children('.answerContainer').children('.has-feedback').children(':radio:checked').val();

                        if (answerIsChecked === "True") {
                            question.Answers.push($(questions[i]).children('.panel-body').children('.answerContainer').children('.has-feedback').children(':radio:checked'));
                        }
                    //}
                   data.Questions.push(question)
                }

                $.ajax({
                    url: "/users/dashboard/details",
                    type: "POST",
                    contentType: "application/json", //charset=utf-8
                    //Accept: "application/json",
                    //data: JSON.stringify(data),
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