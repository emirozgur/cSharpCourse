﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    class Customer
    {
        public void Save()
        {

        }
        public void Delete()
        {

        }
    }
    class Student:Customer
    {
        public void Save2()
        {

        }
    }
    public class Course
    {
        public String Name { get; set; }
    }
}
