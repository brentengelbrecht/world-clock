using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WorldClock
{
    public partial class SettingsForm : Form
    {
        private IReadOnlyCollection<TimeZoneInfo> zones;
        private Configuration configuration;

        public SettingsForm(Configuration Configuration)
        {
            InitializeComponent();

            this.configuration = Configuration;

            ButtonIn.Text = char.ConvertFromUtf32(9654);
            ButtonOut.Text = char.ConvertFromUtf32(9664);
            ButtonUp.Text = char.ConvertFromUtf32(9650);
            ButtonDown.Text = char.ConvertFromUtf32(9660);

            zones = GetAllTimezones();
            PopulatePlaces();
            PopulateSelected();
            PopulateDisplay();
            PopulateProgram();
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            ArrayList listToSave = new ArrayList();
            foreach (String s in ListBoxSelected.Items)
            {
                listToSave.Add(s);
            }
            configuration.SetTimezoneIds(listToSave);

            configuration.InternationalTime = CheckBox24Hour.Checked;
            configuration.IncludeSeconds = CheckBoxIncludeSeconds.Checked;

            configuration.MinimizeOnClose = CheckBoxMinimize.Checked;

            configuration.Save();
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private IReadOnlyCollection<TimeZoneInfo> GetAllTimezones()
        {
            return TimeZoneInfo.GetSystemTimeZones();
        }

        private void PopulateSelected()
        {
            ArrayList loaded = (ArrayList)configuration.GetTimezoneIds();
            ListBoxSelected.Items.Clear();
            foreach (String s in loaded)
            {
                ListBoxSelected.Items.Add(s);
                ListBoxPlaces.Items.Remove(s);
            }
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

        private void PopulateDisplay()
        {
            CheckBox24Hour.Checked = configuration.InternationalTime;
            CheckBoxIncludeSeconds.Checked = configuration.IncludeSeconds;
        }

        private void PopulateProgram()
        {
            CheckBoxMinimize.Checked = configuration.MinimizeOnClose;
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
