//$(function () {
//    var noQuestionFrame =
//        `<div>
//            <h4 class="w-100 p-3">You need to add Questions to your Test</h4>
//        </div>`;

//    var noAnswersFrame =
//        `<div class="no-answers">
//            <h4 class="w-100 p-3">You need to add Answers to your Question</h4>
//        </div>`;

//    //configs
//    var questionSummernoteConfig = {
//        placeholder: 'Add your description here...',
//        height: 200,
//        toolbar: [
//            ['style', ['bold', 'italic', 'underline', 'clear']],
//            ['font', ['strikethrough', 'superscript', 'subscript']],
//            ['fontsize', ['fontsize']],
//            ['para', ['ul', 'ol', 'paragraph']]
//        ],
//        disableResizeEditor: true
//    };

//    var answerSummernoteConfig = {
//        height: 200,
//        toolbar: [
//            ['style', ['bold', 'italic', 'underline', 'clear']],
//            ['font', ['strikethrough', 'superscript', 'subscript']],
//            ['fontsize', ['fontsize']],
//            ['para', ['ul', 'ol', 'paragraph']]
//        ],
//        disableResizeEditor: true
//    };

//    // functions
//    var initializeSummernote = (function () {
//        $('.summernote')
//            .toArray()
//            .forEach(function (textarea) {
//                var text = textarea.textContent;
//                $(textarea).summernote(answerSummernoteConfig);
//                textarea.textContent = text;
//            });
//    })();

//    //todo radio button click to match model props

//    var collapseQuestions = $('.collapseBtn').on('click', function () {
//        $('.changeIcon').toggleClass("glyphicon-minus").toggleClass("glyphicon-plus");
//    });


//});

$(function () {
    var questionFrame =
        ` <div id="question-{{q_id}}" class="question-container panel panel-default">

     <button class="collapseBtn question btn btn-success btn-sm pull-right" href="#collapse-{{q_id}}" data-toggle="collapse" type="button">
         <span class="changeIcon glyphicon glyphicon-plus"></span>
     </button>
     <button class="delete-question btn btn-danger btn-sm pull-right" type="button">
         <span class="glyphicon glyphicon-trash"></span>
     </button>
     <button class="edit-question btn btn-info btn-sm pull-right" type="button">
         <span class="glyphicon glyphicon-pencil"></span>
     </button>
     <div>
         <a class="panel-heading" href="#collapse-{{q_id}}" data-toggle="collapse">
             <h4 class="panel-title">
                 Question {{q_number}}
             </h4>
         </a>
     </div>

     <div id="collapse-{{q_id}}" class="panel-collapse collapse">
         <div class="panel-body">
             <div class="question-description">
                 <h4>Description</h4>
                 <input type="hidden" id="Questions_{{q_id}}__Description" name="Questions[{{q_id}}].Description" value="" />
                 <textarea id="Questions_{{q_id}}__Description" name="Questions[{{q_id}}].Description" class="summernote form-control"></textarea>
                 <span asp-validation-for="Questions[@i].Description" class="text-danger"></span>


             </div>

             <div class="answers-container">

                 <div id="question-{{q_id}}-answer-0" class="answer-container">
                     <div class="answer-header">
                         <button class="delete-answer btn btn-danger btn-xs pull-right" type="button">
                             <span class="glyphicon glyphicon-trash"></span>
                         </button>
                         <label class="btn btn-success btn-xs pull-right">
                             <input id="Questions_{{q_id}}__Answers_0__IsCorrect" name="radio-{{q_id}}" class="answer-is-correct" type="radio" value="true" autocomplete="off" checked />
                             <span class="glyphicon glyphicon-ok">Correct</span>
                         </label>
                     </div>
                     <input type="hidden" id="Questions_{{q_id}}__Answers_0__DescriptionPlainText" name="Questions[{{q_id}}].Answers[0].DescriptionPlainText" value="" />
                     <h4>Answer 1</h4>
                     <textarea id="Questions_{{q_id}}__Answers_0__Description" name="Questions[{{q_id}}].Answers[0].Description" class="answer-content summernote form-control"></textarea>
                 </div>

                 <div id="question-{{q_id}}-answer-1" class="answer-container">
                     <div class="answer-header">
                         <button class="delete-answer btn btn-danger btn-xs pull-right" type="button">
                             <span class="glyphicon glyphicon-trash"></span>
                         </button>
                         <label class="btn btn-success btn-xs pull-right">
                             <input id="Questions_{{q_id}}__Answers_1__IsCorrect" name="radio-{{q_id}}" class="answer-is-correct" type="radio" value="true" autocomplete="off" checked />
                             <span class="glyphicon glyphicon-ok">Correct</span>
                         </label>
                     </div>
                     <input type="hidden" id="Questions_{{q_id}}__Answers_1__DescriptionPlainText" name="Questions[{{q_id}}].Answers[1].DescriptionPlainText" value="" />
                     <h4>Answer 2</h4>
                     <textarea id="Questions_{{q_id}}__Answers_1__Description" name="Questions[{{q_id}}].Answers[1].Description" class="answer-content summernote form-control"></textarea>
                 </div>

                 <div id="question-{{q_id}}-answer-2" class="answer-container">
                     <div class="answer-header">
                         <button class="delete-answer btn btn-danger btn-xs pull-right" type="button">
                             <span class="glyphicon glyphicon-trash"></span>
                         </button>
                         <label class="btn btn-success btn-xs pull-right">
                             <input id="Questions_{{q_id}}__Answers_2__IsCorrect" name="radio-{{q_id}}" class="answer-is-correct" type="radio" value="true" autocomplete="off" checked />
                             <span class="glyphicon glyphicon-ok">Correct</span>
                         </label>
                     </div>
                     <input type="hidden" id="Questions_{{q_id}}__Answers_2__DescriptionPlainText" name="Questions[{{q_id}}].Answers[2].DescriptionPlainText" value="" />
                     <h4>Answer 3</h4>
                     <textarea id="Questions_{{q_id}}__Answers_2__Description" name="Questions[{{q_id}}].Answers[2].Description" class="answer-content summernote form-control"></textarea>
                 </div>
             </div>
             <div class="panel-body">
                 <button class="add-answer btn btn-default pull-right" name="collapse-{{q_id}}" type="button">Add Answer</button>
             </div>
         </div>
     </div>`;

    var answerFrame = 
        `<div class="answers-container">

                 <div id="question-{{q_id}}-answer-{{a_id}}" class="answer-container">
                     <div class="answer-header">
                         <button class="delete-answer btn btn-danger btn-xs pull-right" type="button">
                             <span class="glyphicon glyphicon-trash"></span>
                         </button>
                         <label class="btn btn-success btn-xs pull-right">
                             <input id="Questions_{{q_id}}__Answers_{{a_id}}__IsCorrect" name="radio-{{q_id}}" class="answer-is-correct" type="radio" value="true" autocomplete="off" checked />
                             <span class="glyphicon glyphicon-ok">Correct</span>
                         </label>
                     </div>
                     <input type="hidden" id="Questions_{{q_id}}__Answers_{{a_id}}__DescriptionPlainText" name="Questions[{{q_id}}].Answers[{{a_id}}].DescriptionPlainText" value="" />
                     <h4>Answer {{a_number}}</h4>
                     <textarea id="Questions_{{q_id}}__Answers_{{a_id}}__Description" name="Questions[{{q_id}}].Answers[{{a_id}}].Description" class="answer-content summernote form-control"></textarea>
                 </div>
        </div>`;

    var questionSummernoteConfig = {
        placeholder: 'Add your description here...',
        height: 200,
        toolbar: [
            ['style', ['bold', 'italic', 'underline', 'clear']],
            ['font', ['strikethrough', 'superscript', 'subscript']],
            ['fontsize', ['fontsize']],
            ['para', ['ul', 'ol', 'paragraph']]
        ],
        disableResizeEditor: true
    };

    var answerSummernoteConfig = {
        height: 200,
        toolbar: [
            ['style', ['bold', 'italic', 'underline', 'clear']],
            ['font', ['strikethrough', 'superscript', 'subscript']],
            ['fontsize', ['fontsize']],
            ['para', ['ul', 'ol', 'paragraph']]
        ],
        disableResizeEditor: true
    };

    //functions
    var initializeSummernote = function () {
        $('.summernote')
            .toArray()
            .forEach(function (textarea) {
                var text = textarea.textContent;
                $(textarea).summernote(answerSummernoteConfig);
                textarea.textContent = text;
            });
    };

    var radioButtonClick = function (questionNumber) {
        var answerRadioButtons = $(`#question-${questionNumber} .answers-container .answer-container input`)
            .filter(function () {
                return this.type === 'radio';
            });

        var hasCheckedRadioButton = answerRadioButtons
            .is(function () {
                return $(this).prop('checked') === true;
            });

        if (!hasCheckedRadioButton) {
            answerRadioButtons.first().prop('checked', true);
        }
    };

    //var collapseQuestions = function () {
    //    $('#questions-container .question-container > a')
    //        .filter(function () {
    //            var isCollapsed = $(`#${this.parentNode.id} > div`)[0]
    //                .classList
    //                .contains('in');

    //            return isCollapsed;
    //        })
    //        .click();
    //}

    ////event listeners
    //var collapseQuestionsClickEvent = $('#questions-container #collapse-questions').on('click', collapseQuestions);

    var addQuestionClickEvent = $('#questions-container #add-question').on('click', function () {
       // collapseQuestions();

        var newQuestionId = $('#questions-body .question-container').length;
        var questionHtml = questionFrame
            .replace(/\{\{\q_id\}\}/g, newQuestionId)
            .replace(/\{\{\q_number\}\}/g, newQuestionId + 1);

        var question = $(questionHtml);
        question.find(`#Questions_${newQuestionId}__Description`).summernote(questionSummernoteConfig);
        question.find(`.answer-content`).summernote(answerSummernoteConfig);
        $('.note-statusbar').hide();

        if (newQuestionId === 0) {
            $('#questions-container #questions-body')
                .html(question);
        }
        else {
            $('#questions-container #questions-body')
                .append(question);
        }

        $(`#questions-container #questions-body #question-${newQuestionId} a`).click();
    });
});