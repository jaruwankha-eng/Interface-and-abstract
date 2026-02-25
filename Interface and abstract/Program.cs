using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_and_abstract
{
    using System;
    using System.Collections.Generic;

    namespace TrainingRegistrationSystem
    {
        class Program
        {
            static void Main(string[] args)
            {
                // เปลี่ยนจาก TrainingRegistrationSystem เป็น TrainingSystem
                TrainingSystem system = new TrainingSystem();
                int choice;

                do
                {
                    ShowMenu();
                    Console.Write("กรุณาเลือกเมนู: ");
                    choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            RegisterStudent(system);
                            break;
                        case 2:
                            RegisterTeacher(system);
                            break;
                        case 3:
                            RegisterGeneralPublic(system);
                            break;
                        case 4:
                            RegisterTrainer(system);
                            break;
                        case 5:
                            ConvertToTrainer(system);
                            break;
                        case 6:
                            ApproveTrainingResult(system);
                            break;
                        case 7:
                            system.DisplayAllParticipants();
                            break;
                        case 8:
                            system.DisplayAllTrainers();
                            break;
                        case 9:
                            system.GetSystemStatus();
                            break;
                        case 0:
                            Console.WriteLine("ขอบคุณที่ใช้บริการ!");
                            break;
                        default:
                            Console.WriteLine("กรุณาเลือกเมนูใหม่!");
                            break;
                    }

                    Console.WriteLine();

                } while (choice != 0);
            }

            // ==================== แสดงเมนู ====================

            static void ShowMenu()
            {
                Console.WriteLine("\n============================================================");
                Console.WriteLine("           ระบบรับสมัครฝึกอบรม");
                Console.WriteLine("============================================================");
                Console.WriteLine("1. ลงทะเบียนนักศึกษา");
                Console.WriteLine("2. ลงทะเบียนอาจารย์");
                Console.WriteLine("3. ลงทะเบียนบุคคลทั่วไป");
                Console.WriteLine("4. ลงทะเบียนวิทยากร");
                Console.WriteLine("5. แปลงเป็นวิทยากร (อาจารย์/บุคคลทั่วไป)");
                Console.WriteLine("6. อนุมัติผลการอบรม");
                Console.WriteLine("7. แสดงรายชื่อผู้เข้าอบรม");
                Console.WriteLine("8. แสดงรายชื่อวิทยากร");
                Console.WriteLine("9. แสดงสถานะระบบ");
                Console.WriteLine("0. ออกจากโปรแกรม");
                Console.WriteLine("============================================================");
            }

            // ==================== ฟังก์ชันลงทะเบียน ====================

            static void RegisterStudent(TrainingSystem system)
            {
                Console.WriteLine("\n--- ลงทะเบียนนักศึกษา ---");

                Console.Write("ชื่อ: ");
                string firstName = Console.ReadLine();

                Console.Write("นามสกุล: ");
                string lastName = Console.ReadLine();

                Console.Write("เบอร์โทรศัพท์: ");
                string phone = Console.ReadLine();

                Console.Write("อีเมล: ");
                string email = Console.ReadLine();

                Console.Write("สาขา: ");
                string major = Console.ReadLine();

                Console.Write("รหัสนักศึกษา: ");
                string studentId = Console.ReadLine();

                system.RegisterStudent(firstName, lastName, phone, email, major, studentId);
                Console.WriteLine("✅ ลงทะเบียนนักศึกษาเรียบร้อย!");
            }

            static void RegisterTeacher(TrainingSystem system)
            {
                Console.WriteLine("\n--- ลงทะเบียนอาจารย์ ---");

                Console.Write("ชื่อ: ");
                string firstName = Console.ReadLine();

                Console.Write("นามสกุล: ");
                string lastName = Console.ReadLine();

                Console.Write("เบอร์โทรศัพท์: ");
                string phone = Console.ReadLine();

                Console.Write("อีเมล: ");
                string email = Console.ReadLine();

                Console.Write("สาขา: ");
                string major = Console.ReadLine();

                Console.WriteLine("ตำแหน่งทางวิชาการ:");
                Console.WriteLine("  1. อาจารย์");
                Console.WriteLine("  2. ผศ.");
                Console.WriteLine("  3. รศ.");
                Console.WriteLine("  4. ศ.");
                Console.Write("เลือกตำแหน่ง (1-4): ");
                int positionChoice = int.Parse(Console.ReadLine());

                // ใช้ Switch Statement
                string academicPosition;
                switch (positionChoice)
                {
                    case 1:
                        academicPosition = "อาจารย์";
                        break;
                    case 2:
                        academicPosition = "ผศ.";
                        break;
                    case 3:
                        academicPosition = "รศ.";
                        break;
                    case 4:
                        academicPosition = "ศ.";
                        break;
                    default:
                        academicPosition = "อาจารย์";
                        break;
                }

                Console.Write("สามารถเป็นวิทยากรได้หรือไม่ (y/n): ");
                string canBeTrainerInput = Console.ReadLine().ToLower();
                bool canBeTrainer = (canBeTrainerInput == "y" || canBeTrainerInput == "yes");

                system.RegisterTeacher(firstName, lastName, phone, email, major, academicPosition, canBeTrainer);
                Console.WriteLine("✅ ลงทะเบียนอาจารย์เรียบร้อย!");
            }

            static void RegisterGeneralPublic(TrainingSystem system)
            {
                Console.WriteLine("\n--- ลงทะเบียนบุคคลทั่วไป ---");

                Console.Write("ชื่อ: ");
                string firstName = Console.ReadLine();

                Console.Write("นามสกุล: ");
                string lastName = Console.ReadLine();

                Console.Write("เบอร์โทรศัพท์: ");
                string phone = Console.ReadLine();

                Console.Write("อีเมล: ");
                string email = Console.ReadLine();

                Console.Write("สถานที่ทำงาน: ");
                string workplace = Console.ReadLine();

                Console.Write("ตำแหน่ง: ");
                string position = Console.ReadLine();

                Console.Write("สามารถเป็นวิทยากรได้หรือไม่ (y/n): ");
                string canBeTrainerInput = Console.ReadLine().ToLower();
                bool canBeTrainer = (canBeTrainerInput == "y" || canBeTrainerInput == "yes");

                system.RegisterGeneralPublic(firstName, lastName, phone, email, workplace, position, canBeTrainer);
                Console.WriteLine("✅ ลงทะเบียนบุคคลทั่วไปเรียบร้อย!");
            }

            static void RegisterTrainer(TrainingSystem system)
            {
                Console.WriteLine("\n--- ลงทะเบียนวิทยากร ---");

                Console.Write("ชื่อ: ");
                string firstName = Console.ReadLine();

                Console.Write("นามสกุล: ");
                string lastName = Console.ReadLine();

                Console.Write("เบอร์โทรศัพท์: ");
                string phone = Console.ReadLine();

                Console.Write("อีเมล: ");
                string email = Console.ReadLine();

                Console.Write("ความเชี่ยวชาญ: ");
                string expertise = Console.ReadLine();

                Console.Write("สังกัด (ถ้ามี): ");
                string institution = Console.ReadLine();

                if (institution == "")
                    institution = "ทรัพย์";

                system.RegisterTrainer(firstName, lastName, phone, email, expertise, institution);
                Console.WriteLine("✅ ลงทะเบียนวิทยากรเรียบร้อย!");
            }

            // ==================== ฟังก์ชันแปลงเป็นวิทยากร ====================

            static void ConvertToTrainer(TrainingSystem system)
            {
                Console.WriteLine("\n--- แปลงเป็นวิทยากร ---");
                Console.WriteLine("1. แปลงอาจารย์เป็นวิทยากร");
                Console.WriteLine("2. แปลงบุคคลทั่วไปเป็นวิทยากร");
                Console.Write("เลือกประเภท (1-2): ");
                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    ConvertTeacherToTrainer(system);
                }
                else if (choice == 2)
                {
                    ConvertGeneralPublicToTrainer(system);
                }
                else
                {
                    Console.WriteLine("กรุณาเลือกใหม่!");
                }
            }

            static void ConvertTeacherToTrainer(TrainingSystem system)
            {
                var teachers = system.GetTeachers();

                if (teachers.Count == 0)
                {
                    Console.WriteLine("ไม่มีอาจารย์ในระบบ!");
                    return;
                }

                Console.WriteLine("\nรายชื่ออาจารย์:");
                for (int i = 0; i < teachers.Count; i++)
                {
                    string status = teachers[i].CanBeTrainer ? " (เป็นวิทยากรแล้ว)" : "";
                    Console.WriteLine((i + 1) + ". " + teachers[i].GetFullName() + status);
                }

                Console.Write("เลือกอาจารย์ที่ต้องการแปลง: ");
                int index = int.Parse(Console.ReadLine()) - 1;

                if (index >= 0 && index < teachers.Count)
                {
                    if (teachers[index].CanBeTrainer)
                    {
                        Console.WriteLine("อาจารย์ท่านนี้เป็นวิทยากรอยู่แล้ว!");
                    }
                    else
                    {
                        Trainer newTrainer = system.ConvertTeacherToTrainer(teachers[index]);
                        Console.WriteLine("✅ แปลง " + teachers[index].GetFullName() + " เป็นวิทยากรเรียบร้อย!");
                    }
                }
                else
                {
                    Console.WriteLine("เลือกไม่ถูกต้อง!");
                }
            }

            static void ConvertGeneralPublicToTrainer(TrainingSystem system)
            {
                var generalPublic = system.GetGeneralPublic();

                if (generalPublic.Count == 0)
                {
                    Console.WriteLine("ไม่มีบุคคลทั่วไปในระบบ!");
                    return;
                }

                Console.WriteLine("\nรายชื่อบุคคลทั่วไป:");
                for (int i = 0; i < generalPublic.Count; i++)
                {
                    string status = generalPublic[i].CanBeTrainer ? " (เป็นวิทยากรแล้ว)" : "";
                    Console.WriteLine((i + 1) + ". " + generalPublic[i].GetFullName() + status);
                }

                Console.Write("เลือกบุคคลทั่วไปที่ต้องการแปลง: ");
                int index = int.Parse(Console.ReadLine()) - 1;

                if (index >= 0 && index < generalPublic.Count)
                {
                    if (generalPublic[index].CanBeTrainer)
                    {
                        Console.WriteLine("บุคคลท่านนี้เป็นวิทยากรอยู่แล้ว!");
                    }
                    else
                    {
                        Trainer newTrainer = system.ConvertGeneralPublicToTrainer(generalPublic[index]);
                        Console.WriteLine("✅ แปลง " + generalPublic[index].GetFullName() + " เป็นวิทยากรเรียบร้อย!");
                    }
                }
                else
                {
                    Console.WriteLine("เลือกไม่ถูกต้อง!");
                }
            }

            // ==================== ฟังก์ชันอนุมัติผลการอบรม ====================

            static void ApproveTrainingResult(TrainingSystem system)
            {
                Console.WriteLine("\n--- อนุมัติผลการอบรม ---");

                var trainers = system.GetTrainers();

                if (trainers.Count == 0)
                {
                    Console.WriteLine("ไม่มีวิทยากรในระบบ!");
                    return;
                }

                // เลือกวิทยากร
                Console.WriteLine("รายชื่อวิทยากร:");
                for (int i = 0; i < trainers.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + trainers[i].GetFullName() + " (" + trainers[i].Expertise + ")");
                }

                Console.Write("เลือกวิทยากร: ");
                int trainerIndex = int.Parse(Console.ReadLine()) - 1;

                if (trainerIndex < 0 || trainerIndex >= trainers.Count)
                {
                    Console.WriteLine("เลือกไม่ถูกต้อง!");
                    return;
                }

                Trainer selectedTrainer = trainers[trainerIndex];

                // เลือกผู้เข้ารับการอบรม
                var registrations = system.GetAllRegistrations();

                if (registrations.Count == 0)
                {
                    Console.WriteLine("ไม่มีผู้เข้าอบรมในระบบ!");
                    return;
                }

                Console.WriteLine("\nรายชื่อผู้เข้าอบรม:");
                for (int i = 0; i < registrations.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + registrations[i].GetFullName());
                }

                Console.Write("เลือกผู้เข้าอบรม: ");
                int participantIndex = int.Parse(Console.ReadLine()) - 1;

                if (participantIndex < 0 || participantIndex >= registrations.Count)
                {
                    Console.WriteLine("เลือกไม่ถูกต้อง!");
                    return;
                }

                Person selectedParticipant = registrations[participantIndex];

                // กรอกข้อมูลการอบรม
                Console.Write("ชื่อหลักสูตร: ");
                string trainingName = Console.ReadLine();

                Console.WriteLine("ผลการอบรม:");
                Console.WriteLine("  1. ผ่าน");
                Console.WriteLine("  2. ไม่ผ่าน");
                Console.Write("เลือกผล (1-2): ");
                int resultChoice = int.Parse(Console.ReadLine());

                string status = (resultChoice == 1) ? "ผ่าน" : "ไม่ผ่าน";

                double score = 0;
                if (resultChoice == 1)
                {
                    Console.Write("คะแนน: ");
                    score = double.Parse(Console.ReadLine());
                }

                bool success = system.ApproveTrainingResult(selectedTrainer, selectedParticipant, trainingName, status, score);

                if (success)
                {
                    Console.WriteLine("✅ อนุมัติผลการอบรมเรียบร้อย!");
                    Console.WriteLine("   วิทยากร: " + selectedTrainer.GetFullName());
                    Console.WriteLine("   ผู้เข้ารับการอบรม: " + selectedParticipant.GetFullName());
                    Console.WriteLine("   หลักสูตร: " + trainingName);
                    Console.WriteLine("   ผล: " + status + " (คะแนน: " + score + ")");
                }
                else
                {
                    Console.WriteLine("❌ เกิดข้อผิดพลาด!");
                }
            }
        }
    }
}


