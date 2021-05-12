$(document).ready(function () {

    $.ajax({
        url: "/Account/IsAuthenticated",
        data: {
        },
        type: "post"
    })
        .done(function (result) {
            if (result != null) {

                if (!result.userTypeName.toLowerCase().includes("admin")) {
                    $('#overview').remove();
                    $('#hrview').remove();
                }

                $('#userrol a i').after(" " + result.userTypeName);
                $('#username a i').after(" " + result.userFullName);
                $('#login').remove();
            }
            else {
                $('#overview').remove();
                $('#owncommissions').remove();
                $('#hrview').remove();
                $('#username').remove();
                $('#logout').remove();
            }
        })
});