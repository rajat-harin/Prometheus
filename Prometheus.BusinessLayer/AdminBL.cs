using Prometheus.DataAccessLayer.Repositories;
using Prometheus.Entities;
using Prometheus.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prometheus.BusinessLayer
{
    public class AdminBL
    {
        public bool RegisterStudent(Student student,string Password, string SecurityQuestion, string SecurityAnswer)
        {
            try
            {
                if (student != null)
                {
                    if (ValidateStudent(student))
                        {
                            UserRepo userRepo = new UserRepo();
                            StudentRepo studentRepo = new StudentRepo();
                            User user = new User { UserID = student.UserID, Password = Password, Role = "student", SecurityQuestion = SecurityQuestion, SecurityAnswer = SecurityAnswer};

                            if (userRepo.InsertUser(user))
                            {
                                if (studentRepo.InsertStudent(student))
                                {
                                    return true;
                                }
                                else
                                {
                                    userRepo.DeleteUser(user);
                                    throw new PrometheusException("Student registration failed");
                                }
                            }
                            else
                            {
                                throw new PrometheusException("Student registration failed");
                            }
                        }
                    }
            }
            catch (Exception)
            {
                throw;
            }
            return false;

        }

        public bool RegisterTeacher(Teacher teacher, string Password, string SecurityQuestion, string SecurityAnswer)
        {
            try
            {
                if (teacher != null)
                {
                    if (ValidateTeacher(teacher))
                    {
                        UserRepo userRepo = new UserRepo();
                        TeacherRepo teacherRepo = new TeacherRepo();
                        User user = new User { UserID = teacher.UserID, Password = Password, Role = "teacher" , SecurityQuestion = SecurityQuestion, SecurityAnswer = SecurityAnswer};
                        if (teacher.IsAdmin)
                        {
                            user.Role = "admin";
                        }
                        if (userRepo.InsertUser(user))
                        {
                            if (teacherRepo.InsertTeacher(teacher))
                            {
                                return true;
                            }
                            else
                            {
                                userRepo.DeleteUser(user);
                                throw new PrometheusException("Teacher registration failed");
                            }
                        }
                    }

                    else
                    {
                        throw new PrometheusException("Teacher registration failed");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return false;

        }

        public string Login(User guest)
        {
            try
            {
                UserRepo userRepo = new UserRepo();
                User user = new User();
                user = userRepo.GetUserByID(guest.UserID);
                if (user != null)
                {
                    if (guest.Password.Equals(user.Password))
                    {
                        return user.Role;
                    }
                    else
                    {
                        throw new PrometheusException("Incorrect password!");
                    }
                }
                else
                {
                    throw new PrometheusException("User does not exists!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Student> GetStudents()
        {
            List<Student> studentList;
            try
            {
                User user = new User();
                studentList = new StudentRepo().GetStudents();
                if (studentList.Any())
                {
                    return studentList;
                }

                else
                {
                    throw new PrometheusException("No Students Found!");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Student> GetStudentByUserID(string userID)
        {

            try
            {
                StudentRepo studentRepo = new StudentRepo();
                List<Student> students = studentRepo.GetStudents();
                User user = new User();
                var result = students.Where(item => item.UserID == userID).ToList();
                if (result.Any())
                {
                    return result;
                }
                else
                {
                    throw new PrometheusException("No Student Found!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Teacher> GetTeachers()
        {
            List<Teacher> teacherList;
            try
            {
                teacherList = new TeacherRepo().GetTeachers();
                User user = new User();
                if (teacherList.Any())
                {
                    return teacherList;
                }
                else
                {
                    throw new PrometheusException("No Teachers Found!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Teacher> GetTeachersByUserID(string userID)
        {
            try
            {
                TeacherRepo teacherRepo = new TeacherRepo();
                List<Teacher> teachers = teacherRepo.GetTeachers();

                var result = teachers.Where(item => item.UserID == userID).ToList();
                if (result.Any())
                {
                    return result;
                }
                else
                {
                    throw new PrometheusException("No Teacher Found!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ForgotPassword(User guest)
        {
            try
            {
                UserRepo userRepo = new UserRepo();
                User user = new User();
                user = userRepo.GetUser(guest.UserID);
                if (user != null)
                {
                    if (user.SecurityQuestion.Equals(guest.SecurityQuestion) && user.SecurityAnswer.Equals(guest.SecurityAnswer))
                    {
                        return true;
                    }
                    
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public bool ChangePassword(User user)
        {
            try
            {
               UserRepo userRepo = new UserRepo();
                    User guest = new User { UserID = user.UserID, Password = user.Password };

                    if (user != null)
                    {
                        if (userRepo.UpdateUser(user))
                        {
                            return true;
                        }
                    }
                    else
                    {
                        throw new PrometheusException("User does not exists!");
                    }
                
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public bool ValidateStudent(Student student)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool validStudent = true;
            if (student.UserID == string.Empty)
            {
                validStudent = false;
                stringBuilder.Append(Environment.NewLine + "Cannot Pass Empty UserID");

            }
            if (student.FName == string.Empty)
            {
                validStudent = false;
                stringBuilder.Append(Environment.NewLine + "Cannot Pass Empty FName");

            }
            if (student.LName == string.Empty)
            {
                validStudent = false;
                stringBuilder.Append(Environment.NewLine + "Cannot Pass Empty LName");
            }
            if (student.DOB == DateTime.Now)
            {
                validStudent = false;
                stringBuilder.Append(Environment.NewLine + "Cannot Pass Empty DOB");
            }
            if (student.City == string.Empty)
            {
                validStudent = false;
                stringBuilder.Append(Environment.NewLine + "Cannot Pass Empty City");
            }
            if (student.Address == string.Empty)
            {
                validStudent = false;
                stringBuilder.Append(Environment.NewLine + "Cannot Pass Empty Address");
            }
            if (student.MobileNo == string.Empty)
            {
                validStudent = false;
                stringBuilder.Append(Environment.NewLine + "Cannot Pass Empty MobileNo");
            }
            if (validStudent == false)
                throw new Exception(stringBuilder.ToString());//when  it is not false
            return validStudent;
        }

        public bool ValidateTeacher(Teacher teacher)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool validTeacher = true;
            if (teacher.UserID == string.Empty)
            {
                validTeacher = false;
                stringBuilder.Append(Environment.NewLine + "Cannot Pass Empty UserID");

            }
            if (teacher.FName == string.Empty)
            {
                validTeacher = false;
                stringBuilder.Append(Environment.NewLine + "Cannot Pass Empty FName");

            }
            if (teacher.LName == string.Empty)
            {
                validTeacher = false;
                stringBuilder.Append(Environment.NewLine + "Cannot Pass Empty LName");
            }
            if (teacher.DOB == DateTime.Now)
            {
                validTeacher = false;
                stringBuilder.Append(Environment.NewLine + "Cannot Pass Empty DOB");
            }
            if (teacher.City == string.Empty)
            {
                validTeacher = false;
                stringBuilder.Append(Environment.NewLine + "Cannot Pass Empty City");
            }
            if (teacher.Address == string.Empty)
            {
                validTeacher = false;
                stringBuilder.Append(Environment.NewLine + "Cannot Pass Empty Address");
            }
            if (teacher.MobileNo == string.Empty)
            {
                validTeacher = false;
                stringBuilder.Append(Environment.NewLine + "Cannot Pass Empty MobileNo");
            }
            if (validTeacher == false)
                throw new Exception(stringBuilder.ToString());//when  it is not false
            return validTeacher;
        }

        public bool ValidateUser(User user)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool validTeacher = true;
            if (user.UserID == string.Empty)
            {
                validTeacher = false;
                stringBuilder.Append(Environment.NewLine + "Cannot Pass Empty UserID");

            }
            if (user.Password == string.Empty)
            {
                validTeacher = false;
                stringBuilder.Append(Environment.NewLine + "Not a Valid Password");

            }
            if (user.Role == string.Empty)
            {
                validTeacher = false;
                stringBuilder.Append(Environment.NewLine + "Cannot proceed without role");
            }
            if (user.SecurityQuestion == string.Empty)
            {
                validTeacher = false;
                stringBuilder.Append(Environment.NewLine + "Cannot proceed without SecurityQuestion");
            }
            if (user.SecurityAnswer == string.Empty)
            {
                validTeacher = false;
                stringBuilder.Append(Environment.NewLine + "Cannot proceed without SecurityAnswer");
            }
            if (validTeacher == false)
                throw new Exception(stringBuilder.ToString());//when  it is not false
            return validTeacher;
        }
    }
}

