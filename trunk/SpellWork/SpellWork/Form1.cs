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
           // var item = (object[])Enum.GetValues(typeof(ProcFlags));
            foreach (var elem in Enum.GetValues(typeof(ProcFlags)))
            {
                _clbProcFlaf.Items.Add(elem.ToString().Substring(10));
            }
            SetEnumValues(_cbSpellFamilyNames, typeof(SpellFamilyNames), true);
            SetEnumValues(_cbSpellAura, typeof(AuraType), false);
            SetEnumValues(_cbSpellEffect, typeof(SpellEffects), false);
            SetEnumValues(_cbTarget1, typeof(Targets), true);
            SetEnumValues(_cbTarget2, typeof(Targets), true);
        }
        /// <summary>
        /// Заполняет контрол, значениями из энумераторов
        /// </summary>
        /// <param name="cb">Контрол, который нужно заполнить</param>
        /// <param name="enums">Перечисление</param>
        /// <param name="first">Указывает, должен ли стоять в начале списка</param>
        private void SetEnumValues(ComboBox cb, Type enums, bool first)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("NAME");
            if (first)
                dt.Rows.Add(new Object[] {-1, "Не использовать фильтр"});
            
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
            Spell spell = new Spell();
            spellData = spell.SpellData;
        }

        private void _cbSpellFamilyNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var filter1 = _cbSpellFamilyNames.SelectedValue.ToString();
                var filter2 = _cbSpellFamilyNames.SelectedValue.ToString();
                var filter3 = _cbSpellFamilyNames.SelectedValue.ToString();
                var filter4 = _cbSpellFamilyNames.SelectedValue.ToString();
                _rtSpellInfo.Text = filter1.ToString();
                DataView(filter1.ToString());
            }
            catch { }
        }
        /*
         * IEnumerable<DataRow> query =
                                from order in orders.AsEnumerable()
                                where order.Field<DateTime>("OrderDate") > new DateTime(2001, 8, 1)
                                select order;
         */
        private void DataView(string filter)
        {

            IEnumerable<DataRow> query = from spell in spellData.AsEnumerable()
                        where spell.Field<string>("SpellFamilyName") == filter
                        select spell;
            
            tempTable = query.CopyToDataTable<DataRow>();
            
            _lvSpellList.Items.Clear();


            foreach (DataRow item in tempTable.Select())
            {
                _lvSpellList.Items.Add(new ListViewItem(new String[] { "" + item["ID"], "" + item["SpellName_1"], "" + item["SpellFamilyName"] }));
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2Collapsed = !splitContainer1.Panel2Collapsed;
            //var find = Spell.SpellData.Select("");
        }

        private void _lvSpellList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _rtSpellInfo.Clear();
            if (_lvSpellList.SelectedItems.Count > 0)
            {

                var index = _lvSpellList.SelectedItems[0].SubItems[0].Text;
                IEnumerable<DataRow> query = from spell in tempTable.AsEnumerable()
                                             where spell.Field<string>("ID") == index
                                             select spell;
                DataRow[] dtr = query.CopyToDataTable < DataRow >().Select();

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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

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
            //_rtSpellInfo.SelectionColor = Color.Aqua;
            //_rtSpellInfo.AppendText("SpellID: " + spellInfo["ID"]);
            //_rtSpellInfo.SelectionColor = Color.Blue;
            //_rtSpellInfo.AppendText("Spell Name: " + spellInfo["SpellName_1"]);
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
