using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ICARUS.HVNC.Properties
{
    [CompilerGenerated]
    [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0")]
    internal sealed class Settings : ApplicationSettingsBase
    {
        private static Settings defaultInstance;

        public static Settings Default => Settings.defaultInstance;

        [UserScopedSetting]
        [DefaultSettingValue("")]
        [DebuggerNonUserCode]
        public string PORT
        {
            get
            {
                return (string)this["PORT"];
            }
            set
            {
                this["PORT"] = value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("")]
        public string String_0
        {
            get
            {
                return (string)this["IP"];
            }
            set
            {
                this["IP"] = value;
            }
        }

        static Settings()
        {
            Settings.defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
        }
    }
}
