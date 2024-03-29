﻿using System;
using System.Linq;
using System.Data;
using System.Collections;
using System.Collections.Generic;

namespace SpellWork
{
    public class Spell
    {
        public static LocalesDBC Locales {get; set;}

        public Spell()
        {
            //todo: selected folder in settings
            try
            {
                var path = @"dbc\";

                new DBCReader(path + "Spell.dbc", ref SpellData, SpellStructure);

                new DBCReader(path + "SpellCastTimes.dbc", ref SpellCastTime, SpellCastTimeStructure);
                new DBCReader(path + "SpellRadius.dbc", ref SpellRadius, SpellRadiusStructure);
                new DBCReader(path + "SpellDuration.dbc", ref SpellDuration, DurationStructure);
                new DBCReader(path + "SpellRange.dbc", ref SpellRange, SpellRangeStructure);
                //new DBCReader(path + "SkillLineAbility.dbc", ref SkillLineAbility, SkillLineAbilityStructure);
                //new DBCReader(path + "SkillLine.dbc",        ref SkillLine,        SkillLineStructure);

                GetLocale();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Not files in \"\\dbc\" folder");
                System.Windows.Forms.Application.Exit();
            }
       }
        
        static void GetLocale()
        {
            bool local = false;
            foreach (LocalesDBC loc in Enum.GetValues(typeof(LocalesDBC)))
            {
                if (SpellData.Select().First()["SpellName_" + loc].ToString() != "")
                {
                    Locales = loc;
                    local = true;
                    break;
                }
            }
            if (!local)
            {
                System.Windows.Forms.MessageBox.Show("Unk dbc locale, application exit");
                System.Windows.Forms.Application.Exit();
            }
        }

        #region SpellDataTable

        public static DataTable SpellData        = new DataTable();
        public static DataTable SpellCastTime    = new DataTable();
        public static DataTable SpellRadius      = new DataTable();
        public static DataTable SpellRange       = new DataTable();
        public static DataTable SpellDuration    = new DataTable();
        public static DataTable SkillLineAbility = new DataTable();
        public static DataTable SkillLine        = new DataTable();

        #endregion

        #region Spell structure
        public static readonly String[][] SpellStructure = new String[][]
        {
	        new String[] {"uint",    "ID"},        //used
	        new String[] {"uint",    "Category"},  //used
	        new String[] {"uint",    "Dispel"},    //used
	        new String[] {"uint",    "Mechanics"}, //????
	        new String[] {"uint",    "Attributes"},   //used
	        new String[] {"uint",    "AttributesEx"}, //used
	        new String[] {"uint",    "AttributesEx2"},//used
	        new String[] {"uint",    "AttributesEx3"},//used
	        new String[] {"uint",    "AttributesEx4"},//used
	        new String[] {"uint",    "AttributesEx5"},//used
	        new String[] {"uint",    "AttributesEx6"},//used
	        new String[] {"uint",    "AttributesExG"},//used
	        new String[] {"uint",    "Stances_1"},    //used
	        new String[] {"uint",    "Stances_2"},    //used
	        new String[] {"uint",    "StancesNot_1"}, //used
	        new String[] {"uint",    "StancesNot_2"}, //used
	        new String[] {"uint",    "Targets"},        // ???
	        new String[] {"uint",    "TargetCreatureType"},
	        new String[] {"uint",    "RequiresSpellFocus"},
	        new String[] {"uint",    "FacingCasterFlags"},
	        new String[] {"uint",    "CasterAuraState"},
	        new String[] {"uint",    "TargetAuraState"},
	        new String[] {"uint",    "CasterAuraStateNot"},
	        new String[] {"uint",    "TargetAuraStateNot"},
	        new String[] {"uint",    "CasterAuraSpell"},
	        new String[] {"uint",    "TargetAuraSpell"},
	        new String[] {"uint",    "ExcludeCasterAuraSpell"},
	        new String[] {"uint",    "ExcludeTargetAuraSpell"},
	        new String[] {"uint",    "CastingTimeIndex"},//used
	        new String[] {"uint",    "RecoveryTime"},
	        new String[] {"uint",    "CategoryRecoveryTime"},
	        new String[] {"uint",    "InterruptFlags"},
	        new String[] {"uint",    "AuraInterruptFlags"},
	        new String[] {"uint",    "ChannelInterruptFlags"},
	        new String[] {"uint",    "ProcFlags"},
	        new String[] {"uint",    "ProcChance"},
	        new String[] {"uint",    "ProcCharges"},
	        new String[] {"uint",    "MaxLevel"},
	        new String[] {"uint",    "BaseLevel"},
	        new String[] {"uint",    "SpellLevel"},   //used
	        new String[] {"uint",    "DurationIndex"},//used
	        new String[] {"uint",    "PowerType"},
	        new String[] {"uint",    "ManaCost"},
	        new String[] {"uint",    "ManaCostPerLevel"},
	        new String[] {"uint",    "ManaPerSecond"},
	        new String[] {"uint",    "ManaPerSecondPerLeve"},
	        new String[] {"uint",    "RangeIndex"},//used
	        new String[] {"float",   "Speed"},
	        new String[] {"uint",    "ModalNextSpell"},
	        new String[] {"uint",    "StackAmount"},
            #region Used
	        new String[] {"uint",    "Totem_1"},   //used
	        new String[] {"uint",    "Totem_2"},   //used
	        new String[] {"int",     "Reagent_1"}, //used
	        new String[] {"int",     "Reagent_2"}, //used
	        new String[] {"int",     "Reagent_3"}, //used
	        new String[] {"int",     "Reagent_4"}, //used
	        new String[] {"int",     "Reagent_5"}, //used
	        new String[] {"int",     "Reagent_6"}, //used
	        new String[] {"int",     "Reagent_7"}, //used
	        new String[] {"int",     "Reagent_8"}, //used
	        new String[] {"uint",    "ReagentCount_1"}, //used
	        new String[] {"uint",    "ReagentCount_2"}, //used
	        new String[] {"uint",    "ReagentCount_3"}, //used
	        new String[] {"uint",    "ReagentCount_4"}, //used
	        new String[] {"uint",    "ReagentCount_5"}, //used
	        new String[] {"uint",    "ReagentCount_6"}, //used
	        new String[] {"uint",    "ReagentCount_7"}, //used
	        new String[] {"uint",    "ReagentCount_8"}, //used
	        new String[] {"int",     "EquippedItemClass"}, //used
	        new String[] {"int",     "EquippedItemSubClassMask"}, //used
	        new String[] {"int",     "EquippedItemInventoryTypeMask"}, //used
	        new String[] {"uint",    "Effect_1"}, //used
	        new String[] {"uint",    "Effect_2"}, //used
	        new String[] {"uint",    "Effect_3"}, //used
	        new String[] {"int",     "EffectDieSides_1"}, //used
	        new String[] {"int",     "EffectDieSides_2"}, //used
	        new String[] {"int",     "EffectDieSides_3"}, //used
	        new String[] {"uint",    "EffectBaseDice_1"}, //used
	        new String[] {"uint",    "EffectBaseDice_2"}, //used
	        new String[] {"uint",    "EffectBaseDice_3"}, //used
	        new String[] {"float",   "EffectDicePerLevel_1"}, //used
	        new String[] {"float",   "EffectDicePerLevel_2"}, //used
	        new String[] {"float",   "EffectDicePerLevel_3"}, //used
	        new String[] {"float",   "EffectRealPointsPerLevel_1"}, //used
	        new String[] {"float",   "EffectRealPointsPerLevel_2"}, //used
	        new String[] {"float",   "EffectRealPointsPerLevel_3"}, //used
	        new String[] {"int",     "EffectBasePoints_1"}, //used
	        new String[] {"int",     "EffectBasePoints_2"}, //used
	        new String[] {"int",     "EffectBasePoints_3"}, //used
	        new String[] {"uint",    "EffectMechanic_1"}, //used
	        new String[] {"uint",    "EffectMechanic_2"}, //used
	        new String[] {"uint",    "EffectMechanic_3"}, //used
	        new String[] {"uint",    "EffectImplicitTargetA_1"}, //used
	        new String[] {"uint",    "EffectImplicitTargetA_2"}, //used
	        new String[] {"uint",    "EffectImplicitTargetA_3"}, //used
	        new String[] {"uint",    "EffectImplicitTargetB_1"}, //used
	        new String[] {"uint",    "EffectImplicitTargetB_2"}, //used
	        new String[] {"uint",    "EffectImplicitTargetB_3"}, //used
	        new String[] {"uint",    "EffectRadiusIndex_1"}, //used
	        new String[] {"uint",    "EffectRadiusIndex_2"}, //used
	        new String[] {"uint",    "EffectRadiusIndex_3"}, //used
	        new String[] {"uint",    "EffectApplyAuraName_1"}, //used
	        new String[] {"uint",    "EffectApplyAuraName_2"}, //used
	        new String[] {"uint",    "EffectApplyAuraName_3"}, //used
	        new String[] {"uint",    "EffectAmplitude_1"}, //used
	        new String[] {"uint",    "EffectAmplitude_2"}, //used
	        new String[] {"uint",    "EffectAmplitude_3"}, //used
	        new String[] {"float",   "EffectMultipleValue_1"}, //used
	        new String[] {"float",   "EffectMultipleValue_2"}, //used
	        new String[] {"float",   "EffectMultipleValue_3"}, //used
	        new String[] {"uint",    "EffectChainTargets_1"}, //used
	        new String[] {"uint",    "EffectChainTargets_2"}, //used
	        new String[] {"uint",    "EffectChainTargets_3"}, //used
	        new String[] {"uint",    "EffectItemType_1"}, //used
	        new String[] {"uint",    "EffectItemType_2"}, //used
	        new String[] {"uint",    "EffectItemType_3"}, //used
	        new String[] {"int",     "EffectMiscValueA_1"}, //used
	        new String[] {"int",     "EffectMiscValueA_2"}, //used
	        new String[] {"int",     "EffectMiscValueA_3"}, //used
	        new String[] {"int",     "EffectMiscValueB_1"}, //used
	        new String[] {"int",     "EffectMiscValueB_2"}, //used
	        new String[] {"int",     "EffectMiscValueB_3"}, //used
	        new String[] {"uint",    "EffectTriggerSpell_1"}, //used
	        new String[] {"uint",    "EffectTriggerSpell_2"}, //used
	        new String[] {"uint",    "EffectTriggerSpell_3"}, //used
	        new String[] {"float",   "EffectPointsPerComboPoint_1"}, //used
	        new String[] {"float",   "EffectPointsPerComboPoint_2"}, //used
	        new String[] {"float",   "EffectPointsPerComboPoint_3"}, //used
	        new String[] {"uint",    "EffectSpellClassMaskA_1"}, //used
	        new String[] {"uint",    "EffectSpellClassMaskA_2"}, //used
	        new String[] {"uint",    "EffectSpellClassMaskA_3"}, //used
	        new String[] {"uint",    "EffectSpellClassMaskB_1"}, //used
	        new String[] {"uint",    "EffectSpellClassMaskB_2"}, //used
	        new String[] {"uint",    "EffectSpellClassMaskB_3"}, //used
	        new String[] {"uint",    "EffectSpellClassMaskC_1"}, //used
	        new String[] {"uint",    "EffectSpellClassMaskC_2"}, //used
	        new String[] {"uint",    "EffectSpellClassMaskC_3"}, //used
	        new String[] {"uint",    "SpellVisual_1"}, //used
	        new String[] {"uint",    "SpellVisual_2"}, //used
	        new String[] {"uint",    "SpellIconID"}, //used
	        new String[] {"uint",    "ActiveIconID"}, //used
	        new String[] {"uint",    "SpellPriority"}, //used
            #endregion
            #region String (text info)
            new String[] {"string",  "SpellName_enUS"},
	        new String[] {"string",  "SpellName_koKR"},
	        new String[] {"string",  "SpellName_frFR"},
	        new String[] {"string",  "SpellName_deDE"},
	        new String[] {"string",  "SpellName_zhCN"},
	        new String[] {"string",  "SpellName_zhTW"},
	        new String[] {"string",  "SpellName_esES"},
	        new String[] {"string",  "SpellName_esMX"},
	        new String[] {"string",  "SpellName_ruRU"},
	        new String[] {"string",  "SpellName_9"},
	        new String[] {"string",  "SpellName_10"},
	        new String[] {"string",  "SpellName_11"},
	        new String[] {"string",  "SpellName_12"},
	        new String[] {"string",  "SpellName_13"},
	        new String[] {"string",  "SpellName_14"},
	        new String[] {"string",  "SpellName_15"},
	        new String[] {"uint",    "SpellNameFlags"},
            new String[] {"string",  "Rank_enUS"},
	        new String[] {"string",  "Rank_koKR"},
	        new String[] {"string",  "Rank_frFR"},
	        new String[] {"string",  "Rank_deDE"},
	        new String[] {"string",  "Rank_zhCN"},
	        new String[] {"string",  "Rank_zhTW"},
	        new String[] {"string",  "Rank_esES"},
	        new String[] {"string",  "Rank_esMX"},
	        new String[] {"string",  "Rank_ruRU"},
	        new String[] {"string",  "Rank_9"},
	        new String[] {"string",  "Rank_10"},
	        new String[] {"string",  "Rank_11"},
	        new String[] {"string",  "Rank_12"},
	        new String[] {"string",  "Rank_13"},
	        new String[] {"string",  "Rank_14"},
	        new String[] {"string",  "Rank_15"},
	        new String[] {"uint",    "RankFlags"},
            new String[] {"string",  "Description_enUS"},
	        new String[] {"string",  "Description_koKR"},
	        new String[] {"string",  "Description_frFR"},
	        new String[] {"string",  "Description_deDE"},
	        new String[] {"string",  "Description_zhCN"},
	        new String[] {"string",  "Description_zhTW"},
	        new String[] {"string",  "Description_esES"},
	        new String[] {"string",  "Description_esMX"},
	        new String[] {"string",  "Description_ruRU"},
	        new String[] {"string",  "Description_9"},
	        new String[] {"string",  "Description_10"},
	        new String[] {"string",  "Description_11"},
	        new String[] {"string",  "Description_12"},
	        new String[] {"string",  "Description_13"},
	        new String[] {"string",  "Description_14"},
	        new String[] {"string",  "Description_15"},
	        new String[] {"uint",    "DescriptionFlags"},
            new String[] {"string",  "ToolTip_enUS"},
	        new String[] {"string",  "ToolTip_koKR"},
	        new String[] {"string",  "ToolTip_frFR"},
	        new String[] {"string",  "ToolTip_deDE"},
	        new String[] {"string",  "ToolTip_zhCN"},
	        new String[] {"string",  "ToolTip_zhTW"},
	        new String[] {"string",  "ToolTip_esES"},
	        new String[] {"string",  "ToolTip_esMX"},
	        new String[] {"string",  "ToolTip_ruRU"},
	        new String[] {"string",  "ToolTip_9"},
	        new String[] {"string",  "ToolTip_10"},
	        new String[] {"string",  "ToolTip_11"},
	        new String[] {"string",  "ToolTip_12"},
	        new String[] {"string",  "ToolTip_13"},
	        new String[] {"string",  "ToolTip_14"},
	        new String[] {"string",  "ToolTip_15"},
	        new String[] {"uint",    "ToolTipFlags"},
            #endregion
	        new String[] {"uint",    "ManaCostPercentage"},
	        new String[] {"uint",    "StartRecoveryCategory"},
	        new String[] {"uint",    "StartRecoveryTime"},
	        new String[] {"uint",    "MaxTargetLevel"},
	        new String[] {"uint",    "SpellFamilyName"}, // filter
	        new String[] {"ulong",   "SpellFamilyFlagsHight"}, //used
	        new String[] {"uint",    "SpellFamilyFlagsLow"}, //used
	        new String[] {"uint",    "MaxAffectedTargets"},
	        new String[] {"uint",    "DmgClass"}, //used
	        new String[] {"uint",    "PreventionType"},
	        new String[] {"uint",    "StanceBarOrder"},
	        new String[] {"float",   "DmgMultiplier_1"}, //used
	        new String[] {"float",   "DmgMultiplier_2"}, //used
	        new String[] {"float",   "DmgMultiplier_3"}, //used
	        new String[] {"uint",    "MinFactionID"},
	        new String[] {"uint",    "MinReputation"},
	        new String[] {"uint",    "RequiredAuraVision"},
	        new String[] {"uint",    "TotemCategory_1"}, //used
	        new String[] {"uint",    "TotemCategory_2"}, //used
	        new String[] {"uint",    "AreaGroupId"},
	        new String[] {"uint",    "SpellSchoolMask"}, //used
	        new String[] {"uint",    "RuneCostID"},
	        new String[] {"uint",    "SpellMissileID"},
	        new String[] {"uint",    "PowerDisplayID"},
            //new String[] {"float",   "Unk1_1"},
            //new String[] {"float",   "Unk1_2"},
            //new String[] {"float",   "Unk1_3"},
            //new String[] {"uint",    "SpellDescriptionVariableID"}
        };
        #endregion

        #region SpellCastTime structure

        public static readonly String[][] SpellCastTimeStructure = new String[][]
        {
            new String[] {"uint",    "ID"},
            new String[] {"int",     "CastTime"},
            new String[] {"float",   "CastTimePerLevel"},
            new String[] {"int",     "MinCastTime"}
        };

        #endregion

        #region SpellRadius structure

        public static readonly String[][] SpellRadiusStructure = new String[][]
        {
            new String[] {"uint",    "ID"},
            new String[] {"float",   "Radius1"},
            new String[] {"int",     "unk"},
            new String[] {"float",   "Radius2"}
        };

        #endregion

        #region SpellDuration structure

        public static readonly String[][] DurationStructure = new String[][]
        {
            new String[] {"uint",    "ID"},
            new String[] {"int",     "Duration1"},
            new String[] {"int",     "Duration2"},
            new String[] {"int",     "Duration3"}
        };

        #endregion

        #region SpellRange structure
 
        public static readonly String[][] SpellRangeStructure = new String[][]
        {
            new String[] {"uint",    "ID"},
            new String[] {"float",   "minRange"},
            new String[] {"float",   "minRangeFriendly"},
            new String[] {"float",   "maxRange"},
            new String[] {"float",   "maxRangeFriendly"},
              
            new String[] {"int",     "unk"},
            new String[] {"string",  "name"},
            /* is not used
            new String[] {"int",     ""},
            new String[] {"int",     ""},
            new String[] {"int",     ""},
            new String[] {"int",     ""},
            new String[] {"int",     ""},
            new String[] {"int",     ""},
            new String[] {"int",     ""},
            new String[] {"int",     ""},
            new String[] {"int",     ""},
            new String[] {"int",     ""},
            new String[] {"int",     ""},
            new String[] {"int",     ""},
            new String[] {"int",     ""},
            new String[] {"int",     ""},
            new String[] {"int",     ""},
            new String[] {"int",     ""},
            new String[] {"int",     ""},
            new String[] {"int",     ""},
            new String[] {"int",     ""},
            new String[] {"int",     ""},
            new String[] {"int",     ""},
            new String[] {"int",     ""},
            new String[] {"int",     ""},
            new String[] {"int",     ""},
            new String[] {"int",     ""},
            new String[] {"int",     ""},
            new String[] {"int",     ""},
            new String[] {"int",     ""},
            new String[] {"int",     ""},
            new String[] {"int",     ""},
            new String[] {"int",     ""},
            new String[] {"int",     ""},
            new String[] {"int",     ""}*/
        };

        #endregion

        #region SkillLine structure

        public static readonly String[][] SkillLineStructure = new String[][]
        {
            new String[] {"uint",     "ID"},
            new String[] {"uint",     "SkillLineCategory"},
            new String[] {"uint",     "unk"},
            new String[] {"string",   "SkillName_enUS"},
	        new String[] {"string",   "SkillName_koKR"},
	        new String[] {"string",   "SkillName_frFR"},
	        new String[] {"string",   "SkillName_deDE"},
	        new String[] {"string",   "SkillName_zhCN"},
	        new String[] {"string",   "SkillName_zhTW"},
	        new String[] {"string",   "SkillName_esES"},
	        new String[] {"string",   "SkillName_esMX"},
	        new String[] {"string",   "SkillName_ruRU"},
            new String[] {"string",   "SkillName_9"},
            new String[] {"string",   "SkillName_10"},
            new String[] {"string",   "SkillName_11"},
            new String[] {"string",   "SkillName_12"},
            new String[] {"string",   "SkillName_13"},
            new String[] {"string",   "SkillName_14"},
            new String[] {"string",   "SkillName_15"},
            //new String[] {"string",   "Description_enUS"},
            //new String[] {"string",   "Description_koKR"},
            //new String[] {"string",   "Description_frFR"},
            //new String[] {"string",   "Description_deDE"},
            //new String[] {"string",   "Description_zhCN"},
            //new String[] {"string",   "Description_zhTW"},
            //new String[] {"string",   "Description_esES"},
            //new String[] {"string",   "Description_esMX"},
            //new String[] {"string",   "Description_ruRU"},
            //new String[] {"string",   "Description_9"},
            //new String[] {"string",   "Description_10"},
            //new String[] {"string",   "Description_11"},
            //new String[] {"string",   "Description_12"},
            //new String[] {"string",   "Description_13"},
            //new String[] {"string",   "Description_14"},
            //new String[] {"string",   "Description_15"},
            //new String[] {"uint",     "SpellIcon"}
        };

        #endregion

        #region SkillLineAbility structure

        public static readonly String[][] SkillLineAbilityStructure = new String[][]
        {
            new String[] {"uint",     "ID"},
            new String[] {"uint",     "SkillId"},
            new String[] {"uint",     "SpellId"},
            new String[] {"uint",     "Racemask"},
            new String[] {"uint",     "Classmask"},
            new String[] {"uint",     "RacemaskNot"},
            new String[] {"uint",     "ClassmaskNot"},
            new String[] {"uint",     "ReqSkillValue"},
            new String[] {"uint",     "ForwardSpellid"},
            new String[] {"uint",     "LearnOnGetSkill"},
            new String[] {"uint",     "MaxValue"},
            new String[] {"uint",     "MinValue"},
            new String[] {"uint",     "CharacterPoints_1"},
            new String[] {"uint",     "CharacterPoints_2"}
        };

        #endregion

    }
}
