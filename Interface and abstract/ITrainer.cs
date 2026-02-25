using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_and_abstract
{
        public interface ITrainer
        {
            // ==================== Properties ====================

            /// <summary>
            /// ความเชี่ยวชาญ
            /// </summary>
            string Expertise { get; set; }

            /// <summary>
            /// รายการการอนุมัติ
            /// </summary>
            List<TrainingApproval> ApprovedTrainings { get; set; }

            // ==================== Methods ====================

            /// <summary>
            /// อนุมัติผลการอบรม
            /// </summary>
            void ApproveTrainingResult(TrainingResult result);

            /// <summary>
            /// รับจำนวนผู้ที่อนุมัติ
            /// </summary>
            int GetApprovedCount();

            /// <summary>
            /// แสดงรายละเอียดวิทยากร
            /// </summary>
            string GetTrainerInfo();
        }
    
}
