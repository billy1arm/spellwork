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
            Spell spell = new Spell();
            spellData = spell.SpellData;
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
                _lvSpellList.Items.Add(new ListViewItem(new String[] { "" + item["ID"], "" + item["SpellName_1"]}));
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
                    //_rtSpellInfo.SelectionColor = Color.Aqua;
                    //_rtSpellInfo.AppendText("SpellID: "+spellInfo["ID"]);
                    //_rtSpellInfo.SelectionColor = Color.Blue;
                    //_rtSpellInfo.AppendText("Spell Name: " + spellInfo["SpellName_1"]);
                }
            }
        }


        void SpellViewInfo(DataRow spellInfo)
        {
            foreach (var str in Spell.SpellStructure)
            {
                string sig = str[1];
                string inf = spellInfo[sig].ToString();
                if (inf != "0" && inf != "")
                {
                    _rtSpellInfo.AppendText("\r\n"+sig + ": " + inf);
                }
            }
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
