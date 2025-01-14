using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KLTN.Models
{
    public static class TempDataHelper
    {
        public static void SetTempData(Controller controller, string message, string type)
        {
            var classMap = new Dictionary<string, string>
        {
            { "success", "toast-success-custom" },
            { "warning", "toast-warning-custom" },
            { "error", "toast-error-custom" },
            { "info", "toast-info-custom" },
        };
            string customClass = classMap.ContainsKey(type) ? classMap[type] : "toast-info-custom";

            controller.TempData["ToastMessage"] = message;
            controller.TempData["ToastType"] = type;
            controller.TempData["ToastCustomClass"] = customClass;
        }
        public static string ChuyenTiengVietKhongDau(string strVietNamese)
        {
            const string TextToFind = "áàảãạâấầẩẫậăắằẳẵặđéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶĐÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴ";
            const string TextToReplace = "aaaaaaaaaaaaaaaaadeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAADEEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYY";
            int index = -1;
            while ((index = strVietNamese.IndexOfAny(TextToFind.ToCharArray())) != -1)
            {
                int index2 = TextToFind.IndexOf(strVietNamese[index]);
                strVietNamese = strVietNamese.Replace(strVietNamese[index], TextToReplace[index2])
                                             .Replace(" ", "");
            }
            // strVietNamese = strVietNamese.Replace(" ", "-").Replace(".", "");
            return strVietNamese;

        }
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static string GetFolderByDate()
        {
            return $"{DateTime.Now.Year}/{DateTime.Now.Month}/{DateTime.Now.Day}/";
        }
    }
}