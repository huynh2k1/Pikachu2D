namespace HUtils
{
    public static class CoinUtil
    {
        //Từ khóa this - báo hiệu đây là một phương thức mở rộng dành cho kiểu int
        //Hàm này trả về string chỉ hiển thị 000 + đơn vị
        public static string GetNumberAroundString(this int input)
        {
            if (input < 5000)
                return input.ToString();
            else if (input < 1_000_000)
                return input / 1_000 + "K";
            else if (input < 1_000_000_000)
                return input / 1_000_000 + "M";

            return input.ToString();
        }

        public static string GetNumberAroundString(this long input)
        {
            if (input < 5000)
                return input.ToString();
            else if (input < 1_000_000)
                return input / 1_000 + "K";
            else if (input < 1_000_000_000)
                return input / 1_000_000 + "M";
            else if (input < 1_000_000_000_000)
                return input / 1_000_000_000 + "B";

            return input.ToString();
        }
    }
}
