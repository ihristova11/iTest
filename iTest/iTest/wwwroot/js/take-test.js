$(function () {
    $("#confirm-btn").on("click",
        () => {
            if ($("#test-form").valid()) {
                let data = {};

                data.Name = $("#test-name").val();
                data.RequestedTime = $("#test-time").val();
                data.CategoryName = $("#category-name").val();
                data.Questions = [];

                let question = {};
                question.Answers = [];

                var answers = document.getElementsByName('answers');
                for (var i = 0; i < answers.length; i++) {
                    if (answers[i].checked) {
                        if (answer.IsCorrect = true) {
                            question.Answers.push(answer);
                        }
                    }
                }

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