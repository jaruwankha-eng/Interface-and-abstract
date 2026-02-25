using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_and_abstract
{

        public class Teacher : Person, IParticipant, ITrainer
        {
            // ==================== Properties ====================

            /// <summary>
            /// สาขาวิชา
            /// </summary>
            public string Major { get; set; }

            /// <summary>
            /// ตำแหน่งทางวิชาการ (อาจารย์, ผศ., รศ., ศ.)
            /// </summary>
            public string AcademicPosition { get; set; }

            /// <summary>
            /// รายการผลการอบรม
            /// </summary>
            public List<TrainingResult> TrainingResults { get; set; }

            /// <summary>
            /// สามารถเป็นวิทยากรได้หรือไม่
            /// </summary>
            public bool CanBeTrainer { get; set; }

            /// <summary>
            /// ความเชี่ยวชาญ (Implement ITrainer)
            /// </summary>
            public string Expertise { get; set; }

            /// <summary>
            /// รายการการอนุมัติ (Implement ITrainer)
            /// </summary>
            public List<TrainingApproval> ApprovedTrainings { get; set; }

            // ==================== Constructors ====================

            public Teacher() : base()
            {
                Major = "";
                AcademicPosition = "";
                TrainingResults = new List<TrainingResult>();
                CanBeTrainer = false;
                Expertise = "";
                ApprovedTrainings = new List<TrainingApproval>();
            }

            public Teacher(string firstName, string lastName, string phone, string email,
                          string major, string academicPosition, bool canBeTrainer = false)
                : base(firstName, lastName, phone, email)
            {
                Major = major;
                AcademicPosition = academicPosition;
                TrainingResults = new List<TrainingResult>();
                CanBeTrainer = canBeTrainer;
                Expertise = "";
                ApprovedTrainings = new List<TrainingApproval>();
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
            /// แสดงข้อมูลอาจารย์ (Override)
            /// </summary>
            public override string DisplayInfo()
            {
                string trainerStatus = CanBeTrainer ? " (เป็นวิทยากรได้)" : "";
                return base.DisplayInfo() + ", สาขา: " + Major + ", ตำแหน่ง: " + AcademicPosition + trainerStatus;
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

            // ==================== Implement ITrainer ====================

            public void ApproveTrainingResult(TrainingResult result)
            {
                TrainingApproval approval = new TrainingApproval();
                approval.ParticipantName = result.Participant.GetFullName();
                approval.Result = result.Status;
                approval.ApprovedDate = DateTime.Now;
                approval.TrainingName = result.TrainingName;

                ApprovedTrainings.Add(approval);
            }

            public int GetApprovedCount()
            {
                return ApprovedTrainings.Count;
            }

            public string GetTrainerInfo()
            {
                return "วิทยากร: " + GetFullName() + ", ความเชี่ยวชาญ: " + Expertise +
                       ", จำนวนที่อนุมัติ: " + GetApprovedCount() + " คน";
            }

            public override string ToString()
            {
                return DisplayInfo();
            }
        }
    
}
