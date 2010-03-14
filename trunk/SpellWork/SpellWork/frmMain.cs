using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpellWork
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            Loads();
        }

        private DataTable spellData { get; set; }
        private DataTable spellDuration { get; set; }
        private DataTable spellRadius { get; set; }
        private DataTable spellCastTime { get; set; }
        private DataTable spellRange { get; set; }

        private DataTable tempTable { get; set; }

        private void Loads()
        {
            // read dbc to DataTable
           Spell spell     = new Spell();
           // is as
           spellData       = Spell.SpellData;
           spellDuration   = Spell.SpellDuration;
           spellRadius     = Spell.SpellRadius;
           spellCastTime   = Spell.SpellCastTime;
           spellRange      = Spell.SpellRange;
           //*/
           // foreach (var elem in Enum.GetValues(typeof(ProcFlags)))
           // {
                // tested
           // _clbProcFlags.Items.AddRange(new Object[] { Enum.GetValues(typeof(ProcFlags)) });
           //}
            SetEnumValues(_cbSpellFamilyNames, typeof(SpellFamilyNames));
            SetEnumValues(_cbSpellAura, typeof(AuraType));
            SetEnumValues(_cbSpellEffect, typeof(SpellEffects));
            SetEnumValues(_cbTarget1, typeof(Targets));
            SetEnumValues(_cbTarget2, typeof(Targets));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            splitContainer3.SplitterDistance = 52;
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

        private bool ContainText(String text, String str)
        {
            return (text.ToUpper().IndexOf(str.ToUpper(), StringComparison.CurrentCultureIgnoreCase) != -1);
        }

        private void _bSearch_Click(object sender, EventArgs e)
        {
            _lvSpellList.Items.Clear();

            var query =
                from spell in spellData.AsEnumerable()
                where (spell.Field<String>("ID") == _tbSearch.Text)
                  || ContainText(spell.Field<String>("SpellName_" + Spell.Locales), _tbSearch.Text)
                select spell;

            if (query.Count() == 0) return;

            tempTable = query.CopyToDataTable<DataRow>();
           
            foreach (var element in tempTable.Select())
            {
                var id = element["ID"].ToString();
                var name = element["SpellName_" + Spell.Locales].ToString();
                var rank = element["Rank_" + Spell.Locales].ToString() == "" ? "" : " (" + element["Rank_" + Spell.Locales] + ")";

                _lvSpellList.Items.Add(new ListViewItem(new String[] { id, name + rank }));
            }
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

            var bFamilyNames = _cbSpellFamilyNames.SelectedIndex != 0;
            var fFamilyNames = _cbSpellFamilyNames.SelectedValue.ToString();

            var bSpellAura   = _cbSpellAura.SelectedIndex != 0;
            var fSpellAura   = _cbSpellAura.SelectedValue.ToString();

            var bSpellEffect = _cbSpellEffect.SelectedIndex != 0;
            var fSpellEffect = _cbSpellEffect.SelectedValue.ToString();

            var bTarget1     = _cbTarget1.SelectedIndex != 0;
            var fTarget1     = _cbTarget1.SelectedValue.ToString();

            var bTarget2     = _cbTarget2.SelectedIndex != 0;
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
            splitContainer3.SplitterDistance = 70; 
            //splitContainer3.Panel1Collapsed = !splitContainer3.Panel1Collapsed;
        }

        private void _bSpellInfo_Click(object sender, EventArgs e)
        {
            splitContainer2.Panel2Collapsed = !splitContainer2.Panel2Collapsed;
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            _bProc.Visible = _bSpellInfo.Visible = tabControl1.SelectedIndex == 1;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            SpellPorcFlag.BuildFamilyTree(_tvFamilyMask, 0, "");
            return;
            _tvFamilyMask.Nodes.Clear();

            for (int i = 0; i < 96; i++)
            {
                uint mask_0 = 0, mask_1 = 0, mask_2 = 0;

                if (i < 32)
                    mask_0 = 1U << i;
                else if (i < 64)
                    mask_1 = 1U << (i - 32);
                else
                    mask_2 = 1U << (i - 64);
                
                TreeNode node = new TreeNode();
                node.Text = String.Format("0x{0:X8} {1:X8} {2:X8}", mask_2, mask_1, mask_0);
                // test
                if (i < 64)
                {
                    node.Nodes.Add("2222222222222");
                    node.Nodes.Add("3333333333333");
                }

                _tvFamilyMask.Nodes.Add(node);
            }
        }

        private void _cbProcFlag_CheckedChanged(object sender, EventArgs e)
        {
            splitContainer3.SplitterDistance = ((CheckBox)sender).Checked ? 160 : 52;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
