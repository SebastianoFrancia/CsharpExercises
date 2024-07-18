using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class School
    {
        private string _name;
        private Plexus[] _plexusList;

        public School(string name, int plexusNum)
        {
            _name = name;
            if(plexusNum<0) throw new ArgumentException("the numbero of plexus si not corect");
            _plexusList = new Plexus[plexusNum];
        }

        public void AssignsClassToPlexus(Class newClass)
        {
            if (newClass is not Class || newClass == null) throw new ArgumentException("the new class isn't a class or is null");
            

            for (int i = 0; i < _plexusList.Length; i++)
                {
                    Console.WriteLine(_plexusList[i].ClassList.Length);
                    
                    if (_plexusList[i].ClassList.Length == 0)
                    {
                        _plexusList[i].AddClass(newClass);
                    }
                    else
                    {
                        if(_plexusList[i].ClassList.Length < _plexusList[i].Classrooms)
                        {
                            for (int k = 0; k < _plexusList[i].ClassList.Length; k++)
                            {
                                if(_plexusList[i].ClassList[k].Section == newClass.Section && 
                                _plexusList[i].ClassList[k].Year == newClass.Year)
                                {
                                    throw new ArgumentException("the Class alrady exist");
                                }


                                
                                if (_plexusList[i].ClassList[k].Year == newClass.Year)
                                {    
                                    _plexusList[i].AddClass(newClass);
                                }/*
                                else
                                {
                                    if (_plexusList[i].ClassList[k].Year < newClass.Year )
                                    {
                                        // se l'anno è maggiore


                                    }else
                                    {

                                    }  
                                }*/
                            }

                        }else
                        {
                            // non ho spazio nel plesso i
                            break;
                        }
                        
                    }
                }    
            
        }
            
                        

        

        public int CalculateHowManyStudentsinPlexusX(int plexusX)
        {
            if(plexusX >= _plexusList.Length) throw new ArgumentException("there is no plexus inserted");
            int students = 0;
            for(int i=0; i<_plexusList[plexusX].ClassList.Length ;i++)
            {
                students += _plexusList[plexusX].ClassList[i].NumStudents;
            }
            return students;
        }
        public int CalculateTotalNumClassrooms()
        {
            int clasrooms = 0;
            for(int i=0; i<_plexusList.Length;i++)
            {
                clasrooms += _plexusList[i].Classrooms;
            }
            return clasrooms;
        }

        public int TotalStudents()
        {
            int totalStudents = 0;
            for(int i=0; i<_plexusList.Length;i++)
            {
                for(int k=0; k<_plexusList[i].ClassList.Length; k++)
                {
                    totalStudents += _plexusList[i].ClassList[k].NumStudents;
                }
            }
            return totalStudents;
        }

        public int TotalStudentsInCourseX(char courseX)
        {
            int totalStudents = 0;
            for(int i=0; i<_plexusList.Length;i++)
            {
                for(int k=0; k<_plexusList[i].ClassList.Length; k++)
                {
                    if(_plexusList[i].ClassList[k].Section == courseX)
                    {
                        totalStudents += _plexusList[i].ClassList[k].NumStudents;
                    }
                }
            }
            return totalStudents;
        }

        public int TotalStudentsInYearX(char yearX)
        {
            int totalStudents = 0;
            for(int i=0; i<_plexusList.Length;i++)
            {
                for(int k=0; k<_plexusList[i].ClassList.Length; k++)
                {
                    if(_plexusList[i].ClassList[k].Year == yearX)
                    {
                        totalStudents += _plexusList[i].ClassList[k].NumStudents;
                    }
                }
            }
            return totalStudents;
        }
    }
}

