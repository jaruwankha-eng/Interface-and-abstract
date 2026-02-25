using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_and_abstract
{
        public class Student : Person, IParticipant
        {
            // ==================== Properties ====================

            /// <summary>
            /// สาขาวิชา
            /// </summary>
            public string Major { get; set; }

            /// <summary>
            /// รหัสนักศึกษา
            /// </summary>
            public string StudentId { get; set; }

            /// <summary>
            /// รายการผลการอบรม
            /// </summary>
            public List<TrainingResult> TrainingResults { get; set; }

            // ==================== Constructors ====================

            public Student() : base()
            {
                Major = "";
                StudentId = "";
                TrainingResults = new List<TrainingResult>();
            }

            public Student(string firstName, string lastName, string phone, string email,
                          string major, string studentId) : base(firstName, lastName, phone, email)
            {
                Major = major;
                StudentId = studentId;
                TrainingResults = new List<TrainingResult>();
            }

            // ==================== Methods ====================

            /// <summary>
            /// แสดงข้อมูลนักศึกษา (Override)
            /// </summary>
            public override string DisplayInfo()
            {
                return base.DisplayInfo() + ", สาขา: " + Major + ", รหัสนักศึกษา: " + StudentId;
            }

            /// <summary>
            /// เพิ่มผลการอบรม (Implement IParticipant)
            /// </summary>
            public void AddTrainingResult(TrainingResult result)
            {
                TrainingResults.Add(result);
            }

            /// <summary>
            /// รับจำนวนการอบรม (Implement IParticipant)
            /// </summary>
            public int GetTrainingCount()
            {
                return TrainingResults.Count;
            }

            /// <summary>
            /// ตรวจสอบว่าผ่านการอบรมทั้งหมดหรือไม่ (Implement IParticipant)
            /// </summary>
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
