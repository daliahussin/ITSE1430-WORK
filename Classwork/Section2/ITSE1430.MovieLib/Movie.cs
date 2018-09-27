﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSE1430.MovieLib
{
   public class Movie
    {
        public string GetName()
        {
            return _name ?? "";
        }
        public void SetName (string value)
        {
            _name = value;
        }
        private string _name;

        // public System.String Name;

        public String GetDescription()
        {
            return _description ?? "";
        }
        public void SetDescription ( string value)
        {
            _description = value;
        }
        private string _description;

        public int GetReleaseYear()
        {
            return _releaseYear; 
        }
        public void SetReleaseYear(int value)
        {
            if(value >= 1900)
            _releaseYear = value;
        }
        private int _releaseYear;

        public int GetRunLength()
        {
            return _runLength;
        }
        public void SetRunLength(int value)
        {
            if ( value >= 0)
            _runLength = value;
        }
        private int _runLength;


        //public int ReleaseYear;
        //public int RunLength;

        int someValue;
        private int someValue2;

        //void Foo()
        //   {
        //    var x = RunLength;

        //    var isLong = x > 100;

        //     var y = someValue;
        //  }


    }
}
