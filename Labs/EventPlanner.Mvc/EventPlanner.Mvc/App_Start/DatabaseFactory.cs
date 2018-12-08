/* ITSE 1430
 * Dalia Hussin
 * 12/8/2018
 */
using EventPlanner.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventPlanner.Mvc.App_Start
{
    public static class DatabaseFactory
    {
        private static IEventDatabase _database;

        static DatabaseFactory()
        {
            _database = new MemoryEventDatabase();
        }

        public static IEventDatabase Database
        {
            get
            {
                return _database;
            }
        }
    }
}