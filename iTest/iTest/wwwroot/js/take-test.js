$(function () {
    $("#confirm-btn").on("click",
        () => {
            if ($("#test-form").valid()) {
                var data = {};
                data.Questions = [];

                let questions = $('#questionContainer'); // currQuestion // questionContainer

                for (var i = 0; i < questions.length; i++) {

                    let question = questions[i];
                    question.Answers = [];

                    let answers = $('#answerContainer'); // currAnswer // answerContainer

                    for (var j = 0; j < answers.length; j++) {

                        let answerIsChecked = $('input:radio[name="currAnswerIsCorrect"]:checked');

                        if (answerIsChecked) {
                            question.Answers.push(answers[j]);
                        }
                        data.Questions.push(question)
                    }
                }

                $.ajax({
                    url: "/users/dashboard/details",
                    type: "POST",
                    contentType: "application/json;charset=utf-8",
                    Accept: "application/json",
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