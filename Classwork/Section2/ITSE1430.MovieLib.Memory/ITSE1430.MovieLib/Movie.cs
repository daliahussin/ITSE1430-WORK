using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITSE1430.MovieLib
{
   public class Movie
    {
        public string Name
        {
            get { return _name ?? ""; } // string get ()
            set { _name = value; } // void set (string value)
        }
        
        private string _name = "";
        // public System.String Name;

            public string Description
        {
            get { return _description ?? ""; }
            set { _description = value; }

        }
         private string _description;

        public int ReleaseYear { get; set; } = 1900;
      
        // Auto property syntax
        public int RunLength { get; set; }
       

        //int someValue;
        //private int someValue2;

        //void Foo()
        //   {
        //    var x = RunLength;

        //    var isLong = x > 100;

        //     var y = someValue;
        //  }

            //Showing mixed accessability
        public int Id { get; private set; }

        public bool IsColor
        {
            get { return ReleaseYear > 1940; }
        }
        public bool IsOwned { get; set; }
    }
}
