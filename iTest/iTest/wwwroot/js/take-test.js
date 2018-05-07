$(function () {
    $("#confirm").on("submit", function (e) {
        var data = {};
        //data.Questions = [];
        var correctAnswers = 0;
        let questions = $('.currQuestion');
        for (var i = 0; i < questions.length; i++) {
            let question = questions[i];
            question.Answers = [];

            let answerIsChecked = $(questions[i]).children('.panel-body').children('.answerContainer').children('.has-feedback').children(':radio:checked').val();

            if (answerIsChecked === "True") {
                //question.Answers.push($(questions[i]).children('.panel-body').children('.answerContainer').children('.has-feedback').children(':radio:checked'));
                correctAnswers++;
            }
            //data.Questions.push(question)
        }

        data.correctAnswers = correctAnswers;

        $("#confirm").on("click", function (e) {
            $.ajax({
                url: "/users/dashboard/details",
                type: "POST",
                contentType: "application/json;charset=utf-8",
                data: JSON.stringify(data),
                success: (response) => {
                    window.location.href = response;
                },
                error: (err) => {
                    console.log(err);
                }
            })
        });
    });
});



// Var 2
//$(function () {
//    $("#confirm").on("submit", function (e) {
        //e.preventDefault();
        //var url = this.action;
        //var data = $(this).serialize();

        //if ($("#test-form").valid()) {
            //data.Questions = [];
            //let questions = $('.currQuestion');

            //for (var i = 0; i < questions.length; i++) {

            //    let question = questions[i];
            //    question.Answers = [];


            //    let answerIsChecked = $(questions[i]).children('.panel-body').children('.answerContainer').children('.has-feedback').children(':radio:checked').val();

            //    if (answerIsChecked === "True") {
            //        question.Answers.push($(questions[i]).children('.panel-body').children('.answerContainer').children('.has-feedback').children(':radio:checked'));
            //    }

            //    data.Questions.push(question)
            //}

            //$.ajax({
            //    url: "/users/dashboard/details",
            //    type: "POST",
            //    contentType: "application/json",
            //    data: JSON.stringify(data),
            //    success: (response) => {
            //        window.location.href = response;
            //    },
            //    error: (err) => {
            //        console.log(err);
            //    }
            //})
        //}
//    });
//});