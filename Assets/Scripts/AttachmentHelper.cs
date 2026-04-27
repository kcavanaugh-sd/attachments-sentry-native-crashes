using System;
using System.Globalization;
using System.IO;
using System.Text;
using UnityEngine;


    public static class AttachmentHelper
    {
        public static readonly string FilePath = Path.Combine(Application.persistentDataPath, "SampleFile.txt");
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        private static void OnApplicationLoaded()
        {
            WriteFileContents();
        }

        private static void WriteFileContents()
        {
            StringBuilder message = new StringBuilder();

            message.AppendLine($"Writing file on launch at {DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)}");
            message.AppendLine($"Device: {SystemInfo.deviceModel}");
            message.AppendLine($"OS: {SystemInfo.operatingSystem}");
            message.AppendLine($"Unity: {Application.unityVersion}");
            
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
            }

            File.WriteAllText(FilePath, message.ToString());
        }
    }