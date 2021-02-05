using System.Threading.Tasks;
using Xamarin.Essentials;
using static Xamarin.Essentials.Permissions;

namespace SampleSdk.Utils
{
    public static class PermissionHelper
    {
        public static async Task<bool> CheckAndRequestPermissionAsync<T>(T permission)
            where T : BasePermission
        {
            var status = await permission.CheckStatusAsync();
            if (status != PermissionStatus.Granted)
            {
                status = await permission.RequestAsync();
            }

            return status == PermissionStatus.Granted;
        }

    }
}
