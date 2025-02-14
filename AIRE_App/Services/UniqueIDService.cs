namespace AIRE_App.Services;

public static class UniqueIDService
{
    private const String deviceIdKey = "DeviceID";

    public static String GetDeviceID()
    {
        if(Preferences.ContainsKey(deviceIdKey))
        {
            return Preferences.Get(deviceIdKey, String.Empty);
        }

#if IOS || MACCATALYST
        String deviceId = $"{{{UIKit.UIDevice.CurrentDevice.IdentifierForVendor}}}";
#elif ANDROID
        String deviceId = Android.Provider.Settings.Secure.GetString(
            Android.App.Application.Context.ContentResolver,
            Android.Provider.Settings.Secure.AndroidId);

        deviceId = $"{{{deviceId.Substring(0, 8)}-{deviceId.Substring(8, 4)}-{deviceId.Substring(12, 4)}-0000-000000000000}}";
#else
        String deviceId = $"{{{Guid.NewGuid()}}}";
#endif
        Preferences.Set(deviceIdKey, deviceId);
        return deviceId;
    }
}