using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_and_abstract
{
        public abstract class Person
        {
            // ==================== Properties ====================

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }

            // ==================== Constructors ====================

            public Person()
            {
                FirstName = "";
                LastName = "";
                Phone = "";
                Email = "";
            }

            public Person(string firstName, string lastName, string phone, string email)
            {
                FirstName = firstName;
                LastName = lastName;
                Phone = phone;
                Email = email;
            }

            // ==================== Methods ====================

            /// <summary>
            /// รับชื่อ-นามสกุลแบบเต็ม
            /// </summary>
            public string GetFullName()
            {
                return FirstName + " " + LastName;
            }

            /// <summary>
            /// แสดงข้อมูลพื้นฐาน (Virtual Method)
            /// </summary>
            public virtual string DisplayInfo()
            {
                return "ชื่อ: " + GetFullName() + ", โทร: " + Phone + ", อีเมล: " + Email;
            }

            /// <summary>
            /// แสดงข้อมูลแบบสั้น
            /// </summary>
            public string GetShortInfo()
            {
                return FirstName + " " + LastName;
            }

            public override string ToString()
            {
                return DisplayInfo();
            }

            /// <summary>
            /// Print ข้อมูล
            /// </summary>
            public virtual void PrintInfo()
            {
                Console.WriteLine(DisplayInfo());
            }
        }
    
}
