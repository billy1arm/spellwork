using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpellWork
{
    enum SpellFields3
    {
        EffectDieSides,
        EffectBaseDice,
        EffectDicePerLevel,
        EffectRealPointsPerLevel,
        EffectBasePoints,
        EffectMechanic,
        EffectApplyAuraName,
        EffectAmplitude,
        EffectMultipleValue,
        EffectChainTargets,
        EffectItemType,
        EffectMiscValueA,
        EffectMiscValueB,
        EffectTriggerSpell,
        EffectPointsPerComboPoint,
        EffectSpellClassMaskA,
        EffectSpellClassMaskB,
        EffectSpellClassMaskC,
        DmgMultiplier
    };

    enum SpellFields2
    {
        Stances,
        StancesNot,
        Totem,
        SpellVisual,
        TotemCategory
    };
  
    enum SpellFieldBloc1
    {
        Dispel,
        Category,
        SpellIconID,
        ActiveIconID,
        DmgClass,
        PreventionType,
        SpellLevel,
        ManaCostPercentage,
        StartRecoveryCategory,
        StartRecoveryTime,
        MaxTargetLevel,
        MaxAffectedTargets,
        StanceBarOrder,
        MinFactionID,
        MinReputation,
        RequiredAuraVision,
        AreaGroupId,
        RuneCostID,
        SpellMissileID,
        PowerDisplayID,
    };

    enum SpellFieldBloc2
    {
        TargetCreatureType,
        RequiresSpellFocus,
        FacingCasterFlags,
        CasterAuraState,
        TargetAuraState,
        CasterAuraStateNot,
        TargetAuraStateNot,
        CasterAuraSpell,
        TargetAuraSpell,
        ExcludeCasterAuraSpell,
        ExcludeTargetAuraSpell,
        RecoveryTime,
        CategoryRecoveryTime,
        InterruptFlags,
        AuraInterruptFlags,
        ChannelInterruptFlags,
        ProcFlags,
        ProcChance,
        ProcCharges,
        MaxLevel,
        BaseLevel
    };

    enum SpellFieldBloc3
    {
        PowerType,
        ManaCost,
        ManaCostPerLevel,
        ManaPerSecond,
        ManaPerSecondPerLeve,
        Speed,
        ModalNextSpell,
        StackAmount,
    };
}
