using Sentry.Unity;
using UnityEngine;

public class SentryOptionConfiguration : SentryOptionsConfiguration
{
    public override void Configure(SentryUnityOptions options)
    {
        Debug.Log("[SENTRY] Configuring Sentry to add OnBeforeSend method");
        options.Debug = true;
        options.Environment = "test";
        options.CaptureInEditor = true;
        options.SetBeforeSend(CrashHelper.OnBeforeSend);
    }
}