using Neo;
using Neo.Network;
using Neo.SmartContract.Framework;

namespace iDent.API.SmartContracts
{
    public class NeoContract : SmartContract
    {
        private static readonly Map<string, Student> students = new();

        public static void ddStudent(string id, string name, int age)
        {
            var student = new Student { Name = name, Age = age };

            students.Put(id, student);
        }

        public static Student getStudent(string id)
        {
            return students.Get(id);
        }

        public class Student
        {
            public string Name;
            public int Age;
        }
    }
}