using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_and_abstract
{
        public interface IParticipant
        {
            // ==================== Properties ====================

            /// <summary>
            /// รายการผลการอบรม
            /// </summary>
            List<TrainingResult> TrainingResults { get; set; }

            // ==================== Methods ====================

            /// <summary>
            /// เพิ่มผลการอบรม
            /// </summary>
            void AddTrainingResult(TrainingResult result);

            /// <summary>
            /// รับจำนวนการอบรมที่เข้าร่วม
            /// </summary>
            int GetTrainingCount();

            /// <summary>
            /// ตรวจสอบว่าผ่านการอบรมหรือไม่
            /// </summary>
            bool IsPassed();
        }
    
}
