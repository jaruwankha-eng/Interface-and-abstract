using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_and_abstract
{
        public class TrainingResult
        {
            // ==================== Properties ====================

            /// <summary>
            /// รหัสผลการอบรม
            /// </summary>
            public string ResultId { get; set; }

            /// <summary>
            /// ชื่อหลักสูตรการอบรม
            /// </summary>
            public string TrainingName { get; set; }

            /// <summary>
            /// ผู้เข้ารับการอบรม
            /// </summary>
            public Person Participant { get; set; }

            /// <summary>
            /// วิทยากรผู้อนุมัติ
            /// </summary>
            public Trainer ApprovedBy { get; set; }

            /// <summary>
            /// สถานะ (ผ่าน/ไม่ผ่าน)
            /// </summary>
            public string Status { get; set; }

            /// <summary>
            /// คะแนนที่ได้รับ
            /// </summary>
            public double Score { get; set; }

            /// <summary>
            /// วันที่อนุมัติ
            /// </summary>
            public DateTime ApprovedDate { get; set; }

            /// <summary>
            /// หมายเหตุ
            /// </summary>
            public string Remark { get; set; }

            // ==================== Constructors ====================

            public TrainingResult()
            {
                ResultId = Guid.NewGuid().ToString().Substring(0, 8);
                TrainingName = "";
                Participant = null;
                ApprovedBy = null;
                Status = "รอการอนุมัติ";
                Score = 0;
                ApprovedDate = DateTime.Now;
                Remark = "";
            }

            public TrainingResult(string trainingName, Person participant, Trainer approvedBy,
                                 string status, double score = 0) : this()
            {
                TrainingName = trainingName;
                Participant = participant;
                ApprovedBy = approvedBy;
                Status = status;
                Score = score;
            }

            // ==================== Methods ====================

            /// <summary>
            /// อนุมัติผลการอบรม
            /// </summary>
            public void Approve(Trainer trainer, string status, double score)
            {
                ApprovedBy = trainer;
                Status = status;
                Score = score;
                ApprovedDate = DateTime.Now;
            }

            /// <summary>
            /// ตรวจสอบว่าผ่านหรือไม่
            /// </summary>
            public bool IsPassed()
            {
                return Status == "ผ่าน";
            }

            /// <summary>
            /// แสดงข้อมูลผลการอบรม
            /// </summary>
            public string DisplayResult()
            {
                string approvedByInfo = ApprovedBy != null ? ApprovedBy.GetFullName() : "รอการอนุมัติ";
                return "หลักสูตร: " + TrainingName + ", ผู้เข้ารับการอบรม: " +
                       Participant.GetFullName() + ", สถานะ: " + Status +
                       ", คะแนน: " + Score + ", อนุมัติโดย: " + approvedByInfo;
            }

            public override string ToString()
            {
                return DisplayResult();
            }
        }
    
}
