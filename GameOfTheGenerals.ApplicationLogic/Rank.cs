using System.ComponentModel;

namespace GameOfTheGenerals.ApplicationLogic
{   public enum Rank
    {
        [Description("FLG")]
        Flag,
        [Description("PVT")]
        Private,
        [Description("SGT")]
        Sergeant,
        [Description("2LT")]
        SecondLieutenant,
        [Description("1LT")]
        FirstLieutenant,
        [Description("CPT")]
        Captain,
        [Description("MAJ")]
        Major,
        [Description("LTC")]
        LieutenantColonel,
        [Description("COL")]
        Colonel,
        [Description("BRG")]
        BrigadierGeneral,
        [Description("MAG")]
        MajorGeneral,
        [Description("LTG")]
        LieutenantGeneral,
        [Description("GEN")]
        General,
        [Description("GOA")]
        GeneralOfTheArmy,
        [Description("SPY")]
        Spy
    }
}
