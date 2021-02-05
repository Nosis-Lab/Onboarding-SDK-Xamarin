using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleSdk.Utils
{
    /// <summary>
    /// Helpers de navegación
    /// </summary>
    public static class NavigationExtensions
    {
        /// <summary>
        /// Devuelve la página del tipo solicitado,
        /// o null si no existe
        /// </summary>
        public static T Find<T>(this INavigation @this) where T : Page
        {
            return @this.NavigationStack.Where(page => page is T).SingleOrDefault() as T;
        }

        /// <summary>
        /// Vuelve a la página solicitada 
        /// eliminando todas las páginas que se encuentren por encima de la misma
        /// </summary>
        public static async Task PopAsync(this INavigation @this, Page targetPage)
        {
            int i = @this.NavigationStack.Count - 2;

            while (i > 0)
            {
                var page = @this.NavigationStack[i];
                if (page == targetPage)
                    break;
                @this.RemovePage(page);
                i = i - 1;
            }

            await @this.PopAsync();
        }

        /// <summary>
        /// Muestra la página solicitada
        /// reemplanzando del stack la página actual
        /// </summary>
        /// <remarks>
        /// Para corregir un efecto de flicker indeseado,
        /// primero se hace el push de la nueva página y luego se corrige el stack
        /// </remarks>
        public static async Task ReplaceAsync(this INavigation @this, Page newPage)
        {
            var currPage = @this.NavigationStack[@this.NavigationStack.Count - 1];

            // var currPage = @this.NavigationStack.Last();

            await @this.PushAsync(newPage);

            @this.RemovePage(currPage);
        }

        /// <summary>
        /// Muestra la página solicitada
        /// eliminando del stack de navegación todas las páginas intermedias de la pagina desde la que se la solicita.
        /// </summary>
        /// <returns></returns>
        public static async Task PushFromAsync(this INavigation @this, Page fromPage, Page newPage)
        {
            var lista = new List<Page>();
            int i = @this.NavigationStack.Count - 1;

            while (i > 0)
            {
                var page = @this.NavigationStack[i];
                if (page == fromPage)
                    break;
                lista.Add(page);
                i--;
            }

            await @this.PushAsync(newPage);

            foreach (var page in lista)
                @this.RemovePage(page);
        }

        /// <summary>
        /// Muestra la página solicitada como la segunda página del stack de navegación. Si hay otras páginas las elimina del stack.
        /// </summary>
        public static async Task PushAfterRoot(this INavigation @this, Page secondPage)
        {
            if(@this.NavigationStack.Count == 1)
            {
                await @this.PushAsync(secondPage);
            }
            else
            {
                var firstPage = @this.NavigationStack[0];
                await @this.PushFromAsync(firstPage, secondPage);
            }
        }
    }
}