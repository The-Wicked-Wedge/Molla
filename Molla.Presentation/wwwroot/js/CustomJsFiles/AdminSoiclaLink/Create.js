$("#createsubmit").click = function () {

    const Url = $("form").attr("action");

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
                    text: "Slider Created Successfuly",
                    type: "success",
                    showConfirmButton: true,
                    showCancelButton: true,
                    confirmButtonText: "Return To Index",
                    cancelButtonText: "Add One More"
                }).then(async function (result) {
                    if (result.dismiss != 'cancel') {
                        const indexUrl = '/Admin/SocialLink';

                        window.location.replace(indexUrl);
                    } else {
                        window.location.reload();
                    }
                });

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