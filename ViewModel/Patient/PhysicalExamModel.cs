using System;
using System.ComponentModel.DataAnnotations;

namespace EndocPM.WebAPI
{
    public class PhysicalExamModel
    {
        public int PhysicalExamID { get; set; }
        public int PatientID { get; set; }
        public int PatientVisitID { get; set; }
        public DateTime RecordedDate { get; set; }
        public Nullable<bool> GeneralWellappearing { get; set; }
        public Nullable<bool> Generalwellnourished { get; set; }
        public Nullable<bool> Generalinnodistress { get; set; }
        public Nullable<bool> GeneralOrientedx3 { get; set; }
        public Nullable<bool> Generalnormalmoodandaffect { get; set; }
        public Nullable<bool> GeneralAmbulatingwithoutdifficulty { get; set; }
        public Nullable<bool> SkinGoodturgor { get; set; }
        public Nullable<bool> Skinnorash { get; set; }
        public Nullable<bool> Skinunusualbruisingorprominentlesions { get; set; }
        public Nullable<bool> HairNormaltextureanddistribution { get; set; }
        public Nullable<bool> NailsNormalcolor { get; set; }
        public Nullable<bool> Nailsnodeformities { get; set; }
        public Nullable<bool> HeadNormocephalic { get; set; }
        public Nullable<bool> Headatraumatic { get; set; }
        public Nullable<bool> Headnovisibleorpalpablemasses { get; set; }
        public Nullable<bool> Headdepressions { get; set; }
        public Nullable<bool> Headorscaring { get; set; }
        public Nullable<bool> EyesVisualacuityintact { get; set; }
        public Nullable<bool> Eyesconjunctivaclear { get; set; }
        public Nullable<bool> Eyesscleranonicteric { get; set; }
        public Nullable<bool> EyesEOMintact { get; set; }
        public Nullable<bool> EyesPERRL { get; set; }
        public Nullable<bool> Eyesfundihavenormalopticdiscsandvessels { get; set; }
        public Nullable<bool> Eyesnoexudatesorhemorrhages { get; set; }
        public Nullable<bool> EarsEACsclear { get; set; }
        public Nullable<bool> EarsTMstranslucentmobile { get; set; }
        public Nullable<bool> Earsossiclesnlappearance { get; set; }
        public Nullable<bool> Earshearingintact { get; set; }
        public Nullable<bool> NoseNoexternallesions { get; set; }
        public Nullable<bool> Nosemucosanoninflamed { get; set; }
        public Nullable<bool> Noseseptumandturbinatesnormal { get; set; }
        public Nullable<bool> MouthMucousmembranesmoist { get; set; }
        public Nullable<bool> Mouthnomucosallesions { get; set; }
        public Nullable<bool> TeethGumsNoobviouscariesorperiodontaldisease { get; set; }
        public Nullable<bool> TeethGumsNogingivalinflammationorsignificantresorption { get; set; }
        public Nullable<bool> PharynxMucosanoninflamed { get; set; }
        public Nullable<bool> Pharynxnotonsillarhypertrophyorexudate { get; set; }
        public Nullable<bool> PharynxNogingivalinflammationorsignificantresorption { get; set; }
        public Nullable<bool> NeckSupple { get; set; }
        public Nullable<bool> Neckwithoutlesions { get; set; }
        public Nullable<bool> Neckbruits { get; set; }
        public Nullable<bool> Neckoradenopathy { get; set; }
        public Nullable<bool> Neckthyroidnonenlargedandnontender { get; set; }
        public Nullable<bool> HeartNocardiomegalyorthrills { get; set; }
        public Nullable<bool> Heartregularrateandrhythm { get; set; }
        public Nullable<bool> Heartnomurmurorgallop { get; set; }
        public Nullable<bool> HeartAmbulatingwithoutdifficulty { get; set; }
        public Nullable<bool> LungsCleartoauscultationandpercussion { get; set; }
        public Nullable<bool> AbdomenBowelsoundsnormal { get; set; }
        public Nullable<bool> Abdomennotenderness { get; set; }
        public Nullable<bool> Abdomenorganomegaly { get; set; }
        public Nullable<bool> Abdomenmasses { get; set; }
        public Nullable<bool> Abdomenorhernia { get; set; }
        public Nullable<bool> BackSpinenormalwithoutdeformityortenderness { get; set; }
        public Nullable<bool> BacknoCVAtenderness { get; set; }
        public Nullable<bool> Backmasses { get; set; }
        public Nullable<bool> Backorhernia { get; set; }
        public Nullable<bool> RectalNormalsphinctertone { get; set; }
        public Nullable<bool> Rectalnohemorrhoidsormassespalpable { get; set; }
        public Nullable<bool> ExtremitiesNoamputationsordeformities { get; set; }
        public Nullable<bool> Extremitiescyanosis { get; set; }
        public Nullable<bool> Extremitiesedemaorvaricosities { get; set; }
        public Nullable<bool> Extremitiesperipheralpulsesintact { get; set; }
        public Nullable<bool> MusculoskeletalNormalgaitandstation { get; set; }
        public Nullable<bool> MusculoskeletalNomisalignment { get; set; }
        public Nullable<bool> Musculoskeletalasymmetry { get; set; }
        public Nullable<bool> Musculoskeletalcrepitation { get; set; }
        public Nullable<bool> Musculoskeletaldefects { get; set; }
        public Nullable<bool> Musculoskeletaltenderness { get; set; }
        public Nullable<bool> Musculoskeletalmasses { get; set; }
        public Nullable<bool> Musculoskeletaleffusions { get; set; }
        public Nullable<bool> Musculoskeletaldecreasedrangeofmotion { get; set; }
        public Nullable<bool> Musculoskeletalinstability { get; set; }
        public Nullable<bool> Musculoskeletalatrophyorabnormal { get; set; }
        public Nullable<bool> NeurologicCN212normal { get; set; }
        public Nullable<bool> NeurologicSensationtopain { get; set; }
        public Nullable<bool> Neurologictouch { get; set; }
        public Nullable<bool> Neurologicandproprioceptionnormal { get; set; }
        public Nullable<bool> NeurologicDTRsnormalinupperandlowerextremities { get; set; }
        public Nullable<bool> NeurologicNopathologicreflexes { get; set; }
        public Nullable<bool> PsychiatricOrientedX3 { get; set; }
        public Nullable<bool> Psychiatricintactrecentandremotememory { get; set; }
        public Nullable<bool> Psychiatricjudgmentandinsight { get; set; }
        public Nullable<bool> Psychiatricnormalmoodandaffect { get; set; }
        public Nullable<bool> PelvicVaginaandcervixwithoutlesionsordischarge { get; set; }
        public Nullable<bool> PelvicUterusandadnexaParametrianontenderwithoutmasses { get; set; }
        public Nullable<bool> BreastNonippleabnormality { get; set; }
        public Nullable<bool> Breastdominantmasses { get; set; }
        public Nullable<bool> Breasttendernesstopalpation { get; set; }
        public Nullable<bool> Breastaxillaryorsupraclavicularadenopathy { get; set; }
        public Nullable<bool> GUPeniscircumcisedwithoutlesions { get; set; }
        public Nullable<bool> GUurethralmeatusnormallocationwithoutdischarge { get; set; }
        public Nullable<bool> GUtestesandepididymidesnormalsizewithoutmasses { get; set; }
        public Nullable<bool> GUscrotumwithoutlesions { get; set; }
        public bool IsActive { get; set; }
        public DateTime Createddate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }


        public string GeneralValue { get; set; }

        public string SkinValue { get; set; }

        public string HairValue { get; set; }

        public string NailsValue { get; set; }

        public string EyesValue { get; set; }

        public string EarsValue { get; set; }

        public string NoseValue { get; set; }
        public string MouthValue { get; set; }

        public string TeethGumsValue { get; set; }

        public string NeckValue { get; set; }

        public string HeartValue { get; set; }

        public string LungsValue { get; set; }

        public string AbdomenValue { get; set; }

        public string BackValue { get; set; }

        public string RectalValue { get; set; }

        public string ExtremitiesValue { get; set; }

        public string MusculoskeletalValue { get; set; }

        public string NeurologicValue { get; set; }

        public string PsychiatricValue { get; set; }

        public string PelvicValue { get; set; }

        public string BreastValue { get; set; }

        public string GUvalue { get; set; }
    }
}
