$("#editsubmit").click = function () {

    var Url = $("form").attr("action");

    $.ajax({
        url: Url,
        method: 'POST',
        body: new FormData($("form")[0]),
        enctype: 'multipart/form-data',
        processData: false,
        contentType: false,
        cache: false,
        success: function (json) {
            if (!json.includes("Error")) {
                sweetAlert({
                    title: "Done",
                    text: "Baner Edited Successfuly",
                    type: "success",
                    timer: 4000
                })
            } else {
                sweetAlert({
                    title: "Error",
                    text: json,
                    type: "error"
                })

                window.location.reload();
            }
        }
    });

}