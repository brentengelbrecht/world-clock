﻿using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32;

namespace WorldClock
{
    public class Configuration
    {
        private String registryHome;
        private String keyTimezones;
        private const char delimiter = '-';
        private bool isModified = false;
        private ArrayList timezoneIds = new ArrayList();

        public Configuration(String RegistryHome)
        {
            this.registryHome = RegistryHome;
            this.keyTimezones = registryHome + @"\Timezones";
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

        public void Load()
        {
            ArrayList newList = new ArrayList();

            try
            {
                using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                {
                    using (var tz = hklm.OpenSubKey(keyTimezones))
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
                using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64))
                {
                    hklm.DeleteSubKey(keyTimezones, false);
                    using (var tz = hklm.CreateSubKey(keyTimezones, true))
                    {
                        if (tz != null)
                        {
                            for (int i = 0; i < timezoneIds.Count; i++)
                            {
                                tz.SetValue(String.Format("{0:D3}", i), timezoneIds[i]);
                            }
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