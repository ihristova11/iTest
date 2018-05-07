$(function () {
    $("#confirm").on("click", function (e) {

        // get correct answers
        var correctAnswers = 0;
        let questions = $('.currQuestion');
        for (let i = 0; i < questions.length; i++) {

            let answerIsChecked = $(questions[i]).children('.panel-body').children('.answerContainer').children('.has-feedback').children(':radio:checked').val();

            if (answerIsChecked === "True") {
                correctAnswers++;
            }
        }

            // data binding
            let data = {};
            data.Name = $("#Name").val();
            data.CategoryName = $("#CategoryName").val();
            data.QuestionsCount = $("#QuestionsCount").val();
            data.StartedOn = $("#startedOn").val();
            //data.SubmittedOn = $.now();
            data.RequestedTime = $("#RequestedTime").val();
            data.CorrectAnswers = $("#CorrectAnswers").val(parseInt(correctAnswers));


            // post request
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
            });
    });
});