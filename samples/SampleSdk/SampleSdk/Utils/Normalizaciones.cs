using System.Globalization;
using System.Linq;

namespace SampleSdk.Utils
{
    public static class Normalizaciones
    {
        public static string FormatearNombreCompleto(string nombre, string apellido)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return string.Empty;

            return string.Format("{0} {1}", FormatearNombre(nombre), FormatearNombre(apellido));
        }

        public static string FormatearNombre(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return string.Empty;

            return string.Join(" ", nombre.Split(' ').Select(item => item.ToCamel()).ToArray());
        }

        public static string FormatearDni(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            try
            {
                return int.Parse(value).ToString("##0,000", new CultureInfo("es-AR"));
            }
            catch
            {
                return value;
            }
        }

        public static string ToCamel(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            return value.Substring(0, 1).ToUpper() + value.Substring(1).ToLower();
        }
    }
}
