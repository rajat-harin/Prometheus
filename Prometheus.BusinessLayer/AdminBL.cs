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
        public bool RegisterStudent(Student student, string Password, User user)
        {
            try
            {
                if (student != null)
                {
                    if (ValidateUser(user))
                    {
                        if (ValidateStudent(student))
                        {
                            UserRepo userRepo = new UserRepo();
                            StudentRepo studentRepo = new StudentRepo();
                            User guest = new User { UserID = student.UserID, Password = Password, Role = "student" };

                            if (userRepo.InsertUser(guest))
                            {
                                if (studentRepo.InsertStudent(student))
                                {
                                    return true;
                                }
                                else
                                {
                                    userRepo.DeleteUser(guest);
                                    throw new PrometheusException("user registration failed");
                                }
                            }
                            else
                            {
                                throw new PrometheusException("user registration failed");
                            }
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

        public bool RegisterTeacher(User user, Teacher teacher, string Password)
        {
            try
            {
                if (teacher != null)
                {
                    if (ValidateUser(user))
                    {
                        if (ValidateTeacher(teacher))
                        {
                            UserRepo userRepo = new UserRepo();
                            TeacherRepo teacherRepo = new TeacherRepo();
                            User guest = new User { UserID = teacher.UserID, Password = Password, Role = "teacher" };
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
                                    throw new PrometheusException("user registration failed");
                                }
                            }
                        }
                    }
                    else
                    {
                        throw new PrometheusException("user registration failed");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return false;

        }

        public string Login(User user)
        {
            
            try
            {
                    UserRepo userRepo = new UserRepo();
                    User guest = new User();
                    guest = userRepo.GetUserByID(user.UserID);
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
            catch (Exception ex)
            {

                throw new PrometheusException(ex.Message);
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
                        throw new PrometheusException("No Students Found!");
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
                if (teacherList.Any())
                    {
                        return teacherList;
                    }
                
                else
                {
                    throw new PrometheusException("No Teachers Found!");
                }
            }
            catch (Exception ex)
            {

                throw new PrometheusException(ex.Message);
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
                    throw new PrometheusException("No Teachers Found!");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ForgotPassword(User user)
        {
            try
            {
                UserRepo userRepo = new UserRepo();
                User guest = new User();
                guest = userRepo.GetUserByID(user.UserID);
                if (user != null)
                {
                    if (user.UserID.Equals(guest.UserID))
                    {
                        return true;
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

        public bool ChangePassword(User user)
        {
            try
            {
               UserRepo userRepo = new UserRepo();
                User guest = new User { UserID =user.UserID, Password = user.Password};
                
                if(user != null)
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

        public bool ValidateUser(User user)
        {
            StringBuilder stringBuilder = new StringBuilder();
            bool validUser = true;
            if (user.UserID == string.Empty)
            {
                validUser = false;
                stringBuilder.Append(Environment.NewLine + "Cannot Pass Empty UserID");

            }
            if (user.Password == string.Empty)
            {
                validUser = false;
                stringBuilder.Append(Environment.NewLine + "Not a Valid Password");

            }
            if (user.Role == string.Empty)
                validUser = false;
                stringBuilder.Append(Environment.NewLine + "Not a user");
            if (validUser == false)
                throw new Exception(stringBuilder.ToString());//when  it is not false
            return validUser;
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
                stringBuilder.Append(Environment.NewLine + "Not a Valid Password");

            }
            if (student.LName == string.Empty)
            {
                validStudent = false;
                stringBuilder.Append(Environment.NewLine + "Not a user");
            }
            if (student.DOB == DateTime.Now)
            {
                validStudent = false;
                stringBuilder.Append(Environment.NewLine + "Not a user");
            }
            if (student.City == string.Empty)
            {
                validStudent = false;
                stringBuilder.Append(Environment.NewLine + "Not a user");
            }
            if (student.Address == string.Empty)
            {
                validStudent = false;
                stringBuilder.Append(Environment.NewLine + "Not a user");
            }
            if (student.MobileNo == string.Empty)
            {
                validStudent = false;
                stringBuilder.Append(Environment.NewLine + "Not a user");
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
                stringBuilder.Append(Environment.NewLine + "Not a Valid Password");

            }
            if (teacher.LName == string.Empty)
            {
                validTeacher = false;
                stringBuilder.Append(Environment.NewLine + "Not a user");
            }
            if (teacher.DOB == DateTime.Now)
            {
                validTeacher = false;
                stringBuilder.Append(Environment.NewLine + "Not a user");
            }
            if (teacher.City == string.Empty)
            {
                validTeacher = false;
                stringBuilder.Append(Environment.NewLine + "Not a user");
            }
            if (teacher.Address == string.Empty)
            {
                validTeacher = false;
                stringBuilder.Append(Environment.NewLine + "Not a user");
            }
            if (teacher.MobileNo == string.Empty)
            {
                validTeacher = false;
                stringBuilder.Append(Environment.NewLine + "Not a user");
            }
            if (validTeacher == false)
                throw new Exception(stringBuilder.ToString());//when  it is not false
            return validTeacher;
        }

    }
}

