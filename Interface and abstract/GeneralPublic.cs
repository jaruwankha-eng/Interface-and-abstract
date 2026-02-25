using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_and_abstract
{
        public class GeneralPublic : Person, IParticipant
        {
            // ==================== Properties ====================

            /// <summary>
            /// สถานที่ทำงาน
            /// </summary>
            public string Workplace { get; set; }

            /// <summary>
            /// ตำแหน่ง
            /// </summary>
            public string Position { get; set; }

            /// <summary>
            /// รายการผลการอบรม
            /// </summary>
            public List<TrainingResult> TrainingResults { get; set; }

            /// <summary>
            /// สามารถเป็นวิทยากรได้หรือไม่
            /// </summary>
            public bool CanBeTrainer { get; set; }

            // ==================== Constructors ====================

            public GeneralPublic() : base()
            {
                Workplace = "";
                Position = "";
                TrainingResults = new List<TrainingResult>();
                CanBeTrainer = false;
            }

            public GeneralPublic(string firstName, string lastName, string phone, string email,
                                string workplace, string position, bool canBeTrainer = false)
                : base(firstName, lastName, phone, email)
            {
                Workplace = workplace;
                Position = position;
                TrainingResults = new List<TrainingResult>();
                CanBeTrainer = canBeTrainer;
            }

            // ==================== Methods ====================

            /// <summary>
            /// เปิดใช้งานให้เป็นวิทยากรได้
            /// </summary>
            public void EnableTrainer()
            {
                CanBeTrainer = true;
            }

            /// <summary>
            /// ปิดใช้งานไม่ให้เป็นวิทยากร
            /// </summary>
            public void DisableTrainer()
            {
                CanBeTrainer = false;
            }

            /// <summary>
            /// แสดงข้อมูลบุคคลทั่วไป (Override)
            /// </summary>
            public override string DisplayInfo()
            {
                string trainerStatus = CanBeTrainer ? " (เป็นวิทยากรได้)" : "";
                return base.DisplayInfo() + ", สถานที่ทำงาน: " + Workplace + ", ตำแหน่ง: " + Position + trainerStatus;
            }

            // ==================== Implement IParticipant ====================

            public void AddTrainingResult(TrainingResult result)
            {
                TrainingResults.Add(result);
            }

            public int GetTrainingCount()
            {
                return TrainingResults.Count;
            }

            public bool IsPassed()
            {
                if (TrainingResults.Count == 0)
                    return false;

                foreach (var result in TrainingResults)
                {
                    if (result.Status != "ผ่าน")
                        return false;
                }
                return true;
            }

            public override string ToString()
            {
                return DisplayInfo();
            }
        }
    
}
