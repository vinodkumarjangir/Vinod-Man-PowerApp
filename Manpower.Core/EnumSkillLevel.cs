using System.ComponentModel;

namespace ManpowerApp.Manpower.Core
{
    public enum EnumSkillLevel
    {
        [Description("Operator I")]
        Operator_I = 1,
        [Description("Machinist I")]
        Machinist_I = 1,
        [Description("Operator II")]
        Operator_II = 2,
        [Description("Specialist Machinist")]
        SpecialistMachinist = 3,
        [Description("Master Machinist")]
        MasterMachinist = 4
    }
}
