using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_and_abstract
{
        public class TrainingApproval
        {
            // ==================== Properties ====================

            /// <summary>
            /// ชื่อผู้เข้ารับการอบรม
            /// </summary>
            public string ParticipantName { get; set; }

            /// <summary>
            /// ผลการอบรม
            /// </summary>
            public string Result { get; set; }

            /// <summary>
            /// วันที่อนุมัติ
            /// </summary>
            public DateTime ApprovedDate { get; set; }

            /// <summary>
            /// ชื่อหลักสูตร
            /// </summary>
            public string TrainingName { get; set; }

            // ==================== Constructors ====================

            public TrainingApproval()
            {
                ParticipantName = "";
                Result = "";
                ApprovedDate = DateTime.Now;
                TrainingName = "";
            }

            public TrainingApproval(string participantName, string result, string trainingName)
            {
                ParticipantName = participantName;
                Result = result;
                TrainingName = trainingName;
                ApprovedDate = DateTime.Now;
            }

            // ==================== Methods ====================

            /// <summary>
            /// แสดงข้อมูลการอนุมัติ
            /// </summary>
            public string DisplayApproval()
            {
                return ParticipantName + " - " + Result + " (" + TrainingName +
                       ", วันที่: " + ApprovedDate.ToString("dd/MM/yyyy") + ")";
            }

            public override string ToString()
            {
                return DisplayApproval();
            }
        }
    
}
