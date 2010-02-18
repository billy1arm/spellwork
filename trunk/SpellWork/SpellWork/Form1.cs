using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SpellWork.DbcReader;

namespace SpellWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private DataTable spellData { get; set; }
        private DataTable tempTable { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            // read dbc to DataTable
            Spell spell = new Spell();
            spellData = spell.SpellData;

            foreach (var elem in Enum.GetValues(typeof(ProcFlags)))
            {
                // tested
                _clbProcFlaf.Items.Add(elem.ToString().Substring(10));
            }
            SetEnumValues(_cbSpellFamilyNames, typeof(SpellFamilyNames), true);
            SetEnumValues(_cbSpellAura,        typeof(AuraType),        false);
            SetEnumValues(_cbSpellEffect,      typeof(SpellEffects),    false);
            SetEnumValues(_cbTarget1,          typeof(Targets),          true);
        }

        private void SetEnumValues(ComboBox cb, Type enums, bool first)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("NAME");
            if (first)
                dt.Rows.Add(new Object[] {-1, "No filter"});
            
            foreach (var str in Enum.GetValues(enums))
            {
                dt.Rows.Add(new Object[] { (int)str, "(" + ((int)str).ToString("000") + ")" + str });
            }

            cb.DataSource    = dt;
            cb.DisplayMember = "NAME";
            cb.ValueMember   = "ID";
        }

        private void _bSearch_Click(object sender, EventArgs e)
        {
            //todo: inplement spell info in Spell Class
        }

        private void _cbSpellFamilyNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(((ComboBox)sender).SelectedIndex != 0)
            {
                // todo: more ex
                DataView("");
            }
        }

        private void DataView(string index)
        {
            _lvSpellList.Items.Clear();

            var bFamilyNames = _cbSpellFamilyNames.SelectedIndex == 0 ? false : true;
            var fFamilyNames = _cbSpellFamilyNames.SelectedValue.ToString();

            var bSpellAura = _cbSpellAura.SelectedIndex == 0 ? false : true;
            var fSpellAura = _cbSpellAura.SelectedValue.ToString();

            var bSpellEffect = _cbSpellEffect.SelectedIndex == 0 ? false : true;
            var fSpellEffect = _cbSpellEffect.SelectedValue.ToString();

            var bTarget1 = _cbTarget1.SelectedIndex == 0 ? false : true;
            var fTarget1 = _cbTarget1.SelectedValue.ToString();
            
            IEnumerable<DataRow> query = 
                from spell in spellData.AsEnumerable()
                // filter
                where (!bFamilyNames || spell.Field<string>("SpellFamilyName") == fFamilyNames)
                   // if SpellAura selected
                   && (!bSpellAura   || spell.Field<string>("EffectApplyAuraName_1") == fSpellAura
                                     || spell.Field<string>("EffectApplyAuraName_2") == fSpellAura
                                     || spell.Field<string>("EffectApplyAuraName_3") == fSpellAura)
                    // if SpellEffect selected
                   && (!bSpellEffect || spell.Field<string>("Effect_1") == fSpellEffect
                                     || spell.Field<string>("Effect_2") == fSpellEffect
                                     || spell.Field<string>("Effect_3") == fSpellEffect)

                   && (!bTarget1     || spell.Field<string>("Targets") == fTarget1)
                
                select spell;
            
            if (query.Count() == 0) return;

            tempTable = query.CopyToDataTable<DataRow>();
            
            _lvSpellList.Items.Clear();

            foreach (DataRow item in tempTable.Select())
            {
                _lvSpellList.Items.Add(new ListViewItem(new String[] 
                { "" + item["ID"], "" + item["SpellName_1"]+"("+item["Rank_1"]+")" }));
            }
        }

        private void _lvSpellList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _rtSpellInfo.Clear();
            if (_lvSpellList.SelectedItems.Count > 0)
            {
                var entry = _lvSpellList.SelectedItems[0].SubItems[0].Text;
                IEnumerable<DataRow> query = from spell in tempTable.AsEnumerable()
                                             where spell.Field<string>("ID") == entry
                                             select spell;
                DataRow[] dtr = query.CopyToDataTable<DataRow>().Select();

                foreach (var spellInfo in dtr)
                {
                    SpellViewInfo(spellInfo);
                }
            }
        }


        void SpellViewInfo(DataRow spellInfo)
        {
            _rtSpellInfo.SelectionColor = Color.Blue;
            
            _rtSpellInfo.AppendText(String.Format("ID - {0} {1}({2})", spellInfo["ID"], spellInfo["SpellName_1"], spellInfo["Rank_1"]));
            _rtSpellInfo.AppendText("\r\n------------------------------------------");
            _rtSpellInfo.AppendText("\r\nDescription: " + spellInfo["Description_1"]);
            _rtSpellInfo.AppendText("\r\nToolTip: "     + spellInfo["ToolTip_1"]);
            _rtSpellInfo.AppendText("\r\n------------------------------------------");
            _rtSpellInfo.AppendText(String.Format("\r\nCategory = {0}, SpellIconID = {1}, ActiveIconID = {2}, SpellVisual_1 = {3}, SpellVisual_2 = {4}",
                spellInfo["Category"], spellInfo["SpellIconID"], spellInfo["ActiveIconID"], spellInfo["SpellVisual_1"], spellInfo["SpellVisual_2"]));

            _rtSpellInfo.AppendText(String.Format("\r\nSchool = {0}, DamageClass = {1}, PreventionType = {2}",
                spellInfo["SchoolMask"], spellInfo["DmgClass"], spellInfo["PreventionType"]));

            _rtSpellInfo.AppendText("\r\nSpellLevel = " + spellInfo["SpellLevel"]);

            _rtSpellInfo.AppendText(String.Format("\r\nAttributes 0x{0:X8}, Ex 0x{1:X8}, Ex2 0x{2:X8}, Ex3 0x{3:X8}, Ex4 0x{4:X8}, Ex5 0x{5:X8}, Ex6 0x{6:X8}, ExG 0x{7:X8}",
                uint.Parse(""+spellInfo["Attributes"]), uint.Parse(""+spellInfo["AttributesEx"]), uint.Parse(""+spellInfo["AttributesEx2"]), uint.Parse(""+spellInfo["AttributesEx3"]), 
                uint.Parse(""+spellInfo["AttributesEx4"]), uint.Parse(""+spellInfo["AttributesEx5"]), uint.Parse(""+spellInfo["AttributesEx6"]), uint.Parse(""+spellInfo["AttributesExG"])));

            _rtSpellInfo.AppendText(String.Format("\r\nDuration = (todo)xxx, xxx, xxx"));

            //todo: more info
        }

        private void _bProc_Click(object sender, EventArgs e)
        {
            splitContainer3.Panel1Collapsed = !splitContainer3.Panel1Collapsed;
        }

        private void _bSpellInfo_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2Collapsed = !splitContainer2.Panel2Collapsed;
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                _bProc.Visible = true;
                _bSpellInfo.Visible = true;
            }
            else
            {
                _bProc.Visible = false;
                _bSpellInfo.Visible = false;
            }
        }

        private void _bProcFlag_Click(object sender, EventArgs e)
        {
            splitContainer6.Panel2Collapsed = !splitContainer6.Panel2Collapsed;
        }

    }
}
