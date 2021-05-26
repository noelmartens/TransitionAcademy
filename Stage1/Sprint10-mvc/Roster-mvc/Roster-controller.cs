using System;
using System.Collections.Generic;
using System.Text;

namespace Roster_mvc
{
    class Roster_controller
    {
        string firstName;
        string lastName;
        string classRank;
        string emailAddr;
        string op;

        Boolean enterMore = true;

        public Roster_view v = new Roster_view();
        public Roster_model m = new Roster_model();

        public Roster_controller()
        {
            op = v.SendWelcome().ToUpper();
            if (op == "N")   //  quit
            {
                enterMore = false;
            }

            while (enterMore)
            {
                op = v.SendMenu();
                switch (op)
                {
                    case "1":    //  add instructor
                        firstName = v.GetInstructorFname();
                        if (String.IsNullOrEmpty(firstName))
                        {
                            v.ShowError("Instructor first name is required...try again");
                            break;
                        }
                        lastName = v.GetInstructorLname();
                        if (String.IsNullOrEmpty(lastName))
                        {
                            v.ShowError("Instructor last name is required...try again");
                            break;
                        }
                        emailAddr = v.GetInstructorEmail();
                        if (String.IsNullOrEmpty(emailAddr))
                        {
                            v.ShowError("Instructor email address is required...try again");
                            break;
                        }

                        // data is clean, create the instructor
                        m.AddInstuctor(firstName, lastName, emailAddr);
                        break;


                    case "2":    //  add students
                        firstName = v.GetStudentFname();
                        if (String.IsNullOrEmpty(firstName))
                        {
                            v.ShowError("Student first name is required.........try again");
                            break;
                        }
                        lastName = v.GetStudentLname();
                        if (String.IsNullOrEmpty(lastName))
                        {
                            v.ShowError("Student last name is required..........try again");
                            break;
                        }
                        classRank = v.GetStudentRank();
                        if (String.IsNullOrEmpty(classRank))
                        {
                            v.ShowError("Student grade level is required........try again");
                            break;
                        }
                        switch (classRank)
                        {
                            case "1":
                            case "2":
                            case "3":
                            case "4":
                                // data is clean, create the student, add person to person class list
                                m.AddStudent(firstName, lastName, classRank);
                                break;

                            default:
                                v.ShowError("Student grade level should be (1,2,3 or 4).....");
                                v.ShowError("try again");
                                break;

                        }
                        break;


                    case "3":    //  display roster
                        v.PrintClass(m.getInstuctor(), m.GetClassList());
                        break;


                    case "4":    //  quit
                    case "q":    //  quit
                        enterMore = false;
                        break;

                }

            }

        }
    }
}
