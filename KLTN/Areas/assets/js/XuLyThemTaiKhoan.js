$(document).ready(function () {
    $("#formThemMoi").on("submit", function (event) {
        event.preventDefault();
        var isValid = true;

        // Xóa thông báo cũ
        $(".tx-danger").remove();

        // Kiểm tra Họ và tên
        var HoVaTen = $("#val_HoVaTen").val();
        if (!HoVaTen) {
            $("#messageHoVaTen").html("<div class='tx-danger'>Họ và tên không được để trống.</div>");
            isValid = false;
        }

        // Kiểm tra Tên đăng nhập
        var TenDangNhap = $("#val_TenDangNhap").val();
        if (!TenDangNhap) {
            $("#messageTenDangNhap").html("<div class='tx-danger'>Tên đăng nhập không được để trống.</div>");
            isValid = false;
        }

        // Kiểm tra Nhóm quyền
        var NhomQuyen = $("#val_PhanLoai").val();
        if (!NhomQuyen) {
            $("#messageNhomQuyen").html("<div class='tx-danger'>Nhóm quyền không được để trống.</div>");
            isValid = false;
        }

        // Kiểm tra Email
        var Email = $("#val_email").val();
        if (!Email) {
            $("#messageEmail").html("<div class='tx-danger'>Email không được để trống.</div>");
            isValid = false;
        } else if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(Email)) {
            $("#messageEmail").html("<div class='tx-danger'>Email không đúng định dạng.</div>");
            isValid = false;
        }

        // Kiểm tra Mật khẩu
        var Pass = $("#pass").val();
        if (!Pass) {
            $("#messagePass").html("<div class='tx-danger'>Mật khẩu không được để trống.</div>");
            isValid = false;
        }

        // Nếu hợp lệ, gửi form
        if (isValid) {
            this.submit();
        }
    });
});