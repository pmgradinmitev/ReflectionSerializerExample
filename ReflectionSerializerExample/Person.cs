﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionSerializerExample
{
    internal class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; }
    }
}
