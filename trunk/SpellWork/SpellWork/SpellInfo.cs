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

            _rtSpellInfo.AppendText(ViewFlags(spellInfo));

            _rtSpellInfo.AppendText(ViewInfoFromOtherTable(spellInfo));

            _rtSpellInfo.AppendText(ViewReagent(spellInfo));

            _rtSpellInfo.AppendText(ViewOtherSpellInfo(spellInfo, typeof(SpellFields2), 2));

            _rtSpellInfo.AppendText(ViewOtherSpellInfo(spellInfo, typeof(SpellFields3), 3));

            _rtSpellInfo.AppendText(ViewMask(spellInfo));
            //todo: more info
        }

        static String ViewMask(DataRow spellInfo)
        {
            var spellFamilyFlags_1 = uint.Parse((string)spellInfo["SpellFamilyFlags_1"]);
            var spellFamilyFlags_2 = uint.Parse((string)spellInfo["SpellFamilyFlags_2"]);
            var spellFamilyFlags_3 = uint.Parse((string)spellInfo["SpellFamilyFlags_3"]);

            return String.Format("\r\nSpellFamilyFlags: = 0x{0:X8} {1:X8} {2:X8}", spellFamilyFlags_3, spellFamilyFlags_2, spellFamilyFlags_1);
        }

        static String ViewTextInfo(DataRow spellInfo)
        {
            var entry       = spellInfo["ID"];
            var name        = spellInfo["SpellName_" + Spell.Locales];
            var rank        = spellInfo["Rank_" + Spell.Locales].ToString();
            var description = spellInfo["Description_" + Spell.Locales].ToString();
            var tooltip     = spellInfo["ToolTip_" + Spell.Locales].ToString();

            var info = String.Format("ID - {0} {1} ", entry, name);
            info += rank == "" ? "" : " (" + rank + ")";
            info += (description == "") ? "" : "\r\nDescription: " + description;
            info += (tooltip == "") ? "" : "\r\nToolTip: " + tooltip;

            return info + "\r\n==========================================";
        }

        static String ViewInfoFromOtherTable(DataRow spellInfo)
        {
            var info = "";

            var casttime = SelectCastTimes((string)spellInfo["CastingTimeIndex"]);
            info += (casttime != null) ? casttime : "";

            var duration = SelectDuration((string)spellInfo["DurationIndex"]);
            info += (duration != null) ? duration : "";

            var radius = SelectRadius((string)spellInfo["EffectRadiusIndex_1"], (string)spellInfo["EffectRadiusIndex_2"], (string)spellInfo["EffectRadiusIndex_3"]);
            info += (radius != null) ? radius : "";

            var range = SelectRange((string)spellInfo["RangeIndex"]);
            info += (range != null) ? range : "";

            //var skill = SelectSkillLineAbility((string)spellInfo["ID"]);
            //info += (skill != null) ? skill : "";

            return (info == "") ? "" : info + "\r\n------------------------------";
        }

        static String ViewReagent(DataRow spellInfo)
        {
            var info = "";
            for (int i = 1; i < 9; i++)
            {
                var reagent = (string)spellInfo["Reagent_" + i];
                var count   = (string)spellInfo["ReagentCount_" + i];
                info += (reagent != "0") ? String.Format("\r\nReagent_{0} ItemID = {1} (Count = {2})", i, reagent, count) : "";
            }

            return (info == "") ? "" : info + "\r\n------------------------------";
        }

        static String ViewFlags(DataRow spellInfo)
        {
            int COUNT = 4;
            var info = "";
            info = "\r\nSpellFamilyNames: " + (SpellFamilyNames)uint.Parse((string)spellInfo["SpellFamilyName"]);

            for (int i = 1; i < COUNT; i++)
            {
                var spellAura = (AuraType)uint.Parse((string)spellInfo["EffectApplyAuraName_" + i]);
                info += (spellAura == AuraType.SPELL_AURA_NONE) ? "" : String.Format("\r\nEffectApplyAuraName_{0}: {1}", i, spellAura);
            }

            for (int i = 1; i < COUNT; i++)
            {
                var effekt = (SpellEffects)uint.Parse((string)spellInfo["Effect_" + i]);
                info += (effekt == SpellEffects.NO_SPELL_EFFECT) ? "" : String.Format("\r\nEffect_{0}: {1}", i, effekt);
            }

            for (int i = 1; i < COUNT; i++)
            {
                var targetA = (SpellEffects)uint.Parse((string)spellInfo["EffectImplicitTargetA_" + i]);
                info += (targetA == SpellEffects.NO_SPELL_EFFECT) ? "" : String.Format("\r\nEffectImplicitTargetA_{0}: {1}", i, targetA);
            }

            for (int i = 1; i < COUNT; i++)
            {
                var targetB = (SpellEffects)uint.Parse((string)spellInfo["EffectImplicitTargetB_" + i]);
                info += (targetB == SpellEffects.NO_SPELL_EFFECT) ? "" : String.Format("\r\nEffectImplicitTargetB_{0}: {1}", i, targetB);
            }

            return (info == "") ? "" : info + "\r\n------------------------------";
        }

        static String ViewOtherSpellInfo(DataRow spellInfo, Type fields, int count)
        {
            var info = "";

            foreach (var field in Enum.GetValues(fields))
            {
                for (int i = 1; i <= count; i++)
                {
                    var val = spellInfo[field + "_" + i].ToString();
                    info += (val == "0") ? "" : String.Format("\r\n{0}_{1} = {2}", field, i, val);
                }
            }

            return (info == "") ? "" : info + "\r\n------------------------------";
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
            var res = "\r\nRadius:";
            //tested
            foreach (var str in result.Select())
            {
                res += String.Format(" ID - {0}, Radius1 = {1}, Unk = {2}, Radius2 = {3}",str[0], str[1], str[2], str[3]);
            }
            return res;
        }

        static String SelectSkillLineAbility(string entry)
        {
            var query =
               from skillLineAbility in Spell.SkillLineAbility.AsEnumerable()
               join skillLine in Spell.SkillLine.AsEnumerable()
               on skillLineAbility.Field<string>("SkillId") equals skillLine.Field<string>("ID") 
               where skillLineAbility.Field<string>("SpellId") == entry
               select new 
               {
                   Name = skillLine.Field<string>("SkillName_"+Spell.Locales),
                   SkillId = skillLineAbility.Field<string>("SkillId"),
                   Racemask = skillLineAbility.Field<string>("Racemask"),
                   Classmask = skillLineAbility.Field<string>("Classmask"),
                   RacemaskNot = skillLineAbility.Field<string>("RacemaskNot"),
                   ClassmaskNot = skillLineAbility.Field<string>("ClassmaskNot"),
                   ReqSkillValue = skillLineAbility.Field<string>("ReqSkillValue"),
                   ForwardSpellid = skillLineAbility.Field<string>("ForwardSpellid"),
                   LearnOnGetSkill = skillLineAbility.Field<string>("LearnOnGetSkill"),
                   MaxValue = skillLineAbility.Field<string>("MaxValue"),
                   MinValue = skillLineAbility.Field<string>("MinValue"),
                   CharacterPoints_1 = skillLineAbility.Field<string>("CharacterPoints_1"),
                   CharacterPoints_2 = skillLineAbility.Field<string>("CharacterPoints_2")
               };

            if (query.Count() == 0)
                return null;

            //   var result = query.CopyToDataTable<DataRow>();
            var res = "\r\nSkill: ID - ";
           
            foreach (var rows in query)
            {
                res += rows.SkillId;
                res += " Name: " + rows.Name;
                res += "\r\nRacemask = " + rows.Racemask;
                res += ", Classmask = " + rows.Classmask;
                res += ", RacemaskNot = " + rows.RacemaskNot;
                res += ", ClassmaskNot = " + rows.ClassmaskNot;
                res += "\r\nReqSkillValue = " + rows.ReqSkillValue;
                res += ", ForwardSpellid = " + rows.ForwardSpellid;
                res += ", LearnOnGetSkill = " + rows.LearnOnGetSkill;
                res += "\r\nMaxValue = " + rows.MaxValue;
                res += ", MaxValue = " + rows.SkillId;
                res += "\r\nCharacterPoints_1 = " + rows.CharacterPoints_1;
                res += ", CharacterPoints_2 = " + rows.CharacterPoints_2;
            }
            return res;
        }
    }
}
