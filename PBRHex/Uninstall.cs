using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.IO;

namespace PBRHex
{
    [RunInstaller(true)]
    public partial class Uninstall : Installer
    {
        protected override void OnAfterUninstall(IDictionary savedState) {
            base.OnAfterUninstall(savedState);
            Directory.Delete(Program.DataDir, true);
        }
    }
}
