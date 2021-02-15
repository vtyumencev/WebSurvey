$(document).on('change', '.ob-radio', function (e) {
    $(this).parents(".question-block").removeClass('warning').find('.option-block').removeClass("active");
    $(this).parents(".option-block").addClass("active");
}).on('focus', '.ob-radio', function (e) {
    $(this).parents(".option-block").addClass("focus");
}).on('blur', '.ob-radio', function (e) {
    $(".option-block").removeClass("focus");
});

$(document).on('click', '.send-survey', function (e) {
    let val;
    let isReadyForSend = true;
    let answers = [];
    $('.questions-body .question-block').each(function (i) {
        val = $(this).find('input.ob-radio:checked').val();
        if (!val && $(this).hasClass("is-required")) {
            $(this).addClass("warning");
            isReadyForSend = false;
        }
        else {
            answers.push(
                {
                    QuestionID: parseInt($(this).attr("data-question-id")),
                    OptionID: parseInt(val)
                });
        }
    });

    if (isReadyForSend) {
        let el = $(this);

        if (el.hasClass("pending")) return;
        else {
            el.addClass("pending");
            $.ajax({
                url: '/Answers/Post',
                type: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(answers),
                complete (data) {
                    el.removeClass("pending");
                    completeSurveyAnim();
                }
            });
        }
    }
});

function completeSurveyAnim() {
    let sb = $('.survey-body').outerHeight();
    $('.survey-body').height(sb);

    $('.done-message').show();

    setTimeout(function () {
        $('.survey-body').addClass('hidden');
        $('.survey-body').height(0);
    }, 5);

    setTimeout(function () {
        $('.done-message').addClass('show');
    }, 100);
}