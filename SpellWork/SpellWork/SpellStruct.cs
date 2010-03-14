using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpellWork
{
    class SpellStruct
    {
    }
    
    public struct SpellEntry
    {
        uint     Id;                                           // 0        m_ID
        uint     Category;                                     // 1        m_category
        uint     Dispel;                                       // 2        m_dispelType
        uint     Mechanic;                                     // 3        m_mechanic
        uint     Attributes;                                   // 4        m_attribute
        uint     AttributesEx;                                 // 5        m_attributesEx
        uint     AttributesEx2;                                // 6        m_attributesExB
        uint     AttributesEx3;                                // 7        m_attributesExC
        uint     AttributesEx4;                                // 8        m_attributesExD
        uint     AttributesEx5;                                // 9        m_attributesExE
        uint     AttributesEx6;                                // 10       m_attributesExF
        uint     Unk_320_1;                                    // 11       3.2.0 (0x20 - totems, 0x4 - paladin auras, etc...)
        uint     Stances;                                      // 12       m_shapeshiftMask
        uint     Unk_320_2;                                    // 13       3.2.0
        uint     StancesNot;                                   // 14       m_shapeshiftExclude
        uint     Unk_320_3;                                    // 15       3.2.0
        uint     Targets;                                      // 16       m_targets
        uint     TargetCreatureType;                           // 17       m_targetCreatureType
        uint     RequiresSpellFocus;                           // 18       m_requiresSpellFocus
        uint     FacingCasterFlags;                            // 19       m_facingCasterFlags
        uint     CasterAuraState;                              // 20       m_casterAuraState
        uint     TargetAuraState;                              // 21       m_targetAuraState
        uint     CasterAuraStateNot;                           // 22       m_excludeCasterAuraState
        uint     TargetAuraStateNot;                           // 23       m_excludeTargetAuraState
        uint     CasterAuraSpell;                              // 24       m_casterAuraSpell
        uint     TargetAuraSpell;                              // 25       m_targetAuraSpell
        uint     ExcludeCasterAuraSpell;                       // 26       m_excludeCasterAuraSpell
        uint     ExcludeTargetAuraSpell;                       // 27       m_excludeTargetAuraSpell
        uint     CastingTimeIndex;                             // 28       m_castingTimeIndex
        uint     RecoveryTime;                                 // 29       m_recoveryTime
        uint     CategoryRecoveryTime;                         // 30       m_categoryRecoveryTime
        uint     InterruptFlags;                               // 31       m_interruptFlags
        uint     AuraInterruptFlags;                           // 32       m_auraInterruptFlags
        uint     ChannelInterruptFlags;                        // 33       m_channelInterruptFlags
        uint     ProcFlags;                                    // 34       m_procTypeMask
        uint     ProcChance;                                   // 35       m_procChance
        uint     ProcCharges;                                  // 36       m_procCharges
        uint     MaxLevel;                                     // 37       m_maxLevel
        uint     BaseLevel;                                    // 38       m_baseLevel
        uint     SpellLevel;                                   // 39       m_spellLevel
        uint     DurationIndex;                                // 40       m_durationIndex
        uint     PowerType;                                    // 41       m_powerType
        uint     ManaCost;                                     // 42       m_manaCost
        uint     ManaCostPerlevel;                             // 43       m_manaCostPerLevel
        uint     ManaPerSecond;                                // 44       m_manaPerSecond
        uint     ManaPerSecondPerLevel;                        // 45       m_manaPerSecondPerLeve
        uint     RangeIndex;                                   // 46       m_rangeIndex
        float    Speed;                                        // 47       m_speed
        uint     ModalNextSpell;                               // 48       m_modalNextSpell not used
        uint     StackAmount;                                  // 49       m_cumulativeAura
        uint[]   Totem;                                        // 50-51    m_totem
        int[]    Reagent;                                      // 52-59    m_reagent
        uint[]   ReagentCount;                                 // 60-67    m_reagentCount
        int      EquippedItemClass;                            // 68       m_equippedItemClass (value)
        int      EquippedItemSubClassMask;                     // 69       m_equippedItemSubclass (mask)
        int      EquippedItemInventoryTypeMask;                // 70       m_equippedItemInvTypes (mask)
        uint[]   Effect;                         // 71-73    m_effect
        int[]    EffectDieSides;                  // 74-76    m_effectDieSides
        uint[]   EffectBaseDice;                 // 77-79    m_effectBaseDice
        float[]  EffectDicePerLevel;            // 80-82    m_effectDicePerLevel
        float[]  EffectRealPointsPerLevel;      // 83-85    m_effectRealPointsPerLevel
        int[]    EffectBasePoints;                // 86-88    m_effectBasePoints (don't must be used in spell/auras explicitly, must be used cached Spell::m_currentBasePoints)
        uint[]   EffectMechanic;                 // 89-91    m_effectMechanic
        uint[]   EffectImplicitTargetA;          // 92-94    m_implicitTargetA
        uint[]   EffectImplicitTargetB;          // 95-97    m_implicitTargetB
        uint[]   EffectRadiusIndex;              // 98-100   m_effectRadiusIndex - spellradius.dbc
        uint[]   EffectApplyAuraName;            // 101-103  m_effectAura
        uint[]   EffectAmplitude;                // 104-106  m_effectAuraPeriod
        float[]  EffectMultipleValue;           // 107-109  m_effectAmplitude
        uint[]   EffectChainTarget;              // 110-112  m_effectChainTargets
        uint[]   EffectItemType;                 // 113-115  m_effectItemType
        int[]    EffectMiscValue;                 // 116-118  m_effectMiscValue
        int[]    EffectMiscValueB;                // 119-121  m_effectMiscValueB
        uint[]   EffectTriggerSpell;             // 122-124  m_effectTriggerSpell
        float[]  EffectPointsPerComboPoint;     // 125-127  m_effectPointsPerCombo
        uint[]   EffectSpellClassMaskA;          // 128-130  m_effectSpellClassMaskA, effect 0
        uint[]   EffectSpellClassMaskB;          // 131-133  m_effectSpellClassMaskB, effect 1
        uint[]   EffectSpellClassMaskC;          // 134-136  m_effectSpellClassMaskC, effect 2
        uint[]   SpellVisual;                      // 137-138  m_spellVisualID
        uint     SpellIconID;                                  // 139      m_spellIconID
        uint     ActiveIconID;                                 // 140      m_activeIconID
        uint     SpellPriority;                                // 141      m_spellPriority not used
        string[] SpellName;                                    // 142-157  m_name_lang
        uint     SpellNameFlag;                                // 158 not used
        string[] Rank;                                         // 159-174  m_nameSubtext_lang
        uint     RankFlags;                                    // 175 not used
        string[] Description;                                  // 176-191  m_description_lang not used
        uint     DescriptionFlags;                             // 192 not used
        string[] ToolTip;                                      // 193-208  m_auraDescription_lang not used
        uint     ToolTipFlags;                                 // 209 not used
        uint     ManaCostPercentage;                           // 210      m_manaCostPct
        uint     StartRecoveryCategory;                        // 211      m_startRecoveryCategory
        uint     StartRecoveryTime;                            // 212      m_startRecoveryTime
        uint     MaxTargetLevel;                               // 213      m_maxTargetLevel
        uint     SpellFamilyName;                              // 214      m_spellClassSet
        ulong    SpellFamilyFlags;                             // 215-216  m_spellClassMask NOTE: size is 12 bytes!!!
        uint     SpellFamilyFlags2;                            // 217      addition to m_spellClassMask
        uint     MaxAffectedTargets;                           // 218      m_maxTargets
        uint     DmgClass;                                     // 219      m_defenseType
        uint     PreventionType;                               // 220      m_preventionType
        uint     StanceBarOrder;                               // 221      m_stanceBarOrder not used
        float[]  DmgMultiplier;                                // 222-224  m_effectChainAmplitude
        uint     MinFactionId;                                 // 225      m_minFactionID not used
        uint     MinReputation;                                // 226      m_minReputation not used
        uint     RequiredAuraVision;                           // 227      m_requiredAuraVision not used
        uint[]   TotemCategory;                                // 228-229  m_requiredTotemCategoryID
        int      AreaGroupId;                                  // 230      m_requiredAreaGroupId
        uint     SchoolMask;                                   // 231      m_schoolMask
        uint     RuneCostID;                                   // 232      m_runeCostID
        uint     SpellMissileID;                               // 233      m_spellMissileID not used
        uint     PowerDisplayId;                               // 234 PowerDisplay.dbc, new in 3.1
        float[]  Unk_320_4;                                    // 235-237  3.2.0
        uint     SpellDescriptionVariableID;                   // 238      3.2.0
        uint     SpellDifficultyId;                            // 239      3.3.0
    };

    struct SkillLineEntry
    {
        uint     Id;                                            // 0        m_ID
        int      CategoryId;                                    // 1        m_categoryID
        //uint32    skillCostID;                                // 2        m_skillCostsID
        string[] Name;                                          // 3-18     m_displayName_lang
                                                                // 19 string flags
        //char*     description[16];                            // 20-35    m_description_lang
                                                                // 36 string flags
        uint      SpellIcon;                                    // 37       m_spellIconID
        //char*     alternateVerb[16];                          // 38-53    m_alternateVerb_lang
                                                                // 54 string flags
        uint      CanLink;                                      // 55       m_canLink (prof. with recipes
    };

    struct SkillLineAbilityEntry
    {
        uint    Id;                                             // 0        m_ID
        uint    SkillId;                                        // 1        m_skillLine
        uint    SpellId;                                        // 2        m_spell
        uint    Racemask;                                       // 3        m_raceMask
        uint    Classmask;                                      // 4        m_classMask
        uint    RacemaskNot;                                    // 5        m_excludeRace
        uint    ClassmaskNot;                                   // 6        m_excludeClass
        uint    Req_skill_value;                                // 7        m_minSkillLineRank
        uint    Forward_spellid;                                // 8        m_supercededBySpell
        uint    LearnOnGetSkill;                                // 9        m_acquireMethod
        uint    Max_value;                                      // 10       m_trivialSkillLineRankHigh
        uint    Min_value;                                      // 11       m_trivialSkillLineRankLow
        //uint32    characterPoints[2];                         // 12-13    m_characterPoints[2]
    };

    struct SpellRadiusEntry
    {
        uint  ID;
        float Radius;
        float Radius2;
    };

    struct SpellRangeEntry
    {
        uint  ID;
        float MinRange;
        float MinRangeFriendly;
        float MaxRange;
        float MaxRangeFriendly;
    };

    struct SpellDurationEntry
    {
        uint    ID;
        int[]   Duration;
    };
}
