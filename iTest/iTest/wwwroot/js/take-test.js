$(function () {
    $("#publish-btn").on("click",
        () => {
            if ($("#test-form").valid()) {
                let data = {};

                data.Name = $("#test-name").val();
                data.RequestedTime = $("#test-time").val();
                data.CategoryName = $("#category-name").val();
                data.Questions = [];

                let allQuestionHolders = $(".question-holder");

                $.each(allQuestionHolders,
                    (i, q) => {
                        let $q = $(q);
                        let question = {};

                        let qContent = $q.find(".question-content .summernote").summernote("code")
                            .replace(/<\/?[^>]+(>|$)/g, "");

                        question.Description = qContent;
                        question.Answers = [];

                        let qAnswers = $q.find(".answer-holder .answer-content");

                        $.each(qAnswers,
                            (i, a) => {
                                let $a = $(a);
                                let answer = {};
                                answer.Description =
                                    $a.find(".summernote").summernote("code").replace(/<\/?[^>]+(>|$)/g, "");
                                if ($a.find(".correct-answer-cb").is(":checked")) {
                                    answer.IsCorrect = true;
                                }

                                question.Answers.push(answer);
                            });

                        data.Questions.push(question);
                    });

                $.ajax({
                    url: "/Users/Dashboard/Details",
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