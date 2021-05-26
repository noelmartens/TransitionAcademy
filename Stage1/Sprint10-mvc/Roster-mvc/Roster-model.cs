using System;
using System.Collections.Generic;
using System.Text;

namespace Roster_mvc
{
    class Roster_model
    {
        Instructor ins = new Instructor();
        List<Student> myClass = new List<Student>();

        public void AddInstuctor(string pfirstName, string plastName, string pemailAddr)
        {
            ins.FirstName = pfirstName;
            ins.LastName = plastName;
            ins.EmailAddr = pemailAddr;
        }

        public void AddStudent(string pfirstName, string plastName, string pclassRank)
        {
            Student stu = new Student(pfirstName, plastName, pclassRank);
            myClass.Add(stu);
        }


        public Instructor getInstuctor()
        {
            return ins;
        }


        public List<Student> GetClassList()
        {
            return myClass;
        }

    }
}
