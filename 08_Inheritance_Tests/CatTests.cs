﻿using System;
using _08_Inheritance_Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _08_Inheritance_Tests
{
    [TestClass]
    public class CatTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            Cat firstCat = new Cat();
            firstCat.MakeSound();
            firstCat.Move();

            Liger firstLiger = new Liger();
            firstLiger.MakeSound();
            firstLiger.Move();
        }
    }
}
