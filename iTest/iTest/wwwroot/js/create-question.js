﻿$(function () {
    const errorPanel = $(".error-panel ul");
    let finishTest = function (shouldPublish, url) {
        errorPanel.children().remove();
        $("#question-container").accordion({ header: "h3", active: false });
        let shouldPost = true;

        if ($("#test-form").valid()) {
            let data = {};
            let valid = true;
            data.Title = $("#test-name").val();
            data.RequiredTime = $("#test-time").val();
            data.Category = $("#test-category").val();

            if (shouldPublish) {
                data.Status = "Published";
            }
            else {
                data.Status = "Draft";
            }

            data.Questions = [];

            let allQuestionHolders = $(".question-holder");

            if (shouldPublish && allQuestionHolders.length === 0) {
                toastr.options.positionClass = "toast-top-center";
                toastr.error("Cannot publish a test with no questions!");
                return;
            }

            $.each(allQuestionHolders, (i, q) => {
                let $q = $(q);
                let question = {};

                let qContent = $q.find(".question-content .summernote").summernote("code").replace(/<\/?[^>]+(>|$)/g, "");

                valid = validateStringContent("Question", errorPanel, qContent, $q, $q);

                if (!valid) {
                    shouldPost = false;
                }

                question.Content = qContent;
                question.Answers = [];

                let qAnswers = $q.find(".answer-holder .answer-content");

                $.each(qAnswers, (i, a) => {
                    let $a = $(a);
                    let answer = {};
                    let aContent = $a.find(".summernote").summernote("code").replace(/<\/?[^>]+(>|$)/g, "")

                    valid = validateStringContent("Answer", errorPanel, aContent, $a, $q);

                    if (!valid) {
                        shouldPost = false;
                    }

                    answer.Content = aContent;

                    if ($a.find(".correct-answer-cb").is(":checked")) {
                        answer.IsCorrect = true;
                    }

                    question.Answers.push(answer);
                });

                if (!valid) {
                    shouldPost = false;
                }

                data.Questions.push(question);
            });

            if (!shouldPost) {
                return;
            }

            let tokenHeader = $("input[name=__RequestVerificationToken]").val();

            $.ajax({
                url: url,
                type: "POST",
                contentType: "application/json",
                headers: { "__RequestVerificationToken": tokenHeader },
                data: JSON.stringify(data),
                success: (response) => {
                    window.location.href = response;
                },
                error: (err) => {
                    console.log(err);
                }
            });
        }
    };

    $("#publish-btn").on("click", () => {
        $.confirm({
            title: 'Confirm!',
            content: 'Are you sure you want to publish this test?',
            buttons: {
                confirm: function () {
                    finishTest(true, "/admin/managetest/create/");
                },
                cancel: function () {
                },
            }
        });
    });

    $("#draft-btn").on("click", () => {
        $.confirm({
            title: 'Confirm!',
            content: 'Are you sure you want to save this test as draft?',
            buttons: {
                confirm: function () {
                    finishTest(false, "/admin/managetest/create/");
                },
                cancel: function () {
                },
            }
        });
    });

    $("#edit-save-btn").on("click", (e) => {
        $.confirm({
            title: 'Confirm!',
            content: 'Save the test?',
            buttons: {
                confirm: function () {
                    const elId = $(e.target).attr("data-id");
                    finishTest(false, `/administration/edit/${elId}`);
                },
                cancel: function () {
                },
            }
        });
    });

    // Add and delete questions
    let $accordion = $("#question-container");

    $('#add-question-btn').on("click", () => {
        $.ajax({
            url: '/AdmiN/ManageTest/AddQuestion/',
            type: 'GET',
            contentType: 'application/html',
            success: function (html) {
                $accordion.append(html);
                incrementAnswers();
                incrementQuestions();
                $accordion.accordion("refresh")
                $accordion.accordion("option", "active", ($accordion.children("div").length - 1));
                summernoteInit();
            },
            error: function (err) {
                $('#question-container').append("<p>Something went wrong... Status: " + err.status + "</p>");
            }
        });
    });

    $('#question-container').on("click", '.delete-question-btn', (e) => {
        let buttonClicked = $(e.target);
        let questionHolder = buttonClicked.closest(".question-holder");
        let questionHolderTitleTab = questionHolder.prev();
        questionHolder.remove();
        questionHolderTitleTab.remove();
        incrementQuestions();
    });

    // Add and delete answers
    $('#question-container').on("click", '.add-answer-btn', (e) => {
        let buttonClicked = $(e.target);
        let extraAnswersContainer = buttonClicked.parent().find(".extra-answer-container");
        $.ajax({
            url: '/Admin/ManageTest/AddAnswer/',
            type: 'GET',
            contentType: 'application/html',
            success: function (html) {
                extraAnswersContainer.append(html);
                incrementAnswers();
                summernoteInit();
            },
            error: function (err) {
                extraAnswersContainer.append("<p>Something went wrong... Status: " + err.status + "</p>");
            }
        });
    });

    $('#question-container').on("click", '.delete-answer-btn', (e) => {
        let buttonClicked = $(e.target);
        const isValid = validateAnswerCount(buttonClicked);

        if (isValid) {
            let answerContent = buttonClicked.closest(".answer-content");
            answerContent.remove();
            incrementAnswers();
        }
    });

    // Accordion init
    $("#question-container").accordion({
        heightStyle: "content",
        collapsible: true
    });

    // Summernote.js init
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
        });
    }

    summernoteInit();

    // Answers and questions number incrementation
    function incrementAnswers() {

        let $answerHolders = $(".answer-holder");

        $.each($answerHolders, (i, el) => {
            let $answers = $(el).find(".answer-number");

            $.each($answers, (i, el) => {
                $(el).html(i + 1);
            });
        });
    }

    function incrementQuestions() {

        let $questionHolders = $(".question-holder")

        $.each($questionHolders, (i, el) => {
            let $el = $(el);
            $el.prev("h3").find(".question-number").html(i + 1);
        });
    }

    // Validation for empty or too long answers and questions
    function validateStringContent(answerOrQuestionStr, $errorPanel, content, $element, $question) {
        let msg;
        let questionNumber = $question.prev().find(".question-number").html();

        if (!content) {
            if (answerOrQuestionStr === "Question") {
                msg = `<li>${answerOrQuestionStr} ${questionNumber} text is empty!</li>`;
            }
            else {
                let answerNumber = $element.find(".answer-number").html();
                msg = `<li>${answerOrQuestionStr} ${answerNumber} text for Question ${questionNumber} is empty!</li>`;
            }

            let liEl = $(msg);
            $errorPanel.append(liEl);
            return false;
        }
        else if (content.length > 500) {
            if (answerOrQuestionStr === "Question") {
                msg = `<li>${answerOrQuestionStr} ${questionNumber} text length is invalid! It must be max 500 characters!</li>`;
            }
            else {
                let answerNumber = $element.find(".answer-number").html();
                msg = `<li>${answerOrQuestionStr} ${answerNumber} text length for Question ${questionNumber} is invalid! It must be max 500 characters!</li>`;
            }

            let liEl = $(msg);
            $errorPanel.append(liEl);
            return false;
        }

        return true;
    }

    function validateAnswerCount($answerToBeDeleted) {
        const minNumOfAnswers = 2;
        const actualAnswers = $answerToBeDeleted.closest(".question-holder").find(".answer-content").length;

        if (actualAnswers === minNumOfAnswers) {
            toastr.options.positionClass = "toast-bottom-left";
            toastr.error('A question must have at least 2 answers!');
            return false;
        }

        return true;
    }
});