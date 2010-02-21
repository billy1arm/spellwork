using System;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace SpellWork
{
    public class SpellInfo
    {


        public static void SpellViewInfo(DataRow spellInfo, RichTextBox _rtSpellInfo)
        {
            _rtSpellInfo.SelectionColor = Color.Blue;

            _rtSpellInfo.AppendText(String.Format("ID - {0} {1} ({2})", spellInfo["ID"], spellInfo["SpellName_" + Spell.Locales], spellInfo["Rank_" + Spell.Locales]));
            _rtSpellInfo.AppendText("\r\n==========================================");
            _rtSpellInfo.AppendText("\r\nDescription: " + spellInfo["Description_" + Spell.Locales]);
            _rtSpellInfo.AppendText("\r\nToolTip: " + spellInfo["ToolTip_" + Spell.Locales]);
            _rtSpellInfo.AppendText("\r\n==========================================");
            _rtSpellInfo.AppendText(String.Format("\r\nCategory = {0}, SpellIconID = {1}, ActiveIconID = {2}, SpellVisual_1 = {3}, SpellVisual_2 = {4}",
                spellInfo["Category"], spellInfo["SpellIconID"], spellInfo["ActiveIconID"], spellInfo["SpellVisual_1"], spellInfo["SpellVisual_2"]));

            _rtSpellInfo.AppendText(String.Format("\r\nSchool = {0}, DamageClass = {1}, PreventionType = {2}",
                spellInfo["SchoolMask"], spellInfo["DmgClass"], spellInfo["PreventionType"]));

            _rtSpellInfo.AppendText("\r\nSpellLevel = " + spellInfo["SpellLevel"]);

            _rtSpellInfo.AppendText(String.Format("\r\nAttributes 0x{0:X8}, Ex 0x{1:X8}, Ex2 0x{2:X8}, Ex3 0x{3:X8}, Ex4 0x{4:X8}, Ex5 0x{5:X8}, Ex6 0x{6:X8}, ExG 0x{7:X8}",
                uint.Parse((string)spellInfo["Attributes"]), uint.Parse((string)spellInfo["AttributesEx"]), uint.Parse((string)spellInfo["AttributesEx2"]), uint.Parse((string)spellInfo["AttributesEx3"]),
                uint.Parse((string)spellInfo["AttributesEx4"]), uint.Parse((string)spellInfo["AttributesEx5"]), uint.Parse((string)spellInfo["AttributesEx6"]), uint.Parse((string)spellInfo["AttributesExG"])));

            var duration = SelectDuration((string)spellInfo["DurationIndex"]);
            if (duration != null)
                _rtSpellInfo.AppendText(String.Format("\r\nDuration = " + duration));

            var radius = SelectRadius((string)spellInfo["EffectRadiusIndex_1"], (string)spellInfo["EffectRadiusIndex_2"], (string)spellInfo["EffectRadiusIndex_3"]);
            if (radius != null)
                _rtSpellInfo.AppendText(String.Format("\r\nRadius = " + radius));

            //todo: more info
        }

        static String SelectCastTimes(string CastingTimeIndex)
        {
            var query =
                from casttime in Spell.SpellCastTime.AsEnumerable()
                where casttime.Field<string>("ID") == CastingTimeIndex
                select casttime;

            if (query.Count() == 0)
                return null;

            var result = query.CopyToDataTable<DataRow>().Select().First();
            return String.Format("{0}, {1}, {2}", result[0], result[1], result[2]);
        }

        static String SelectDuration(string DurationIndex)
        {
            var query =
                from duration in Spell.SpellDuration.AsEnumerable()
                where duration.Field<string>("ID") == DurationIndex
                select duration;

            if (query.Count() == 0)
                return null;

            var result = query.CopyToDataTable<DataRow>().Select().First();
            return String.Format("{0}, {1}, {2}", result[0], result[1], result[2]);
        }

        static String SelectRange(string DurationIndex)
        {
            var query =
                from rande in Spell.SpellRange.AsEnumerable()
                where rande.Field<string>("ID") == DurationIndex
                select rande;

            if (query.Count() == 0)
                return "0, 0, 0";

            var result = query.CopyToDataTable<DataRow>().Select().First();
            return String.Format("{0}, {1}, {2}", result[0], result[1], result[2]);
        }

        static String SelectRadius(string EffectRadiusIndex_1, string EffectRadiusIndex_2, string EffectRadiusIndex_3)
        {
            var query =
                from radius in Spell.SpellRadius.AsEnumerable()
                where radius.Field<string>("ID") == EffectRadiusIndex_1
                   || radius.Field<string>("ID") == EffectRadiusIndex_2
                   || radius.Field<string>("ID") == EffectRadiusIndex_3
                select radius;

            if (query.Count() == 0)
                return null;

            var result = query.CopyToDataTable<DataRow>();
            var res = "";
            //tested
            foreach (var str in result.Select())
            {
                res += String.Format("{0}, {1}, {2}", str[1], str[2], str[3]) + "\r\n";
            }
            return res;
        }
    }
}
