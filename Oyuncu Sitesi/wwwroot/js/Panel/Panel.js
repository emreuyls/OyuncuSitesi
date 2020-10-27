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
        $('#paneltable').DataTable({
            language: {
            info: "_TOTAL_ kayıttan _START_ - _END_ kayıt gösteriliyor.",
                infoEmpty:      "Gösterilecek hiç kayıt yok.",
                loadingRecords: "Kayıtlar yükleniyor.",
                zeroRecords: "Tablo boş",
                search: "Arama:",
                sLengthMenu: "Sayfada _MENU_ Sırala",
                infoFiltered:   "(toplam _MAX_ kayıttan filtrelenenler)",
                buttons: {
            copyTitle: "Panoya kopyalandı.",
                    copySuccess:"Panoya %d satır kopyalandı",
                    copy: "Kopyala",
                    print: "Yazdır",
                },

                paginate: {
            first: "İlk",
                    previous: "Önceki",
                    next: "Sonraki",
                    last: "Son"
                },
            }
        });
});

$(function () {
    var sPath = window.location.pathname;
    var sPage = sPath.substring(sPath.lastIndexOf('/') + 1);
    $('a[href="' + sPath + '"]').parent("li").addClass('active');
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
             
                $('.alert').alert().text(msg.message)
            });
        }
        return false;
    } catch (ex) {
        console.log(ex)
    }
}

transferUser = () => {
   
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
            $('.alert').alert().text(message.Message)
        });
    }
};
