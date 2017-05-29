using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigLang.ConsoleTesting
{
    public class Config
    {
        private bool works;
        private double works2;
        private int thisIsAnInt;
        private string thisIsAnIdent;

        public bool Works
        {
            get
            {
                return works;
            }

            private set
            {
                works = value;
            }
        }

        public double Works2
        {
            get
            {
                return works2;
            }

            private set
            {
                works2 = value;
            }
        }

        public int ThisIsAnInt
        {
            get
            {
                return thisIsAnInt;
            }

            private set
            {
                thisIsAnInt = value;
            }
        }

        public string ThisIsAnIdent
        {
            get
            {
                return thisIsAnIdent;
            }

            private set
            {
                thisIsAnIdent = value;
            }
        }
    }
}
