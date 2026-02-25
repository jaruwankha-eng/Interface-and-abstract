using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_and_abstract
{

    namespace TrainingRegistrationSystem
    {
        /// <summary>
        /// Class หลักสำหรับระบบรับสมัครฝึกอบรม
        /// </summary>
        public class TrainingSystem
        {
            // ==================== Properties ====================

            private List<Student> students;
            private List<Teacher> teachers;
            private List<GeneralPublic> generalPublic;
            private List<Trainer> trainers;
            private List<Person> registrations;
            private List<Training> trainings;
            private string systemName;

            // ==================== Constructors ====================

            public TrainingSystem()
            {
                students = new List<Student>();
                teachers = new List<Teacher>();
                generalPublic = new List<GeneralPublic>();
                trainers = new List<Trainer>();
                registrations = new List<Person>();
                trainings = new List<Training>();
                systemName = "ระบบรับสมัครฝึกอบรม";
            }

            // ==================== ฟังก์ชันลงทะเบียน ====================

            /// <summary>
            /// ลงทะเบียนนักศึกษา
            /// </summary>
            public Student RegisterStudent(string firstName, string lastName, string phone,
                                           string email, string major, string studentId)
            {
                Student student = new Student(firstName, lastName, phone, email, major, studentId);
                students.Add(student);
                registrations.Add(student);
                return student;
            }

            /// <summary>
            /// ลงทะเบียนอาจารย์
            /// </summary>
            public Teacher RegisterTeacher(string firstName, string lastName, string phone,
                                           string email, string major, string academicPosition,
                                           bool canBeTrainer = false)
            {
                Teacher teacher = new Teacher(firstName, lastName, phone, email, major, academicPosition, canBeTrainer);
                teachers.Add(teacher);
                registrations.Add(teacher);
                return teacher;
            }

            /// <summary>
            /// ลงทะเบียนบุคคลทั่วไป
            /// </summary>
            public GeneralPublic RegisterGeneralPublic(string firstName, string lastName, string phone,
                                                        string email, string workplace, string position,
                                                        bool canBeTrainer = false)
            {
                GeneralPublic person = new GeneralPublic(firstName, lastName, phone, email, workplace, position, canBeTrainer);
                generalPublic.Add(person);
                registrations.Add(person);
                return person;
            }

            /// <summary>
            /// ลงทะเบียนวิทยากร
            /// </summary>
            public Trainer RegisterTrainer(string firstName, string lastName, string phone,
                                           string email, string expertise, string institution = "")
            {
                Trainer trainer = new Trainer(firstName, lastName, phone, email, expertise, institution);
                trainers.Add(trainer);
                return trainer;
            }

            // ==================== ฟังก์ชันแปลงเป็นวิทยากร ====================

            /// <summary>
            /// แปลงอาจารย์เป็นวิทยากร
            /// </summary>
            public Trainer ConvertTeacherToTrainer(Teacher teacher)
            {
                if (teacher == null)
                    return null;

                teacher.EnableTrainer();
                string expertise = "วิทยากรจากสาขา " + teacher.Major;

                Trainer newTrainer = new Trainer(teacher.FirstName, teacher.LastName,
                                                 teacher.Phone, teacher.Email,
                                                 expertise, teacher.Major);
                trainers.Add(newTrainer);
                return newTrainer;
            }

            /// <summary>
            /// แปลงบุคคลทั่วไปเป็นวิทยากร
            /// </summary>
            public Trainer ConvertGeneralPublicToTrainer(GeneralPublic person)
            {
                if (person == null)
                    return null;

                person.EnableTrainer();
                string expertise = "วิทยากรจาก " + person.Workplace;

                Trainer newTrainer = new Trainer(person.FirstName, person.LastName,
                                                 person.Phone, person.Email,
                                                 expertise, person.Workplace);
                trainers.Add(newTrainer);
                return newTrainer;
            }

            // ==================== ฟังก์ชันอนุมัติผลการอบรม ====================

            /// <summary>
            /// อนุมัติผลการอบรม
            /// </summary>
            public bool ApproveTrainingResult(Trainer trainer, Person participant,
                                              string trainingName, string status, double score = 0)
            {
                if (trainer == null || participant == null)
                    return false;

                // สร้างผลการอบรม
                TrainingResult result = new TrainingResult(trainingName, participant, trainer, status, score);

                // เพิ่มให้ผู้เข้าร่วม
                if (participant is Student)
                {
                    ((Student)participant).AddTrainingResult(result);
                }
                else if (participant is Teacher)
                {
                    ((Teacher)participant).AddTrainingResult(result);
                }
                else if (participant is GeneralPublic)
                {
                    ((GeneralPublic)participant).AddTrainingResult(result);
                }

                // อนุมัติให้วิทยากร
                trainer.ApproveTrainingResult(result);

                return true;
            }

            // ==================== ฟังก์ชันแสดงข้อมูล ====================

            /// <summary>
            /// แสดงรายชื่อผู้เข้าอบรมทั้งหมด
            /// </summary>
            public void DisplayAllParticipants()
            {
                Console.WriteLine("\n============================================================");
                Console.WriteLine("รายชื่อผู้เข้าอบรมทั้งหมด");
                Console.WriteLine("============================================================");

                if (registrations.Count == 0)
                {
                    Console.WriteLine("ไม่มีผู้ลงทะเบียนเข้าอบรม");
                    return;
                }

                Console.WriteLine("\nจำนวนผู้ลงทะเบียนทั้งหมด: " + registrations.Count + " คน\n");

                // แสดงนักศึกษา
                if (students.Count > 0)
                {
                    Console.WriteLine("📚 นักศึกษา (" + students.Count + " คน)");
                    Console.WriteLine("------------------------------------------------------");
                    for (int i = 0; i < students.Count; i++)
                    {
                        Console.WriteLine((i + 1) + ". " + students[i].DisplayInfo());
                    }
                    Console.WriteLine();
                }

                // แสดงอาจารย์
                if (teachers.Count > 0)
                {
                    Console.WriteLine("👨‍🏫 อาจารย์ (" + teachers.Count + " คน)");
                    Console.WriteLine("------------------------------------------------------");
                    for (int i = 0; i < teachers.Count; i++)
                    {
                        Console.WriteLine((i + 1) + ". " + teachers[i].DisplayInfo());
                    }
                    Console.WriteLine();
                }

                // แสดงบุคคลทั่วไป
                if (generalPublic.Count > 0)
                {
                    Console.WriteLine("👥 บุคคลทั่วไป (" + generalPublic.Count + " คน)");
                    Console.WriteLine("------------------------------------------------------");
                    for (int i = 0; i < generalPublic.Count; i++)
                    {
                        Console.WriteLine((i + 1) + ". " + generalPublic[i].DisplayInfo());
                    }
                    Console.WriteLine();
                }
            }

            /// <summary>
            /// แสดงรายชื่อวิทยากรทั้งหมด
            /// </summary>
            public void DisplayAllTrainers()
            {
                Console.WriteLine("\n============================================================");
                Console.WriteLine("รายชื่อวิทยากรทั้งหมด");
                Console.WriteLine("============================================================");

                if (trainers.Count == 0)
                {
                    Console.WriteLine("ไม่มีวิทยากรในระบบ");
                    return;
                }

                Console.WriteLine("\nจำนวนวิทยากรทั้งหมด: " + trainers.Count + " คน\n");

                for (int i = 0; i < trainers.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + trainers[i].DisplayInfo());
                    if (trainers[i].ApprovedTrainings.Count > 0)
                    {
                        trainers[i].PrintApprovedList();
                    }
                }
                Console.WriteLine();
            }

            /// <summary>
            /// แสดงสถานะระบบ
            /// </summary>
            public void GetSystemStatus()
            {
                Console.WriteLine("\n============================================================");
                Console.WriteLine("สถานะระบบ");
                Console.WriteLine("============================================================");
                Console.WriteLine("นักศึกษา: " + students.Count + " คน");
                Console.WriteLine("อาจารย์: " + teachers.Count + " คน");
                Console.WriteLine("บุคคลทั่วไป: " + generalPublic.Count + " คน");
                Console.WriteLine("วิทยากร: " + trainers.Count + " คน");
                Console.WriteLine("ผู้เข้าอบรมทั้งหมด: " + registrations.Count + " คน");
                Console.WriteLine("จำนวนหลักสูตร: " + trainings.Count + " หลักสูตร");
                Console.WriteLine("============================================================");
            }

            // ==================== Getter Functions ====================

            public List<Student> GetStudents() { return students; }
            public List<Teacher> GetTeachers() { return teachers; }
            public List<GeneralPublic> GetGeneralPublic() { return generalPublic; }
            public List<Trainer> GetTrainers() { return trainers; }
            public List<Person> GetAllRegistrations() { return registrations; }
            public List<Training> GetTrainings() { return trainings; }

            public int GetTotalParticipants() { return registrations.Count; }
            public int GetTotalTrainers() { return trainers.Count; }
            public int GetStudentCount() { return students.Count; }
            public int GetTeacherCount() { return teachers.Count; }
            public int GetGeneralPublicCount() { return generalPublic.Count; }

            public override string ToString()
            {
                return "ระบบรับสมัครฝึกอบรม: ผู้เข้าอบรม " + GetTotalParticipants() +
                       " คน, วิทยากร " + GetTotalTrainers() + " คน";
            }
        }
    }
}
