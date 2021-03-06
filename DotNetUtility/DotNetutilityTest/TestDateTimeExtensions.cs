﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DotNetUtility;
using System.Linq;

namespace DotNetutilityTest
{
    /// <summary>
    /// Test DateTimeExtensions
    /// </summary>
    [TestClass]
    public class TestDateTimeExtensions
    {
        /// <summary>
        /// Test GetFisicalYear
        /// </summary>
        [TestMethod]
        public void TestGetFiscalYear()
        {
            int startMonth = 4;

            var dtCase1 = new DateTime(2017, 4, 1);
            var dtCase2 = new DateTime(2017, 3, 31);
            var dtCase3 = new DateTime(2017, 12, 31);
            var dtCase4 = new DateTime(2017, 1, 1);

            Assert.AreEqual(2017, dtCase1.GetFiscalYear(startMonth));
            Assert.AreEqual(2016, dtCase2.GetFiscalYear(startMonth));
            Assert.AreEqual(2017, dtCase3.GetFiscalYear(startMonth));
            Assert.AreEqual(2016, dtCase4.GetFiscalYear(startMonth));
        }

        /// <summary>
        /// Test GetTimeZone
        /// </summary>
        [TestMethod]
        public void TestGetTimeZone()
        {
            Assert.AreEqual(DateTime.Now, DateTimeExtensions.GetTimeZone(DotNetUtility.TimeZone.Local));
            Assert.AreEqual(DateTime.UtcNow, DateTimeExtensions.GetTimeZone(DotNetUtility.TimeZone.Utc));
        }

        /// <summary>
        /// Test GetAge
        /// </summary>
        [TestMethod]
        public void TestGetAge()
        {
            var dt = new DateTime(2000, 2, 1);

            Assert.AreEqual(16, dt.GetAge(new DateTime(2016, 12, 31)));
            Assert.AreEqual(16, dt.GetAge(new DateTime(2017, 1, 1)));
            Assert.AreEqual(16, dt.GetAge(new DateTime(2017, 1, 31)));
            Assert.AreEqual(17, dt.GetAge(new DateTime(2017, 2, 1)));
            Assert.AreEqual(17, dt.GetAge(new DateTime(2017, 2, 28)));
            Assert.AreEqual(17, dt.GetAge(new DateTime(2017, 3, 1)));
        }

        /// <summary>
        /// Test ToInt
        /// </summary>
        [TestMethod]
        public void TestToInt()
        {
            var dtCase1 = new DateTime(2000, 1, 1);
            var dtCase2 = new DateTime(2000, 10, 1);
            var dtCase3 = new DateTime(2000, 1, 10);
            var dtCase4 = new DateTime(2000, 10, 10);

            Assert.AreEqual(20000101, dtCase1.ToInt());
            Assert.AreEqual(20001001, dtCase2.ToInt());
            Assert.AreEqual(20000110, dtCase3.ToInt());
            Assert.AreEqual(20001010, dtCase4.ToInt());
        }

        /// <summary>
        /// Test MothLastDay
        /// </summary>
        [TestMethod]
        public void TestMonthLastDay()
        {
            var dtCase1 = new DateTime(2010, 1, 1);
            var dtCase2 = new DateTime(2010, 2, 1);
            var dtCase3 = new DateTime(2010, 3, 1);
            var dtCase4 = new DateTime(2010, 4, 1);
            var dtCase5 = new DateTime(2010, 5, 1);
            var dtCase6 = new DateTime(2010, 6, 1);
            var dtCase7 = new DateTime(2010, 7, 1);
            var dtCase8 = new DateTime(2010, 8, 1);
            var dtCase9 = new DateTime(2010, 9, 1);
            var dtCase10 = new DateTime(2010, 10, 1);
            var dtCase11 = new DateTime(2010, 11, 1);
            var dtCase12 = new DateTime(2010, 12, 1);
            var dtCase13 = new DateTime(2010, 12, 31);

            // うるう年の2月
            var dtCase14 = new DateTime(2000, 2, 1);

            Assert.AreEqual(new DateTime(2010, 1, 31), dtCase1.LastDayOfMonth());
            Assert.AreEqual(new DateTime(2010, 2, 28), dtCase2.LastDayOfMonth());
            Assert.AreEqual(new DateTime(2010, 3, 31), dtCase3.LastDayOfMonth());
            Assert.AreEqual(new DateTime(2010, 4, 30), dtCase4.LastDayOfMonth());
            Assert.AreEqual(new DateTime(2010, 5, 31), dtCase5.LastDayOfMonth());
            Assert.AreEqual(new DateTime(2010, 6, 30), dtCase6.LastDayOfMonth());
            Assert.AreEqual(new DateTime(2010, 7, 31), dtCase7.LastDayOfMonth());
            Assert.AreEqual(new DateTime(2010, 8, 31), dtCase8.LastDayOfMonth());
            Assert.AreEqual(new DateTime(2010, 9, 30), dtCase9.LastDayOfMonth());
            Assert.AreEqual(new DateTime(2010, 10, 31), dtCase10.LastDayOfMonth());
            Assert.AreEqual(new DateTime(2010, 11, 30), dtCase11.LastDayOfMonth());
            Assert.AreEqual(new DateTime(2010, 12, 31), dtCase12.LastDayOfMonth());
            Assert.AreEqual(new DateTime(2010, 12, 31), dtCase13.LastDayOfMonth());

            // うるう年検証
            Assert.AreEqual(new DateTime(2000, 2, 29), dtCase14.LastDayOfMonth());
            
        }

        /// <summary>
        /// Test Holiday Constructor
        /// </summary>
        [TestMethod]
        public void TestHolidayConstructor()
        {
            var gantan2017 = new Holiday("元旦", HolidayKind.NationalPublicHoliday, new DateTime(2017, 1, 1));

            Assert.AreEqual("元旦", gantan2017.Name);
            Assert.AreEqual(HolidayKind.NationalPublicHoliday, gantan2017.Kind);
            Assert.AreEqual(new DateTime(2017, 1, 1), gantan2017.Date);

            //// 2016年
            var seizinNoHi2016 = new Holiday("成人の日", HolidayKind.NationalHoliday, 2016, 1, 2, DayOfWeek.Monday);
            var umiNoHi2016 = new Holiday("海の日", HolidayKind.NationalPublicHoliday, 2016, 7, 3, DayOfWeek.Monday);
            var keirouNoHi2016 = new Holiday("敬老の日", HolidayKind.NationalPublicHoliday, 2016, 9, 3, DayOfWeek.Monday);
            var taiikuNoHi2016 = new Holiday("体育の日", HolidayKind.NationalPublicHoliday, 2016, 10, 2, DayOfWeek.Monday);

            Assert.AreEqual(new DateTime(2016, 1, 11), seizinNoHi2016.Date);
            Assert.AreEqual(new DateTime(2016, 7, 18), umiNoHi2016.Date);
            Assert.AreEqual(new DateTime(2016, 9, 19), keirouNoHi2016.Date);
            Assert.AreEqual(new DateTime(2016, 10, 10), taiikuNoHi2016.Date);

            //// 2017年
            var seizinNoHi2017 = new Holiday("成人の日", HolidayKind.NationalHoliday, 2017, 1, 2, DayOfWeek.Monday);
            var umiNoHi2017 = new Holiday("海の日", HolidayKind.NationalPublicHoliday, 2017, 7, 3, DayOfWeek.Monday);
            var keirouNoHi2017 = new Holiday("敬老の日", HolidayKind.NationalPublicHoliday, 2017, 9, 3, DayOfWeek.Monday);
            var taiikuNoHi2017 = new Holiday("体育の日", HolidayKind.NationalPublicHoliday, 2017, 10, 2, DayOfWeek.Monday);

            Assert.AreEqual(new DateTime(2017, 1, 9), seizinNoHi2017.Date);
            Assert.AreEqual(new DateTime(2017, 7, 17), umiNoHi2017.Date);
            Assert.AreEqual(new DateTime(2017, 9, 18), keirouNoHi2017.Date);
            Assert.AreEqual(new DateTime(2017, 10, 9), taiikuNoHi2017.Date);

            //// 2018年
            var seizinNoHi2018 = new Holiday("成人の日", HolidayKind.NationalHoliday, 2018, 1, 2, DayOfWeek.Monday);
            var umiNoHi2018 = new Holiday("海の日", HolidayKind.NationalPublicHoliday, 2018, 7, 3, DayOfWeek.Monday);
            var keirouNoHi2018 = new Holiday("敬老の日", HolidayKind.NationalPublicHoliday, 2018, 9, 3, DayOfWeek.Monday);
            var taiikuNoHi2018 = new Holiday("体育の日", HolidayKind.NationalPublicHoliday, 2018, 10, 2, DayOfWeek.Monday);

            Assert.AreEqual(new DateTime(2018, 1, 8), seizinNoHi2018.Date);
            Assert.AreEqual(new DateTime(2018, 7, 16), umiNoHi2018.Date);
            Assert.AreEqual(new DateTime(2018, 9, 17), keirouNoHi2018.Date);
            Assert.AreEqual(new DateTime(2018, 10, 8), taiikuNoHi2018.Date);
        }

        /// <summary>
        /// Test Holiday Create
        /// </summary>
        [TestMethod]
        public void TestHolidayCreate()
        {
            int year = 2017;
            int springEquinoxDay = 21;
            int autumnalEquinoxDay = 23;

            var holidays = Holiday.Create(year, springEquinoxDay, autumnalEquinoxDay);
        }
    }
}
