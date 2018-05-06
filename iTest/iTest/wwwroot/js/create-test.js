$(function () {
    $("#publish-btn").on("click",
        () => {
            if ($("#test-form").valid()) {
                let data = {};

                data.Name = $("#test-name").val();
                data.RequestedTime = $("#test-time").val();
                data.CategoryName = $("#CategoryName").find(":selected").text();
                data.Status = "Published";
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


                // Validate number of questions 
                if (data.Questions.length === 0) {
                    toastr.error('Add at least one question!');
                    return;
                }

                for (var k = 0; k < data.Questions.length; k++) {
                    var question = data.Questions[k];
                    if (question.Description.length === 0) {
                        toastr.error('Add description to your question!');
                        return;
                    }
                }

                // Validate number of answers for each question
                for (var j = 0; j < data.Questions.length; j++) {
                    var answersPerQuestion = data.Questions[j].Answers.length;
                    if (answersPerQuestion < 2) {
                        toastr.error('Add at least two answers for your question!');
                        return;
                    }

                    var currQuestionAnswers = data.Questions[j].Answers;
                    var isCheckedAnswerAsCorrect = true;
                    for (var l = 0; l < currQuestionAnswers.length; l++) {
                        var answer = currQuestionAnswers[l];
                        if (answer.Description.length === 0) {
                            toastr.error('Add description to your answer!');
                            return;
                        }

                        isCheckedAnswerAsCorrect = answer.IsCorrect;
                    }

                    if (!isCheckedAnswerAsCorrect) {
                        toastr.error('Check correct answer!');
                        return;
                    }
                }

                $.ajax({
                    url: "/Admin/ManageTest/Create",
                    type: "POST",
                    contentType: "application/json",
                    data: JSON.stringify(data),
                    success: (response) => {
                        console.log('should redirect');
                        window.location.href = response;
                    },
                    error: (err) => {
                        console.log(err);
                    }
                })
            }
        });

    $("#draft-btn").on("click",
        () => {
            if ($("#test-form").valid()) {
                let data = {};
                        
                data.Name = $("#test-name").val();
                data.RequestedTime = $("#test-time").val();
                data.CategoryName = $("#CategoryName").find(":selected").text();
                data.Status = "Draft";
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
                    url: "/Admin/ManageTest/Create",
                    type: "POST",
                    contentType: "application/json",
                    data: JSON.stringify(data),
                    success: (response) => {
                        window.location.href = response;
                    },
                    error: (err) => {
                        console.log(err);
                    }
                });
            }
        });

    let $accordion = $("#question-container");

    var nameCounter = 0;


    $('#add-question-btn').on("click",
        () => {
            $.ajax({
                url: '/Admin/ManageTest/AddQuestion/',
                type: 'GET',
                contentType: 'application/html',
                success: function (html) {
                    $accordion.append(html);
                    IncrementAnswers();
                    IncrementQuestions();
                    //$('.correct-answer-cb').attr('name', ++nameCounter);
                    // get all radio buttons -> $('.answer-holder').children('.answer-content').children('.row').children('.text-right').children().attr('name', 'irina')
                    $accordion.accordion("refresh");
                    $accordion.accordion("option", "active", ($accordion.children("div").length - 1));
                    summernoteInit();
                },
                error: function (err) {
                    $('#question-container')
                        .append("<p>Something went wrong... Status: " + err.status + "</p>");
                }
            });
        });

    $('#question-container').on("click",
        '.delete-question-btn',
        (e) => {
            let buttonClicked = $(e.target);
            let questionHolder = buttonClicked.closest(".question-holder");
            let questionHolderTitleTab = questionHolder.prev();
            questionHolder.remove();
            questionHolderTitleTab.remove();
            IncrementQuestions();
        });


    $('#question-container').on("click",
        '.add-answer-btn',
        (e) => {
            let buttonClicked = $(e.target);
            let extraAnswersContainer = buttonClicked.parent().find(".extra-answer-container");
            $.ajax({
                url: '/Admin/ManageTest/AddAnswer/',
                type: 'GET',
                contentType: 'application/html',
                success: function (html) {
                    extraAnswersContainer.append(html);
                    IncrementAnswers();
                    summernoteInit();
                },
                error: function (err) {
                    extraAnswersContainer.append("<p>Something went wrong... Status: " + err.status + "</p>");
                }
            });
        });

    $('#question-container').on("click",
        '.delete-answer-btn',
        (e) => {
            let buttonClicked = $(e.target);
            let answerContent = buttonClicked.closest(".answer-content");
            answerContent.remove();
            IncrementAnswers();
        });


    $("#question-container").accordion({
        heightStyle: "content",
        collapsible: true
    });
});

function summernoteInit() {
    $(".summernote").summernote({
        height: 150,
        disableResizeEditor: true,
        toolbar: [
            ['style', ['bold', 'italic', 'underline', 'clear']],
            ['fontsize', ['fontname', 'fontsize']],
            ['color', ['color']],
            ['font', ['strikethrough', 'superscript', 'subscript', 'height']],
            ['para', ['ul', 'ol', 'paragraph', 'table']],
            ['misc', ['fullscreen', 'codeview', 'help']]
        ],
        popover: {
            image: [],
            link: [],
            air: []
        }
    }
    );
}

summernoteInit();

function toastrInit() {
    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-top-center",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
};

toastrInit();




function IncrementAnswers() {

    let $answerHolders = $(".answer-holder");

    $.each($answerHolders,
        (i, el) => {
            let $answers = $(el).find(".answer-number");

            $.each($answers,
                (i, el) => {
                    $(el).html(i + 1);
                });
        });
}

function IncrementQuestions() {

    let $questionHolders = $(".question-holder");

    $.each($questionHolders,
        (i, el) => {
            let $el = $(el);
            $el.prev("h3").find(".question-number").html(i + 1);
        });
}