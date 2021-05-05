$(document).ready(function () {

    $.ajax({
        url: "/Account/IsAuthenticated",
        data: {
        },
        type: "post"
    })
        .done(function (result) {
            if (result != null) {
                $('#username a').text(result.userFullName);
                $('#login').remove();
            }
            else {
                $('#username').remove();
                $('#logout').remove();
            }
        })
});