﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WorldClock
{
    public partial class SettingsForm : Form
    {
        private IReadOnlyCollection<TimeZoneInfo> zones;

        public SettingsForm()
        {
            InitializeComponent();

            ButtonIn.Text = char.ConvertFromUtf32(9654);
            ButtonOut.Text = char.ConvertFromUtf32(9664);
            ButtonUp.Text = char.ConvertFromUtf32(9650);
            ButtonDown.Text = char.ConvertFromUtf32(9660);

            zones = GetAllTimezones();
            PopulatePlaces();
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private IReadOnlyCollection<TimeZoneInfo> GetAllTimezones()
        {
            return TimeZoneInfo.GetSystemTimeZones();
        }

        private void PopulatePlaces()
        {
            ListBoxPlaces.Items.Clear();

            foreach (TimeZoneInfo zone in zones)
            {
                if (TextBoxFilter.Text == "")
                {
                    ListBoxPlaces.Items.Add(zone.Id);
                }
                else
                {
                    if (zone.Id.Contains(TextBoxFilter.Text))
                    {
                        ListBoxPlaces.Items.Add(zone.Id);
                    }
                }
            }
        }

        private void TextBoxFilter_TextChanged(object sender, EventArgs e)
        {
            PopulatePlaces();
        }

        private void ButtonIn_Click(object sender, EventArgs e)
        {
            ArrayList selected = new ArrayList(ListBoxPlaces.SelectedItems);

            foreach (String item in selected)
            {
                ListBoxSelected.Items.Add(item);
                ListBoxPlaces.Items.Remove(item);
            }
        }

        private void ButtonOut_Click(object sender, EventArgs e)
        {
            ArrayList selected = new ArrayList(ListBoxSelected.SelectedItems);

            foreach (String item in selected)
            {
                ListBoxPlaces.Items.Add(item);
                ListBoxSelected.Items.Remove(item);
            }
        }

        private void ButtonUp_Click(object sender, EventArgs e)
        {
            if (ListBoxSelected.SelectedIndex != -1)
            {
                if (ListBoxSelected.SelectedIndex > 0)
                {
                    ListBoxSelected.Items.Insert(ListBoxSelected.SelectedIndex + 1, ListBoxSelected.Items[ListBoxSelected.SelectedIndex - 1]);
                    ListBoxSelected.Items.RemoveAt(ListBoxSelected.SelectedIndex - 1);
                }
            }
        }

        private void ButtonDown_Click(object sender, EventArgs e)
        {
            if (ListBoxSelected.SelectedIndex != -1)
            {
                if (ListBoxSelected.SelectedIndex < ListBoxSelected.Items.Count - 1)
                {
                    if (ListBoxSelected.SelectedIndex + 2 > ListBoxSelected.Items.Count - 1)
                    {
                        ListBoxSelected.Items.Add(ListBoxSelected.Items[ListBoxSelected.SelectedIndex]);
                        ListBoxSelected.Items.RemoveAt(ListBoxSelected.SelectedIndex);
                        ListBoxSelected.SelectedIndex = ListBoxSelected.Items.Count - 1;
                    }
                    else
                    {
                        ListBoxSelected.Items.Insert(ListBoxSelected.SelectedIndex + 2, ListBoxSelected.Items[ListBoxSelected.SelectedIndex]);
                        int newSelected = ListBoxSelected.SelectedIndex + 1;
                        ListBoxSelected.Items.RemoveAt(ListBoxSelected.SelectedIndex);
                        ListBoxSelected.SelectedIndex = newSelected;
                    }
                }
            }
        }
    }
}