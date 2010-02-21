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
            //_rtSpellInfo.SelectionColor = Color.Blue;
            _rtSpellInfo.AppendText(ViewTextInfo(spellInfo));

            _rtSpellInfo.AppendText(String.Format("\r\nCategory = {0}, SpellIconID = {1}, ActiveIconID = {2}, SpellVisual_1 = {3}, SpellVisual_2 = {4}",
                spellInfo["Category"], spellInfo["SpellIconID"], spellInfo["ActiveIconID"], spellInfo["SpellVisual_1"], spellInfo["SpellVisual_2"]));

            _rtSpellInfo.AppendText(String.Format("\r\nSchool = {0}, DamageClass = {1}, PreventionType = {2}",
                spellInfo["SchoolMask"], spellInfo["DmgClass"], spellInfo["PreventionType"]));

            _rtSpellInfo.AppendText("\r\nSpellLevel = " + spellInfo["SpellLevel"]);

            _rtSpellInfo.AppendText(String.Format("\r\nAttributes 0x{0:X8}, Ex 0x{1:X8}, Ex2 0x{2:X8}, Ex3 0x{3:X8}, Ex4 0x{4:X8}, Ex5 0x{5:X8}, Ex6 0x{6:X8}, ExG 0x{7:X8}",
                uint.Parse((string)spellInfo["Attributes"]), uint.Parse((string)spellInfo["AttributesEx"]), uint.Parse((string)spellInfo["AttributesEx2"]), uint.Parse((string)spellInfo["AttributesEx3"]),
                uint.Parse((string)spellInfo["AttributesEx4"]), uint.Parse((string)spellInfo["AttributesEx5"]), uint.Parse((string)spellInfo["AttributesEx6"]), uint.Parse((string)spellInfo["AttributesExG"])));

            _rtSpellInfo.AppendText(ViewGlags(spellInfo));

            _rtSpellInfo.AppendText(ViewInfoFromOtherTable(spellInfo));
            
            //todo: more info
        }

        static String ViewTextInfo(DataRow spellInfo)
        {
            var entry       = spellInfo["ID"];
            var name        = spellInfo["SpellName_" + Spell.Locales];
            var rank        = spellInfo["Rank_" + Spell.Locales].ToString();
            var description = spellInfo["Description_" + Spell.Locales].ToString();
            var tooltip     = spellInfo["ToolTip_" + Spell.Locales].ToString();

            var info = String.Format("ID - {0} {1} ", entry, name);
            
            if (rank != "")
                info += " (" + rank + ")";
            
            info += "\r\n";

            if (description != "")
                info += "\r\nDescription: " + description;
            if (tooltip != "")
                info += "\r\nToolTip: " + tooltip;

            info += "\r\n==========================================";

            return info;
        }

        static String ViewInfoFromOtherTable(DataRow spellInfo)
        {
            string body = null;
            var casttime = SelectCastTimes((string)spellInfo["CastingTimeIndex"]);
            if (casttime != null)
                body += "\r\nSpellCastTime: " + casttime;

            var duration = SelectDuration((string)spellInfo["DurationIndex"]);
            if (duration != null)
                body += "\r\nSpellDuration: " + duration;

            var radius = SelectRadius((string)spellInfo["EffectRadiusIndex_1"], (string)spellInfo["EffectRadiusIndex_2"], (string)spellInfo["EffectRadiusIndex_3"]);
            if (radius != null)
                body += "\r\nSpellRadius: " + radius;

            var range = SelectRange((string)spellInfo["RangeIndex"]);
            if (range != null)
                body += "\r\nSpellRange: " + range;

            if (body==null)
                return "";

            var info = "\r\n------------------------------" +
                            body+
                       "\r\n------------------------------";

            return info;
        }

        static String ViewGlags(DataRow spellInfo)
        {
            var spellFemily = "\r\nSpellFamilyNames: " + (SpellFamilyNames)uint.Parse((string)spellInfo["SpellFamilyName"]);

            var spellAura1 = (AuraType)uint.Parse((string)spellInfo["EffectApplyAuraName_1"]);
            var spellAura2 = (AuraType)uint.Parse((string)spellInfo["EffectApplyAuraName_2"]);
            var spellAura3 = (AuraType)uint.Parse((string)spellInfo["EffectApplyAuraName_3"]);

            var aurs = (spellAura1 == AuraType.SPELL_AURA_NONE ? "" : "\r\nEffectApplyAuraName_1: " + spellAura1)
                     + (spellAura2 == AuraType.SPELL_AURA_NONE ? "" : "\r\nEffectApplyAuraName_2: " + spellAura2)
                     + (spellAura3 == AuraType.SPELL_AURA_NONE ? "" : "\r\nEffectApplyAuraName_3: " + spellAura3);

            var effekt1 = (SpellEffects)uint.Parse((string)spellInfo["Effect_1"]);
            var effekt2 = (SpellEffects)uint.Parse((string)spellInfo["Effect_1"]);
            var effekt3 = (SpellEffects)uint.Parse((string)spellInfo["Effect_1"]);

            var effekts = (effekt1 == SpellEffects.NO_SPELL_EFFECT ? "" : "\r\nEffect_1: " + effekt1)
                        + (effekt2 == SpellEffects.NO_SPELL_EFFECT || effekt2 == effekt1 ? "" : "\r\nEffect_2: " + effekt2)
                        + (effekt3 == SpellEffects.NO_SPELL_EFFECT || effekt3 == effekt2 ? "" : "\r\nEffect_3: " + effekt3);

            var targetA1 = (Targets)uint.Parse((string)spellInfo["EffectImplicitTargetA_1"]);
            var targetA2 = (Targets)uint.Parse((string)spellInfo["EffectImplicitTargetA_2"]);
            var targetA3 = (Targets)uint.Parse((string)spellInfo["EffectImplicitTargetA_3"]);

            var targetsA = (targetA1 == Targets.NO_TARGET ? "" : "\r\nEffectImplicitTargetA_1: " + targetA1)
                         + (targetA2 == Targets.NO_TARGET || targetA2 == targetA1 ? "" : "\r\nEffectImplicitTargetA_2: " + targetA2)
                         + (targetA3 == Targets.NO_TARGET || targetA3 == targetA2 ? "" : "\r\nEffectImplicitTargetA_3: " + targetA3);

            var targetB1 = (Targets)uint.Parse((string)spellInfo["EffectImplicitTargetB_1"]);
            var targetB2 = (Targets)uint.Parse((string)spellInfo["EffectImplicitTargetB_2"]);
            var targetB3 = (Targets)uint.Parse((string)spellInfo["EffectImplicitTargetB_3"]);

            var targetsB = (targetB1 == Targets.NO_TARGET ? "" : "\r\nEffectImplicitTargetB_1: " + targetA1)
                         + (targetB2 == Targets.NO_TARGET || targetB2 == targetB1 ? "" : "\r\nEffectImplicitTargetB_2: " + targetB2)
                         + (targetB3 == Targets.NO_TARGET || targetB3 == targetB2 ? "" : "\r\nEffectImplicitTargetB_3: " + targetB3);

            
            var info = "\r\n------------------------------"
                     + spellFemily + aurs + effekts + targetsA + targetsB
                     + "\r\n------------------------------";
            
            return info;
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
            return String.Format("\r\nSpellCastTime: ID - {0}, CastTime = {1}, CastTimePerLevel = {2}, MinCastTime = {3}", 
                result[0], result[1], result[2], result[3]);
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
            return String.Format("\r\nDuration: ID - {0}    {1}, {2}, {3}", result[0], result[1], result[2], result[3]);
        }

        static String SelectRange(string RangeIndex)
        {
            var query =
                from rande in Spell.SpellRange.AsEnumerable()
                where rande.Field<string>("ID") == RangeIndex
                select rande;

            if (query.Count() == 0)
                return null;

            var result = query.CopyToDataTable<DataRow>().Select().First();

            return String.Format("\r\nSpellRange: ID - {0} {1} (unk = {2})"+
                                 " MinRange = {3}, MinRangeFriendly = {4}, MaxRange = {5}, MaxRangeFriendly = {6}", 
                result[0], result[6], result[5], result[1], result[2], result[3], result[4]);

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
            var res = "\r\nRadius = ";
            //tested
            foreach (var str in result.Select())
            {
                res += String.Format("{0}, {1}, {2}", str[1], str[2], str[3]) + " ";
            }
            return res;
        }
    }
}
