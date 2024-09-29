using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EndocPM.WebAPI
{
    public partial class PatientROS
    {
        [Key]
        public int PatientROSID { get; set; }
        public int PatientID { get; set; }
        public DateTime RecordedDate { get; set; }
        public string Sex { get; set; }
        public bool ConstitutionalNegative { get; set; }
        public bool ConstitutionalWeightloss { get; set; }
        public bool ConstitutionalWeightgain { get; set; }
        public bool ConstitutionalFever { get; set; }
        public bool ConstitutionalNightsweats { get; set; }
        public bool ConstitutionalFatigue { get; set; }
        public bool ENTNegative { get; set; }
        public bool ENTUlcers { get; set; }
        public bool ENTSinus { get; set; }
        public bool ENTHeadache { get; set; }
        public bool ENTHearingLoss { get; set; }
        public bool ENTFatigue { get; set; }
        public bool RespiratoryNegative { get; set; }
        public bool RespiratoryWheezing { get; set; }
        public bool RespiratoryHemoptysis { get; set; }
        public bool RespiratoryCough { get; set; }
        public bool RespiratoryShortnessofBreath { get; set; }
        public bool GenitourinaryNegative { get; set; }
        public bool GenitourinaryUrgency { get; set; }
        public bool GenitourinaryDysuria { get; set; }
        public bool GenitourinaryPolyuria { get; set; }
        public bool GenitourinaryFrequentUrination { get; set; }
        public bool SkinNegative { get; set; }
        public bool SkinRash { get; set; }
        public bool SkinUlcers { get; set; }
        public bool SkinDrySkin { get; set; }
        public bool SkinPigmentedLesions { get; set; }
        public bool PsychiatricNegative { get; set; }
        public bool PsychiatricDepression { get; set; }
        public bool PsychiatricAnxiety { get; set; }
        public bool PsychiatricCrying { get; set; }
        public bool PsychiatricHighStress { get; set; }
        public bool PsychiatricSuicidalIdeation { get; set; }
        public bool HematologicNegative { get; set; }
        public bool HematologicBleeds { get; set; }
        public bool HematologicBruises { get; set; }
        public bool HematologicLymphedema { get; set; }
        public bool HematologicAdenopathys { get; set; }
        public bool HematologicIssueswithBloodclots { get; set; }
        public bool EyesNegative { get; set; }
        public bool EyesVisionChange { get; set; }
        public bool EyesGlassesorContacts { get; set; }
        public bool CardiovascularNegative { get; set; }
        public bool CardiovascularOrthopnea { get; set; }
        public bool CardiovascularChestPain { get; set; }
        public bool CardiovascularEdema { get; set; }
        public bool CardiovascularPalpitation { get; set; }
        public bool CardiovascularClaudication { get; set; }
        public bool GastrointestinalNegative { get; set; }
        public bool GastrointestinalDiarrhea { get; set; }
        public bool GastrointestinalAbdominalPain { get; set; }
        public bool GastrointestinalHeartBurn { get; set; }
        public bool GastrointestinalBloodyStool { get; set; }
        public bool GastrointestinalConstipation { get; set; }
        public bool MusculoSkeletelNegative { get; set; }
        public bool MusculoSkeletelBackPain { get; set; }
        public bool MusculoSkeletelJointPain { get; set; }
        public bool MusculoSkeletelNeckPain { get; set; }
        public bool MusculoSkeletelMuscleWeakness { get; set; }
        public bool NeurologicNegative { get; set; }
        public bool NeurologicSyncope { get; set; }
        public bool NeurologicDizziness { get; set; }
        public bool NeurologicNumbness { get; set; }
        public bool NeurologicHeadaches { get; set; }
        public bool NeurologicSevereMemoryProblems { get; set; }
        public bool EndocrinologyNegative { get; set; }
        public bool EndocrinologyDiabetes { get; set; }
        public bool EndocrinologyHypoThyroid { get; set; }
        public bool EndocrinologyHyperThyroid { get; set; }
        public bool EndocrinologyHairLoss { get; set; }
        public bool EndocrinologyHeatorColdIntolerance { get; set; }
        public bool ImmunologicNegative { get; set; }
        public bool ImmunologicFoodAllergies { get; set; }
        public bool ImmunologicSeasonalAllergies { get; set; }
        public string Notes { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}
