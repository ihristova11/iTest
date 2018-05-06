$(function () {
    $("#confirm-btn").on("click",
        () => {
            if ($("#test-form").valid()) {
                var data = {};
                data.Questions = [];
                var questions = $('#questions');

                $.each(questions,
                    (i, q) => {
                        let $q = $(q);
                        let question = {};

                        let qContent = $q.find(".question")

                        question.Description = qContent;
                        question.Answers = [];

                        let qAnswers = $q.find(".allAnswers");

                        console.log(qAnswers);

                        $.each(qAnswers,
                            (i, a) => {
                                let $a = $(a);
                                let answer = {};

                                if ($a.find(".answer").is(":checked")) {
                                    question.Answers.push(answer);
                                }
                            });

                        data.Questions.push(question);
                    });


                //for (var i = 0; i < questions.length; i++) {
                //    let question = questions[i];
                //    var answers = $('#allAnswers');
                //    for (var j = 0; j < answers.length; j++) {

                //        //let selected = $('input:radio[name="answer"]:checked');
                //        let selected2 = $('.answer').is(":checked")

                //        console.log(selected);
                //        console.log(selected2);

                //        if (selected2) {
                //            question.push(answers[j]);
                //        }
                //        data.Questions.push(question);
                //        console.log(data.Questions)
                //    }
                //}

                $.ajax({
                    url: "/users/dashboard/details",
                    type: "POST",
                    contentType: "application/json",
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