using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_and_abstract
{
    /*
 * ไฟล์: Training.cs
 * Class สำหรับการอบรม
 */

    using System;
    using System.Collections.Generic;

    namespace TrainingRegistrationSystem
    {
        /// <summary>
        /// Class สำหรับการอบรม
        /// </summary>
        public class Training
        {
            // ==================== Properties ====================

            /// <summary>
            /// รหัสการอบรม
            /// </summary>
            public string TrainingId { get; set; }

            /// <summary>
            /// ชื่อหลักสูตร
            /// </summary>
            public string TrainingName { get; set; }

            /// <summary>
            /// รายละเอียด
            /// </summary>
            public string Description { get; set; }

            /// <summary>
            /// วันที่จัดอบรม
            /// </summary>
            public DateTime TrainingDate { get; set; }

            /// <summary>
            /// สถานที่
            /// </summary>
            public string Location { get; set; }

            /// <summary>
            /// วิทยากร
            /// </summary>
            public Trainer Trainer { get; set; }

            /// <summary>
            /// รายชื่อผู้เข้าร่วม
            /// </summary>
            public List<Person> Participants { get; set; }

            /// <summary>
            /// สถานะ
            /// </summary>
            public string Status { get; set; }

            /// <summary>
            /// จำนวนที่นั่ง
            /// </summary>
            public int MaxCapacity { get; set; }

            // ==================== Constructors ====================

            public Training()
            {
                TrainingId = Guid.NewGuid().ToString().Substring(0, 8);
                TrainingName = "";
                Description = "";
                TrainingDate = DateTime.Now;
                Location = "";
                Trainer = null;
                Participants = new List<Person>();
                Status = "เปิดรับสมัคร";
                MaxCapacity = 50;
            }

            public Training(string trainingName, string description, DateTime trainingDate,
                            string location, Trainer trainer, int maxCapacity = 50) : this()
            {
                TrainingName = trainingName;
                Description = description;
                TrainingDate = trainingDate;
                Location = location;
                Trainer = trainer;
                MaxCapacity = maxCapacity;
            }

            // ==================== Methods ====================

            /// <summary>
            /// เพิ่มผู้เข้าร่วม
            /// </summary>
            public bool AddParticipant(Person person)
            {
                if (Participants.Count >= MaxCapacity)
                {
                    Console.WriteLine("เต็มแล้ว!");
                    return false;
                }

                if (!Participants.Contains(person))
                {
                    Participants.Add(person);
                    return true;
                }
                return false;
            }

            /// <summary>
            /// ลบผู้เข้าร่วม
            /// </summary>
            public bool RemoveParticipant(Person person)
            {
                return Participants.Remove(person);
            }

            /// <summary>
            /// รับจำนวนผู้เข้าร่วม
            /// </summary>
            public int GetParticipantCount()
            {
                return Participants.Count;
            }

            /// <summary>
            /// ตรวจสอบว่าว่างหรือไม่
            /// </summary>
            public bool IsAvailable()
            {
                return Participants.Count < MaxCapacity;
            }

            /// <summary>
            /// ตั้งค่าวิทยากร
            /// </summary>
            public void SetTrainer(Trainer trainer)
            {
                Trainer = trainer;
            }

            /// <summary>
            /// อัปเดตสถานะ
            /// </summary>
            public void UpdateStatus(string status)
            {
                Status = status;
            }

            /// <summary>
            /// แสดงข้อมูลการอบรม
            /// </summary>
            public string GetTrainingInfo()
            {
                string trainerInfo = Trainer != null ? Trainer.GetFullName() : "ยังไม่กำหนด";
                return "หลักสูตร: " + TrainingName + ", วันที่: " + TrainingDate.ToString("dd/MM/yyyy") +
                       ", สถานที่: " + Location + ", วิทยากร: " + trainerInfo +
                       ", ผู้เข้าร่วม: " + GetParticipantCount() + "/" + MaxCapacity;
            }

            /// <summary>
            /// แสดงข้อมูลการอบรมแบบละเอียด
            /// </summary>
            public void DisplayTrainingDetails()
            {
                Console.WriteLine("\n============================================================");
                Console.WriteLine("ข้อมูลการอบรม");
                Console.WriteLine("============================================================");
                Console.WriteLine("รหัก: " + TrainingId);
                Console.WriteLine("หลักสูตร: " + TrainingName);
                Console.WriteLine("รายละเอียด: " + Description);
                Console.WriteLine("วันที่: " + TrainingDate.ToString("dd/MM/yyyy HH:mm"));
                Console.WriteLine("สถานที่: " + Location);
                Console.WriteLine("วิทยากร: " + (Trainer != null ? Trainer.GetFullName() : "ยังไม่กำหนด"));
                Console.WriteLine("จำนวนที่นั่ง: " + GetParticipantCount() + "/" + MaxCapacity);
                Console.WriteLine("สถานะ: " + Status);
                Console.WriteLine("============================================================");

                if (Participants.Count > 0)
                {
                    Console.WriteLine("รายชื่อผู้เข้าร่วม:");
                    for (int i = 0; i < Participants.Count; i++)
                    {
                        Console.WriteLine("  " + (i + 1) + ". " + Participants[i].GetFullName());
                    }
                }
                Console.WriteLine();
            }

            public override string ToString()
            {
                return GetTrainingInfo();
            }
        }
    }
}
