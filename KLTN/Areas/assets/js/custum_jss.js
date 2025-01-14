(function ($) {
    "use strict";

    $(document).ready(function () {
        // Lấy thông báo và cấu hình từ TempData
        var message = '@TempData["ToastMessage"]';
        var type = '@TempData["ToastType"]';
        var customClass = '@TempData["ToastCustomClass"]'; // Lớp tùy chỉnh từ TempData

        if (message) {
            toastr.options = {
                timeOut: 5000, // Thời gian hiển thị (ms)
                closeButton: true, // Nút đóng
                progressBar: true, // Thanh tiến trình
                positionClass: "toast-top-right", // Vị trí hiển thị
                toastClass: customClass || "toast", // Lớp CSS tùy chỉnh
            };

            // Hiển thị thông báo dựa trên loại
            switch (type) {
                case "success":
                    toastr.success(message, "Thành công");
                    break;
                case "info":
                    toastr.info(message, "Thông báo");
                    break;
                case "warning":
                    toastr.warning(message, "Cảnh báo");
                    break;
                case "error":
                    toastr.error(message, "Lỗi");
                    break;
            }
        }
    });
})(jQuery);