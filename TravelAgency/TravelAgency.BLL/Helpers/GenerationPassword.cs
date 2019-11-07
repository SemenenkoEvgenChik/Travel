using System;
using System.Text;

namespace TravelAgency.BLL.Helpers
{
    public static class GenerationPassword
    {
        public static Random random = new Random((int)DateTime.Now.Ticks);
        public static string GeneratePassword()
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < 10; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }
    }
}
