using System;

namespace EndocPM.WebAPI
{
    public class PatientTobaccoAlcoholHistoryModel
    {
        public PatientTobaccoAlcoholHistoryModel()
        {
            this.RecordedDate = DateTime.UtcNow;
        }

        #region Model Properities

        public int PatientTobaccoAlcoholHistoryID { get; set; }
        public int PatientID { get; set; }
        public Nullable<int> PatientAppointmentID { get; set; }
        public DateTime RecordedDate { get; set; }
        public string RecordedDateString { get; set; }
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










        #region NewFields

        public Nullable<DateTime> RecordedTime { get; set; }
        public Nullable<int> RecordedDuringId { get; set; }
        public string RecordedDuringName { get; set; }
        public string SmokingMaterial { get; set; }
        public Nullable<DateTime> SmokingStartedOn { get; set; }
        public Nullable<DateTime> SmokingQuittedOn { get; set; }
        public string DrinkingMaterial { get; set; }
        public string RehabilitationNotes { get; set; }
        public Nullable<DateTime> DrinkingStartedOn { get; set; }
        public Nullable<DateTime> DrinkingQuittedOn { get; set; }
        public string SmokingMethodToQuit { get; set; }
        public string DrinkingMethodToQuit { get; set; }
        public bool RecentlyTravelled { get; set; }
        public string RecentlyTravelledCountry { get; set; }
        public string DrugHabits { get; set; }
        public string ExerciseHabits { get; set; }
        public string DailyLivingActivities { get; set; }
        public string RecordedTimeString { get; set; }


        #endregion

        #endregion

        #region Custom Properities
        public string SmokingStatusDescription { get; set; }
        public string DrinkingStatusDescription { get; set; }
        public string PatientTobaccoAlcoholHistoryTitle { get; set; }
        public string PerDayLabel { get; set; }
        public string PerYearLabel { get; set; }
        public Nullable<int> PatientTobaccoAlcoholHistoryCaseSheetBack { get; set; }

        public Nullable<DateTime> FromDate { get; set; }
        public Nullable<DateTime> ToDate { get; set; }
        public Nullable<int> SearchSmokingStatusID { get; set; }
        public Nullable<int> SearchDrinkingStatusID { get; set; }

        public string PatientTobaccoAlcoholHistoryDescription { get; set; }
        public string IsSearch { get; set; }
        public string PatientTransactionDateString { get; set; }
        public Nullable<DateTime> PatientTransactionDate { get; set; }
        public string VisitTime { get; set; }
        #endregion

        #region Search Properties
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }

        #endregion
    }
}
