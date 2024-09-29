using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.AspNetCore.Http;

namespace EndocPM.WebAPI
{
    public class PatientROSMap : IEntityTypeConfiguration<PatientROS>
    {

        public readonly IHttpContextAccessor _iHttpContextAccessor;


        public PatientROSMap(IHttpContextAccessor iHttpContextAccessor)
        {
            _iHttpContextAccessor = iHttpContextAccessor;
        }
        public PatientROSMap()
        {

        }

        public void Configure(EntityTypeBuilder<PatientROS> builder)
        {

            builder.ToTable("PatientROS", "Tenant2");
            builder.HasKey(x => x.PatientROSID);

            builder.Property(x => x.PatientROSID).HasColumnName("PatientROSID");
            builder.Property(x => x.PatientID).HasColumnName("PatientID");
            builder.Property(x => x.RecordedDate).HasColumnName("RecordedDate");
            builder.Property(x => x.Sex).HasColumnName("Sex").HasMaxLength(15);
            builder.Property(x => x.ConstitutionalNegative).HasColumnName("ConstitutionalNegative");
            builder.Property(x => x.ConstitutionalWeightloss).HasColumnName("ConstitutionalWeightloss");
            builder.Property(x => x.ConstitutionalWeightgain).HasColumnName("ConstitutionalWeightgain");
            builder.Property(x => x.ConstitutionalFever).HasColumnName("ConstitutionalFever");
            builder.Property(x => x.ConstitutionalNightsweats).HasColumnName("ConstitutionalNightsweats");
            builder.Property(x => x.ConstitutionalFatigue).HasColumnName("ConstitutionalFatigue");
            builder.Property(x => x.ENTNegative).HasColumnName("ENTNegative");
            builder.Property(x => x.ENTUlcers).HasColumnName("ENTUlcers");
            builder.Property(x => x.ENTSinus).HasColumnName("ENTSinus");
            builder.Property(x => x.ENTHeadache).HasColumnName("ENTHeadache");
            builder.Property(x => x.ENTHearingLoss).HasColumnName("ENTHearingLoss");
            builder.Property(x => x.ENTFatigue).HasColumnName("ENTFatigue");
            builder.Property(x => x.RespiratoryNegative).HasColumnName("RespiratoryNegative");
            builder.Property(x => x.RespiratoryWheezing).HasColumnName("RespiratoryWheezing");
            builder.Property(x => x.RespiratoryHemoptysis).HasColumnName("RespiratoryHemoptysis");
            builder.Property(x => x.RespiratoryCough).HasColumnName("RespiratoryCough");
            builder.Property(x => x.RespiratoryShortnessofBreath).HasColumnName("RespiratoryShortnessofBreath");
            builder.Property(x => x.GenitourinaryNegative).HasColumnName("GenitourinaryNegative");
            builder.Property(x => x.GenitourinaryUrgency).HasColumnName("GenitourinaryUrgency");
            builder.Property(x => x.GenitourinaryDysuria).HasColumnName("GenitourinaryDysuria");
            builder.Property(x => x.GenitourinaryPolyuria).HasColumnName("GenitourinaryPolyuria");
            builder.Property(x => x.GenitourinaryFrequentUrination).HasColumnName("GenitourinaryFrequentUrination");
            builder.Property(x => x.SkinNegative).HasColumnName("SkinNegative");
            builder.Property(x => x.SkinRash).HasColumnName("SkinRash");
            builder.Property(x => x.SkinUlcers).HasColumnName("SkinUlcers");
            builder.Property(x => x.SkinDrySkin).HasColumnName("SkinDrySkin");
            builder.Property(x => x.SkinPigmentedLesions).HasColumnName("SkinPigmentedLesions");
            builder.Property(x => x.PsychiatricNegative).HasColumnName("PsychiatricNegative");
            builder.Property(x => x.PsychiatricDepression).HasColumnName("PsychiatricDepression");
            builder.Property(x => x.PsychiatricAnxiety).HasColumnName("PsychiatricAnxiety");
            builder.Property(x => x.PsychiatricCrying).HasColumnName("PsychiatricCrying");
            builder.Property(x => x.PsychiatricHighStress).HasColumnName("PsychiatricHighStress");
            builder.Property(x => x.PsychiatricSuicidalIdeation).HasColumnName("PsychiatricSuicidalIdeation");
            builder.Property(x => x.HematologicNegative).HasColumnName("HematologicNegative");
            builder.Property(x => x.HematologicBleeds).HasColumnName("HematologicBleeds");
            builder.Property(x => x.HematologicBruises).HasColumnName("HematologicBruises");
            builder.Property(x => x.HematologicLymphedema).HasColumnName("HematologicLymphedema");
            builder.Property(x => x.HematologicAdenopathys).HasColumnName("HematologicAdenopathys");
            builder.Property(x => x.HematologicIssueswithBloodclots).HasColumnName("HematologicIssueswithBloodclots");
            builder.Property(x => x.EyesNegative).HasColumnName("EyesNegative");
            builder.Property(x => x.EyesVisionChange).HasColumnName("EyesVisionChange");
            builder.Property(x => x.EyesGlassesorContacts).HasColumnName("EyesGlassesorContacts");
            builder.Property(x => x.CardiovascularNegative).HasColumnName("CardiovascularNegative");
            builder.Property(x => x.CardiovascularOrthopnea).HasColumnName("CardiovascularOrthopnea");
            builder.Property(x => x.CardiovascularChestPain).HasColumnName("CardiovascularChestPain");
            builder.Property(x => x.CardiovascularEdema).HasColumnName("CardiovascularEdema");
            builder.Property(x => x.CardiovascularPalpitation).HasColumnName("CardiovascularPalpitation");
            builder.Property(x => x.CardiovascularClaudication).HasColumnName("CardiovascularClaudication");
            builder.Property(x => x.GastrointestinalNegative).HasColumnName("GastrointestinalNegative");
            builder.Property(x => x.GastrointestinalDiarrhea).HasColumnName("GastrointestinalDiarrhea");
            builder.Property(x => x.GastrointestinalAbdominalPain).HasColumnName("GastrointestinalAbdominalPain");
            builder.Property(x => x.GastrointestinalHeartBurn).HasColumnName("GastrointestinalHeartBurn");
            builder.Property(x => x.GastrointestinalBloodyStool).HasColumnName("GastrointestinalBloodyStool");
            builder.Property(x => x.GastrointestinalConstipation).HasColumnName("GastrointestinalConstipation");
            builder.Property(x => x.MusculoSkeletelNegative).HasColumnName("MusculoSkeletelNegative");
            builder.Property(x => x.MusculoSkeletelBackPain).HasColumnName("MusculoSkeletelBackPain");
            builder.Property(x => x.MusculoSkeletelJointPain).HasColumnName("MusculoSkeletelJointPain");
            builder.Property(x => x.MusculoSkeletelNeckPain).HasColumnName("MusculoSkeletelNeckPain");
            builder.Property(x => x.MusculoSkeletelMuscleWeakness).HasColumnName("MusculoSkeletelMuscleWeakness");
            builder.Property(x => x.NeurologicNegative).HasColumnName("NeurologicNegative");
            builder.Property(x => x.NeurologicSyncope).HasColumnName("NeurologicSyncope");
            builder.Property(x => x.NeurologicDizziness).HasColumnName("NeurologicDizziness");
            builder.Property(x => x.NeurologicNumbness).HasColumnName("NeurologicNumbness");
            builder.Property(x => x.NeurologicHeadaches).HasColumnName("NeurologicHeadaches");
            builder.Property(x => x.NeurologicSevereMemoryProblems).HasColumnName("NeurologicSevereMemoryProblems");
            builder.Property(x => x.EndocrinologyNegative).HasColumnName("EndocrinologyNegative");
            builder.Property(x => x.EndocrinologyDiabetes).HasColumnName("EndocrinologyDiabetes");
            builder.Property(x => x.EndocrinologyHypoThyroid).HasColumnName("EndocrinologyHypoThyroid");
            builder.Property(x => x.EndocrinologyHyperThyroid).HasColumnName("EndocrinologyHyperThyroid");
            builder.Property(x => x.EndocrinologyHairLoss).HasColumnName("EndocrinologyHairLoss");
            builder.Property(x => x.EndocrinologyHeatorColdIntolerance).HasColumnName("EndocrinologyHeatorColdIntolerance");
            builder.Property(x => x.ImmunologicNegative).HasColumnName("ImmunologicNegative");
            builder.Property(x => x.ImmunologicFoodAllergies).HasColumnName("ImmunologicFoodAllergies");
            builder.Property(x => x.ImmunologicSeasonalAllergies).HasColumnName("ImmunologicSeasonalAllergies");
            builder.Property(x => x.Notes).HasColumnName("Notes").HasMaxLength(2000);
            builder.Property(x => x.Deleted).HasColumnName("Deleted");
            builder.Property(x => x.CreatedDate).HasColumnName("CreatedDate");
            builder.Property(x => x.CreatedBy).HasColumnName("CreatedBy").HasMaxLength(20);
            builder.Property(x => x.ModifiedDate).HasColumnName("ModifiedDate");
            builder.Property(x => x.ModifiedBy).HasColumnName("ModifiedBy").HasMaxLength(20);

        }
    }
}
