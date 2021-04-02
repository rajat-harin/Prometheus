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
        public bool RegisterStudent(Student student, string Password)
        {
            try
            {
                if (student != null)
                {
                    UserRepo userRepo = new UserRepo();
                    StudentRepo studentRepo = new StudentRepo();
                    User user = new User { UserID = student.UserID, Password = Password, Role = "student" };

                    if (userRepo.InsertUser(user))
                    {
                        if (studentRepo.InsertStudent(student))
                        {
                            return true;
                        }
                        else
                        {
                            userRepo.DeleteUser(user);
                            throw new PrometheusException("user registration failed");
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

        public bool RegisterTeacher(Teacher teacher, string Password)
        {
            try
            {
                if (teacher != null)
                {
                    UserRepo userRepo = new UserRepo();
                    TeacherRepo teacherRepo = new TeacherRepo();
                    User user = new User { UserID = teacher.UserID, Password = Password, Role = "teacher" };
                    if (teacher.IsAdmin.Equals("admin"))
                    {
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

        public string Login(User guest)
        {
            
            try
            {
                UserRepo userRepo = new UserRepo();
                User user = new User();
                user = userRepo.GetUserByID(user.UserID);
                if (user!=null)
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
                if (user.Role.Equals("student"))
                {
                    if (studentList.Any())
                    {
                        return studentList;
                    }
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
            return studentList;
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
                User user = new User();
                if (user.Role.Equals("teacher"))
                {
                    if (teacherList.Any())
                    {
                        return teacherList;
                    }
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
            return teacherList;
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

        public string ForgotPassword(User user)
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
                        return user.UserID;
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

        public bool ChangePassword(User user, string UserId, string Password)
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
    }
}
