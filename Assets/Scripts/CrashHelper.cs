using System;
using System.IO;
using Sentry;
using Sentry.Unity;
using UnityEngine;
using UnityEngine.Diagnostics;

public class CrashHelper : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("[SENTRY] Adding " + AttachmentHelper.FilePath +" to Sentry scope");
        SentrySdk.ConfigureScope(scope =>
        {
            scope.AddAttachment(AttachmentHelper.FilePath);
        });
    }
    
    public static SentryEvent OnBeforeSend(SentryEvent evt, SentryHint hint)
    {
        evt.SetTag("application.build", "test build");
        evt.SetTag("OnBeforeSend", "ran successfully");
        
        return evt;
    }

    public void ThrowException()
    {
        throw new Exception("Hello I am an unhandled exception.");
    }
    
    public void AccessViolation()
    {
        Utils.ForceCrash(ForcedCrashCategory.AccessViolation);
    }
    
    public void Abort()
    {
        Utils.ForceCrash(ForcedCrashCategory.Abort);
    }
    
    public void FatalError()
    {
        Utils.ForceCrash(ForcedCrashCategory.FatalError);
    }
}
