﻿using System;

namespace Model.Models
{
    public class Messenger
    {
        private int code;
        private String mss;


        public Messenger()
        {
            code = -1;
            mss = null;
        }

        public int Code
        {
            get => code;
            set => code = value;
        }

        public string Mss
        {
            get => mss;
            set => mss = value;
        }
    }
}