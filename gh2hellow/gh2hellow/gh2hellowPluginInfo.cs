using System;
using System.Reflection;
using Grasshopper2.UI;
using Grasshopper2.UI.Icon;


namespace gh2hellow
{
    public sealed class gh2hellowPluginInfo : Grasshopper2.Framework.Plugin
    {
        static T GetAttribute<T>() where T : Attribute => typeof(gh2hellowPluginInfo).Assembly.GetCustomAttribute<T>();

        public gh2hellowPluginInfo()
          : base(new Guid("2622082d-908e-4e65-b8ec-40bb3b77d449"),
                 new Nomen(
                    GetAttribute<AssemblyTitleAttribute>()?.Title,
                    GetAttribute<AssemblyDescriptionAttribute>()?.Description),
                 typeof(gh2hellowPluginInfo).Assembly.GetName().Version)
        {
            Icon = AbstractIcon.FromResource("gh2hellowPlugin", typeof(gh2hellowPluginInfo));
        }

        public override string Author => GetAttribute<AssemblyCompanyAttribute>()?.Company;

        public override sealed IIcon Icon { get; }

        public override sealed string Copyright => GetAttribute<AssemblyCopyrightAttribute>()?.Copyright ?? base.Copyright;

        // public override sealed string Website => "https://mywebsite.example.com";

        // public override sealed string Contact => "myemail@example.com";

        // public override sealed string LicenceAgreement => "license or URL";

    }
}