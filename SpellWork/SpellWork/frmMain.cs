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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private DataTable spellData { get; set; }
        private DataTable spellDuration { get; set; }
        private DataTable spellRadius { get; set; }
        private DataTable spellCastTime { get; set; }
        private DataTable spellRange { get; set; }

        private DataTable tempTable { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            // read dbc to DataTable
            Spell spell     = new Spell();
            // is as
            spellData       = Spell.SpellData;
            spellDuration   = Spell.SpellDuration;
            spellRadius     = Spell.SpellRadius;
            spellCastTime   = Spell.SpellCastTime;
            spellRange      = Spell.SpellRange;

            foreach (var elem in Enum.GetValues(typeof(ProcFlags)))
            {
                // tested
                _clbProcFlaf.Items.Add(elem.ToString().Substring(10));
            }
            SetEnumValues(_cbSpellFamilyNames, typeof(SpellFamilyNames));
            SetEnumValues(_cbSpellAura,        typeof(AuraType));
            SetEnumValues(_cbSpellEffect,      typeof(SpellEffects));
            SetEnumValues(_cbTarget1,          typeof(Targets));
            SetEnumValues(_cbTarget2,          typeof(Targets));
        }

        private void SetEnumValues(ComboBox cb, Type enums)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("NAME");

            dt.Rows.Add(new Object[] { -1, "No filter" });
            
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

            var bSpellAura   = _cbSpellAura.SelectedIndex == 0 ? false : true;
            var fSpellAura   = _cbSpellAura.SelectedValue.ToString();

            var bSpellEffect = _cbSpellEffect.SelectedIndex == 0 ? false : true;
            var fSpellEffect = _cbSpellEffect.SelectedValue.ToString();

            var bTarget1     = _cbTarget1.SelectedIndex == 0 ? false : true;
            var fTarget1     = _cbTarget1.SelectedValue.ToString();

            var bTarget2     = _cbTarget2.SelectedIndex == 0 ? false : true;
            var fTarget2     = _cbTarget2.SelectedValue.ToString();

            var query =
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
                    // target A
                   && (!bTarget1     || spell.Field<string>("EffectImplicitTargetA_1") == fTarget1
                                     || spell.Field<string>("EffectImplicitTargetA_2") == fTarget1
                                     || spell.Field<string>("EffectImplicitTargetA_3") == fTarget1)
                    // target B
                   && (!bTarget2     || spell.Field<string>("EffectImplicitTargetB_1") == fTarget2
                                     || spell.Field<string>("EffectImplicitTargetB_2") == fTarget2
                                     || spell.Field<string>("EffectImplicitTargetB_3") == fTarget2)

                select spell;

            if (query.Count() == 0) return;
            // in temp datatable from speed
            tempTable = query.CopyToDataTable<DataRow>();
            foreach (var element in tempTable.Select())
            {
                var id   = element["ID"].ToString();
                var name = element["SpellName_" + Spell.Locales].ToString();
                var rank = element["Rank_" + Spell.Locales].ToString() == "" ? "" : " (" + element["Rank_" + Spell.Locales] + ")";

                _lvSpellList.Items.Add(new ListViewItem(new String[] { id, name + rank}));
            }
        }

        private void _lvSpellList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _rtSpellInfo.Clear();
            if (_lvSpellList.SelectedItems.Count > 0)
            {
                var entry = _lvSpellList.SelectedItems[0].SubItems[0].Text;
                var query = from spell in tempTable.AsEnumerable()
                            where spell.Field<string>("ID") == entry
                            select spell;

                var result = query.CopyToDataTable<DataRow>().Select().First();
                SpellInfo.SpellViewInfo(result, _rtSpellInfo);
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
