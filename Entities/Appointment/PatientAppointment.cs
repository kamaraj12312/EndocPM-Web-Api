using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EndocPM.WebAPI
{
    public partial class PatientAppointment
    {        
        public int PatientAppointmentID { get; set; }
        public int PatientID { get; set; }
        public int FacilityID { get; set; }
        public int ProviderID { get; set; }

        public DateTime AppointmentDate { get; set; }
        public int VisitTypeID { get; set; }

        public DateTime StartTime { get; set; }

        public  DateTime EndTime { get; set; }
        public decimal Duration { get; set; }
        public int SlotNumber { get; set; }
        public string AppointmentStatusCode { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsRecurrence { get; set; }
        public Nullable<int> ParentAppointID { get; set; }
        public string RecurrenceRule { get; set; }
        public string RecurrenceException { get; set; }
        public string StartTimezone { get; set; }
        public string EndTimezone { get; set; }
        public bool IsWaiting { get; set; }
        public bool Deleted { get; set; }
        public bool ShowInGrid { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<bool> IsMobileRequest { get; set; }
        public Nullable<int> PatientVisitID { get; set; }
        public Nullable<bool> IsReminder { get; set; }
        public Nullable<int> RemindBeforeDays { get; set; }
        public Nullable<int> RemindBeforeHours { get; set; }
        public Nullable<int> NumberOfMessagesToSendPerPatient { get; set; }
        public Nullable<int> IntervalPerMessage { get; set; }
        public Nullable<int> IntervalBetweenMessagesTypeId { get; set; }
        public bool IsSuperBillGenerated { get; set; }
        public string OtherAppointmentType { get; set; }
        public bool IsPrinted { get; set; }
        public Nullable<int> ConsultationTypeID{ get; set; }
        public Nullable<bool> IsUnScheduledAppointment { get; set; }
        public Nullable<int> AppointmentTypeId { get; set; }
        public Nullable<int> EndAfter { get; set; }
        public Nullable<DateTime> EndOnDate { get; set; }
        public Nullable<int> RepeatID { get; set; }
        public Nullable<int> RepeatDaysInterval { get; set; }
        public string Notes { get; set; }


    }
}
