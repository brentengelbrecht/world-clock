using System;
using System.Collections;
using Microsoft.Win32;

namespace WorldClock
{
    public class Configuration
    {
        private String registryHome;
        private String keyTimezones;
        private String keyDisplay;
        private String keyProgram;
        private const char delimiter = '-';
        private bool isModified = false;
        private ArrayList timezoneIds = new ArrayList();

        public Configuration(String RegistryHome)
        {
            this.registryHome = RegistryHome;
            this.keyTimezones = registryHome + @"\Timezones";
            this.keyDisplay = registryHome + @"\Display";
            this.keyProgram = registryHome + @"\Program";
            Load();
        }

        public void SetTimezoneIds(ArrayList tz)
        {
            timezoneIds.Clear();
            isModified = true;

            foreach (String s in tz)
            {
                timezoneIds.Add(s);
            }
        }

        public ICollection GetTimezoneIds()
        {
            return new ArrayList(timezoneIds);
        }

        private bool internationalTime;
        public bool InternationalTime
         {
            get
            {
                return internationalTime;
            }
            set
            {
                internationalTime = value;
                isModified = true;
            }
        }

        private bool includeSeconds;
        public bool IncludeSeconds
        {
            get
            {
                return includeSeconds;
            }
            set
            {
                includeSeconds = value;
                isModified = true;
            }
        }

        private bool minimizeOnClose;
        public bool MinimizeOnClose
        {
            get
            {
                return minimizeOnClose;
            }
            set
            {
                minimizeOnClose = value;
                isModified = true;
            }
        }

        private bool minimizeToStatusArea;
        public bool MinimizeToStatusArea
        {
            get
            {
                return minimizeToStatusArea;
            }
            set
            {
                minimizeToStatusArea = value;
                isModified = true;
            }
        }

        private bool launchAtStartup;
        public bool LaunchAtStartup
        {
            get
            {
                return launchAtStartup;
            }
            set
            {
                launchAtStartup = value;
                isModified = true;
            }
        }

        public void Load()
        {
            ArrayList newList = new ArrayList();

            try
            {
                using (var hkcu = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                {
                    using (var tz = hkcu.OpenSubKey(keyTimezones))
                    {
                        if (tz != null)
                        {
                            foreach (String k in tz.GetValueNames())
                            {
                                var v = tz.GetValue(k);
                                newList.Add(k + delimiter + v);
                            }
                            newList.Sort();
                        }

                        foreach (String s in newList)
                        {
                            timezoneIds.Add(s.Substring(s.IndexOf(delimiter) + 1));
                        }

                        isModified = false;
                    }

                    using (var tz = hkcu.OpenSubKey(keyDisplay))
                    {
                        try
                        {
                            internationalTime = tz.GetValue("InternationalTime").Equals("True") ? true : false;
                        }
                        catch (Exception)
                        {
                            internationalTime = true;
                        }

                        try
                        {
                            includeSeconds = tz.GetValue("IncludeSeconds").Equals("True") ? true : false;
                        }
                        catch (Exception)
                        {
                            includeSeconds = true;
                        }
                    }

                    using (var tz = hkcu.OpenSubKey(keyProgram))
                    {
                        try
                        {
                            minimizeOnClose = tz.GetValue("MinimizeOnClose").Equals("True") ? true : false;
                        }
                        catch (Exception)
                        {
                            minimizeOnClose = false;
                        }

                        try
                        {
                            minimizeToStatusArea = tz.GetValue("MinimizeToStatusArea").Equals("True") ? true : false;
                        }
                        catch (Exception)
                        {
                            minimizeToStatusArea = false;
                        }

                        try
                        {
                            launchAtStartup = tz.GetValue("LaunchAtStartup").Equals("True") ? true : false;
                        }
                        catch (Exception)
                        {
                            launchAtStartup = false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void Save()
        {
            if (!isModified)
            {
                return;
            }

            try
            {
                using (var hkcu = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                {
                    hkcu.DeleteSubKey(keyTimezones, false);
                    using (var tz = hkcu.CreateSubKey(keyTimezones, true))
                    {
                        if (tz != null)
                        {
                            for (int i = 0; i < timezoneIds.Count; i++)
                            {
                                tz.SetValue(String.Format("{0:D3}", i), timezoneIds[i]);
                            }
                        }
                    }

                    hkcu.DeleteSubKey(keyDisplay, false);
                    using (var tz = hkcu.CreateSubKey(keyDisplay, true))
                    {
                        tz.SetValue("InternationalTime", internationalTime);
                        tz.SetValue("IncludeSeconds", includeSeconds);
                    }

                    hkcu.DeleteSubKey(keyProgram, false);
                    using (var tz = hkcu.CreateSubKey(keyProgram, true))
                    {
                        tz.SetValue("MinimizeOnClose", minimizeOnClose);
                        tz.SetValue("MinimizeToStatusArea", minimizeToStatusArea);
                        tz.SetValue("LaunchAtStartup", launchAtStartup);
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void SetUserKeyValue(String Node, String Key, String Value)
        {
            try
            {
                using (var hkcu = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
                {
                    using (var rk = hkcu.OpenSubKey(Node, true))
                    {
                        if (Value != null)
                        {
                            rk.SetValue(Key, Value);
                        }
                        else
                        {
                            rk.DeleteValue(Key, false);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
