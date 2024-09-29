using System;

namespace EndocPM.WebAPI
{
    public class PatientTobaccoAlcoholHistory
    {
        public int PatientTobaccoAlcoholHistoryID { get; set; }
        public int PatientID { get; set; }
        public Nullable<int> PatientAppointmentID { get; set; }
        public DateTime RecordedDate { get; set; }
        public Nullable<int> SmokingStatusID { get; set; }
        public Nullable<int> DrinkingStatusID { get; set; }
        public Nullable<int> CigarettesPerDay { get; set; }
        public Nullable<int> CigarettesPerYear { get; set; }
        public Nullable<decimal> ConsumptionMLPerDay { get; set; }
        public Nullable<decimal> ConsumptionMLPerYear { get; set; }
        public string Notes { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<int> PatientVisitID { get; set; }
        public bool IsPrinted { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual PatientAppointment PatientAppointment { get; set; }


        //#region NewFields
        //public Nullable<DateTime> RecordedTime { get; set; }
        //public Nullable<int> RecordedDuringId { get; set; }
        //public string SmokingMaterial { get; set; }
        //public Nullable<DateTime> SmokingStartedOn { get; set; }
        //public Nullable<DateTime> SmokingQuittedOn { get; set; }
        //public string DrinkingMaterial { get; set; }
        //public string RehabilitationNotes { get; set; }
        //public Nullable<DateTime> DrinkingStartedOn { get; set; }
        //public Nullable<DateTime> DrinkingQuittedOn { get; set; }
        //public string SmokingMethodToQuit { get; set; }
        //public string DrinkingMethodToQuit { get; set; }
        //public bool RecentlyTravelled { get; set; }
        //public string RecentlyTravelledCountry { get; set; }
        //public string DrugHabits { get; set; }
        //public string ExerciseHabits { get; set; }
        //public string DailyLivingActivities { get; set; }
        //#endregion
    }
}
