using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;
using System.Security.Principal;

namespace Invertex.UnityVersionLauncher
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            GetUnityVersions();
        }

        public List<UnityInstallObject> UnityInstalls
        {
            get { return unityInstalls; }
            set { unityInstalls = value; }
        }

        public List<UnityInstallObject> unityInstalls = new List<UnityInstallObject>();

        public class UnityInstallObject
        {
            public string version;
            public string displayVersion;

            public string DisplayVersion
            {
                get { return displayVersion; }
            }

            public string keyPath;
            public string installPath;
        };

        public void GetUnityVersions()
        {
            string uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(uninstallKey))
            {
                foreach (string skName in rk.GetSubKeyNames())
                {
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        try
                        {
                            if (sk.Name.Contains("Unity"))
                            {
                                string installLoc = sk.GetValue("DisplayIcon").ToString();
                                string dispVer = sk.GetValue("DisplayVersion").ToString();
                                string keyPath = sk.Name.Replace(@"HKEY_LOCAL_MACHINE\", "");
                                if (File.Exists(installLoc))
                                {
                                    UnityInstallObject unityInstall = new UnityInstallObject();
                                    unityInstall.installPath = installLoc;
                                    unityInstall.version = FileVersionInfo.GetVersionInfo(installLoc).ProductVersion;
                                    unityInstall.displayVersion = dispVer;
                                    unityInstall.keyPath = keyPath;

                                    CheckIfExistingInstall(unityInstalls, unityInstall);
                                }
                                else
                                {
                                    DialogResult dialogResult = MessageBox.Show("Registry key for " + dispVer + " has empty install location, registry entry is useless, Delete?",
                                                                                "Empty Registry Key Detected",
                                                                                MessageBoxButtons.YesNo);
                                    if (dialogResult == DialogResult.Yes)
                                    {
                                        RemoveKey(keyPath);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        { }
                    }
                  
                }
            }
            this.UnityInstallList.DataSource = this.UnityInstalls;
        }

        bool CheckIfExistingInstall(List<UnityInstallObject> installList, UnityInstallObject nextInstall)
        {
            for(int i = 0; i < installList.Count; i++)
            {
                if(installList[i].installPath.Equals(nextInstall.installPath))
                {
                    int displayVerDiff = String.Compare(installList[i].displayVersion, nextInstall.displayVersion);

                    if(displayVerDiff < 0)
                    {
                        RemoveDuplicateVersionPrompt(installList[i], nextInstall);
                        installList[i] = nextInstall;
                    }
                    else if(displayVerDiff > 0)
                    {
                        RemoveDuplicateVersionPrompt(nextInstall, installList[i]);
                    }
                    else
                    {
                        Console.WriteLine(nextInstall.displayVersion + " is duplicate of: " + installList[i].displayVersion);
                    }
                    return true;
                }
            }
            unityInstalls.Add(nextInstall);
            return false;
        }

        void RemoveDuplicateVersionPrompt(UnityInstallObject older, UnityInstallObject newer)
        {
            DialogResult dialogResult = MessageBox.Show(
                "Registry keys for " + older.displayVersion + " & " + newer.displayVersion + " have matching install locations." + Environment.NewLine + 
                "Remove useless " + older.displayVersion + " Registry key?", "Matching install paths detected!", 
                MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                RemoveKey(older.keyPath);
            }
        }

        public static void RemoveKey(string key)
        {
            if (IsAdministrator() == false)
            {
                // Launch new instance of this program as Admin so we can delete registry key, instace kills itself right after.
                var exeName = Process.GetCurrentProcess().MainModule.FileName;
                ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                startInfo.Verb = "runas";
                string argers = " \"" + key + "\"" + "^del";
                startInfo.Arguments = argers;
                Process.Start(startInfo);
                return;
            }

            Registry.LocalMachine.DeleteSubKeyTree(key);
            MessageBox.Show(Environment.NewLine + key,  "Deleted Registry Key", MessageBoxButtons.OK);
        }

        private static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void OptionChosen(object sender, MouseEventArgs e)
        {
            UnityInstallObject unityInstall = (UnityInstallObject)UnityInstallList.SelectedItem;
            Process.Start(unityInstall.installPath);
            Application.Exit();
        }

        private void AuthorLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://invertex.xyz");
        }
    }
}
