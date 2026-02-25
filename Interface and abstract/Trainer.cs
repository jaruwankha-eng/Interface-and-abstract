using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_and_abstract
{
        public class Trainer : Person, ITrainer
        {
            // ==================== Properties ====================

            /// <summary>
            /// ความเชี่ยวชาญ
            /// </summary>
            public string Expertise { get; set; }

            /// <summary>
            /// สถาบัน/สังกัด
            /// </summary>
            public string Institution { get; set; }

            /// <summary>
            /// รายการการอนุมัติ
            /// </summary>
            public List<TrainingApproval> ApprovedTrainings { get; set; }

            // ==================== Constructors ====================

            public Trainer() : base()
            {
                Expertise = "";
                Institution = "";
                ApprovedTrainings = new List<TrainingApproval>();
            }

            public Trainer(string firstName, string lastName, string phone, string email,
                          string expertise, string institution = "") : base(firstName, lastName, phone, email)
            {
                Expertise = expertise;
                Institution = institution;
                ApprovedTrainings = new List<TrainingApproval>();
            }

            // ==================== Methods ====================

            /// <summary>
            /// แสดงข้อมูลวิทยากร (Override)
            /// </summary>
            public override string DisplayInfo()
            {
                string institutionInfo = Institution != "" ? ", สังกัด: " + Institution : "";
                return base.DisplayInfo() + ", ความเชี่ยวชาญ: " + Expertise + institutionInfo;
            }

            // ==================== Implement ITrainer ====================

            /// <summary>
            /// อนุมัติผลการอบรม
            /// </summary>
            public void ApproveTrainingResult(TrainingResult result)
            {
                TrainingApproval approval = new TrainingApproval();
                approval.ParticipantName = result.Participant.GetFullName();
                approval.Result = result.Status;
                approval.ApprovedDate = DateTime.Now;
                approval.TrainingName = result.TrainingName;

                ApprovedTrainings.Add(approval);
            }

            /// <summary>
            /// รับจำนวนผู้ที่อนุมัติ
            /// </summary>
            public int GetApprovedCount()
            {
                return ApprovedTrainings.Count;
            }

            /// <summary>
            /// แสดงรายละเอียดวิทยากร
            /// </summary>
            public string GetTrainerInfo()
            {
                return "วิทยากร: " + GetFullName() + ", ความเชี่ยวชาญ: " + Expertise +
                       ", จำนวนที่อนุมัติ: " + GetApprovedCount() + " คน";
            }

            /// <summary>
            /// แสดงรายชื่อผู้ที่อนุมัติทั้งหมด
            /// </summary>
            public void PrintApprovedList()
            {
                Console.WriteLine("รายชื่อผู้ที่ได้รับการอนุมัติ (" + ApprovedTrainings.Count + " คน):");
                foreach (var training in ApprovedTrainings)
                {
                    Console.WriteLine("  - " + training.ParticipantName + ": " + training.Result +
                                    " (วันที่: " + training.ApprovedDate.ToString("dd/MM/yyyy") + ")");
                }
            }

            public override string ToString()
            {
                return DisplayInfo();
            }
        }
    
}
