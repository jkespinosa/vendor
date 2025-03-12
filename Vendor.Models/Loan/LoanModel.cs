
namespace Vendor.Models.Loan
{
    public class LoanModel
    {
        public string sLNm { get; set; }
        public string sTerm { get; set; }
        public string sNoteIR { get; set; }
        public string sSchedDueD1 { get; set; }
        public bool sSchedDueD1Lckd { get; set; }
        public bool sAggregateAdjRsrvLckd { get; set; }
        public bool sAppSubmittedDLckd { get; set; }
        public int sFinMethT { get; set; }
        public int sLT { get; set; }
        public int sGseRefPurposeT { get; set; }

        public List<ConsumerModel> ConsumerList { get;  set; }


    }
}
