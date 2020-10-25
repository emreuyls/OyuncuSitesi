$(document).ready(function () {
    showInPopup = (url, title) => {

        $.ajax({
            type: 'GET',
            url: url,
            success: function (res) {
                $('#panel-modal .modal-body').html(res);
                $('#panel-modal .modal-title').html(title);
                $('#panel-modal').modal('show')
            }
        });
    };


});

jQueryAjaxPost = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.success) {
                    location.reload();
                }
                else {
                    console.log(res);
                    $('#panel-modal .modal-body').html(res.html);
                    if (res.customerror != null) {
                        ValidationErrors(res.customerror[0]);
                    }
                }
            },
            error: function (err) {
                console.log(err)
            }
        })
        function ValidationErrors(errors) {           
            $.each(error, function (code, msg) {
                console.log(msg.message)
                $('.alert').alert().text(msg.message)
            });
        }
        return false;
    } catch (ex) {
        console.log(ex)
    }
}

transferUser = () => {
    console.log("transfer button2")
    var id = $("#roleuserid").html();
    var url = "/admin/role/AddUserRole";
    var rolename = $("#RoleName").val();
    $.ajax({
        type: 'POST',
        url: url,
        data: {
            "roleuserid": id, "rolename": rolename
        },
        success: function (res) {
            if (res.success) {
                location.reload();
            }
            else {
                $('.alert').show()
                ValidationErrors(res.errors);

            }
        }
    });
    function ValidationErrors(errors) {
        var error = JSON.parse(errors)
        $.each(error, function (Code, message) {
            console.log(message.Message)
            $('.alert').alert().text(message.Message)
        });
    }
};
