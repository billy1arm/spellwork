using System;
using System.Linq;
using System.Data;
using SpellWork.DbcReader;
using System.Collections;
using System.Collections.Generic;

namespace SpellWork
{
    /// <summary>
    /// Места для хранения данных с dbc
    /// </summary>
    public class Spell
    {
        public Spell()
        {
            //todo: selected folder in settings
            try
            {
                var path = @"dbc\";

                new DBCReader(path + "Spell.dbc",            ref SpellData,        SpellStructure);
                new DBCReader(path + "SpellCastTimes.dbc",   ref SpellCastTime,    SpellCastTimeStructure);
                new DBCReader(path + "SpellRadius.dbc",      ref SpellRadius,      SpellRadiusStructure);
                new DBCReader(path + "SpellDuration.dbc",    ref SpellDuration,    DurationStructure);
                new DBCReader(path + "SpellRange.dbc",       ref SpellRange,       SpellRangeStructure);
                new DBCReader(path + "SkillLineAbility.dbc", ref SkillLineAbility, SkillLineAbilityStructure);
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("not files in \"\\dbc\" folder");
            }
       }

        #region SpellDataTable
        /// <summary>
        /// 
        /// </summary>
        public DataTable SpellData            = new DataTable();
        /// <summary>
        /// 
        /// </summary>
        public DataTable SpellCastTime        = new DataTable();
        /// <summary>
        /// 
        /// </summary>
        public DataTable SpellRadius          = new DataTable();
        /// <summary>
        /// 
        /// </summary>
        public DataTable SpellRange           = new DataTable();
        /// <summary>
        /// 
        /// </summary>
        public DataTable SpellDuration        = new DataTable();
        /// <summary>
        /// 
        /// </summary>
        public DataTable SkillLineAbility     = new DataTable();

        #endregion

        #region Spell structure
        /// <summary>
        /// 
        /// </summary>
        public static readonly String[][] SpellStructure = new String[][]
        {
           //на будущее: обнулить то, что не нужно :)
	        new String[] {"uint",    "ID"}, 
	        new String[] {"uint",    "Category"},
	        new String[] {"uint",    "Dispel"},
	        new String[] {"uint",    "Mechanic"},
	        new String[] {"uint",    "Attributes"},
	        new String[] {"uint",    "AttributesEx"},
	        new String[] {"uint",    "AttributesEx2"},
	        new String[] {"uint",    "AttributesEx3"},
	        new String[] {"uint",    "AttributesEx4"},
	        new String[] {"uint",    "AttributesEx5"},
	        new String[] {"uint",    "AttributesEx6"},
	        new String[] {"uint",    "AttributesExG"},
	        new String[] {"uint",    "Stances"},
	        new String[] {"uint",    "Stances_2"},
	        new String[] {"uint",    "StancesNot"},
	        new String[] {"uint",    "StancesNot_2"},
	        new String[] {"uint",    "Targets"},
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
	        new String[] {"uint",    "CastingTimeIndex"},
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
	        new String[] {"uint",    "SpellLevel"},
	        new String[] {"uint",    "DurationIndex"},
	        new String[] {"uint",    "PowerType"},
	        new String[] {"uint",    "ManaCost"},
	        new String[] {"uint",    "ManaCostPerLevel"},
	        new String[] {"uint",    "ManaPerSecond"},
	        new String[] {"uint",    "ManaPerSecondPerLeve"},
	        new String[] {"uint",    "RangeIndex"},
	        new String[] {"float",   "Speed"},
	        new String[] {"uint",    "ModalNextSpell"},
	        new String[] {"uint",    "StackAmount"},
	        new String[] {"uint",    "Totem_1"},
	        new String[] {"uint",    "Totem_2"},
	        new String[] {"int",     "Reagent_1"},
	        new String[] {"int",     "Reagent_2"},
	        new String[] {"int",     "Reagent_3"},
	        new String[] {"int",     "Reagent_4"},
	        new String[] {"int",     "Reagent_5"},
	        new String[] {"int",     "Reagent_6"},
	        new String[] {"int",     "Reagent_7"},
	        new String[] {"int",     "Reagent_8"},
	        new String[] {"uint",    "ReagentCount_1"},
	        new String[] {"uint",    "ReagentCount_2"},
	        new String[] {"uint",    "ReagentCount_3"},
	        new String[] {"uint",    "ReagentCount_4"},
	        new String[] {"uint",    "ReagentCount_5"},
	        new String[] {"uint",    "ReagentCount_6"},
	        new String[] {"uint",    "ReagentCount_7"},
	        new String[] {"uint",    "ReagentCount_8"},
	        new String[] {"int",     "EquippedItemClass"},
	        new String[] {"int",     "EquippedItemSubClassMask"},
	        new String[] {"int",     "EquippedItemInventoryTypeMask"},
	        new String[] {"uint",    "Effect_1"},
	        new String[] {"uint",    "Effect_2"},
	        new String[] {"uint",    "Effect_3"},
	        new String[] {"int",     "EffectDieSides_1"},
	        new String[] {"int",     "EffectDieSides_2"},
	        new String[] {"int",     "EffectDieSides_3"},
	        new String[] {"uint",    "EffectBaseDice_1"},
	        new String[] {"uint",    "EffectBaseDice_2"},
	        new String[] {"uint",    "EffectBaseDice_3"},
	        new String[] {"float",   "EffectDicePerLevel_1"},
	        new String[] {"float",   "EffectDicePerLevel_2"},
	        new String[] {"float",   "EffectDicePerLevel_3"},
	        new String[] {"float",   "EffectRealPointsPerLevel_1"},
	        new String[] {"float",   "EffectRealPointsPerLevel_2"},
	        new String[] {"float",   "EffectRealPointsPerLevel_3"},
	        new String[] {"int",     "EffectBasePoints_1"},
	        new String[] {"int",     "EffectBasePoints_2"},
	        new String[] {"int",     "EffectBasePoints_3"},
	        new String[] {"uint",    "EffectMechanic_1"},
	        new String[] {"uint",    "EffectMechanic_2"},
	        new String[] {"uint",    "EffectMechanic_3"},
	        new String[] {"uint",    "EffectImplicitTargetA_1"},
	        new String[] {"uint",    "EffectImplicitTargetA_2"},
	        new String[] {"uint",    "EffectImplicitTargetA_3"},
	        new String[] {"uint",    "EffectImplicitTargetB_1"},
	        new String[] {"uint",    "EffectImplicitTargetB_2"},
	        new String[] {"uint",    "EffectImplicitTargetB_3"},
	        new String[] {"uint",    "EffectRadiusIndex_1"},
	        new String[] {"uint",    "EffectRadiusIndex_2"},
	        new String[] {"uint",    "EffectRadiusIndex_3"},
	        new String[] {"uint",    "EffectApplyAuraName_1"},
	        new String[] {"uint",    "EffectApplyAuraName_2"},
	        new String[] {"uint",    "EffectApplyAuraName_3"},
	        new String[] {"uint",    "EffectAmplitude_1"},
	        new String[] {"uint",    "EffectAmplitude_2"},
	        new String[] {"uint",    "EffectAmplitude_3"},
	        new String[] {"float",   "EffectMultipleValue_1"},
	        new String[] {"float",   "EffectMultipleValue_2"},
	        new String[] {"float",   "EffectMultipleValue_3"},
	        new String[] {"uint",    "EffectChainTargets_1"},
	        new String[] {"uint",    "EffectChainTargets_2"},
	        new String[] {"uint",    "EffectChainTargets_3"},
	        new String[] {"uint",    "EffectItemType_1"},
	        new String[] {"uint",    "EffectItemType_2"},
	        new String[] {"uint",    "EffectItemType_3"},
	        new String[] {"int",     "EffectMiscValue_1"},
	        new String[] {"int",     "EffectMiscValue_2"},
	        new String[] {"int",     "EffectMiscValue_3"},
	        new String[] {"int",     "EffectMiscValueB_1"},
	        new String[] {"int",     "EffectMiscValueB_2"},
	        new String[] {"int",     "EffectMiscValueB_3"},
	        new String[] {"uint",    "EffectTriggerSpell_1"},
	        new String[] {"uint",    "EffectTriggerSpell_2"},
	        new String[] {"uint",    "EffectTriggerSpell_3"},
	        new String[] {"float",   "EffectPointsPerComboPoint_1"},
	        new String[] {"float",   "EffectPointsPerComboPoint_2"},
	        new String[] {"float",   "EffectPointsPerComboPoint_3"},
	        new String[] {"uint",    "EffectSpellClassMaskA_1"},
	        new String[] {"uint",    "EffectSpellClassMaskA_2"},
	        new String[] {"uint",    "EffectSpellClassMaskA_3"},
	        new String[] {"uint",    "EffectSpellClassMaskB_1"},
	        new String[] {"uint",    "EffectSpellClassMaskB_2"},
	        new String[] {"uint",    "EffectSpellClassMaskB_3"},
	        new String[] {"uint",    "EffectSpellClassMaskC_1"},
	        new String[] {"uint",    "EffectSpellClassMaskC_2"},
	        new String[] {"uint",    "EffectSpellClassMaskC_3"},
	        new String[] {"uint",    "SpellVisual_1"},
	        new String[] {"uint",    "SpellVisual_2"},
	        new String[] {"uint",    "SpellIconID"},
	        new String[] {"uint",    "ActiveIconID"},
	        new String[] {"uint",    "SpellPriority"},
	        new String[] {"string",  "SpellName_1"},
	        new String[] {"string",  "SpellName_2"},
	        new String[] {"string",  "SpellName_3"},
	        new String[] {"string",  "SpellName_4"},
	        new String[] {"string",  "SpellName_5"},
	        new String[] {"string",  "SpellName_6"},
	        new String[] {"string",  "SpellName_7"},
	        new String[] {"string",  "SpellName_8"},
	        new String[] {"string",  "SpellName_9"},
	        new String[] {"string",  "SpellName_10"},
	        new String[] {"string",  "SpellName_11"},
	        new String[] {"string",  "SpellName_12"},
	        new String[] {"string",  "SpellName_13"},
	        new String[] {"string",  "SpellName_14"},
	        new String[] {"string",  "SpellName_15"},
	        new String[] {"string",  "SpellName_16"},
	        new String[] {"uint",    "SpellNameFlags"},
	        new String[] {"string",  "Rank_1"},
	        new String[] {"string",  "Rank_2"},
	        new String[] {"string",  "Rank_3"},
	        new String[] {"string",  "Rank_4"},
	        new String[] {"string",  "Rank_5"},
	        new String[] {"string",  "Rank_6"},
	        new String[] {"string",  "Rank_7"},
	        new String[] {"string",  "Rank_8"},
	        new String[] {"string",  "Rank_9"},
	        new String[] {"string",  "Rank_10"},
	        new String[] {"string",  "Rank_11"},
	        new String[] {"string",  "Rank_12"},
	        new String[] {"string",  "Rank_13"},
	        new String[] {"string",  "Rank_14"},
	        new String[] {"string",  "Rank_15"},
	        new String[] {"string",  "Rank_16"},
	        new String[] {"uint",    "RankFlags"},
	        new String[] {"string",  "Description_1"},
	        new String[] {"string",  "Description_2"},
	        new String[] {"string",  "Description_3"},
	        new String[] {"string",  "Description_4"},
	        new String[] {"string",  "Description_5"},
	        new String[] {"string",  "Description_6"},
	        new String[] {"string",  "Description_7"},
	        new String[] {"string",  "Description_8"},
	        new String[] {"string",  "Description_9"},
	        new String[] {"string",  "Description_10"},
	        new String[] {"string",  "Description_11"},
	        new String[] {"string",  "Description_12"},
	        new String[] {"string",  "Description_13"},
	        new String[] {"string",  "Description_14"},
	        new String[] {"string",  "Description_15"},
	        new String[] {"string",  "Description_16"},
	        new String[] {"uint",    "DescriptionFlags"},
	        new String[] {"string",  "ToolTip_1"},
	        new String[] {"string",  "ToolTip_2"},
	        new String[] {"string",  "ToolTip_3"},
	        new String[] {"string",  "ToolTip_4"},
	        new String[] {"string",  "ToolTip_5"},
	        new String[] {"string",  "ToolTip_6"},
	        new String[] {"string",  "ToolTip_7"},
	        new String[] {"string",  "ToolTip_8"},
	        new String[] {"string",  "ToolTip_9"},
	        new String[] {"string",  "ToolTip_10"},
	        new String[] {"string",  "ToolTip_11"},
	        new String[] {"string",  "ToolTip_12"},
	        new String[] {"string",  "ToolTip_13"},
	        new String[] {"string",  "ToolTip_14"},
	        new String[] {"string",  "ToolTip_15"},
	        new String[] {"string",  "ToolTip_16"},
	        new String[] {"uint",    "ToolTipFlags"},
	        new String[] {"uint",    "ManaCostPercentage"},
	        new String[] {"uint",    "StartRecoveryCategory"},
	        new String[] {"uint",    "StartRecoveryTime"},
	        new String[] {"uint",    "MaxTargetLevel"},
	        new String[] {"uint",    "SpellFamilyName"},
	        new String[] {"ulong",   "SpellFamilyFlags"},
	        new String[] {"uint",    "SpellFamilyFlags_2"},
	        new String[] {"uint",    "MaxAffectedTargets"},
	        new String[] {"uint",    "DmgClass"},
	        new String[] {"uint",    "PreventionType"},
	        new String[] {"uint",    "StanceBarOrder"},
	        new String[] {"float",   "DmgMultiplier_1"},
	        new String[] {"float",   "DmgMultiplier_2"},
	        new String[] {"float",   "DmgMultiplier_3"},
	        new String[] {"uint",    "MinFactionID"},
	        new String[] {"uint",    "MinReputation"},
	        new String[] {"uint",    "RequiredAuraVision"},
	        new String[] {"uint",    "TotemCategory_1"},
	        new String[] {"uint",    "TotemCategory_2"},
	        new String[] {"uint",    "AreaGroupId"},
	        new String[] {"uint",    "SchoolMask"},
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
        /// <summary>
        /// 
        /// </summary>
        public static readonly String[][] SpellCastTimeStructure = new String[][]
        {
            new String[] {"uint",    "ID"},
            new String[] {"int",     "CastTime"},
            new String[] {"float",   "CastTimePerLevel"},
            new String[] {"int",     "MinCastTime"}
        };

        #endregion

        #region SpellRadius structure
        /// <summary>
        /// 
        /// </summary>
        public static readonly String[][] SpellRadiusStructure = new String[][]
        {
            new String[] {"uint",    "ID"},
            new String[] {"float",   "Radius1"},
            new String[] {"int",     "unk"},
            new String[] {"float",   "Radius2"}
        };

        #endregion

        #region SpellDuration structure
        /// <summary>
        /// 
        /// </summary>
        public static readonly String[][] DurationStructure = new String[][]
        {
            new String[] {"uint",    "ID"},
            new String[] {"int",     "Duration1"},
            new String[] {"int",     "Duration2"},
            new String[] {"int",     "Duration3"}
        };

        #endregion

        #region SpellRange structure
        /// <summary>
        /// 
        /// </summary>
        public static readonly String[][] SpellRangeStructure = new String[][]
        {
            new String[] {"uint",    "ID"},
            new String[] {"float",   "minRange"},
            new String[] {"float",   "minRangeFriendly"},
            new String[] {"float",   "maxRange"},
            new String[] {"float",   "maxRangeFriendly"},
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
            new String[] {"int",     ""},
            new String[] {"int",     ""},
            new String[] {"int",     ""}*/
        };

        #endregion

        #region SkillLineAbility structure
        /// <summary>
        /// 
        /// </summary>
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
