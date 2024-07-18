using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Plexus
    {
        private string _name;
        private int _classrooms;
        private int _baths;
        private Class[] _classList;
        
        public int Classrooms
        {
            get{ return _classrooms; }
            private set
            {
                if(value <= 0) throw new ArgumentException("the number of clasrooms isn't corect");
                _classrooms = value;
            }
        }

        public Class[] ClassList
        {
            get{ return _classList; }
        }

        public int Baths
        {
            get{ return _baths; }
            private set
            {
                if(value <= 0) throw new ArgumentException("the number of clasrooms isn't corect");
                _baths = value;
            }
        }

        public Plexus(string name, int classrooms, int baths)
        {
            _name = name;
            Classrooms = classrooms;
            Baths = baths;
            _classList = new Class[0];
            /*
            if (classList.Length > classrooms) throw new ArgumentException("the number of clasroom isn't corect");
            _classList = classList;
            SortClasses();
            */
            
        }

        private void SortClasses()
        {
            Class temp;
            for (int i = 1; i<_classList.Length; i++)
            {
                for(int k = 1; k<_classList.Length; k++)
                {
                    if(_classList[k].Year < _classList[k-1].Year)
                    {
                        temp = _classList[k-1];
                        _classList[k-1].Year = _classList[k].Year;
                        _classList[k] = temp;
                    }
                }
            }
        }
        public void AddClass(Class newClass)
        {
            if (newClass is not Class || newClass == null) throw new ArgumentException("the new class isn't a class or is null");
            if (_classList.Length + 1 >= _classrooms) throw new Exception("teh pleexuxs is full");

            Class[] temp = new Class[_classList.Length+1];
            
            for(int i=0; i<_classList.Length;i++)
            {
                temp[i]=_classList[i];
            }
            
            temp[_classList.Length] = newClass;
            _classList = temp;
            SortClasses();
        }


    }
}
